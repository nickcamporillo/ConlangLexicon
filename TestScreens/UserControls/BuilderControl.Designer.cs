namespace TableBuilder.NET.View.UserControls
{
    partial class BuilderControl
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
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBuilderPostOffice = new System.Windows.Forms.TextBox();
            this.txtBuilderAddress = new System.Windows.Forms.TextBox();
            this.txtBuilderName = new System.Windows.Forms.TextBox();
            this.txtBuilderCode = new System.Windows.Forms.TextBox();
            this.lblBuilderCode = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.Location = new System.Drawing.Point(487, 68);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(78, 21);
            this.cmbState.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(449, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 109;
            this.label15.Text = "State";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 108;
            this.label14.Text = "Builder Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 107;
            this.label13.Text = "Post Office:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 106;
            this.label12.Text = "Address:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(575, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 104;
            this.label5.Text = "Zip Code";
            // 
            // txtBuilderPostOffice
            // 
            this.txtBuilderPostOffice.Location = new System.Drawing.Point(102, 68);
            this.txtBuilderPostOffice.Name = "txtBuilderPostOffice";
            this.txtBuilderPostOffice.Size = new System.Drawing.Size(309, 20);
            this.txtBuilderPostOffice.TabIndex = 3;
            // 
            // txtBuilderAddress
            // 
            this.txtBuilderAddress.Location = new System.Drawing.Point(102, 43);
            this.txtBuilderAddress.Name = "txtBuilderAddress";
            this.txtBuilderAddress.Size = new System.Drawing.Size(309, 20);
            this.txtBuilderAddress.TabIndex = 2;
            // 
            // txtBuilderName
            // 
            this.txtBuilderName.Location = new System.Drawing.Point(102, 18);
            this.txtBuilderName.Name = "txtBuilderName";
            this.txtBuilderName.Size = new System.Drawing.Size(309, 20);
            this.txtBuilderName.TabIndex = 1;
            // 
            // txtBuilderCode
            // 
            this.txtBuilderCode.Location = new System.Drawing.Point(631, 21);
            this.txtBuilderCode.MaxLength = 5;
            this.txtBuilderCode.Name = "txtBuilderCode";
            this.txtBuilderCode.Size = new System.Drawing.Size(92, 20);
            this.txtBuilderCode.TabIndex = 111;
            // 
            // lblBuilderCode
            // 
            this.lblBuilderCode.AutoSize = true;
            this.lblBuilderCode.Location = new System.Drawing.Point(484, 21);
            this.lblBuilderCode.Name = "lblBuilderCode";
            this.lblBuilderCode.Size = new System.Drawing.Size(70, 13);
            this.lblBuilderCode.TabIndex = 112;
            this.lblBuilderCode.Text = "Builder Code:";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(631, 69);
            this.txtZip.Mask = "00000";
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(92, 20);
            this.txtZip.TabIndex = 113;
            // 
            // BuilderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.lblBuilderCode);
            this.Controls.Add(this.txtBuilderCode);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBuilderPostOffice);
            this.Controls.Add(this.txtBuilderAddress);
            this.Controls.Add(this.txtBuilderName);
            this.Name = "BuilderControl";
            this.Size = new System.Drawing.Size(734, 98);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBuilderPostOffice;
        private System.Windows.Forms.TextBox txtBuilderAddress;
        private System.Windows.Forms.TextBox txtBuilderName;
        private System.Windows.Forms.TextBox txtBuilderCode;
        private System.Windows.Forms.Label lblBuilderCode;
        private System.Windows.Forms.MaskedTextBox txtZip;
    }
}
