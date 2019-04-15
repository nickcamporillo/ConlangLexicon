using Utilties;

namespace TestScreens
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
            this.btnEditData = new System.Windows.Forms.Button();
            this.btnF10 = new System.Windows.Forms.Button();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.grpSearchType = new System.Windows.Forms.GroupBox();
            this.rbContains = new System.Windows.Forms.RadioButton();
            this.rbStartsWith = new System.Windows.Forms.RadioButton();
            this.lblEntryId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLangId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWordCount = new System.Windows.Forms.Label();
            this.searchBox = new TestScreens.SearchBox();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgWordList)).BeginInit();
            this.grpSearchType.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgWordList
            // 
            this.dgWordList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWordList.Location = new System.Drawing.Point(28, 211);
            this.dgWordList.MultiSelect = false;
            this.dgWordList.Name = "dgWordList";
            this.dgWordList.Size = new System.Drawing.Size(858, 325);
            this.dgWordList.TabIndex = 0;
            // 
            // btnEditData
            // 
            this.btnEditData.Location = new System.Drawing.Point(426, 559);
            this.btnEditData.Name = "btnEditData";
            this.btnEditData.Size = new System.Drawing.Size(106, 23);
            this.btnEditData.TabIndex = 9;
            this.btnEditData.Text = "Edit Data";
            this.btnEditData.UseVisualStyleBackColor = true;
            // 
            // btnF10
            // 
            this.btnF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF10.Location = new System.Drawing.Point(680, 96);
            this.btnF10.Name = "btnF10";
            this.btnF10.Size = new System.Drawing.Size(75, 23);
            this.btnF10.TabIndex = 10;
            this.btnF10.Text = "F10";
            this.btnF10.UseVisualStyleBackColor = true;
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(310, 559);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(106, 23);
            this.btnAddWord.TabIndex = 11;
            this.btnAddWord.Text = "Add New Word";
            this.btnAddWord.UseVisualStyleBackColor = true;
            // 
            // grpSearchType
            // 
            this.grpSearchType.Controls.Add(this.rbContains);
            this.grpSearchType.Controls.Add(this.rbStartsWith);
            this.grpSearchType.Location = new System.Drawing.Point(76, 114);
            this.grpSearchType.Name = "grpSearchType";
            this.grpSearchType.Size = new System.Drawing.Size(200, 72);
            this.grpSearchType.TabIndex = 12;
            this.grpSearchType.TabStop = false;
            this.grpSearchType.Text = "Search Type";
            // 
            // rbContains
            // 
            this.rbContains.AutoSize = true;
            this.rbContains.Location = new System.Drawing.Point(22, 43);
            this.rbContains.Name = "rbContains";
            this.rbContains.Size = new System.Drawing.Size(66, 17);
            this.rbContains.TabIndex = 1;
            this.rbContains.TabStop = true;
            this.rbContains.Text = "Contains";
            this.rbContains.UseVisualStyleBackColor = true;
            // 
            // rbStartsWith
            // 
            this.rbStartsWith.AutoSize = true;
            this.rbStartsWith.Checked = true;
            this.rbStartsWith.Location = new System.Drawing.Point(22, 20);
            this.rbStartsWith.Name = "rbStartsWith";
            this.rbStartsWith.Size = new System.Drawing.Size(77, 17);
            this.rbStartsWith.TabIndex = 0;
            this.rbStartsWith.TabStop = true;
            this.rbStartsWith.Text = "Starts With";
            this.rbStartsWith.UseVisualStyleBackColor = true;
            // 
            // lblEntryId
            // 
            this.lblEntryId.AutoSize = true;
            this.lblEntryId.Location = new System.Drawing.Point(73, 30);
            this.lblEntryId.Name = "lblEntryId";
            this.lblEntryId.Size = new System.Drawing.Size(35, 13);
            this.lblEntryId.TabIndex = 13;
            this.lblEntryId.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Entry Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Language Id:";
            // 
            // lblLangId
            // 
            this.lblLangId.AutoSize = true;
            this.lblLangId.Location = new System.Drawing.Point(73, 9);
            this.lblLangId.Name = "lblLangId";
            this.lblLangId.Size = new System.Drawing.Size(35, 13);
            this.lblLangId.TabIndex = 16;
            this.lblLangId.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Word Count:";
            // 
            // lblWordCount
            // 
            this.lblWordCount.AutoSize = true;
            this.lblWordCount.Location = new System.Drawing.Point(496, 9);
            this.lblWordCount.Name = "lblWordCount";
            this.lblWordCount.Size = new System.Drawing.Size(67, 13);
            this.lblWordCount.TabIndex = 18;
            this.lblWordCount.Text = "Word Count:";
            // 
            // searchBox
            // 
            this.searchBox.IconLocation = null;
            this.searchBox.InstructionText = "Find Word";
            this.searchBox.Location = new System.Drawing.Point(28, 67);
            this.searchBox.Name = "searchBox";
            this.searchBox.SearchText = "";
            this.searchBox.SearchType = Utilties.SearchMode.ByEntry;
            this.searchBox.Size = new System.Drawing.Size(402, 43);
            this.searchBox.TabIndex = 8;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(549, 559);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 23);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // WordListGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 611);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblWordCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLangId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEntryId);
            this.Controls.Add(this.grpSearchType);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.btnF10);
            this.Controls.Add(this.btnEditData);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.dgWordList);
            this.Name = "WordListGrid";
            this.Text = "Word List";
            ((System.ComponentModel.ISupportInitialize)(this.dgWordList)).EndInit();
            this.grpSearchType.ResumeLayout(false);
            this.grpSearchType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgWordList;
        private SearchBox searchBox;
        private System.Windows.Forms.Button btnEditData;
        private System.Windows.Forms.Button btnF10;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.GroupBox grpSearchType;
        private System.Windows.Forms.RadioButton rbContains;
        private System.Windows.Forms.RadioButton rbStartsWith;
        private System.Windows.Forms.Label lblEntryId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLangId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWordCount;
        private System.Windows.Forms.Button btnClear;
    }
}

