namespace TableBuilder.NET
{
    partial class PlaceHeader
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlaceState = new System.Windows.Forms.TextBox();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.txtBpoid = new System.Windows.Forms.TextBox();
            this.txtPsu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(360, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Place/Segment:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "BPOID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "PSU:";
            // 
            // txtPlaceState
            // 
            this.txtPlaceState.BackColor = System.Drawing.SystemColors.Menu;
            this.txtPlaceState.Enabled = false;
            this.txtPlaceState.Location = new System.Drawing.Point(833, 11);
            this.txtPlaceState.Name = "txtPlaceState";
            this.txtPlaceState.Size = new System.Drawing.Size(39, 20);
            this.txtPlaceState.TabIndex = 24;
            // 
            // txtPlace
            // 
            this.txtPlace.BackColor = System.Drawing.SystemColors.Menu;
            this.txtPlace.Enabled = false;
            this.txtPlace.Location = new System.Drawing.Point(469, 11);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(309, 20);
            this.txtPlace.TabIndex = 23;
            // 
            // txtBpoid
            // 
            this.txtBpoid.BackColor = System.Drawing.SystemColors.Menu;
            this.txtBpoid.Enabled = false;
            this.txtBpoid.Location = new System.Drawing.Point(219, 11);
            this.txtBpoid.Name = "txtBpoid";
            this.txtBpoid.Size = new System.Drawing.Size(119, 20);
            this.txtBpoid.TabIndex = 22;
            // 
            // txtPsu
            // 
            this.txtPsu.BackColor = System.Drawing.SystemColors.Menu;
            this.txtPsu.Enabled = false;
            this.txtPsu.Location = new System.Drawing.Point(50, 11);
            this.txtPsu.Name = "txtPsu";
            this.txtPsu.Size = new System.Drawing.Size(100, 20);
            this.txtPsu.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(792, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "State:";
            // 
            // PlaceHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPlaceState);
            this.Controls.Add(this.txtPlace);
            this.Controls.Add(this.txtBpoid);
            this.Controls.Add(this.txtPsu);
            this.Name = "PlaceHeader";
            this.Size = new System.Drawing.Size(934, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPlaceState;
        private System.Windows.Forms.TextBox txtPlace;
        private System.Windows.Forms.TextBox txtBpoid;
        private System.Windows.Forms.TextBox txtPsu;
        private System.Windows.Forms.Label label4;
    }
}
