namespace Lexicon.Legacy2019.Screens
{
    partial class SearchBox
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
            this.picBox = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblInstrx = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(3, 12);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(41, 24);
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            this.picBox.Click += new System.EventHandler(this.picBox_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(50, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(251, 20);
            this.txtSearch.TabIndex = 2;
            // 
            // lblInstrx
            // 
            this.lblInstrx.AutoSize = true;
            this.lblInstrx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrx.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblInstrx.Location = new System.Drawing.Point(307, 15);
            this.lblInstrx.Name = "lblInstrx";
            this.lblInstrx.Size = new System.Drawing.Size(131, 17);
            this.lblInstrx.TabIndex = 3;
            this.lblInstrx.Text = "Find  [Control -F]";
            this.lblInstrx.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SearchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInstrx);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.picBox);
            this.Name = "SearchBox";
            this.Size = new System.Drawing.Size(477, 46);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblInstrx;
    }
}
