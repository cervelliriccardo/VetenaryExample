using System;
using System.Windows.Forms;
using VetExample.Common;
using VetExample.Entities.Base;

namespace VetExample.Base
{
    public partial class frmBaseSimpleEdit : Form
    {
        #region LocalMembers
        internal IBaseEntity CurrEl;
        internal object[] ControlsToCheck;
        public EventHandler SaveButtonClicked;
        public EventHandler CancelButtonClicked;
        #endregion
        #region action
        public frmBaseSimpleEdit()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ViewEditing.CheckMandatoryField(ref ControlsToCheck))
            {
                Display.ShowError("Check the highlighted fields");
                return;
            }
            try
            {
                Display.ShowWaitCursor(this, true);
                this.Focus();
                if (CurrEl.CurrentState != ObjectState.view)
                {
                    if (SaveButtonClicked != null)
                    {
                        SaveButtonClicked(sender, e);
                    }
                }
                else {
                    Display.ShowWarning("No changes to save");
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
            finally
            {
                Display.ShowWaitCursor(this, false);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Display.ShowWaitCursor(this, true);
                this.Focus();
                
                if (CancelButtonClicked != null)
                {
                    CancelButtonClicked(sender, e);
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
            finally
            {
                Display.ShowWaitCursor(this, false);
            }
        }
        #endregion        
    }
}
