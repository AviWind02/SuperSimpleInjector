namespace SuperSimpleInjector
{
    partial class Injector
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
            this.srcFilePathToDLLbox = new System.Windows.Forms.ListBox();
            this.InjectButton = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.textBoxForInputPath = new System.Windows.Forms.TextBox();
            this.Path = new System.Windows.Forms.GroupBox();
            this.HistoryPaths = new System.Windows.Forms.ListBox();
            this.quitButton = new System.Windows.Forms.Button();
            this.boxOfEXE = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelForEXE = new System.Windows.Forms.Label();
            this.labelForDLL = new System.Windows.Forms.Label();
            this.Path.SuspendLayout();
            this.SuspendLayout();
            // 
            // srcFilePathToDLLbox
            // 
            this.srcFilePathToDLLbox.FormattingEnabled = true;
            this.srcFilePathToDLLbox.Location = new System.Drawing.Point(12, 12);
            this.srcFilePathToDLLbox.Name = "srcFilePathToDLLbox";
            this.srcFilePathToDLLbox.Size = new System.Drawing.Size(280, 160);
            this.srcFilePathToDLLbox.TabIndex = 0;
            this.srcFilePathToDLLbox.SelectedIndexChanged += new System.EventHandler(this.srcFilePathToDLLbox_SelectedIndexChanged);
            // 
            // InjectButton
            // 
            this.InjectButton.Location = new System.Drawing.Point(262, 276);
            this.InjectButton.Name = "InjectButton";
            this.InjectButton.Size = new System.Drawing.Size(75, 23);
            this.InjectButton.TabIndex = 1;
            this.InjectButton.Text = "Inject";
            this.InjectButton.UseVisualStyleBackColor = true;
            this.InjectButton.Click += new System.EventHandler(this.InjectButton_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(298, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 79);
            this.checkedListBox1.TabIndex = 2;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // textBoxForInputPath
            // 
            this.textBoxForInputPath.Location = new System.Drawing.Point(6, 16);
            this.textBoxForInputPath.Name = "textBoxForInputPath";
            this.textBoxForInputPath.Size = new System.Drawing.Size(268, 20);
            this.textBoxForInputPath.TabIndex = 3;
            this.textBoxForInputPath.TextChanged += new System.EventHandler(this.textBoxForInputPath_TextChanged);
            this.textBoxForInputPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxForInputPath_TextChanged);
            // 
            // Path
            // 
            this.Path.Controls.Add(this.textBoxForInputPath);
            this.Path.Location = new System.Drawing.Point(12, 178);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(280, 42);
            this.Path.TabIndex = 4;
            this.Path.TabStop = false;
            this.Path.Text = "Path to DLL";
            // 
            // HistoryPaths
            // 
            this.HistoryPaths.FormattingEnabled = true;
            this.HistoryPaths.Location = new System.Drawing.Point(12, 220);
            this.HistoryPaths.Name = "HistoryPaths";
            this.HistoryPaths.Size = new System.Drawing.Size(406, 43);
            this.HistoryPaths.TabIndex = 5;
            this.HistoryPaths.SelectedIndexChanged += new System.EventHandler(this.HistoryPaths_SelectedIndexChanged);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(343, 276);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 6;
            this.quitButton.Text = "Back";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // boxOfEXE
            // 
            this.boxOfEXE.FormattingEnabled = true;
            this.boxOfEXE.Location = new System.Drawing.Point(299, 96);
            this.boxOfEXE.Name = "boxOfEXE";
            this.boxOfEXE.Size = new System.Drawing.Size(120, 121);
            this.boxOfEXE.TabIndex = 7;
            this.boxOfEXE.SelectedIndexChanged += new System.EventHandler(this.boxOfEXE_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Made by: Avi \"Super Simple Injector\"";
            // 
            // labelForEXE
            // 
            this.labelForEXE.AutoSize = true;
            this.labelForEXE.Location = new System.Drawing.Point(9, 276);
            this.labelForEXE.Name = "labelForEXE";
            this.labelForEXE.Size = new System.Drawing.Size(178, 13);
            this.labelForEXE.TabIndex = 9;
            this.labelForEXE.Text = "Selected Process:  bottom left hand.";
            // 
            // labelForDLL
            // 
            this.labelForDLL.AutoSize = true;
            this.labelForDLL.Location = new System.Drawing.Point(9, 263);
            this.labelForDLL.Name = "labelForDLL";
            this.labelForDLL.Size = new System.Drawing.Size(95, 13);
            this.labelForDLL.TabIndex = 10;
            this.labelForDLL.Text = "Selected DLL: hey";
            // 
            // Injector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 311);
            this.Controls.Add(this.labelForDLL);
            this.Controls.Add(this.labelForEXE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxOfEXE);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.HistoryPaths);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.InjectButton);
            this.Controls.Add(this.srcFilePathToDLLbox);
            this.Name = "Injector";
            this.Text = "SuperSimpleInjector";
            this.Load += new System.EventHandler(this.Injector_Load);
            this.Path.ResumeLayout(false);
            this.Path.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox srcFilePathToDLLbox;
        private System.Windows.Forms.Button InjectButton;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox textBoxForInputPath;
        private System.Windows.Forms.GroupBox Path;
        private System.Windows.Forms.ListBox HistoryPaths;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.ListBox boxOfEXE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelForEXE;
        private System.Windows.Forms.Label labelForDLL;
    }
}

