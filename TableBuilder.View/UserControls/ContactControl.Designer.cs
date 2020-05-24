namespace TableBuilder.NET
{
    partial class ContactControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.txtThirdPhone = new System.Windows.Forms.MaskedTextBox();
            this.txtSecondPhone = new System.Windows.Forms.MaskedTextBox();
            this.txtFirstPhone = new System.Windows.Forms.MaskedTextBox();
            this.txtFirstPhoneExt = new System.Windows.Forms.TextBox();
            this.txtSecondPhoneExt = new System.Windows.Forms.TextBox();
            this.txtThirdPhoneExt = new System.Windows.Forms.TextBox();
            this.lblContactName = new System.Windows.Forms.Label();
            this.lblFirstPhone = new System.Windows.Forms.Label();
            this.lblSecondPhone = new System.Windows.Forms.Label();
            this.lblThirdPhone = new System.Windows.Forms.Label();
            this.cmbPhoneTypeOne = new System.Windows.Forms.ComboBox();
            this.cmbPhoneTypeTwo = new System.Windows.Forms.ComboBox();
            this.cmbPhoneTypeThree = new System.Windows.Forms.ComboBox();
            this.txtBestTimeCall = new System.Windows.Forms.TextBox();
            this.txtContactNotes = new System.Windows.Forms.TextBox();
            this.lblBestTimeCall = new System.Windows.Forms.Label();
            this.lblContactNotes = new System.Windows.Forms.Label();
            this.txtDateAdded = new System.Windows.Forms.TextBox();
            this.txtDateAssigned = new System.Windows.Forms.TextBox();
            this.cmbMarkForDeletion = new System.Windows.Forms.ComboBox();
            this.lblDateAdded = new System.Windows.Forms.Label();
            this.lblLastDateAssigned = new System.Windows.Forms.Label();
            this.lblMarkForDeletion = new System.Windows.Forms.Label();
            this.txtContactCode = new System.Windows.Forms.TextBox();
            this.lblContactCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(124, 14);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(339, 20);
            this.txtContactName.TabIndex = 0;
            // 
            // txtThirdPhone
            // 
            this.txtThirdPhone.Location = new System.Drawing.Point(124, 95);
            this.txtThirdPhone.Mask = "(999) 000-0000";
            this.txtThirdPhone.Name = "txtThirdPhone";
            this.txtThirdPhone.Size = new System.Drawing.Size(100, 20);
            this.txtThirdPhone.TabIndex = 7;
            // 
            // txtSecondPhone
            // 
            this.txtSecondPhone.Location = new System.Drawing.Point(126, 67);
            this.txtSecondPhone.Mask = "(999) 000-0000";
            this.txtSecondPhone.Name = "txtSecondPhone";
            this.txtSecondPhone.Size = new System.Drawing.Size(100, 20);
            this.txtSecondPhone.TabIndex = 4;
            // 
            // txtFirstPhone
            // 
            this.txtFirstPhone.Location = new System.Drawing.Point(124, 40);
            this.txtFirstPhone.Mask = "(999) 000-0000";
            this.txtFirstPhone.Name = "txtFirstPhone";
            this.txtFirstPhone.Size = new System.Drawing.Size(100, 20);
            this.txtFirstPhone.TabIndex = 1;
            // 
            // txtFirstPhoneExt
            // 
            this.txtFirstPhoneExt.Location = new System.Drawing.Point(230, 40);
            this.txtFirstPhoneExt.Name = "txtFirstPhoneExt";
            this.txtFirstPhoneExt.Size = new System.Drawing.Size(100, 20);
            this.txtFirstPhoneExt.TabIndex = 2;
            // 
            // txtSecondPhoneExt
            // 
            this.txtSecondPhoneExt.Location = new System.Drawing.Point(232, 67);
            this.txtSecondPhoneExt.Name = "txtSecondPhoneExt";
            this.txtSecondPhoneExt.Size = new System.Drawing.Size(100, 20);
            this.txtSecondPhoneExt.TabIndex = 5;
            // 
            // txtThirdPhoneExt
            // 
            this.txtThirdPhoneExt.Location = new System.Drawing.Point(230, 95);
            this.txtThirdPhoneExt.Name = "txtThirdPhoneExt";
            this.txtThirdPhoneExt.Size = new System.Drawing.Size(100, 20);
            this.txtThirdPhoneExt.TabIndex = 8;
            // 
            // lblContactName
            // 
            this.lblContactName.AutoSize = true;
            this.lblContactName.Location = new System.Drawing.Point(3, 18);
            this.lblContactName.Name = "lblContactName";
            this.lblContactName.Size = new System.Drawing.Size(75, 13);
            this.lblContactName.TabIndex = 20;
            this.lblContactName.Text = "Contact Name";
            // 
            // lblFirstPhone
            // 
            this.lblFirstPhone.AutoSize = true;
            this.lblFirstPhone.Location = new System.Drawing.Point(6, 47);
            this.lblFirstPhone.Name = "lblFirstPhone";
            this.lblFirstPhone.Size = new System.Drawing.Size(60, 13);
            this.lblFirstPhone.TabIndex = 19;
            this.lblFirstPhone.Text = "First Phone";
            // 
            // lblSecondPhone
            // 
            this.lblSecondPhone.AutoSize = true;
            this.lblSecondPhone.Location = new System.Drawing.Point(5, 74);
            this.lblSecondPhone.Name = "lblSecondPhone";
            this.lblSecondPhone.Size = new System.Drawing.Size(78, 13);
            this.lblSecondPhone.TabIndex = 18;
            this.lblSecondPhone.Text = "Second Phone";
            // 
            // lblThirdPhone
            // 
            this.lblThirdPhone.AutoSize = true;
            this.lblThirdPhone.Location = new System.Drawing.Point(6, 98);
            this.lblThirdPhone.Name = "lblThirdPhone";
            this.lblThirdPhone.Size = new System.Drawing.Size(65, 13);
            this.lblThirdPhone.TabIndex = 17;
            this.lblThirdPhone.Text = "Third Phone";
            // 
            // cmbPhoneTypeOne
            // 
            this.cmbPhoneTypeOne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhoneTypeOne.FormattingEnabled = true;
            this.cmbPhoneTypeOne.Location = new System.Drawing.Point(340, 40);
            this.cmbPhoneTypeOne.Name = "cmbPhoneTypeOne";
            this.cmbPhoneTypeOne.Size = new System.Drawing.Size(121, 21);
            this.cmbPhoneTypeOne.TabIndex = 3;
            // 
            // cmbPhoneTypeTwo
            // 
            this.cmbPhoneTypeTwo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhoneTypeTwo.FormattingEnabled = true;
            this.cmbPhoneTypeTwo.Location = new System.Drawing.Point(342, 67);
            this.cmbPhoneTypeTwo.Name = "cmbPhoneTypeTwo";
            this.cmbPhoneTypeTwo.Size = new System.Drawing.Size(121, 21);
            this.cmbPhoneTypeTwo.TabIndex = 6;
            // 
            // cmbPhoneTypeThree
            // 
            this.cmbPhoneTypeThree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhoneTypeThree.FormattingEnabled = true;
            this.cmbPhoneTypeThree.Location = new System.Drawing.Point(342, 94);
            this.cmbPhoneTypeThree.Name = "cmbPhoneTypeThree";
            this.cmbPhoneTypeThree.Size = new System.Drawing.Size(121, 21);
            this.cmbPhoneTypeThree.TabIndex = 9;
            // 
            // txtBestTimeCall
            // 
            this.txtBestTimeCall.Location = new System.Drawing.Point(124, 121);
            this.txtBestTimeCall.Name = "txtBestTimeCall";
            this.txtBestTimeCall.Size = new System.Drawing.Size(339, 20);
            this.txtBestTimeCall.TabIndex = 10;
            // 
            // txtContactNotes
            // 
            this.txtContactNotes.Location = new System.Drawing.Point(124, 147);
            this.txtContactNotes.Name = "txtContactNotes";
            this.txtContactNotes.Size = new System.Drawing.Size(633, 20);
            this.txtContactNotes.TabIndex = 11;
            // 
            // lblBestTimeCall
            // 
            this.lblBestTimeCall.AutoSize = true;
            this.lblBestTimeCall.Location = new System.Drawing.Point(6, 124);
            this.lblBestTimeCall.Name = "lblBestTimeCall";
            this.lblBestTimeCall.Size = new System.Drawing.Size(93, 13);
            this.lblBestTimeCall.TabIndex = 16;
            this.lblBestTimeCall.Text = "Best Time To Call:";
            // 
            // lblContactNotes
            // 
            this.lblContactNotes.AutoSize = true;
            this.lblContactNotes.Location = new System.Drawing.Point(6, 154);
            this.lblContactNotes.Name = "lblContactNotes";
            this.lblContactNotes.Size = new System.Drawing.Size(78, 13);
            this.lblContactNotes.TabIndex = 15;
            this.lblContactNotes.Text = "Contact Notes:";
            // 
            // txtDateAdded
            // 
            this.txtDateAdded.BackColor = System.Drawing.SystemColors.Menu;
            this.txtDateAdded.Enabled = false;
            this.txtDateAdded.Location = new System.Drawing.Point(636, 14);
            this.txtDateAdded.Name = "txtDateAdded";
            this.txtDateAdded.Size = new System.Drawing.Size(121, 20);
            this.txtDateAdded.TabIndex = 12;
            // 
            // txtDateAssigned
            // 
            this.txtDateAssigned.BackColor = System.Drawing.SystemColors.Menu;
            this.txtDateAssigned.Enabled = false;
            this.txtDateAssigned.Location = new System.Drawing.Point(636, 40);
            this.txtDateAssigned.Name = "txtDateAssigned";
            this.txtDateAssigned.Size = new System.Drawing.Size(121, 20);
            this.txtDateAssigned.TabIndex = 13;
            // 
            // cmbMarkForDeletion
            // 
            this.cmbMarkForDeletion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarkForDeletion.FormattingEnabled = true;
            this.cmbMarkForDeletion.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cmbMarkForDeletion.Location = new System.Drawing.Point(636, 66);
            this.cmbMarkForDeletion.Name = "cmbMarkForDeletion";
            this.cmbMarkForDeletion.Size = new System.Drawing.Size(121, 21);
            this.cmbMarkForDeletion.TabIndex = 14;
            // 
            // lblDateAdded
            // 
            this.lblDateAdded.AutoSize = true;
            this.lblDateAdded.Location = new System.Drawing.Point(528, 21);
            this.lblDateAdded.Name = "lblDateAdded";
            this.lblDateAdded.Size = new System.Drawing.Size(64, 13);
            this.lblDateAdded.TabIndex = 2;
            this.lblDateAdded.Text = "Date Added";
            // 
            // lblLastDateAssigned
            // 
            this.lblLastDateAssigned.AutoSize = true;
            this.lblLastDateAssigned.Location = new System.Drawing.Point(528, 48);
            this.lblLastDateAssigned.Name = "lblLastDateAssigned";
            this.lblLastDateAssigned.Size = new System.Drawing.Size(99, 13);
            this.lblLastDateAssigned.TabIndex = 1;
            this.lblLastDateAssigned.Text = "Last Date Assigned";
            // 
            // lblMarkForDeletion
            // 
            this.lblMarkForDeletion.AutoSize = true;
            this.lblMarkForDeletion.Location = new System.Drawing.Point(528, 74);
            this.lblMarkForDeletion.Name = "lblMarkForDeletion";
            this.lblMarkForDeletion.Size = new System.Drawing.Size(94, 13);
            this.lblMarkForDeletion.TabIndex = 0;
            this.lblMarkForDeletion.Text = "Mark For Deletion:";
            // 
            // txtContactCode
            // 
            this.txtContactCode.Location = new System.Drawing.Point(636, 117);
            this.txtContactCode.Name = "txtContactCode";
            this.txtContactCode.Size = new System.Drawing.Size(100, 20);
            this.txtContactCode.TabIndex = 21;
            // 
            // lblContactCode
            // 
            this.lblContactCode.AutoSize = true;
            this.lblContactCode.Location = new System.Drawing.Point(529, 120);
            this.lblContactCode.Name = "lblContactCode";
            this.lblContactCode.Size = new System.Drawing.Size(72, 13);
            this.lblContactCode.TabIndex = 22;
            this.lblContactCode.Text = "Contact Code";
            // 
            // ContactControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblContactCode);
            this.Controls.Add(this.txtContactCode);
            this.Controls.Add(this.lblMarkForDeletion);
            this.Controls.Add(this.lblLastDateAssigned);
            this.Controls.Add(this.lblDateAdded);
            this.Controls.Add(this.cmbMarkForDeletion);
            this.Controls.Add(this.txtDateAssigned);
            this.Controls.Add(this.txtDateAdded);
            this.Controls.Add(this.lblContactNotes);
            this.Controls.Add(this.lblBestTimeCall);
            this.Controls.Add(this.txtContactNotes);
            this.Controls.Add(this.txtBestTimeCall);
            this.Controls.Add(this.cmbPhoneTypeThree);
            this.Controls.Add(this.cmbPhoneTypeTwo);
            this.Controls.Add(this.cmbPhoneTypeOne);
            this.Controls.Add(this.lblThirdPhone);
            this.Controls.Add(this.lblSecondPhone);
            this.Controls.Add(this.lblFirstPhone);
            this.Controls.Add(this.lblContactName);
            this.Controls.Add(this.txtFirstPhoneExt);
            this.Controls.Add(this.txtSecondPhoneExt);
            this.Controls.Add(this.txtThirdPhoneExt);
            this.Controls.Add(this.txtFirstPhone);
            this.Controls.Add(this.txtSecondPhone);
            this.Controls.Add(this.txtThirdPhone);
            this.Controls.Add(this.txtContactName);
            this.Name = "ContactControl";
            this.Size = new System.Drawing.Size(773, 178);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.MaskedTextBox txtThirdPhone;
        private System.Windows.Forms.MaskedTextBox txtSecondPhone;
        private System.Windows.Forms.MaskedTextBox txtFirstPhone;
        private System.Windows.Forms.TextBox txtFirstPhoneExt;
        private System.Windows.Forms.TextBox txtSecondPhoneExt;
        private System.Windows.Forms.TextBox txtThirdPhoneExt;
        private System.Windows.Forms.Label lblContactName;
        private System.Windows.Forms.Label lblFirstPhone;
        private System.Windows.Forms.Label lblSecondPhone;
        private System.Windows.Forms.Label lblThirdPhone;
        private System.Windows.Forms.ComboBox cmbPhoneTypeOne;
        private System.Windows.Forms.ComboBox cmbPhoneTypeTwo;
        private System.Windows.Forms.ComboBox cmbPhoneTypeThree;
        private System.Windows.Forms.TextBox txtBestTimeCall;
        private System.Windows.Forms.TextBox txtContactNotes;
        private System.Windows.Forms.Label lblBestTimeCall;
        private System.Windows.Forms.Label lblContactNotes;
        private System.Windows.Forms.TextBox txtDateAdded;
        private System.Windows.Forms.TextBox txtDateAssigned;
        private System.Windows.Forms.ComboBox cmbMarkForDeletion;
        private System.Windows.Forms.Label lblDateAdded;
        private System.Windows.Forms.Label lblLastDateAssigned;
        private System.Windows.Forms.Label lblMarkForDeletion;
        private System.Windows.Forms.TextBox txtContactCode;
        private System.Windows.Forms.Label lblContactCode;
    }
}
