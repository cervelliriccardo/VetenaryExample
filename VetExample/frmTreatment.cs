using System;
using System.Windows.Forms;
using VetExample.BLL;
using VetExample.Common;
using VetExample.Entities;
using VetExample.Entities.Base;

namespace VetExample
{
    public partial class frmTreatment : VetExample.Base.frmBaseSimpleEdit
    {
        #region LocalMembers
        public Treatment CurrentElement
        {
            get { return (Treatment)CurrEl; }
            set
            {
                CurrEl = value;
                treatmentBindingSource.DataSource = value;
            }
        }
        #endregion
        #region Gui
        public frmTreatment()
        {
            Initialize();
        }
        private void Initialize()
        {
            this.InitializeComponent();

            ControlsToCheck = new object[]{
                cbTreatmentType,
                tbTreatmentDate
            };
            CancelButtonClicked += onCancelButtonClicked;
            SaveButtonClicked += onSaveButtonClicked;
            LoadTreatmentType();
        }
        #endregion
        #region DataLoader
        private void LoadTreatmentType()
        {
            try
            {
                TreatmentTypeBLL treatTypeBll = new TreatmentTypeBLL();
                bool result = treatTypeBll.GetTreatmentType();
                if (result)
                {
                    treatmentTypeBindingSource.DataSource = treatTypeBll.treatmentTypes;
                    cbTreatmentType.Refresh();
                }
            }
            catch (Exception ex)
            {
                Display.ShowError(ex.Message);
            }
        }
        #endregion
        #region Action
        private void onSaveButtonClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        private void onCancelButtonClicked(object sender, EventArgs e)
        {
            if (CurrentElement.CurrentState != ObjectState.view)
            {
                if (Display.ShowMessageWithConferm(Properties.Resources.QCancelOperation, Properties.Resources.Cancel) == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
            else {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        #endregion        
    }
}