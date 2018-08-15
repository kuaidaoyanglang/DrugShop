using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DrugShop.Model;
using DrugShop.Date;

namespace DrugShop.Core
{
    public class StockBillService
    {
        /// <summary>
        /// 开出库或则入库的票
        /// </summary>
        /// <param name="bill">票据</param>
        public void MakeBill(Bills bill)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IDbTransaction trans = conn.BeginTransaction();
                try
                {
                    //1、保存票据信息；
                    IBillsDAO billDao = DAOFactory.Instance.CreateBillsDAO();
                    billDao.InsertBill(bill, conn, trans);
                    //2、更改库存数据；
                    IStockDAO stockDao = DAOFactory.Instance.CreateStockDAO();
                    foreach (BillsItem item in bill.Items)
                    {
                        Stock stock = stockDao.SelectStockByDrugsAndStorehouse(item.Drugs.ID, bill.Storehouse.ID, conn, trans);
                        //如果库存中没有该商品，则创建库存信息
                        if (stock == null)
                        {
                            stock = new Stock();
                            stock.Storehouse = bill.Storehouse;
                            stock.Drug = item.Drugs;
                            stock.Count = 0;
                            stockDao.InsertStock(stock, conn, trans);
                        }

                        if (bill.BillsType.IsOut)
                        {
                            stock.Count -= item.Count;
                        }
                        else
                        {
                            stock.Count += item.Count;
                        }
                        stockDao.UpdateStock(stock, conn, trans);

                    }

                    //3、提交
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    //4、回滚
                    trans.Rollback();
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 冲销一条票据
        /// </summary>
        /// <param name="bill">票据</param>
        /// <param name="maker">冲票人</param>
        /// <param name="makeDate">冲票日期</param>
        /// <param name="remark">备注</param>
        public Bills CancelOutBill(Bills bill, string maker, DateTime makeDate, string remark)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                //1、构造负子票
                Bills redBill = new Bills();
                redBill.Actived = true;
                redBill.BillsType = bill.BillsType;
                redBill.Code = bill.Code;
                redBill.Company = bill.Company;
                redBill.CreateDate = DateTime.Now;
                redBill.IsCancelOut = false;
                redBill.IsRedBill = true;
                redBill.MakeDate = makeDate;
                redBill.Maker = maker;
                redBill.Storehouse = bill.Storehouse;
                redBill.Remark = "对冲票据" + bill.ID.ToString();
                foreach (BillsItem item in bill.Items)
                {
                    BillsItem redbillitem = new BillsItem();
                    redbillitem.Drugs = item.Drugs;
                    redbillitem.Count = item.Count * (-1);
                    redbillitem.UnitPrice = item.UnitPrice;
                    redbillitem.Money = item.Money * (-1);
                    redBill.Items.Add(redbillitem);
                }

                IDbTransaction trans = conn.BeginTransaction();
                try
                {
                    IBillsDAO billDao = DAOFactory.Instance.CreateBillsDAO();
                    // 2. 保存红票
                    billDao.InsertBill(redBill, conn, trans);

                    // 3. 保存原票据信息
                    bill.IsCancelOut = true;
                    bill.Remark += " 被冲销" + redBill.ID.ToString();
                    billDao.UpdateBill(bill, conn, trans);

                    // 4. 更改库存数据
                    IStockDAO stockDao = DAOFactory.Instance.CreateStockDAO();
                    
                    foreach (BillsItem item in redBill.Items)
                    {
                        Stock stock = stockDao.SelectStockByDrugsAndStorehouse(item.Drugs.ID, bill.Storehouse.ID, conn, trans);
                        if (redBill.BillsType.IsOut)
                        {
                            stock.Count -= item.Count;
                        }
                        else
                        {
                            stock.Count += item.Count;
                        }
                        stockDao.UpdateStock(stock, conn, trans);

                    }

                    //5、提交
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    //6、回滚
                    bill.IsCancelOut = false;
                    trans.Rollback();
                    throw ex;
                }
                return redBill;
            }
        }
        /// <summary>
        /// 作废一条票据
        /// </summary>
        /// <param name="bill">作废的票据</param>
        /// <param name="maker">做废人</param>
        /// <param name="makeDate">作废日期</param>
        /// <param name="remark">备注</param>
        public void BlankOutBill(Bills bill, string remark)
        {
            if (!bill.Actived)
            {
                throw new ApplicationException(string.Format("票据{0}已经被作废，不能重复被作废。", bill.ID));
            }
            if (bill.IsCancelOut)
            {
                throw new ApplicationException(string.Format("票据{0}已被冲销，不能作废。", bill.ID));
            }
            if (bill.IsRedBill)
            {
                throw new ApplicationException(string.Format("票据{0}是冲销票，不能作废。", bill.ID));
            }
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IDbTransaction trans = conn.BeginTransaction();
                try
                {
                    //1、更新票据状态
                    bill.Actived = false;
                    bill.Remark += remark;
                    IBillsDAO billDao = DAOFactory.Instance.CreateBillsDAO();
                    billDao.UpdateBill(bill, conn, trans);
                    //2、更改库存数据
                    IStockDAO stockDao = DAOFactory.Instance.CreateStockDAO();
                    foreach (BillsItem item in bill.Items)
                    {
                        Stock stock = stockDao.SelectStockByDrugsAndStorehouse(item.Drugs.ID, bill.Storehouse.ID, conn, trans);
                        if (bill.BillsType.IsOut)
                        {
                            stock.Count += item.Count;
                        }
                        else
                        {
                            stock.Count -= item.Count;
                        }
                        stockDao.UpdateStock(stock, conn, trans);
                    }
                    //3、记录票据作废事件日志
                    LogServices.Info("作废票据" + bill.ID);
                    //4、提交
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    //5、回滚
                    bill.Actived = true;
                    trans.Rollback();
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 根据ID来查找一个票据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Bills FindBill(int id)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IBillsDAO billDao = DAOFactory.Instance.CreateBillsDAO();
                return billDao.SelectBill(id, conn);
            }
        }
        /// <summary>
        /// 根据给定的一些条件来进行票据的模糊查询
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="companyCond"></param>
        /// <param name="drugsCond"></param>
        /// <param name="drugsFromCond"></param>
        /// <param name="drugsCategoryCond"></param>
        /// <param name="storeHouseCond"></param>
        /// <param name="billMaker"></param>
        /// <returns></returns>
        public List<Bills> SearchBill(DateTime fromDate, DateTime toDate, string companyCond, string drugsCond, string drugsFromCond, string drugsCategoryCond, string storeHouseCond, User billMaker, string billsID, BillsType billsType)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IBillsDAO dao = DAOFactory.Instance.CreateBillsDAO();
                SearchBillsTemplate sbt = new SearchBillsTemplate();
                sbt.FromDate = fromDate;
                sbt.ToDate = toDate;
                sbt.CompanyCond = companyCond;
                sbt.BillMaker = billMaker.Name;
                List<Bills> billsList = dao.SearchBills(sbt, conn);
                for (int i = billsList.Count - 1; i >= 0; i--)
                {
                    Bills bill = billsList[i];
                    if (!bill.ID.ToString().Contains(billsID))
                    {
                        billsList.Remove(bill);
                    }
                    if (!billsType.Equals(bill.BillsType))
                    {
                        billsList.Remove(bill);
                    }
                }
                return billsList;
            }
        }
        /// <summary>
        /// 根据给定的条件来进行票据的模糊查询
        /// </summary>
        /// <param name="sbt"></param>
        /// <returns></returns>
        public List<Bills> SearchBill(SearchBillsTemplate sbt)
        {
            using (IDbConnection conn = DAOFactory.Instance.OpenConnection())
            {
                IBillsDAO dao = DAOFactory.Instance.CreateBillsDAO();
                return dao.SearchBills(sbt, conn);
            }
        }
    }
}
