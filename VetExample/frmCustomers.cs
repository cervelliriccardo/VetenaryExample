using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using VetExample.BLL;
using VetExample.Common;
using VetExample.Entities;
using VetExample.Entities.Base;
using System.Resources;

namespace VetExample
{
    public partial class frmCustomers : VetExample.Base.frmBaseListDetail
    {
        #region LocalMembers
        CustomerBLL custBll = new CustomerBLL();

        public Customer CurrentElement
        {
            get { return (Customer)CurrEl; }
            set { CurrEl = value; }
        }
        #endregion
        #region GUI
        public frmCustomers()
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
            this.mainBindingSource = customerBindingSource;
            //Controls initialization to validate on saving
            ControlsToCheck = new object[] {
                tbName,
                tbSurname
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
            dgvCustomers.CellFormatting += grid_CellFormatting;
            dgvAnimals.CellFormatting += grid_CellFormatting;
            dgvTreatments.CellFormatting += grid_CellFormatting;
        }
        public static void ShowCustomers()
        {
            try
            {
                frmCustomers oCustomers = new frmCustomers();
                oCustomers.ShowDialog();
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void frmCustomers_Shown(object sender, EventArgs e)
        {
            Display.ShowWaitCursor(this, true);
            try
            {
                RefreshCustomers(true);
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
        private void dgvCustomers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (custBll.customers.Count > 0)
                {
                    tcListDetail.SelectedTab = tpDetails;
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }

        private void dgvCustomers_Click(object sender, EventArgs e)
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
        private void RefreshCustomers(bool reload)
        {
            try
            {
                bool result = !reload;
                if (reload)
                {
                    result = custBll.GetAllCustomersFull(ckiJustValid.Checked);
                }
                if (result)
                {
                    if (custBll.customers != null)
                    {
                        customerBindingSource.DataSource = custBll.customers;
                        if (customerBindingSource.Current != null)
                            CurrentElement = (Customer)customerBindingSource.Current;

                        dgvCustomers.ReadOnly = true;
                        tsslFound.Text = custBll.customers.Count.ToString();
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
        #region Customers
        private void onCurrElPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }
        private void onJustValidCheckedChanged(object sender, EventArgs e)
        {
            RefreshCustomers(true);
        }
        private void onButtonSaveClicked(object sender, EventArgs e)
        {
            try
            {
                Display.ShowWaitCursor(this, true);
                bool retOp = false;

                if (oViewEditing.actualStatus == state.edit)
                {
                    retOp = custBll.UpdateFull(CurrentElement);
                }
                else if (oViewEditing.actualStatus == state.insert)
                {
                    retOp = custBll.SaveFull(CurrentElement);
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
                if (CurrentElement == null || CurrentElement.CUST_SURMANE == null)
                {
                    Display.ShowWarning(string.Format(Properties.Resources.MustSelectToRestore, "a customer"));
                    return;
                }
                if (Display.ShowMessageWithConferm(string.Format(Properties.Resources.SureToRestore, "the customer", CurrentElement.ToString()), Properties.Resources.WorningDataRestoring) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (custBll.Restore(CurrentElement))
                    {
                        RefreshCustomers(true);
                        oViewEditing.actualStatus = state.view;
                        Display.ShowMessage(string.Format(Properties.Resources.SuccessfullyRestored, "Customer"));
                    }
                    else {
                        Display.ShowMessage(string.Format(Properties.Resources.WarningNotRestored, "customer"));
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
                customerBindingSource.CancelEdit();
                RefreshCustomers(true);
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
                if (customerBindingSource.Count > 0)
                {
                    if (CurrentElement == null || CurrentElement.CUST_SURMANE == null)
                    {
                        Display.ShowWarning(string.Format(Properties.Resources.MustSelectToDelete, "a customer"));
                        return;
                    }
                    if (Display.ShowMessageWithConferm(string.Format(Properties.Resources.SureToDelete, "the customer", CurrentElement.ToString()), Properties.Resources.WorningDataDeleting) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (custBll.Delete(CurrentElement))
                        {
                            RefreshCustomers(true);
                            oViewEditing.actualStatus = state.view;
                            Display.ShowMessage(string.Format(Properties.Resources.SuccessfullyDeleted, "customer"));
                            tcListDetail.SelectedTab = tpList;
                        }
                        else {
                            Display.ShowMessage(string.Format(Properties.Resources.WarningNotDeleted, "customer"));
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
            RefreshCustomers(true);
        }
        private void onViewEditingStatusChanged(object sender, PropertyChangedEventArgs e)
        {
            SetGui4UserProfile();
        }
        #endregion
        #region Animals
        private void btnAnimalType_Click(object sender, EventArgs e)
        {
            try
            {
                frmAnimalType.ShowAnimalType();
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void btnNewAnimal_Click(object sender, EventArgs e)
        {
            animalsBindingSource.AddNew();
            frmAnimal oAnimal = new frmAnimal();
            oAnimal.CurrentElement = (Animal)animalsBindingSource.Current;
            System.Windows.Forms.DialogResult res = oAnimal.ShowDialog();
            switch (res)
            {
                case System.Windows.Forms.DialogResult.OK:
                    if (oViewEditing.actualStatus != state.insert)
                    {
                        oViewEditing.actualStatus = state.edit;
                    }
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                    oAnimal.CurrentElement.CancelEdit();
                    break;
                case System.Windows.Forms.DialogResult.Abort:
                    animalsBindingSource.Remove(oAnimal.CurrentElement);
                    break;
                case System.Windows.Forms.DialogResult.Ignore:
                    break;
                case System.Windows.Forms.DialogResult.No:
                    break;
                case System.Windows.Forms.DialogResult.None:
                    break;
                case System.Windows.Forms.DialogResult.Retry:
                    break;
                case System.Windows.Forms.DialogResult.Yes:
                    break;
            }
        }
        private void btnEditAnimal_Click(object sender, EventArgs e)
        {
            EditAnimal();
        }
        private void dgvAnimals_DoubleClick(object sender, EventArgs e)
        {
            EditAnimal();
        }
        private void EditAnimal()
        {
            frmAnimal oAnimal = new frmAnimal();
            oAnimal.CurrentElement = (Animal)animalsBindingSource.Current;
            System.Windows.Forms.DialogResult res = oAnimal.ShowDialog();
            switch (res)
            {
                case System.Windows.Forms.DialogResult.OK:
                    if (oViewEditing.actualStatus != state.insert)
                    {
                        oViewEditing.actualStatus = state.edit;
                    }
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                    oAnimal.CurrentElement.CancelEdit();
                    break;
                case System.Windows.Forms.DialogResult.Abort:
                    oAnimal.CurrentElement.CancelEdit();
                    break;
                case System.Windows.Forms.DialogResult.Ignore:
                    break;
                case System.Windows.Forms.DialogResult.No:
                    break;
                case System.Windows.Forms.DialogResult.None:
                    break;
                case System.Windows.Forms.DialogResult.Retry:
                    break;
                case System.Windows.Forms.DialogResult.Yes:
                    break;
            }
        }
        private void btnDeleteAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                if (animalsBindingSource.Count > 0)
                {
                    Animal curel = (Animal)animalsBindingSource.Current;
                    if (curel == null || curel.ANIM_NAME == null)
                    {
                        Display.ShowWarning(string.Format(Properties.Resources.MustSelectToDelete, "an animal"));
                        return;
                    }
                    if (Display.ShowMessageWithConferm(string.Format(Properties.Resources.SureToDelete, "the animal", curel.ToString()), Properties.Resources.WorningDataDeleting) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (oViewEditing.actualStatus != state.insert)
                        {
                            oViewEditing.actualStatus = state.edit;
                        }
                        if (curel.CurrentState == ObjectState.insert)
                        {
                            animalsBindingSource.RemoveCurrent();
                        }
                        else {
                            curel.deletedDate = DateTime.Now;
                            curel.CurrentState = ObjectState.delete;
                        }
                    }
                    else {
                        Display.ShowWarning(string.Format(Properties.Resources.WarningNotDeleted, "Animal"));
                    }
                }
                else {
                    Display.ShowWarning(string.Format(Properties.Resources.TheresNo, "Animal"));
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void btnRestoreAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                if (animalsBindingSource.Count > 0)
                {
                    Animal curel = (Animal)animalsBindingSource.Current;
                    if (curel == null || curel.deletedDate == null)
                    {
                        Display.ShowWarning(string.Format(Properties.Resources.MustSelectToRestore, "an animal"));
                        return;
                    }
                    if (Display.ShowMessageWithConferm(string.Format(Properties.Resources.SureToRestore, "the animal", curel.ToString()), Properties.Resources.WorningDataRestoring) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (oViewEditing.actualStatus != state.insert)
                        {
                            oViewEditing.actualStatus = state.edit;
                        }
                        curel.deletedDate = null;
                        curel.CurrentState = ObjectState.edit;
                    }
                    else {
                        Display.ShowMessage(string.Format(Properties.Resources.WarningNotRestored, "Animal"));
                    }
                }
                else {
                    Display.ShowWarning(string.Format(Properties.Resources.TheresNo, "Animal"));
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        #endregion
        #region Treatments        
        private void btnTreatmentType_Click(object sender, EventArgs e)
        {
            try
            {
                frmTreatmentType.ShowTreatmentType();
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void btnNewTreatment_Click(object sender, EventArgs e)
        {
            treatmentsBindingSource.AddNew();
            frmTreatment oTreatment = new frmTreatment();
            oTreatment.CurrentElement = (Treatment)treatmentsBindingSource.Current;
            System.Windows.Forms.DialogResult res = oTreatment.ShowDialog();
            switch (res)
            {
                case System.Windows.Forms.DialogResult.OK:
                    if (oViewEditing.actualStatus != state.insert)
                    {
                        oViewEditing.actualStatus = state.edit;
                    }
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                    oTreatment.CurrentElement.CancelEdit();
                    break;
                case System.Windows.Forms.DialogResult.Abort:
                    treatmentsBindingSource.RemoveCurrent();
                    break;
                case System.Windows.Forms.DialogResult.Ignore:
                    break;
                case System.Windows.Forms.DialogResult.No:
                    break;
                case System.Windows.Forms.DialogResult.None:
                    break;
                case System.Windows.Forms.DialogResult.Retry:
                    break;
                case System.Windows.Forms.DialogResult.Yes:
                    break;
            }
        }
        private void dgvTreatments_DoubleClick(object sender, EventArgs e)
        {
            EditTreatment();
        }
        private void btnEditTreatment_Click(object sender, EventArgs e)
        {
            EditTreatment();
        }
        private void EditTreatment()
        {
            frmTreatment oTreatment = new frmTreatment();
            oTreatment.CurrentElement = (Treatment)treatmentsBindingSource.Current;
            System.Windows.Forms.DialogResult res = oTreatment.ShowDialog();
            switch (res)
            {
                case System.Windows.Forms.DialogResult.OK:
                    if (oViewEditing.actualStatus != state.insert)
                    {
                        oViewEditing.actualStatus = state.edit;
                    }
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                    oTreatment.CurrentElement.CancelEdit();
                    break;
                case System.Windows.Forms.DialogResult.Abort:
                    oTreatment.CurrentElement.CancelEdit();
                    break;
                case System.Windows.Forms.DialogResult.Ignore:
                    break;
                case System.Windows.Forms.DialogResult.No:
                    break;
                case System.Windows.Forms.DialogResult.None:
                    break;
                case System.Windows.Forms.DialogResult.Retry:
                    break;
                case System.Windows.Forms.DialogResult.Yes:
                    break;
            }
        }
        private void btnDeleteTreatment_Click(object sender, EventArgs e)
        {
            try
            {
                if (treatmentsBindingSource.Count > 0)
                {
                    Treatment curel = (Treatment)treatmentsBindingSource.Current;
                    if (curel == null)
                    {
                        Display.ShowWarning(string.Format(Properties.Resources.MustSelectToDelete, "a treatment"));
                        return;
                    }
                    if (Display.ShowMessageWithConferm(string.Format(Properties.Resources.SureToDelete, "the treatment", curel.ToString()), Properties.Resources.WorningDataDeleting) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (oViewEditing.actualStatus != state.insert)
                        {
                            oViewEditing.actualStatus = state.edit;
                        }
                        if (curel.CurrentState == ObjectState.insert)
                        {
                            treatmentsBindingSource.RemoveCurrent();
                        }
                        else {
                            curel.deletedDate = DateTime.Now;
                            curel.CurrentState = ObjectState.delete;
                        }
                        dgvTreatments.Invalidate();
                    }
                    else {
                        Display.ShowMessage(string.Format(Properties.Resources.WarningNotDeleted, "Treatment"));
                    }
                }
                else {
                    Display.ShowWarning(string.Format(Properties.Resources.TheresNo, "treatment"));
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void btnRestoreTreatment_Click(object sender, EventArgs e)
        {
            try
            {
                if (treatmentsBindingSource.Count > 0)
                {
                    Treatment curel = (Treatment)treatmentsBindingSource.Current;
                    if (curel == null || curel.deletedDate == null)
                    {
                        Display.ShowWarning(string.Format(Properties.Resources.MustSelectToRestore, "a treatment"));
                        return;
                    }
                    if (Display.ShowMessageWithConferm(string.Format(Properties.Resources.SureToRestore, "the treatment", curel.ToString()), Properties.Resources.WorningDataRestoring) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (oViewEditing.actualStatus != state.insert)
                        {
                            oViewEditing.actualStatus = state.edit;
                        }
                        curel.deletedDate = null;
                        curel.CurrentState = ObjectState.edit;
                    }
                    else {
                        Display.ShowMessage(string.Format(Properties.Resources.WarningNotRestored, "Treatment"));
                    }
                }
                else {
                    Display.ShowWarning(string.Format(Properties.Resources.TheresNo, "treatment"));
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        #endregion
        #endregion
        #region Binding
        private void SetDefaultNewValue()
        {
            try
            {
                customerBindingSource.AddNew();
                tcListDetail.SelectedTab = tpDetails;
                tbName.Focus();
                oViewEditing.actualStatus = state.insert;
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        private void customerBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                CurrentElement = (Customer)customerBindingSource.Current;
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
        private void animalsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            Animal newAnim = new Animal(true);
            newAnim.customer = new Customer(CurrentElement.CUST_ID_PK, false);
            e.NewObject = newAnim;
        }
        private void treatmentsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            Treatment newTreat = new Treatment(true);
            Animal curAnimal = (Animal)animalsBindingSource.Current;
            newTreat.animal = new Animal(curAnimal.ANIM_ID_PK, curAnimal.ANIM_CUST_ID, false);
            e.NewObject = newTreat;
        }
        #endregion        
    }
}
