using Utilties;

namespace Screens
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
            this.components = new System.ComponentModel.Container();
            this.dgWordList = new System.Windows.Forms.DataGridView();
            this.btnEditData = new System.Windows.Forms.Button();
            this.btnF10 = new System.Windows.Forms.Button();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.grpSearchType = new System.Windows.Forms.GroupBox();
            this.rbContains = new System.Windows.Forms.RadioButton();
            this.rbStartsWith = new System.Windows.Forms.RadioButton();
            this.lblId = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.timerDisplay = new System.Windows.Forms.Timer(this.components);
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchBox = new Screens.SearchBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgWordList)).BeginInit();
            this.grpSearchType.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // btnEditData
            // 
            this.btnEditData.Location = new System.Drawing.Point(425, 519);
            this.btnEditData.Name = "btnEditData";
            this.btnEditData.Size = new System.Drawing.Size(106, 23);
            this.btnEditData.TabIndex = 9;
            this.btnEditData.Text = "Edit Data";
            this.btnEditData.UseVisualStyleBackColor = true;
            // 
            // btnF10
            // 
            this.btnF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF10.Location = new System.Drawing.Point(1075, 45);
            this.btnF10.Name = "btnF10";
            this.btnF10.Size = new System.Drawing.Size(75, 23);
            this.btnF10.TabIndex = 10;
            this.btnF10.Text = "F10";
            this.btnF10.UseVisualStyleBackColor = true;
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(309, 519);
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
            this.grpSearchType.Location = new System.Drawing.Point(75, 93);
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
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(27, 13);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(35, 13);
            this.lblId.TabIndex = 13;
            this.lblId.Text = "label1";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(564, 519);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(106, 23);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(137, 25);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(35, 13);
            this.lblTime.TabIndex = 15;
            this.lblTime.Text = "label1";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(735, 519);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(106, 23);
            this.btnExportToExcel.TabIndex = 16;
            this.btnExportToExcel.Text = "Export to Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Current DateTime:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(706, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 59);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // searchBox
            // 
            this.searchBox.IconLocation = null;
            this.searchBox.InstructionText = "Find Word";
            this.searchBox.Location = new System.Drawing.Point(27, 46);
            this.searchBox.Name = "searchBox";
            this.searchBox.SearchText = "";
            this.searchBox.SearchType = Utilties.SearchMode.ByEntry;
            this.searchBox.Size = new System.Drawing.Size(402, 43);
            this.searchBox.TabIndex = 8;
            // 
            // WordListGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblId);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timerDisplay;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

