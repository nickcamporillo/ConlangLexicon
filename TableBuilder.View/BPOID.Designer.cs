namespace TableBuilder.NET
{
    partial class BPOID
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
            this.btnDisplayBuilders = new System.Windows.Forms.Button();
            this.txtBpoid = new System.Windows.Forms.TextBox();
            this.btnF10 = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgBuilders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBuilders
            // 
            this.dgBuilders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBuilders.Location = new System.Drawing.Point(1, 198);
            this.dgBuilders.MultiSelect = false;
            this.dgBuilders.Name = "dgBuilders";
            this.dgBuilders.Size = new System.Drawing.Size(1097, 400);
            this.dgBuilders.TabIndex = 0;
            // 
            // btnDisplayBuilders
            // 
            this.btnDisplayBuilders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplayBuilders.Location = new System.Drawing.Point(853, 146);
            this.btnDisplayBuilders.Name = "btnDisplayBuilders";
            this.btnDisplayBuilders.Size = new System.Drawing.Size(137, 30);
            this.btnDisplayBuilders.TabIndex = 0;
            this.btnDisplayBuilders.Text = "&Display Builders >";
            // 
            // txtBpoid
            // 
            this.txtBpoid.Location = new System.Drawing.Point(60, 16);
            this.txtBpoid.Name = "txtBpoid";
            this.txtBpoid.Size = new System.Drawing.Size(100, 20);
            this.txtBpoid.TabIndex = 1;
            // 
            // btnF10
            // 
            this.btnF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF10.Location = new System.Drawing.Point(1007, 146);
            this.btnF10.Name = "btnF10";
            this.btnF10.Size = new System.Drawing.Size(75, 30);
            this.btnF10.TabIndex = 3;
            this.btnF10.Text = "F10";
            this.btnF10.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(287, 16);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(409, 68);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "This is the Builder Table List.\r\nUse arrow keys to select BPOID.\r\nThen Press <ENT" +
    "ER> or <TAB> to view builders.\r\nYou may also double-click on a BPOID to view bui" +
    "lders.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BPOID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 630);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnF10);
            this.Controls.Add(this.txtBpoid);
            this.Controls.Add(this.btnDisplayBuilders);
            this.Controls.Add(this.dgBuilders);
            this.Name = "BPOID";
            this.Text = "BPOID";
            ((System.ComponentModel.ISupportInitialize)(this.dgBuilders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgBuilders;
        private System.Windows.Forms.Button btnDisplayBuilders;

        #endregion

        private System.Windows.Forms.TextBox txtBpoid;
        private System.Windows.Forms.Button btnF10;
        private System.Windows.Forms.Label lblInfo;
    }
}