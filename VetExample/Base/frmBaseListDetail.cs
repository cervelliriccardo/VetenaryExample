using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using VetExample.Common;
using VetExample.Entities.Base;

namespace VetExample.Base
{
    public partial class frmBaseListDetail : Form
    {
        #region LocalMembers
        //Enumerator for the current state of the operation
        internal ViewEditing oViewEditing = new ViewEditing();
        internal BindingSource mainBindingSource;
        internal event PropertyChangedEventHandler ViewEditingStatusChanged;
        internal event EventHandler ButtonReloadClicked;
        internal event EventHandler ButtonNewClicked;
        internal event EventHandler ButtonDeleteClicked;
        internal event EventHandler ButtonCancelClicked;
        internal event EventHandler ButtonRestoreClicked;
        internal event EventHandler ButtonSaveClicked;
        internal event EventHandler JustValidCheckedChanged;
        internal event PropertyChangedEventHandler CurrElPropertyChanged;
        internal object[] ControlsToCheck;
        internal IBaseEntity _CurrEl;
        public IBaseEntity CurrEl
        {
            get { return _CurrEl; }
            set
            {
                _CurrEl = value;
                if (_CurrEl != null)
                    _CurrEl.PropertyChanged += CurrentElement_PropertyChanged;
            }
        }
        #endregion
        #region Constructor
        public frmBaseListDetail()
        {
            InitializeComponent();
            oViewEditing.OnStatusChanged += oViewEditing_StatusChanged;
        }
        #endregion
        #region GUI
        private void frmBaseElencoDettaglio_Shown(object sender, EventArgs e)
        {
            Display.ShowWaitCursor(this, true);
            try
            {
                Application.DoEvents();
                SetGui4UserProfile();
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

        /// <summary>
        /// Interface set by operation's state
        /// </summary>
        /// <remarks></remarks>
        internal void SetGui4UserProfile()
        {
            btnRestore.Enabled = CurrEl == null ? false : CurrEl.isValid();
            ckiJustValid.Enabled = oViewEditing.actualStatus == state.view;
        }

        private void frmBaseElencoDettaglio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Display.CheckCloseWithoutSaving(sender, e, oViewEditing);
        }

        /// <summary>
        /// Event handler for databinding current property change
        /// </summary>
        private void CurrentElement_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (oViewEditing.actualStatus != state.insert)
            {
                oViewEditing.actualStatus = state.edit;
            }
            if (CurrElPropertyChanged != null)
            {
                CurrElPropertyChanged(sender, e);
            }
        }
        /// <summary>
        /// Raise event for operation status change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oViewEditing_StatusChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ViewEditingStatusChanged != null)
            {
                ViewEditingStatusChanged(sender, e);
            }
        }
        protected void ChangeTabControlPage(object sender, EventArgs e)
        {
            TabControl mailTabControl = (TabControl)sender;
            mailTabControl.SelectedIndexChanged -= ChangeTabControlPage;
            try
            {
                if (Display.IsTabChangingOnEdit(e, oViewEditing))
                {
                    mailTabControl.SelectedTab = mailTabControl.TabPages[1];
                    return;
                }
                else {
                    if (Display.CheckNoDataToShow(e, mainBindingSource, oViewEditing))
                    {
                        mailTabControl.SelectedTab = mailTabControl.TabPages[0];
                        SetGui4UserProfile();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
            finally
            {
                mailTabControl.SelectedIndexChanged += ChangeTabControlPage;
            }
        }
        protected void grid_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.SuspendLayout();

                if (e.RowIndex >= 0)
                {
                    IBaseEntity rowToDraw = (IBaseEntity)((DataGridView)sender).Rows[e.RowIndex].DataBoundItem;
                    if (rowToDraw != null)
                    {
                        if (rowToDraw.deletedDate != null)
                        {
                            e.CellStyle.BackColor = Color.LightCoral;
                        }
                        Font oFont;
                        switch (rowToDraw.CurrentState)
                        {
                            case ObjectState.delete:
                                oFont = new Font(e.CellStyle.Font.Name, e.CellStyle.Font.Size, FontStyle.Strikeout);
                                e.CellStyle.Font = oFont;
                                break;
                            case ObjectState.edit:
                                e.CellStyle.BackColor = Color.Yellow;
                                break;
                            case ObjectState.insert:
                                e.CellStyle.BackColor = Color.LightGreen;
                                break;
                            default:
                                oFont = new Font(e.CellStyle.Font.Name, e.CellStyle.Font.Size, FontStyle.Regular);
                                e.CellStyle.Font = oFont;
                                break;
                        }
                    }
                }
                this.ResumeLayout();
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }

        #endregion
        #region Action
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            panel1.Focus();
            ViewEditing.MoveTo(oViewEditing, mainBindingSource, (Button)sender, panel1);
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            panel1.Focus();
            ViewEditing.MoveTo(oViewEditing, mainBindingSource, (Button)sender, panel1);
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            panel1.Focus();
            ViewEditing.MoveTo(oViewEditing, mainBindingSource, (Button)sender, panel1);
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            panel1.Focus();
            ViewEditing.MoveTo(oViewEditing, mainBindingSource, (Button)sender, panel1);
        }
        private void btnReload_Click(Object sender, EventArgs e)
        {
            try
            {
                Display.ShowWaitCursor(this, true);
                panel1.Focus(); 

                if (oViewEditing.actualStatus != state.view)
                {
                    Display.ShowMessage((oViewEditing.actualStatus == state.edit ? "Editing" : "Inserting") +
                                            " in action!" +
                                            Environment.NewLine +
                                            "Save or Cancel before procede");
                }
                else {
                    if (ButtonReloadClicked != null)
                    {
                        ButtonReloadClicked(sender, e);
                    }
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
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Focus();
                Display.ShowWaitCursor(this, true);
                if (Display.CheckInEditMode(this, oViewEditing))
                    return;
                if (ButtonNewClicked != null)
                {
                    ButtonNewClicked(sender, e);
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Focus();
                Display.ShowWaitCursor(this, true);
                if (Display.CheckInEditMode(this, oViewEditing))
                    return;
                if (ButtonDeleteClicked != null)
                {
                    ButtonDeleteClicked(sender, e);
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
        private void btnRestore_Click(object sender, EventArgs e)
        {
            panel1.Focus();
            if (ButtonRestoreClicked != null)
            {
                ButtonRestoreClicked(sender, e);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Display.ShowWaitCursor(this, true);
                panel1.Focus();
                if (oViewEditing.actualStatus != state.view)
                {
                    if (Display.ShowMessageWithConferm("Cancel operation?", "CANCEL") == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (ButtonCancelClicked != null)
                        {
                            ButtonCancelClicked(sender, e);
                        }
                    }
                }
                else {
                    Display.ShowWarning("No changes to undo");
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Focus();
                if (!ViewEditing.CheckMandatoryField(ref ControlsToCheck))
                {
                    Display.ShowWarning("Check the highlighted fields");
                    return;
                }
                Display.ShowWaitCursor(this, true);

                if (oViewEditing.actualStatus != state.view)
                {
                    if (ButtonSaveClicked != null)
                    {
                        ButtonSaveClicked(sender, e);
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
        private void ckiJustValid_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Focus();
            if (Display.CheckInEditMode(this, oViewEditing))
                return;
            if (JustValidCheckedChanged != null)
            {
                JustValidCheckedChanged(sender, e);
            }
        }
        #endregion
    }
}
