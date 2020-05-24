namespace Lexicon.Legacy2019.Screens
{
    partial class WordListGrid
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
            this.dgWordList = new System.Windows.Forms.DataGridView();
            this.searchBox = new Lexicon.Legacy2019.Screens.SearchBox();
            this.btnGotoEntryScreen = new System.Windows.Forms.Button();
            this.btnF10 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgWordList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgWordList
            // 
            this.dgWordList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWordList.Location = new System.Drawing.Point(27, 171);
            this.dgWordList.MultiSelect = false;
            this.dgWordList.Name = "dgWordList";
            this.dgWordList.Size = new System.Drawing.Size(858, 325);
            this.dgWordList.TabIndex = 0;
            // 
            // searchBox
            // 
            this.searchBox.IconLocation = null;
            this.searchBox.InstructionText = "Find Word";
            this.searchBox.Location = new System.Drawing.Point(27, 46);
            this.searchBox.Name = "searchBox";
            this.searchBox.SearchText = "";
            this.searchBox.SearchType = Lexicon.Legacy2019.Screens.SearchBox.SearchMode.DynamicSeach;
            this.searchBox.Size = new System.Drawing.Size(402, 43);
            this.searchBox.TabIndex = 8;
            // 
            // btnGotoEntryScreen
            // 
            this.btnGotoEntryScreen.Location = new System.Drawing.Point(429, 519);
            this.btnGotoEntryScreen.Name = "btnGotoEntryScreen";
            this.btnGotoEntryScreen.Size = new System.Drawing.Size(75, 23);
            this.btnGotoEntryScreen.TabIndex = 9;
            this.btnGotoEntryScreen.Text = "Enter Data";
            this.btnGotoEntryScreen.UseVisualStyleBackColor = true;
            // 
            // btnF10
            // 
            this.btnF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF10.Location = new System.Drawing.Point(679, 56);
            this.btnF10.Name = "btnF10";
            this.btnF10.Size = new System.Drawing.Size(75, 23);
            this.btnF10.TabIndex = 10;
            this.btnF10.Text = "F10";
            this.btnF10.UseVisualStyleBackColor = true;
            // 
            // WordListGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 566);
            this.Controls.Add(this.btnF10);
            this.Controls.Add(this.btnGotoEntryScreen);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.dgWordList);
            this.Name = "WordListGrid";
            this.Text = "Word List";
            ((System.ComponentModel.ISupportInitialize)(this.dgWordList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgWordList;
        private SearchBox searchBox;
        private System.Windows.Forms.Button btnGotoEntryScreen;
        private System.Windows.Forms.Button btnF10;
    }
}

