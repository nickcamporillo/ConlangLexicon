namespace TableBuilder.NET
{
    public partial class Contact
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
            this.dgContacts = new System.Windows.Forms.DataGridView();
            this.btnSaveEdits = new System.Windows.Forms.Button();
            this.btnBackToBuilders = new System.Windows.Forms.Button();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.btnAssignContact = new System.Windows.Forms.Button();
            this.btnF10 = new System.Windows.Forms.Button();
            this.txtBuilderCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txContactCode = new System.Windows.Forms.TextBox();
            this.btnWriteFiles = new System.Windows.Forms.Button();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.txtDebug_2 = new System.Windows.Forms.TextBox();
            this.txtDebugger3 = new System.Windows.Forms.TextBox();
            this.txtDebugger5 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.uiBuilderInfo = new TableBuilder.NET.View.UserControls.BuilderControl();
            this.placeHeader = new TableBuilder.NET.PlaceHeader();
            this.uiContactInfo = new TableBuilder.NET.ContactControl();
            this.btnEditBuilderContact = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgContacts
            // 
            this.dgContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgContacts.Location = new System.Drawing.Point(22, 204);
            this.dgContacts.Name = "dgContacts";
            this.dgContacts.Size = new System.Drawing.Size(826, 210);
            this.dgContacts.TabIndex = 33;
            // 
            // btnSaveEdits
            // 
            this.btnSaveEdits.Location = new System.Drawing.Point(465, 172);
            this.btnSaveEdits.Name = "btnSaveEdits";
            this.btnSaveEdits.Size = new System.Drawing.Size(69, 23);
            this.btnSaveEdits.TabIndex = 29;
            this.btnSaveEdits.Text = "Save";
            this.btnSaveEdits.UseVisualStyleBackColor = true;
            this.btnSaveEdits.Click += new System.EventHandler(this.btnSaveEdits_Click);
            // 
            // btnBackToBuilders
            // 
            this.btnBackToBuilders.Location = new System.Drawing.Point(24, 172);
            this.btnBackToBuilders.Name = "btnBackToBuilders";
            this.btnBackToBuilders.Size = new System.Drawing.Size(132, 23);
            this.btnBackToBuilders.TabIndex = 27;
            this.btnBackToBuilders.Text = "<< Back to Builders";
            this.btnBackToBuilders.UseVisualStyleBackColor = true;
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(162, 173);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(132, 23);
            this.btnAddContact.TabIndex = 2;
            this.btnAddContact.Text = "Add Contact";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // btnAssignContact
            // 
            this.btnAssignContact.Location = new System.Drawing.Point(629, 172);
            this.btnAssignContact.Name = "btnAssignContact";
            this.btnAssignContact.Size = new System.Drawing.Size(109, 23);
            this.btnAssignContact.TabIndex = 31;
            this.btnAssignContact.Text = "Assign Contact";
            this.btnAssignContact.UseVisualStyleBackColor = true;
            // 
            // btnF10
            // 
            this.btnF10.Location = new System.Drawing.Point(760, 172);
            this.btnF10.Name = "btnF10";
            this.btnF10.Size = new System.Drawing.Size(75, 23);
            this.btnF10.TabIndex = 32;
            this.btnF10.Text = "F10";
            this.btnF10.UseVisualStyleBackColor = true;
            // 
            // txtBuilderCode
            // 
            this.txtBuilderCode.Enabled = false;
            this.txtBuilderCode.Location = new System.Drawing.Point(1004, 24);
            this.txtBuilderCode.Name = "txtBuilderCode";
            this.txtBuilderCode.Size = new System.Drawing.Size(100, 20);
            this.txtBuilderCode.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(915, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 97;
            this.label6.Text = "Builder Code:";
            // 
            // txContactCode
            // 
            this.txContactCode.Enabled = false;
            this.txContactCode.Location = new System.Drawing.Point(924, 175);
            this.txContactCode.Name = "txContactCode";
            this.txContactCode.Size = new System.Drawing.Size(100, 20);
            this.txContactCode.TabIndex = 99;
            // 
            // btnWriteFiles
            // 
            this.btnWriteFiles.Location = new System.Drawing.Point(993, 471);
            this.btnWriteFiles.Name = "btnWriteFiles";
            this.btnWriteFiles.Size = new System.Drawing.Size(147, 23);
            this.btnWriteFiles.TabIndex = 101;
            this.btnWriteFiles.Text = "Write Output Files";
            this.btnWriteFiles.UseVisualStyleBackColor = true;
            this.btnWriteFiles.Click += new System.EventHandler(this.btnWriteFiles_Click);
            // 
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(1004, 287);
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.Size = new System.Drawing.Size(222, 20);
            this.txtDebug.TabIndex = 103;
            // 
            // txtDebug_2
            // 
            this.txtDebug_2.Location = new System.Drawing.Point(1004, 329);
            this.txtDebug_2.Name = "txtDebug_2";
            this.txtDebug_2.Size = new System.Drawing.Size(222, 20);
            this.txtDebug_2.TabIndex = 104;
            // 
            // txtDebugger3
            // 
            this.txtDebugger3.Location = new System.Drawing.Point(1004, 369);
            this.txtDebugger3.Name = "txtDebugger3";
            this.txtDebugger3.Size = new System.Drawing.Size(222, 20);
            this.txtDebugger3.TabIndex = 105;
            // 
            // txtDebugger5
            // 
            this.txtDebugger5.Location = new System.Drawing.Point(1004, 405);
            this.txtDebugger5.Name = "txtDebugger5";
            this.txtDebugger5.Size = new System.Drawing.Size(222, 20);
            this.txtDebugger5.TabIndex = 106;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(540, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 23);
            this.btnCancel.TabIndex = 107;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // uiBuilderInfo
            // 
            this.uiBuilderInfo.BuilderAddress = "";
            this.uiBuilderInfo.BuilderCode = "";
            this.uiBuilderInfo.BuilderName = "";
            this.uiBuilderInfo.BuilderPostOffice = "";
            this.uiBuilderInfo.BuilderState = "";
            this.uiBuilderInfo.IsChanged = false;
            this.uiBuilderInfo.IsLoaded = true;
            this.uiBuilderInfo.Location = new System.Drawing.Point(28, 52);
            this.uiBuilderInfo.LockProperties = false;
            this.uiBuilderInfo.Name = "uiBuilderInfo";
            this.uiBuilderInfo.Size = new System.Drawing.Size(734, 98);
            this.uiBuilderInfo.TabIndex = 102;
            this.uiBuilderInfo.Zip = "";
            // 
            // placeHeader
            // 
            this.placeHeader.Bpoid = "";
            this.placeHeader.Location = new System.Drawing.Point(28, 12);
            this.placeHeader.Name = "placeHeader";
            this.placeHeader.Place = "";
            this.placeHeader.PlaceState = "";
            this.placeHeader.Psu = "";
            this.placeHeader.Size = new System.Drawing.Size(884, 48);
            this.placeHeader.TabIndex = 98;
            // 
            // uiContactInfo
            // 
            this.uiContactInfo.BestTimeToCall = "";
            this.uiContactInfo.ContactCode = "";
            this.uiContactInfo.ContactName = "";
            this.uiContactInfo.ContactNotes = "";
            this.uiContactInfo.DateAdded = "";
            this.uiContactInfo.FirstPhone = "(   )    -";
            this.uiContactInfo.FirstPhoneExt = "";
            this.uiContactInfo.FirstPhoneType = "Home";
            this.uiContactInfo.IsChanged = false;
            this.uiContactInfo.IsEnabled = true;
            this.uiContactInfo.IsLoaded = true;
            this.uiContactInfo.LastDateAssigned = "";
            this.uiContactInfo.Location = new System.Drawing.Point(18, 444);
            this.uiContactInfo.LockProperties = false;
            this.uiContactInfo.MarkForDeletion = false;
            this.uiContactInfo.Name = "uiContactInfo";
            this.uiContactInfo.SecondPhone = "(   )    -";
            this.uiContactInfo.SecondPhoneExt = "";
            this.uiContactInfo.SecondPhoneType = "Home";
            this.uiContactInfo.Size = new System.Drawing.Size(773, 178);
            this.uiContactInfo.TabIndex = 34;
            this.uiContactInfo.ThirdPhone = "(   )    -";
            this.uiContactInfo.ThirdPhoneExt = "";
            this.uiContactInfo.ThirdPhoneType = "Home";
            // 
            // btnEditBuilderContact
            // 
            this.btnEditBuilderContact.Location = new System.Drawing.Point(310, 172);
            this.btnEditBuilderContact.Name = "btnEditBuilderContact";
            this.btnEditBuilderContact.Size = new System.Drawing.Size(132, 23);
            this.btnEditBuilderContact.TabIndex = 108;
            this.btnEditBuilderContact.Text = "Edit Builder/Contact";
            this.btnEditBuilderContact.UseVisualStyleBackColor = true;
            this.btnEditBuilderContact.Click += new System.EventHandler(this.btnEditBuilderContact_Click);
            // 
            // Contact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 646);
            this.Controls.Add(this.btnEditBuilderContact);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDebugger5);
            this.Controls.Add(this.txtDebugger3);
            this.Controls.Add(this.txtDebug_2);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.uiBuilderInfo);
            this.Controls.Add(this.btnWriteFiles);
            this.Controls.Add(this.txContactCode);
            this.Controls.Add(this.placeHeader);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.uiContactInfo);
            this.Controls.Add(this.txtBuilderCode);
            this.Controls.Add(this.btnAssignContact);
            this.Controls.Add(this.btnF10);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.btnBackToBuilders);
            this.Controls.Add(this.btnSaveEdits);
            this.Controls.Add(this.dgContacts);
            this.Name = "Contact";
            this.Text = "Contact";
            ((System.ComponentModel.ISupportInitialize)(this.dgContacts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgContacts;

        #endregion
        private System.Windows.Forms.Button btnSaveEdits;
        private System.Windows.Forms.Button btnBackToBuilders;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Button btnAssignContact;
        private System.Windows.Forms.Button btnF10;
        private System.Windows.Forms.TextBox txtBuilderCode;
        private TableBuilder.NET.ContactControl uiContactInfo;
        private System.Windows.Forms.Label label6;
        private TableBuilder.NET.PlaceHeader placeHeader;
        private System.Windows.Forms.TextBox txContactCode;
        private System.Windows.Forms.Button btnWriteFiles;
        private View.UserControls.BuilderControl uiBuilderInfo;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.TextBox txtDebug_2;
        private System.Windows.Forms.TextBox txtDebugger3;
        private System.Windows.Forms.TextBox txtDebugger5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEditBuilderContact;
    }
}