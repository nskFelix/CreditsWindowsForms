
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
            this.ProductCB = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TestConncetionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAppMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCalculate = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.PercentLabel = new System.Windows.Forms.Label();
            this.DiscontNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DiscontLabel = new System.Windows.Forms.Label();
            this.RubLabel = new System.Windows.Forms.Label();
            this.ProductTypeLabel = new System.Windows.Forms.Label();
            this.ProductTypeCB = new System.Windows.Forms.ComboBox();
            this.PeriodCB = new System.Windows.Forms.ComboBox();
            this.PeriodLabel = new System.Windows.Forms.Label();
            this.ProductLabel = new System.Windows.Forms.Label();
            this.BankLabel = new System.Windows.Forms.Label();
            this.CostNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CostLabel = new System.Windows.Forms.Label();
            this.calculatorDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbDeleteRow = new System.Windows.Forms.CheckBox();
            this.cbTableToEdit = new System.Windows.Forms.ComboBox();
            this.saveTableButton = new System.Windows.Forms.Button();
            this.openTableButton = new System.Windows.Forms.Button();
            this.dgEditDB = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabCalculate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiscontNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculatorDataGridView)).BeginInit();
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
            this.bankCB.Location = new System.Drawing.Point(800, 15);
            this.bankCB.Name = "bankCB";
            this.bankCB.Size = new System.Drawing.Size(121, 21);
            this.bankCB.TabIndex = 3;
            this.bankCB.SelectedIndexChanged += new System.EventHandler(this.BankCB_SelectedIndexChanged);
            // 
            // ProductCB
            // 
            this.ProductCB.FormattingEnabled = true;
            this.ProductCB.Location = new System.Drawing.Point(1004, 15);
            this.ProductCB.Name = "ProductCB";
            this.ProductCB.Size = new System.Drawing.Size(121, 21);
            this.ProductCB.TabIndex = 4;
            this.ProductCB.SelectedIndexChanged += new System.EventHandler(this.ProductCB_SelectedIndexChanged);
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
            this.menuStrip1.Size = new System.Drawing.Size(1332, 24);
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
            this.tabControl.Controls.Add(this.tabCalculate);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabEdit);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1332, 606);
            this.tabControl.TabIndex = 5;
            // 
            // tabCalculate
            // 
            this.tabCalculate.Controls.Add(this.splitContainer2);
            this.tabCalculate.Location = new System.Drawing.Point(4, 22);
            this.tabCalculate.Name = "tabCalculate";
            this.tabCalculate.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalculate.Size = new System.Drawing.Size(1324, 580);
            this.tabCalculate.TabIndex = 1;
            this.tabCalculate.Text = "Калькулятор";
            this.tabCalculate.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.PercentLabel);
            this.splitContainer2.Panel1.Controls.Add(this.DiscontNumericUpDown);
            this.splitContainer2.Panel1.Controls.Add(this.DiscontLabel);
            this.splitContainer2.Panel1.Controls.Add(this.RubLabel);
            this.splitContainer2.Panel1.Controls.Add(this.ProductTypeLabel);
            this.splitContainer2.Panel1.Controls.Add(this.ProductTypeCB);
            this.splitContainer2.Panel1.Controls.Add(this.PeriodCB);
            this.splitContainer2.Panel1.Controls.Add(this.PeriodLabel);
            this.splitContainer2.Panel1.Controls.Add(this.ProductLabel);
            this.splitContainer2.Panel1.Controls.Add(this.BankLabel);
            this.splitContainer2.Panel1.Controls.Add(this.CostNumericUpDown);
            this.splitContainer2.Panel1.Controls.Add(this.CostLabel);
            this.splitContainer2.Panel1.Controls.Add(this.ProductCB);
            this.splitContainer2.Panel1.Controls.Add(this.bankCB);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.calculatorDataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(1318, 574);
            this.splitContainer2.SplitterDistance = 61;
            this.splitContainer2.TabIndex = 0;
            // 
            // PercentLabel
            // 
            this.PercentLabel.AutoSize = true;
            this.PercentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PercentLabel.Location = new System.Drawing.Point(719, 15);
            this.PercentLabel.Name = "PercentLabel";
            this.PercentLabel.Size = new System.Drawing.Size(23, 20);
            this.PercentLabel.TabIndex = 13;
            this.PercentLabel.Text = "%";
            // 
            // DiscontNumericUpDown
            // 
            this.DiscontNumericUpDown.AllowDrop = true;
            this.DiscontNumericUpDown.DecimalPlaces = 1;
            this.DiscontNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DiscontNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.DiscontNumericUpDown.Location = new System.Drawing.Point(654, 13);
            this.DiscontNumericUpDown.Name = "DiscontNumericUpDown";
            this.DiscontNumericUpDown.Size = new System.Drawing.Size(62, 26);
            this.DiscontNumericUpDown.TabIndex = 11;
            this.DiscontNumericUpDown.ThousandsSeparator = true;
            this.DiscontNumericUpDown.ValueChanged += new System.EventHandler(this.DiscontNumericUpDown_ValueChanged);
            // 
            // DiscontLabel
            // 
            this.DiscontLabel.AutoSize = true;
            this.DiscontLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DiscontLabel.Location = new System.Drawing.Point(583, 15);
            this.DiscontLabel.Name = "DiscontLabel";
            this.DiscontLabel.Size = new System.Drawing.Size(65, 20);
            this.DiscontLabel.TabIndex = 12;
            this.DiscontLabel.Text = "Скидка";
            // 
            // RubLabel
            // 
            this.RubLabel.AutoSize = true;
            this.RubLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RubLabel.Location = new System.Drawing.Point(205, 16);
            this.RubLabel.Name = "RubLabel";
            this.RubLabel.Size = new System.Drawing.Size(38, 20);
            this.RubLabel.TabIndex = 10;
            this.RubLabel.Text = "руб.";
            // 
            // ProductTypeLabel
            // 
            this.ProductTypeLabel.AutoSize = true;
            this.ProductTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductTypeLabel.Location = new System.Drawing.Point(345, 15);
            this.ProductTypeLabel.Name = "ProductTypeLabel";
            this.ProductTypeLabel.Size = new System.Drawing.Size(111, 20);
            this.ProductTypeLabel.TabIndex = 9;
            this.ProductTypeLabel.Text = "Тип продукта";
            // 
            // ProductTypeCB
            // 
            this.ProductTypeCB.FormattingEnabled = true;
            this.ProductTypeCB.Location = new System.Drawing.Point(459, 15);
            this.ProductTypeCB.Name = "ProductTypeCB";
            this.ProductTypeCB.Size = new System.Drawing.Size(121, 21);
            this.ProductTypeCB.TabIndex = 2;
            this.ProductTypeCB.SelectedIndexChanged += new System.EventHandler(this.ProductTypeCB_SelectedIndexChanged);
            // 
            // PeriodCB
            // 
            this.PeriodCB.FormattingEnabled = true;
            this.PeriodCB.Location = new System.Drawing.Point(1181, 14);
            this.PeriodCB.Name = "PeriodCB";
            this.PeriodCB.Size = new System.Drawing.Size(121, 21);
            this.PeriodCB.TabIndex = 5;
            this.PeriodCB.SelectedIndexChanged += new System.EventHandler(this.PeriodCB_SelectedIndexChanged);
            // 
            // PeriodLabel
            // 
            this.PeriodLabel.AutoSize = true;
            this.PeriodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PeriodLabel.Location = new System.Drawing.Point(1132, 13);
            this.PeriodLabel.Name = "PeriodLabel";
            this.PeriodLabel.Size = new System.Drawing.Size(46, 20);
            this.PeriodLabel.TabIndex = 6;
            this.PeriodLabel.Text = "Срок";
            // 
            // ProductLabel
            // 
            this.ProductLabel.AutoSize = true;
            this.ProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductLabel.Location = new System.Drawing.Point(927, 14);
            this.ProductLabel.Name = "ProductLabel";
            this.ProductLabel.Size = new System.Drawing.Size(74, 20);
            this.ProductLabel.TabIndex = 5;
            this.ProductLabel.Text = "Продукт";
            // 
            // BankLabel
            // 
            this.BankLabel.AutoSize = true;
            this.BankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BankLabel.Location = new System.Drawing.Point(751, 15);
            this.BankLabel.Name = "BankLabel";
            this.BankLabel.Size = new System.Drawing.Size(46, 20);
            this.BankLabel.TabIndex = 4;
            this.BankLabel.Text = "Банк";
            // 
            // CostNumericUpDown
            // 
            this.CostNumericUpDown.AllowDrop = true;
            this.CostNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CostNumericUpDown.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.CostNumericUpDown.InterceptArrowKeys = false;
            this.CostNumericUpDown.Location = new System.Drawing.Point(103, 14);
            this.CostNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.CostNumericUpDown.Name = "CostNumericUpDown";
            this.CostNumericUpDown.Size = new System.Drawing.Size(101, 26);
            this.CostNumericUpDown.TabIndex = 1;
            this.CostNumericUpDown.ThousandsSeparator = true;
            this.CostNumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.CostNumericUpDown.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.CostNumericUpDown.ValueChanged += new System.EventHandler(this.SumTB_TextChanged);
            this.CostNumericUpDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SumNumericUpDown_KeyDown);
            // 
            // CostLabel
            // 
            this.CostLabel.AutoSize = true;
            this.CostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CostLabel.Location = new System.Drawing.Point(4, 15);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(93, 20);
            this.CostLabel.TabIndex = 1;
            this.CostLabel.Text = "Стоимость";
            // 
            // calculatorDataGridView
            // 
            this.calculatorDataGridView.AllowUserToAddRows = false;
            this.calculatorDataGridView.AllowUserToDeleteRows = false;
            this.calculatorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.calculatorDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calculatorDataGridView.Location = new System.Drawing.Point(0, 0);
            this.calculatorDataGridView.Name = "calculatorDataGridView";
            this.calculatorDataGridView.ReadOnly = true;
            this.calculatorDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.calculatorDataGridView.Size = new System.Drawing.Size(1318, 509);
            this.calculatorDataGridView.TabIndex = 0;
            this.calculatorDataGridView.SelectionChanged += new System.EventHandler(this.СalculatorDataGridView_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1324, 580);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.splitContainer1);
            this.tabEdit.Location = new System.Drawing.Point(4, 22);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdit.Size = new System.Drawing.Size(1324, 580);
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
            this.splitContainer1.Panel1.Controls.Add(this.cbDeleteRow);
            this.splitContainer1.Panel1.Controls.Add(this.cbTableToEdit);
            this.splitContainer1.Panel1.Controls.Add(this.saveTableButton);
            this.splitContainer1.Panel1.Controls.Add(this.openTableButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgEditDB);
            this.splitContainer1.Size = new System.Drawing.Size(1318, 574);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 0;
            // 
            // cbDeleteRow
            // 
            this.cbDeleteRow.AutoSize = true;
            this.cbDeleteRow.Location = new System.Drawing.Point(52, 75);
            this.cbDeleteRow.Name = "cbDeleteRow";
            this.cbDeleteRow.Size = new System.Drawing.Size(108, 17);
            this.cbDeleteRow.TabIndex = 1;
            this.cbDeleteRow.Text = "Удаление строк";
            this.cbDeleteRow.UseVisualStyleBackColor = true;
            this.cbDeleteRow.CheckedChanged += new System.EventHandler(this.СheckBoxDeleteRow_CheckedChanged);
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
            this.dgEditDB.AllowUserToDeleteRows = false;
            this.dgEditDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEditDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEditDB.Location = new System.Drawing.Point(0, 0);
            this.dgEditDB.Name = "dgEditDB";
            this.dgEditDB.Size = new System.Drawing.Size(1103, 574);
            this.dgEditDB.TabIndex = 0;
            this.dgEditDB.CurrentCellChanged += new System.EventHandler(this.DgEditDB_CurrentCellChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 630);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabCalculate.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DiscontNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculatorDataGridView)).EndInit();
            this.tabEdit.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEditDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox bankCB;
        private System.Windows.Forms.ComboBox ProductCB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TestConncetionMenu;
        private System.Windows.Forms.ToolStripMenuItem closeAppMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabCalculate;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgEditDB;
        private System.Windows.Forms.Button saveTableButton;
        private System.Windows.Forms.Button openTableButton;
        private System.Windows.Forms.ComboBox cbTableToEdit;
        private System.Windows.Forms.CheckBox cbDeleteRow;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView calculatorDataGridView;
        private System.Windows.Forms.Label CostLabel;
        private System.Windows.Forms.NumericUpDown CostNumericUpDown;
        private System.Windows.Forms.ComboBox PeriodCB;
        private System.Windows.Forms.Label PeriodLabel;
        private System.Windows.Forms.Label ProductLabel;
        private System.Windows.Forms.Label BankLabel;
        private System.Windows.Forms.Label ProductTypeLabel;
        private System.Windows.Forms.ComboBox ProductTypeCB;
        private System.Windows.Forms.Label PercentLabel;
        private System.Windows.Forms.NumericUpDown DiscontNumericUpDown;
        private System.Windows.Forms.Label DiscontLabel;
        private System.Windows.Forms.Label RubLabel;
    }
}

