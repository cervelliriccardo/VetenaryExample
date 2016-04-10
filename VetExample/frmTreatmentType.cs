using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VetExample.BLL;
using VetExample.Common;
using VetExample.Entities;
using VetExample.Entities.Base;

namespace VetExample
{
    public partial class frmTreatmentType : VetExample.Base.frmBaseListDetail
    {
        #region LocalMembers
        TreatmentTypeBLL treatTypeBll = new TreatmentTypeBLL();

        public TreatmentType CurrentElement
        {
            get { return (TreatmentType)CurrEl; }
            set { CurrEl = value; }
        }
        #endregion
        #region GUI
        public frmTreatmentType()
        {
            try
            {
                Initialize();
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void Initialize()
        {
            this.InitializeComponent();
            this.mainBindingSource = treatmentTypeBindingSource;
            ControlsToCheck = new object[] {
                tbDescription
            };

            ViewEditingStatusChanged += onViewEditingStatusChanged;
            ButtonReloadClicked += onButtonReloadClicked;
            ButtonNewClicked += onButtonNewClicked;
            ButtonDeleteClicked += onButtonDeleteClicked;
            ButtonCancelClicked += onButtonCancelClicked;
            ButtonRestoreClicked += onButtonRestoreClicked;
            ButtonSaveClicked += onButtonSaveClicked;
            JustValidCheckedChanged += onJustValidCheckedChanged;
            CurrElPropertyChanged += onCurrElPropertyChanged;
            tcListDetail.SelectedIndexChanged += ChangeTabControlPage;
            dgvTreatmentTypes.CellFormatting += grid_CellFormatting;
        }
        public static void ShowTreatmentType()
        {
            try
            {
                frmTreatmentType oTreatmentType = new frmTreatmentType();
                oTreatmentType.ShowDialog();
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void frmTreatmentType_Shown(object sender, EventArgs e)
        {
            Display.ShowWaitCursor(this, true);
            try
            {
                RefreshTreatmentTypes(true);
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
        private new void SetGui4UserProfile()
        {
            base.SetGui4UserProfile();
        }
        private void dgvTreatmentTypes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (treatTypeBll.treatmentTypes.Count > 0)
                {
                    tcListDetail.SelectedTab = tpDetails;
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void dgvTreatmentTypes_Click(object sender, EventArgs e)
        {
            try
            {
                if (oViewEditing.actualStatus == state.edit)
                {
                    oViewEditing.actualStatus = state.view;
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        #endregion
        #region DataLoader
        private void RefreshTreatmentTypes(bool reload)
        {
            try
            {
                bool result = !reload;
                if (reload)
                {
                    result = treatTypeBll.GetTreatmentType(ckiJustValid.Checked);
                }

                if (result)
                {

                    if (treatTypeBll.treatmentTypes != null)
                    {
                        treatmentTypeBindingSource.DataSource = treatTypeBll.treatmentTypes;
                        
                        if (treatmentTypeBindingSource.Current != null)
                            CurrentElement = (TreatmentType)treatmentTypeBindingSource.Current;

                        dgvTreatmentTypes.ReadOnly = true;
                        tsslFound.Text = treatTypeBll.treatmentTypes.Count.ToString();
                        SetGui4UserProfile();
                    }
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
            finally
            {
                if (oViewEditing.actualStatus != state.insert)
                {
                    oViewEditing.actualStatus = state.view;
                }
            }
        }
        #endregion
        #region Action
        private void onCurrElPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }
        private void onJustValidCheckedChanged(object sender, EventArgs e)
        {
            RefreshTreatmentTypes(true);
        }
        private void onButtonSaveClicked(object sender, EventArgs e)
        {
            try
            {
                Display.ShowWaitCursor(this, true);
                bool retOp = false;

                if (oViewEditing.actualStatus == state.edit)
                {
                    retOp = treatTypeBll.Update(CurrentElement);
                }
                else if (oViewEditing.actualStatus == state.insert)
                {
                    retOp = treatTypeBll.Save(CurrentElement);
                }

                if (retOp)
                {
                    oViewEditing.actualStatus = state.view;
                    ViewEditing.ResetErrorMessages(ControlsToCheck);
                    onButtonReloadClicked(sender, e);
                    Display.ShowMessage(Properties.Resources.ProperlySaved);
                }
                else {
                    Display.ShowError(Properties.Resources.SavingErrors);
                }

            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void onButtonRestoreClicked(object sender, EventArgs e)
        {
            try
            {
                if (CurrentElement == null || CurrentElement.TRET_DESCRIPTION == null)
                {
                    Display.ShowWarning(string.Format(Properties.Resources.MustSelectToRestore, "a treatment type"));
                    return;
                }
                if (Display.ShowMessageWithConferm(string.Format(Properties.Resources.SureToRestore, "the treatment type", CurrentElement.ToString()), Properties.Resources.WorningDataRestoring) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (treatTypeBll.Restore(CurrentElement))
                    {
                        RefreshTreatmentTypes(true);
                        oViewEditing.actualStatus = state.view;
                        Display.ShowMessage(string.Format(Properties.Resources.SuccessfullyRestored, "Treatment type"));
                    }
                    else {
                        Display.ShowMessage(string.Format(Properties.Resources.WarningNotRestored, "Treatment type"));
                    }
                }

            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void onButtonCancelClicked(object sender, EventArgs e)
        {
            try
            {
                treatmentTypeBindingSource.CancelEdit();
                RefreshTreatmentTypes(true);
                ViewEditing.ResetErrorMessages(ControlsToCheck);
                oViewEditing.actualStatus = state.view;
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void onButtonDeleteClicked(object sender, EventArgs e)
        {
            try
            {
                if (treatmentTypeBindingSource.Count > 0)
                {
                    if (CurrentElement == null || CurrentElement.TRET_DESCRIPTION == null)
                    {
                        Display.ShowWarning(string.Format(Properties.Resources.MustSelectToDelete, "a treatment type"));
                        return;
                    }
                    if (Display.ShowMessageWithConferm(string.Format(Properties.Resources.SureToDelete, "the treatment type", CurrentElement.ToString()), Properties.Resources.WorningDataDeleting) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (treatTypeBll.Delete(CurrentElement))
                        {
                            RefreshTreatmentTypes(true);
                            oViewEditing.actualStatus = state.view;
                            Display.ShowMessage(string.Format(Properties.Resources.SuccessfullyDeleted, "Treatment type"));
                            tcListDetail.SelectedTab = tpList;
                        }
                        else {
                            Display.ShowMessage(string.Format(Properties.Resources.WarningNotDeleted, "Treatment type"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void onButtonNewClicked(object sender, EventArgs e)
        {
            SetDefaultNewValue();
        }
        private void onButtonReloadClicked(object sender, EventArgs e)
        {
            RefreshTreatmentTypes(true);
        }
        private void onViewEditingStatusChanged(object sender, PropertyChangedEventArgs e)
        {
            SetGui4UserProfile();
        }
        #endregion
        #region Binding
        private void SetDefaultNewValue()
        {
            try
            {
                treatmentTypeBindingSource.AddNew();
                tcListDetail.SelectedTab = tpDetails;
                tbDescription.Focus();
                oViewEditing.actualStatus = state.insert;
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void treatmentTypeBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                CurrentElement = (TreatmentType)treatmentTypeBindingSource.Current;
                ViewEditing.ResetErrorMessages(ControlsToCheck);
                SetGui4UserProfile();
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
            finally
            {
                if (oViewEditing.actualStatus != state.insert)
                {
                    oViewEditing.actualStatus = state.view;
                }
            }
        }
        #endregion        
    }
}
