using System;
using System.Windows.Forms;
using VetExample.BLL;
using VetExample.Common;
using VetExample.Entities;
using VetExample.Entities.Base;

namespace VetExample
{
    public partial class frmAnimal : VetExample.Base.frmBaseSimpleEdit
    {
        #region LocalMembers
        public Animal CurrentElement
        {
            get { return (Animal)CurrEl; }
            set
            {
                CurrEl = value;
                animalBindingSource.DataSource = value;
            }
        }
        #endregion
        #region Gui
        public frmAnimal()
        {
            Initialize();
        }
        private void Initialize()
        {
            this.InitializeComponent();

            ControlsToCheck = new object[]{
                    tbAnimalName,
                    cbAnimalType
                };
            CancelButtonClicked += onCancelButtonClicked;
            SaveButtonClicked += onSaveButtonClicked;
            LoadAnimalType();
        }      
        #endregion
        #region DataLoader
        private void LoadAnimalType()
        {
            try
            {
                AnimalTypeBLL animTypeBll = new AnimalTypeBLL();
                bool result = animTypeBll.GetAnimalType();
                if (result)
                {
                    animalTypeBindingSource.DataSource = animTypeBll.animalTypes;
                    cbAnimalType.Refresh();
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
                if (Display.ShowMessageWithConferm("Cancel operation?", "CANCEL") == DialogResult.Yes)
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
