namespace TableBuilder.NET
{
    partial class Builder
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
            this.dgBuilders = new System.Windows.Forms.DataGridView();
            this.btnBackToBpoid = new System.Windows.Forms.Button();
            this.btnAddBuilder = new System.Windows.Forms.Button();
            this.btnMarkForDeletion = new System.Windows.Forms.Button();
            this.btnUndelete = new System.Windows.Forms.Button();
            this.btnContacts = new System.Windows.Forms.Button();
            this.btnF10 = new System.Windows.Forms.Button();
            this.searchBox = new TableBuilder.NET.View.UserControls.SearchBox();
            this.placeHeader = new TableBuilder.NET.PlaceHeader();
            this.txtBuilderCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgBuilders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBuilders
            // 
            this.dgBuilders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBuilders.Location = new System.Drawing.Point(27, 171);
            this.dgBuilders.MultiSelect = false;
            this.dgBuilders.Name = "dgBuilders";
            this.dgBuilders.Size = new System.Drawing.Size(858, 325);
            this.dgBuilders.TabIndex = 0;
            // 
            // btnBackToBpoid
            // 
            this.btnBackToBpoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToBpoid.Location = new System.Drawing.Point(34, 68);
            this.btnBackToBpoid.Name = "btnBackToBpoid";
            this.btnBackToBpoid.Size = new System.Drawing.Size(168, 23);
            this.btnBackToBpoid.TabIndex = 1;
            this.btnBackToBpoid.Text = "Back to Builder Table List";
            this.btnBackToBpoid.UseVisualStyleBackColor = true;
            // 
            // btnAddBuilder
            // 
            this.btnAddBuilder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBuilder.Location = new System.Drawing.Point(208, 68);
            this.btnAddBuilder.Name = "btnAddBuilder";
            this.btnAddBuilder.Size = new System.Drawing.Size(119, 23);
            this.btnAddBuilder.TabIndex = 2;
            this.btnAddBuilder.Text = "Add New Builder";
            this.btnAddBuilder.UseVisualStyleBackColor = true;
            // 
            // btnMarkForDeletion
            // 
            this.btnMarkForDeletion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarkForDeletion.Location = new System.Drawing.Point(344, 68);
            this.btnMarkForDeletion.Name = "btnMarkForDeletion";
            this.btnMarkForDeletion.Size = new System.Drawing.Size(119, 23);
            this.btnMarkForDeletion.TabIndex = 3;
            this.btnMarkForDeletion.Text = "Mark For Deletion";
            this.btnMarkForDeletion.UseVisualStyleBackColor = true;
            // 
            // btnUndelete
            // 
            this.btnUndelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndelete.Location = new System.Drawing.Point(484, 68);
            this.btnUndelete.Name = "btnUndelete";
            this.btnUndelete.Size = new System.Drawing.Size(143, 23);
            this.btnUndelete.TabIndex = 4;
            this.btnUndelete.Text = "Unmark For Deletion";
            this.btnUndelete.UseVisualStyleBackColor = true;
            // 
            // btnContacts
            // 
            this.btnContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContacts.Location = new System.Drawing.Point(633, 68);
            this.btnContacts.Name = "btnContacts";
            this.btnContacts.Size = new System.Drawing.Size(119, 23);
            this.btnContacts.TabIndex = 5;
            this.btnContacts.Text = "Contacts";
            this.btnContacts.UseVisualStyleBackColor = true;
            this.btnContacts.Click += new System.EventHandler(this.btnContacts_Click);
            // 
            // btnF10
            // 
            this.btnF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF10.Location = new System.Drawing.Point(830, 68);
            this.btnF10.Name = "btnF10";
            this.btnF10.Size = new System.Drawing.Size(55, 23);
            this.btnF10.TabIndex = 7;
            this.btnF10.Text = "F10";
            this.btnF10.UseVisualStyleBackColor = true;
            // 
            // searchBox
            // 
            this.searchBox.IconLocation = null;
            this.searchBox.InstructionText = "Find Builder by Name";
            this.searchBox.Location = new System.Drawing.Point(34, 114);
            this.searchBox.Name = "searchBox";
            this.searchBox.SearchText = "";
            this.searchBox.SearchType = TableBuilder.NET.View.UserControls.SearchBox.SearchMode.DynamicSeach;
            this.searchBox.Size = new System.Drawing.Size(610, 43);
            this.searchBox.TabIndex = 8;
            // 
            // placeHeader
            // 
            this.placeHeader.Bpoid = "";
            this.placeHeader.Location = new System.Drawing.Point(34, 13);
            this.placeHeader.Name = "placeHeader";
            this.placeHeader.Place = "";
            this.placeHeader.PlaceState = "";
            this.placeHeader.Psu = "";
            this.placeHeader.Size = new System.Drawing.Size(884, 48);
            this.placeHeader.TabIndex = 6;
            // 
            // txtBuilderCode
            // 
            this.txtBuilderCode.Location = new System.Drawing.Point(633, 128);
            this.txtBuilderCode.Name = "txtBuilderCode";
            this.txtBuilderCode.Size = new System.Drawing.Size(100, 20);
            this.txtBuilderCode.TabIndex = 9;
            // 
            // Builder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 566);
            this.Controls.Add(this.txtBuilderCode);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.btnF10);
            this.Controls.Add(this.placeHeader);
            this.Controls.Add(this.btnContacts);
            this.Controls.Add(this.btnUndelete);
            this.Controls.Add(this.btnMarkForDeletion);
            this.Controls.Add(this.btnAddBuilder);
            this.Controls.Add(this.btnBackToBpoid);
            this.Controls.Add(this.dgBuilders);
            this.Name = "Builder";
            this.Text = "Builder";
            ((System.ComponentModel.ISupportInitialize)(this.dgBuilders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBuilders;
        private System.Windows.Forms.Button btnBackToBpoid;
        private System.Windows.Forms.Button btnAddBuilder;
        private System.Windows.Forms.Button btnMarkForDeletion;
        private System.Windows.Forms.Button btnUndelete;
        private System.Windows.Forms.Button btnContacts;
        private PlaceHeader placeHeader;
        private System.Windows.Forms.Button btnF10;
        private View.UserControls.SearchBox searchBox;
        private System.Windows.Forms.TextBox txtBuilderCode;
    }
}

