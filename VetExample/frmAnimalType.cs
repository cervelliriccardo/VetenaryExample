using System;
using System.ComponentModel;
using System.Drawing;
using VetExample.BLL;
using VetExample.Common;
using VetExample.Entities;
using VetExample.Entities.Base;

namespace VetExample
{
    public partial class frmAnimalType : VetExample.Base.frmBaseListDetail
    {
        #region LocalMembers
        AnimalTypeBLL animTypeBll = new AnimalTypeBLL();

        public AnimalType CurrentElement
        {
            get { return (AnimalType)CurrEl; }
            set { CurrEl = value; }
        }
        #endregion
        #region GUI
        public frmAnimalType()
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
            this.mainBindingSource = animalTypeBindingSource;
            //Controls initialization to validate on saving
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
            dgvAnimalTypes.CellFormatting += grid_CellFormatting;
        }
        public static void ShowAnimalType()
        {
            try
            {
                frmAnimalType oAnimalType = new frmAnimalType();
                oAnimalType.ShowDialog();
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void frmAnimalType_Shown(object sender, EventArgs e)
        {
            Display.ShowWaitCursor(this, true);
            try
            {
                RefreshAnimalTypes(true);
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
        private void dgvAnimalTypes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (animTypeBll.animalTypes.Count > 0)
                {
                    tcListDetail.SelectedTab = tpDetails;
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }

        private void dgvAnimalTypes_Click(object sender, EventArgs e)
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
        private void RefreshAnimalTypes(bool reload)
        {
            try
            {
                bool result = !reload;
                if (reload)
                {
                    result = animTypeBll.GetAnimalType(ckiJustValid.Checked);
                }
                if (result)
                {
                    if (animTypeBll.animalTypes != null)
                    {
                        animalTypeBindingSource.DataSource = animTypeBll.animalTypes;

                        if (animalTypeBindingSource.Current != null)
                            CurrentElement = (AnimalType)animalTypeBindingSource.Current;

                        dgvAnimalTypes.ReadOnly = true;

                        tsslFound.Text = animTypeBll.animalTypes.Count.ToString();
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
            RefreshAnimalTypes(true);
        }
        private void onButtonSaveClicked(object sender, EventArgs e)
        {
            try
            {
                Display.ShowWaitCursor(this, true);
                bool retOp = false;

                if (oViewEditing.actualStatus == state.edit)
                {
                    retOp = animTypeBll.Update(CurrentElement);
                }
                else if (oViewEditing.actualStatus == state.insert)
                {
                    retOp = animTypeBll.Save(CurrentElement);
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
                if (CurrentElement == null || CurrentElement.ANMT_DESCRIPTION == null)
                {
                    Display.ShowWarning(string.Format(Properties.Resources.MustSelectToRestore, "an animal type"));
                    return;
                }
                if (Display.ShowMessageWithConferm(string.Format(Properties.Resources.SureToRestore, "the animal type", CurrentElement.ToString()), Properties.Resources.WorningDataRestoring) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (animTypeBll.Restore(CurrentElement))
                    {
                        RefreshAnimalTypes(true);
                        oViewEditing.actualStatus = state.view;
                        Display.ShowMessage(string.Format(Properties.Resources.SuccessfullyRestored, "Animal type"));
                    }
                    else {
                        Display.ShowMessage(string.Format(Properties.Resources.WarningNotRestored, "Animal type"));
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
                animalTypeBindingSource.CancelEdit();
                RefreshAnimalTypes(true);
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
                if (animalTypeBindingSource.Count > 0)
                {
                    if (CurrentElement == null || CurrentElement.ANMT_DESCRIPTION == null)
                    {
                        Display.ShowWarning(string.Format(Properties.Resources.MustSelectToDelete, "an animal type"));
                        return;
                    }
                    if (Display.ShowMessageWithConferm(string.Format(Properties.Resources.SureToDelete, "the animal type", CurrentElement.ToString()), Properties.Resources.WorningDataDeleting) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (animTypeBll.Delete(CurrentElement))
                        {
                            RefreshAnimalTypes(true);
                            oViewEditing.actualStatus = state.view;
                            Display.ShowMessage(string.Format(Properties.Resources.SuccessfullyDeleted, "Animal type"));
                            tcListDetail.SelectedTab = tpList;
                        }
                        else {
                            Display.ShowMessage(string.Format(Properties.Resources.WarningNotDeleted, "Animal type"));
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
            RefreshAnimalTypes(true);
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
                animalTypeBindingSource.AddNew();
                tcListDetail.SelectedTab = tpDetails;
                tbDescription.Focus();
                oViewEditing.actualStatus = state.insert;
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void animalTypeBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                CurrentElement = (AnimalType)animalTypeBindingSource.Current;
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
