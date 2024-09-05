namespace MergePDFGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbFileList = new ListBox();
            btnAddFiles = new Button();
            btnRemoveFiles = new Button();
            btnClearFiles = new Button();
            btnMergeFiles = new Button();
            SuspendLayout();
            // 
            // lbFileList
            // 
            lbFileList.FormattingEnabled = true;
            lbFileList.HorizontalScrollbar = true;
            lbFileList.ItemHeight = 15;
            lbFileList.Location = new Point(28, 25);
            lbFileList.Name = "lbFileList";
            lbFileList.SelectionMode = SelectionMode.MultiSimple;
            lbFileList.Size = new Size(612, 214);
            lbFileList.TabIndex = 0;
            lbFileList.DragDrop += lbFileList_DragDrop;
            lbFileList.DragOver += lbFileList_DragOver;
            lbFileList.MouseDown += lbFileList_MouseDown;
            // 
            // btnAddFiles
            // 
            btnAddFiles.Location = new Point(673, 43);
            btnAddFiles.Name = "btnAddFiles";
            btnAddFiles.Size = new Size(90, 23);
            btnAddFiles.TabIndex = 1;
            btnAddFiles.Text = "Add Files";
            btnAddFiles.UseVisualStyleBackColor = true;
            btnAddFiles.Click += btnAddFiles_Click;
            // 
            // btnRemoveFiles
            // 
            btnRemoveFiles.Location = new Point(673, 72);
            btnRemoveFiles.Name = "btnRemoveFiles";
            btnRemoveFiles.Size = new Size(90, 23);
            btnRemoveFiles.TabIndex = 2;
            btnRemoveFiles.Text = "Remove Files";
            btnRemoveFiles.UseVisualStyleBackColor = true;
            btnRemoveFiles.Click += btnRemoveFiles_Click;
            // 
            // btnClearFiles
            // 
            btnClearFiles.Location = new Point(673, 101);
            btnClearFiles.Name = "btnClearFiles";
            btnClearFiles.Size = new Size(90, 23);
            btnClearFiles.TabIndex = 3;
            btnClearFiles.Text = "Clear Files";
            btnClearFiles.UseVisualStyleBackColor = true;
            btnClearFiles.Click += btnClearFiles_Click;
            // 
            // btnMergeFiles
            // 
            btnMergeFiles.Location = new Point(673, 130);
            btnMergeFiles.Name = "btnMergeFiles";
            btnMergeFiles.Size = new Size(90, 23);
            btnMergeFiles.TabIndex = 4;
            btnMergeFiles.Text = "Merge Files";
            btnMergeFiles.UseVisualStyleBackColor = true;
            btnMergeFiles.Click += btnMergeFiles_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 269);
            Controls.Add(btnMergeFiles);
            Controls.Add(btnClearFiles);
            Controls.Add(btnRemoveFiles);
            Controls.Add(btnAddFiles);
            Controls.Add(lbFileList);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lbFileList;
        private Button btnAddFiles;
        private Button btnRemoveFiles;
        private Button btnClearFiles;
        private Button btnMergeFiles;
    }
}
