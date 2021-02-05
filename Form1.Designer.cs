
namespace CreditsWindowsForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bankCB = new System.Windows.Forms.ComboBox();
            this.devisionCB = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TestConncetionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAppMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbTableToEdit = new System.Windows.Forms.ComboBox();
            this.saveTableButton = new System.Windows.Forms.Button();
            this.openTableButton = new System.Windows.Forms.Button();
            this.dgEditDB = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEditDB)).BeginInit();
            this.SuspendLayout();
            // 
            // bankCB
            // 
            this.bankCB.FormattingEnabled = true;
            this.bankCB.Location = new System.Drawing.Point(59, 3);
            this.bankCB.Name = "bankCB";
            this.bankCB.Size = new System.Drawing.Size(121, 21);
            this.bankCB.TabIndex = 0;
            this.bankCB.SelectedIndexChanged += new System.EventHandler(this.BankCB_SelectedIndexChanged);
            // 
            // devisionCB
            // 
            this.devisionCB.FormattingEnabled = true;
            this.devisionCB.Location = new System.Drawing.Point(219, 3);
            this.devisionCB.Name = "devisionCB";
            this.devisionCB.Size = new System.Drawing.Size(121, 21);
            this.devisionCB.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestConncetionMenu,
            this.closeAppMenu});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 48);
            // 
            // TestConncetionMenu
            // 
            this.TestConncetionMenu.Name = "TestConncetionMenu";
            this.TestConncetionMenu.Size = new System.Drawing.Size(165, 22);
            this.TestConncetionMenu.Text = "Тест соединения";
            // 
            // closeAppMenu
            // 
            this.closeAppMenu.Name = "closeAppMenu";
            this.closeAppMenu.Size = new System.Drawing.Size(165, 22);
            this.closeAppMenu.Text = "Close";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1171, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabEdit);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1171, 472);
            this.tabControl.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1163, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1163, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.splitContainer1);
            this.tabEdit.Location = new System.Drawing.Point(4, 22);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdit.Size = new System.Drawing.Size(1163, 446);
            this.tabEdit.TabIndex = 2;
            this.tabEdit.Text = "Редактирование БД";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cbTableToEdit);
            this.splitContainer1.Panel1.Controls.Add(this.saveTableButton);
            this.splitContainer1.Panel1.Controls.Add(this.openTableButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgEditDB);
            this.splitContainer1.Size = new System.Drawing.Size(1157, 440);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.TabIndex = 0;
            // 
            // cbTableToEdit
            // 
            this.cbTableToEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTableToEdit.FormattingEnabled = true;
            this.cbTableToEdit.Items.AddRange(new object[] {
            "Банки",
            "Филиалы банков",
            "Способы ввода"});
            this.cbTableToEdit.Location = new System.Drawing.Point(39, 3);
            this.cbTableToEdit.Name = "cbTableToEdit";
            this.cbTableToEdit.Size = new System.Drawing.Size(121, 21);
            this.cbTableToEdit.TabIndex = 7;
            // 
            // saveTableButton
            // 
            this.saveTableButton.Enabled = false;
            this.saveTableButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveTableButton.Location = new System.Drawing.Point(94, 28);
            this.saveTableButton.Name = "saveTableButton";
            this.saveTableButton.Size = new System.Drawing.Size(90, 28);
            this.saveTableButton.TabIndex = 2;
            this.saveTableButton.Text = "Сохранить";
            this.saveTableButton.UseVisualStyleBackColor = true;
            this.saveTableButton.Click += new System.EventHandler(this.SaveTableButton_Click);
            // 
            // openTableButton
            // 
            this.openTableButton.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openTableButton.Location = new System.Drawing.Point(3, 28);
            this.openTableButton.Name = "openTableButton";
            this.openTableButton.Size = new System.Drawing.Size(92, 28);
            this.openTableButton.TabIndex = 1;
            this.openTableButton.Text = "Открыть";
            this.openTableButton.UseVisualStyleBackColor = true;
            this.openTableButton.Click += new System.EventHandler(this.OpenTableButton_Click);
            // 
            // dgEditDB
            // 
            this.dgEditDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEditDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEditDB.Location = new System.Drawing.Point(0, 0);
            this.dgEditDB.Name = "dgEditDB";
            this.dgEditDB.Size = new System.Drawing.Size(967, 440);
            this.dgEditDB.TabIndex = 0;
            this.dgEditDB.CurrentCellChanged += new System.EventHandler(this.DgEditDB_CurrentCellChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 496);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.devisionCB);
            this.Controls.Add(this.bankCB);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabEdit.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEditDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox bankCB;
        private System.Windows.Forms.ComboBox devisionCB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TestConncetionMenu;
        private System.Windows.Forms.ToolStripMenuItem closeAppMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgEditDB;
        private System.Windows.Forms.Button saveTableButton;
        private System.Windows.Forms.Button openTableButton;
        private System.Windows.Forms.ComboBox cbTableToEdit;
    }
}

