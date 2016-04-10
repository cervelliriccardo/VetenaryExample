using System;
using System.Windows.Forms;

namespace VetExample.Common.Ui
{
    static class Message
    {
        public static void Info(string message)
        {
            int num = (int)MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        public static void Warning(string message)
        {
            int num = (int)MessageBox.Show(message, "alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void ErrorMessage(Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        public static DialogResult YesNo(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
        }
        public static DialogResult YesNoWarning(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
        }
    }
}
