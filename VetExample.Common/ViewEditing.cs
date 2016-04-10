using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace VetExample.Common
{
    /// <summary>
    /// enumeration that represents the editing state
    /// </summary>
    public enum state
    {
        view,
        insert,
        edit
    }

    /// <summary>
    /// utility class used for editing states and for required controls check 
    ///for travel in GridView and other
    public class ViewEditing
    {
        public bool ChkErrori;
        //editing state
        private state _actualStatus = state.view;
        public event OnStatusChangingEventHandler OnStatusChanging;
        public delegate void OnStatusChangingEventHandler(object sender, PropertyChangingEventArgs propertyChangingEventArgs);
        public event OnStatusChangedEventHandler OnStatusChanged;
        public delegate void OnStatusChangedEventHandler(object sender, PropertyChangedEventArgs propertyChangedEventArgs);

        public state actualStatus
        {
            get { return _actualStatus; }
            set
            {
                if (OnStatusChanging != null)
                {
                    OnStatusChanging(this, new PropertyChangingEventArgs("actualStatus"));
                }
                _actualStatus = value;
                if (OnStatusChanged != null)
                {
                    OnStatusChanged(this, new PropertyChangedEventArgs("actualStatus"));
                }
            }
        }
        public static bool CheckMandatoryField(Control.ControlCollection EditControls, string StringaErrore = "Required")
        {
            dynamic bRet = true;
            try
            {
                foreach (Control control in EditControls)
                {
                    if (control.Text == string.Empty)
                    {
                        control.BackColor = System.Drawing.Color.Red;
                        bRet = false;
                    }
                    else {
                        control.BackColor = System.Drawing.Color.White;
                    }
                }
                return bRet;
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
                return false;
            }
        }
        public static bool CheckMandatoryField(ref object[] EditControls, string StringaErrore = "Required")
        {

            if (!ResetErrorMessages(EditControls))
                return false;

            dynamic bRet = true;
            try
            {
                foreach (Control control in EditControls)
                {
                    if (control.Text == string.Empty)
                    {
                        control.BackColor = System.Drawing.Color.OrangeRed;
                        bRet = false;
                    }
                    else {
                        control.BackColor = System.Drawing.Color.White;
                    }
                }
                return bRet;
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Reset the error messages for the controls
        /// </summary>
        /// <param name="Controls2Check">set of controls</param>
        /// <returns>It returns true if it succeeds, false vice versa</returns>
        public static bool ResetErrorMessages(object[] Controls2Check)
        {
            try
            {
                foreach (Control control in Controls2Check)
                {
                    try
                    {
                        control.BackColor = System.Drawing.Color.White;
                    }
                    catch (Exception ex)
                    {

                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        ///  Reset the error messages for the controls
        /// </summary>
        /// <param name="EditControls"></param>
        /// <param name="StringaErrore"></param>
        /// <remarks></remarks>
        public static void ResetErrorMessages(System.Windows.Forms.Control.ControlCollection EditControls, string StringaErrore = "")
        {
            try
            {
                foreach (Control control in EditControls)
                {
                    if (control.GetType() == typeof(TextBox))
                    {
                        control.BackColor = System.Drawing.Color.White;
                    }
                }

            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// It manages the repositioning of the record on a GridView
        /// </summary>
        /// <param name="oViewEditing">editing state of the Form</param>
        /// <param name="BindingSource">BindingSource on the data list</param>
        /// <param name="buttonCaller">Button that calls the move</param>
        /// <remarks></remarks>
        public static void MoveTo(ViewEditing oViewEditing, BindingSource bs, Button buttonCaller, Control ControlToFocus = null)
        {
            try
            {
                if (bs == null || bs.Count == 0)
                    return;

                if (ControlToFocus != null)
                {
                    ControlToFocus.Focus();
                }

                if (oViewEditing.actualStatus != state.view)
                {
                    Display.ShowMessage("You are in " + (oViewEditing.actualStatus == state.edit ? "edit!" : "insert!" + Environment.NewLine + "Save or Cancel " + "before proceeding with the update"));
                    return;
                }

                if (buttonCaller.Name.ToLower().Contains("first"))
                    bs.MoveFirst();
                if (buttonCaller.Name.ToLower().Contains("prev"))
                    bs.MovePrevious();
                if (buttonCaller.Name.ToLower().Contains("next"))
                    bs.MoveNext();
                if (buttonCaller.Name.ToLower().Contains("last"))
                    bs.MoveLast();               
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
    }
}
