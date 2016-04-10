using System;
using System.Windows.Forms;

namespace VetExample.Common
{
    /// <summary>
    /// Class that centralizes some of alerting activities in order to better maintenance
    /// </summary>
    public class Display
    {
        private static string MessageNoData = "There are no data to show";
        private static string MessageRecordEditing = "The record is currently being edited.";
        private static string MessageRecordInserting = "The record is currently being inserted.";
        private static string MessageSaveBeforeProcede = "Save, or Cancel before proceeding";
        private static string MessageDataLostOnClose = "Closing without any confirmation you will lose the changes.";
        private static string AlertOnEditing = MessageRecordEditing + Environment.NewLine + MessageSaveBeforeProcede;
        private static string AlertOnInserting = MessageRecordInserting + Environment.NewLine + MessageSaveBeforeProcede;

        private static string AlertOnClosing = string.Format("{0}{2}{1}{2}Close anyway?", AlertOnEditing, MessageDataLostOnClose, Environment.NewLine);

        public static void ShowMessage(string message, Exception ex = null)
        {
            if (ex != null)
            {
                Ui.Message.ErrorMessage(ex);
            }
            else {
                Ui.Message.Info(message);
            }
        }
        public static void ShowError(string message)
        {
            Ui.Message.ErrorMessage(new Exception(message));
        }
        public static void ShowWarning(string message)
        {
            Ui.Message.Warning(message);
        }
        public static DialogResult ShowMessageWithConferm(string message, string title)
        {
            return Ui.Message.YesNoWarning(message, title);
        }
        public static void CheckCloseWithoutSaving(object sender, FormClosingEventArgs e, ViewEditing oViewEditing)
        {
            try
            {
                if (oViewEditing.actualStatus != state.view)
                {
                    e.Cancel = (Display.ShowMessageWithConferm(AlertOnClosing, "Warning") == System.Windows.Forms.DialogResult.No);
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// checks whether the change of a current tab control is performed during an edit
        /// </summary>
        /// <param name="oViewEditing">editing state of the Form</param>
        /// <returns>Returns true if try change tab during en editing, false vice versa</returns>
        public static bool IsTabChangingOnEdit(EventArgs e, ViewEditing oViewEditing)
        {
            bool bRet = false;
            try
            {
                if (oViewEditing.actualStatus != state.view)
                {
                    Display.ShowWarning(AlertOnEditing);
                    bRet = true;
                }
                else {
                    bRet = false;
                }

            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
            return bRet;
        }

        /// <summary>
        /// checks whether the current record is being edited or inserted
        /// </summary>
        /// <param name="oViewEditing">editing state of the Form</param>
        /// <returns>returns true if the record is being edited, false vice versa</returns>
        public static bool CheckInEditMode(object caller, ViewEditing oViewEditing)
        {
            bool bRet = false;
            dynamic sTrace = caller.ToString();
            try
            {
                if (oViewEditing.actualStatus != state.view)
                {
                    string sMessage = oViewEditing.actualStatus == state.insert ? AlertOnInserting : AlertOnEditing;
                    Display.ShowWarning(sMessage);
                    sTrace += sMessage;
                    bRet = true;
                }
                else {
                    bRet = false;
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
            return bRet;
        }

        /// <summary>
        /// check the data presence, and in this case prevents a tab change
        /// </summary>
        /// <param name="BindingSourceObject">BindingSource to check</param>
        /// <param name="oViewEditing">editing state of the Form</param>
        /// <returns>returns true if there are no data to be changed</returns>
        public static bool CheckNoDataToShow(EventArgs e, BindingSource BindingSourceObject, ViewEditing oViewEditing)
        {
            bool bRet = false;
            try
            {
                if ((BindingSourceObject.DataSource == null || BindingSourceObject.Count == 0) && oViewEditing.actualStatus != state.insert)
                {
                    Display.ShowMessage(MessageNoData);
                    bRet = true;
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
            return bRet;
        }
        public static void ShowWaitCursor(Form sender, bool show)
        {
            try
            {
                Ui.Utility.Clessidra(show);

                if (show)
                {
                    sender.Cursor = Cursors.WaitCursor;
                }
                else {
                    sender.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }

        }
    }
}
