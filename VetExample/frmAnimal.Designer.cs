namespace VetExample
{
    partial class frmAnimal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnimal));
            this.animalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tbAnimalName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAnimalBirthDate = new System.Windows.Forms.MaskedTextBox();
            this.tbValidityStartDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbValidityEndDate = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAnimalType = new System.Windows.Forms.ComboBox();
            this.animalTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.animalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // animalBindingSource
            // 
            this.animalBindingSource.DataSource = typeof(VetExample.Entities.Animal);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name:";
            // 
            // tbAnimalName
            // 
            this.tbAnimalName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAnimalName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.animalBindingSource, "ANIM_NAME", true));
            this.tbAnimalName.Location = new System.Drawing.Point(12, 38);
            this.tbAnimalName.Name = "tbAnimalName";
            this.tbAnimalName.Size = new System.Drawing.Size(438, 20);
            this.tbAnimalName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Birth date:";
            // 
            // tbAnimalBirthDate
            // 
            this.tbAnimalBirthDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAnimalBirthDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.animalBindingSource, "ANIM_BIRTHDATE", true));
            this.tbAnimalBirthDate.Location = new System.Drawing.Point(12, 86);
            this.tbAnimalBirthDate.Mask = "00/00/0000";
            this.tbAnimalBirthDate.Name = "tbAnimalBirthDate";
            this.tbAnimalBirthDate.Size = new System.Drawing.Size(207, 20);
            this.tbAnimalBirthDate.TabIndex = 7;
            this.tbAnimalBirthDate.ValidatingType = typeof(System.DateTime);
            // 
            // tbValidityStartDate
            // 
            this.tbValidityStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbValidityStartDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.animalBindingSource, "validityStartDate", true));
            this.tbValidityStartDate.Location = new System.Drawing.Point(12, 135);
            this.tbValidityStartDate.Mask = "00/00/0000";
            this.tbValidityStartDate.Name = "tbValidityStartDate";
            this.tbValidityStartDate.Size = new System.Drawing.Size(207, 20);
            this.tbValidityStartDate.TabIndex = 9;
            this.tbValidityStartDate.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Validity start date:";
            // 
            // tbValidityEndDate
            // 
            this.tbValidityEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbValidityEndDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.animalBindingSource, "validityEndDate", true));
            this.tbValidityEndDate.Location = new System.Drawing.Point(243, 135);
            this.tbValidityEndDate.Mask = "00/00/0000";
            this.tbValidityEndDate.Name = "tbValidityEndDate";
            this.tbValidityEndDate.Size = new System.Drawing.Size(207, 20);
            this.tbValidityEndDate.TabIndex = 11;
            this.tbValidityEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Validity end date:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Animal type:";
            // 
            // cbAnimalType
            // 
            this.cbAnimalType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAnimalType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.animalBindingSource, "animalType", true));
            this.cbAnimalType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.animalBindingSource, "animalType", true));
            this.cbAnimalType.DataSource = this.animalTypeBindingSource;
            this.cbAnimalType.DisplayMember = "ANMT_DESCRIPTION";
            this.cbAnimalType.FormattingEnabled = true;
            this.cbAnimalType.Location = new System.Drawing.Point(243, 85);
            this.cbAnimalType.Name = "cbAnimalType";
            this.cbAnimalType.Size = new System.Drawing.Size(207, 21);
            this.cbAnimalType.TabIndex = 13;
            // 
            // animalTypeBindingSource
            // 
            this.animalTypeBindingSource.DataSource = typeof(VetExample.Entities.AnimalType);
            // 
            // frmAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(462, 249);
            this.Controls.Add(this.cbAnimalType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbValidityEndDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbValidityStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbAnimalBirthDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAnimalName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAnimal";
            this.Text = "Animal";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbAnimalName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbAnimalBirthDate, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbValidityStartDate, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tbValidityEndDate, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cbAnimalType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.animalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalTypeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAnimalName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbAnimalBirthDate;
        private System.Windows.Forms.MaskedTextBox tbValidityStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbValidityEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbAnimalType;
        private System.Windows.Forms.BindingSource animalTypeBindingSource;
        protected System.Windows.Forms.BindingSource animalBindingSource;
    }
}
