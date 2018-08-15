using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DrugShop.UI
{
    class ErrorHandler
    {
        internal static void OnError(Exception ex)
        {
            
            if (ex.GetType()==typeof(ApplicationException)||ex.GetType().IsSubclassOf(typeof(ApplicationException)))
            {
                MessageBox.Show(ex.Message,"提示信息",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(ex.Message+"\r\n\r\n"+ex.StackTrace,"系统错误",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
