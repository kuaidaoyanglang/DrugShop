using System;
using System.Collections.Generic;
using System.Text;
using DrugShop.Model;

namespace DrugShop.Core
{
     public class ReportServices
    {
         /// <summary>
         /// 根据报表的名称获取该报表的数据
         /// </summary>
         /// <param name="rptName"></param>
         /// <returns></returns>
         public Report GenerateReport(string  rptName)
         {
             throw new NotFiniteNumberException();
         }
         /// <summary>
         /// 根据传入的报表类型来获取报表数据
         /// </summary>
         /// <param name="rpt"></param>
         public void FillReportData(Report rpt)
         {
             throw new NotFiniteNumberException();
         }
         /// <summary>
         /// 将报表数据导出到Excel
         /// </summary>
         /// <param name="rpt"></param>
         /// <param name="fileName"></param>
         public void ExportExcel(Report rpt, string fileName)
         {
             throw new NotFiniteNumberException();
         }
    }
}
