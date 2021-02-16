using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;

namespace CreditsWindowsForms
{
    public partial class CreditWorker : Form
    {
        public static string conncetionString = @"Data Source=WORKNOTEBOOK\SQLEXPRESS;Initial Catalog=Credits;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(conncetionString);
        SqlDataReader sqlReader = null;
        SqlCommand command = null;
        public static string noFilter = "Без ограничений";

        //запуск и прекращение программы 
        /*Загрузка окна   
         */
        public CreditWorker()
        {
            InitializeComponent();


            CostNumericUpDown.Controls[0].Visible = false;
            /* Подготовка вкладки редактирование БД 
            * Загрузка списка доступных для редактирования таблиц в БД 
            * Настройка стартовых параметров для компонентов на этой вкладке
            */
            {
                dgEditDB.AutoGenerateColumns = false;
                cbDeleteRow.Checked = false;
                cbTableToEdit.Items.Clear();
                SqlCommand cmd = new SqlCommand($"SELECT TABLE_NAME FROM Credits.INFORMATION_SCHEMA.TABLES", sqlConnection);
                sqlConnection.Open();
                var reader = cmd.ExecuteReader();
                var lst = new List<string>();
                {

                    while (reader.Read())
                    {
                        lst.Add((string)reader[0]);
                    }
                }
                sqlConnection.Close();
                lst.Remove("sysdiagrams");
                lst.Remove("Source_Of_Income");
                lst.Remove("Income");
                cbTableToEdit.Items.AddRange(lst.ToArray());
                cbTableToEdit.SelectedIndex = 0;
            }
            /* Подготовка вкладки Калькулятор 
            * Заполнение коллекций для фильтров 
            * Настройка стартовых параметров для компонентов на этой вкладке
            */
            {
                PartnerCB.Items.Clear();
                PartnerCB.Items.Add(noFilter);
                PartnerCB.Items.AddRange(new SimpleTable("Partner").Names.ToArray());
                PeriodCB.Items.Clear();
                PeriodCB.Items.Add(noFilter);
                PeriodCB.Items.AddRange(new SimpleTable("ProductVersion", "Period").Parametrs.ToArray());
                //ProductTypeCB.SelectedIndex = 2;
                PartnerCB.SelectedIndex = 0;
                bankCB.SelectedIndex = 1;
                ProductCB.SelectedIndex = 1;
                PeriodCB.SelectedIndex = 0;
                CostNumericUpDown.Value = 100000;
                calculatorDataGridView.RowHeadersVisible = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            calculatorDataGridView.ClearSelection();
        }

        /*Закрытие окна
 */
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // новые классы и методы 
        /* класс SimpleTable используется для более удобного получения, хранения и использований различных коллекций с ID и Name 
        * так же может использоваться для создания других коллекций с заполнением коллекции Parametrs всеми вариантами 
        * заданного параметра в указанной таблице
        */
        class SimpleTable
        {
            private readonly List<SimpleRow> items = new List<SimpleRow>();
            private readonly List<string> iDs = new List<string>();
            private readonly List<string> names = new List<string>();
            private readonly List<string> parametrs = new List<string>();
            private readonly string tableBD;
            public class SimpleRow
            {
                private string id;
                private string name;

                public SimpleRow(string id, string name)
                {
                    this.Id = id;
                    this.Name = name;
                }

                public string Id { get => id; set => id = value; }
                public string Name { get => name; set => name = value; }
            }

            public List<SimpleRow> Items { get => items;}
            public List<string> IDs { get => iDs; }
            public List<string> Names { get => names; }
            public List<string> Parametrs { get => names; }

            public static List<SimpleTable> Objects = new List<SimpleTable>();

            public SimpleTable(string tableBD, string parametr)
            {
                this.tableBD = tableBD;
                Objects.Add(this);
                SqlCommand command = new SqlCommand($@"SELECT t.{parametr}
                                                   FROM {tableBD} as t
                                                   GROUP by t.{parametr}
                                                   ORDER BY t.{parametr}",
                                                    sqlConnection);
                this.items.Clear();
                this.iDs.Clear();
                this.names.Clear();
                sqlConnection.Open();

                SqlDataReader sqlReader = null;

                try
                {
                    sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        string ID = sqlReader[0].ToString();
                        this.Parametrs.Add(ID);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();

                }
                sqlConnection.Close();

            }
            public SimpleTable(string tableBD)
            {
                this.tableBD = tableBD;
                Objects.Add(this);
                SqlCommand command = new SqlCommand($@"SELECT *
                                                   FROM {tableBD} as t
                                                   ORDER BY t.ID",
                                                   sqlConnection);
                this.items.Clear();
                this.iDs.Clear();
                this.names.Clear();
                sqlConnection.Open();

                SqlDataReader sqlReader = null;

                try
                {
                    sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        string ID = sqlReader["ID"].ToString();
                        string Name = "";
                        try
                        {
                            Name = (string)sqlReader["Name"];
                        }
                        catch
                        {
                            Name = ID;
                        }
                        this.items.Add(new SimpleRow(ID, Name));
                        this.names.Add(Name);
                        this.iDs.Add(ID);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();

                }
                sqlConnection.Close();
            }

        }

        /*Методы для создания столбцов в DataGridView разных видов, используя разные форматы для этих видов
         */
        DataGridViewTextBoxColumn ColumnID()
        {
            DataGridViewTextBoxColumn column = (new DataGridViewTextBoxColumn
            {
                Name             = "ID",
                HeaderText       = "ID",
                ReadOnly         = true,
                Width = 40,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor    = Color.LightGray
                }
            });
            return column;
        }
        DataGridViewTextBoxColumn ColumnText(string columnName, string columnHeader, int width, Color color)
        {
            DataGridViewTextBoxColumn column = (new DataGridViewTextBoxColumn
            {
                Name        = columnName,
                HeaderText  = columnHeader,
                Width = width,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = color
                }
            });
            return column;
        }
        DataGridViewTextBoxColumn ColumnText(string columnName, string columnHeader, Color color)
        {
            return ColumnText(columnName, columnHeader, 150, color);
        }
        DataGridViewTextBoxColumn ColumnText(string columnName, string columnHeader, int width)
        {
            return ColumnText(columnName, columnHeader, width, Color.Empty);
        }
        DataGridViewTextBoxColumn ColumnText(string columnName, string columnHeader)
        {
            return ColumnText(columnName, columnHeader, 150, Color.Empty);
        }
        DataGridViewTextBoxColumn ColumnText()
        {
            return ColumnText("Name", "Название");
        }
        DataGridViewComboBoxColumn ColumnCombobox(string columnName, string columnHeader, SimpleTable t)
        {
            DataGridViewComboBoxColumn column = (new DataGridViewComboBoxColumn
            {
                Name = columnName,
                HeaderText = columnHeader,
                DataSource = t.Names,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.LightBlue
                }
            });
            return column;
        }
        DataGridViewCheckBoxColumn ColumnCheckBox(string columnName, string columnHeader)
        {
            DataGridViewCheckBoxColumn column = (new DataGridViewCheckBoxColumn
            {
                Name = columnName,
                HeaderText = columnHeader,
                IndeterminateValue = false
            }); ;
            return column;
        }

        //вкладка Редактирование БД
         /*Создание структуры DataGridView под данные из БД, и заполнение этими данными, 
         * колонки содержащие ID из других таблиц заменяются на соответсвующие им значения из им таблиц 
         * для корректной работы замещенные столбцы создаются с типом ComboBoxColumn, в качестве источника данных для таких столбцов 
         * используется класс SimpleTable 
         */
        private void ConstructDataGridView(DataGridView dataGridView, string TableName)
        {
            //получение списка столбцов из БД
            command = new SqlCommand($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{TableName}'", sqlConnection);
            sqlConnection.Open();
            sqlReader = command.ExecuteReader();
            var lst = new List<string>();
            while (sqlReader.Read())
            {
                lst.Add((string)sqlReader[0]);
            }
            sqlConnection.Close();
                
            // создание структуры БД
            dataGridView.Columns.Clear();
            var simpleTableCollection = new SimpleTable[lst.Count];
            foreach (var i in lst)
                {
                    switch (i)
                    {
                        case "ID":
                            { dataGridView.Columns.Add(ColumnID()); break; }
                        case "Name":
                            { dataGridView.Columns.Add(ColumnText()); break; }
                        default:
                        { 
                            if (i.Contains("ID"))
                            {
                                /* если столбец содержит ID из другой таблицы БД, то он заменяется на столбец с названием этой таблицы, 
                                 * и создайтся класс SimpleTable хранящий  коллекции ID и NAME из указанной таблицы, этот класс так же 
                                 * служит источником данных для создаваемого столбца типа ComboBox
                                 */
                                string x=i.TrimEnd(new Char[] { 'I', 'D' });
                                SimpleTable sourse = new SimpleTable(x);
                                dataGridView.Columns.Add(ColumnCombobox(i, x, sourse));
                                simpleTableCollection[dataGridView.Columns.Count - 1] = sourse;                                
                            }
                            else if (i.StartsWith("Is"))
                            {   
                                dataGridView.Columns.Add(ColumnCheckBox(i,i));
                            }
                            else
                            {
                                dataGridView.Columns.Add(ColumnText(i, i));
                            }           
                            break; 
                        }

                    }

                }

            // Заполнение созданной таблицы данными из БД
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM {TableName} ORDER BY ID", sqlConnection);
            try
            {

                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    List<string> parametrs = new List<string>();
                    for (int i = 0; i < dataGridView.ColumnCount; i++)
                    {
                        if (dataGridView.Columns[i].Name.Contains("ID") && (dataGridView.Columns[i].Name != "ID"))
                        {//замена ID из другой таблицы на соответсвующие им Name
                            string tempID   = sqlReader[dataGridView.Columns[i].Name].ToString();
                            int indexID     = simpleTableCollection[i].Items.FindIndex(x => x.Id == tempID);
                            parametrs.Add(simpleTableCollection[i].Items[indexID].Name);
                        }
                        else if (dataGridView.Columns[i].Name.StartsWith("Is"))
                        {
                            parametrs.Add(sqlReader[dataGridView.Columns[i].Name].ToString());
                        }
                        else
                        {
                            parametrs.Add(sqlReader[dataGridView.Columns[i].Name].ToString());
                        }
                    }
                    dataGridView.Rows.Add(parametrs.ToArray());
                }
                sqlReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sqlConnection.Close();

        }

        /*Сохранение данных из DataGridView в БД,  
        * колонки содержащие имена из других таблиц заменяются на соответсвующие им значения ID  
        * замещенные столбцы имеют тип ComboBoxColumn,  
        * для буфера ID и Name используется класс SimpleTable 
        * List baseID создаётся для отслеживания совпадений ID в DataGridView и БД
        * Если совпадение есть, то используется UPDATE, 
        * если ID есть только в БД, то используется DELETE
        * для новых строк в DataGridView ID имеет значение null, для корректной работы таким строкам присваивается ID=""
        */
        private bool SaveDataFromDataGridViewToDB(DataGridView dataGridView, string TableName)
        {
            try
            {
                sqlReader = null;
                command = null;
                List<string> baseID = new SimpleTable(TableName).IDs;
                //проход по строкам в DataGridView
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        List<string> values = new List<string>();
                        List<string> parametrs = new List<string>();
                        //Форматирование данных в DataGridView
                        for (int c = 0; c < dataGridView.Columns.Count; c++)
                        {
                            if (dgEditDB.Columns[c].GetType() == new DataGridViewCheckBoxColumn().GetType())
                            {//замена значений null на false в CheckBoxColumn
                                if (row.Cells[c].Value == null)
                                { row.Cells[c].Value = false; }
                            } 
                            if (row.Cells[c].Value == null && c != 0)
                            {//поиск значений null в таблице, допускается только null в первом столбце (ID)
                                MessageBox.Show("Обнаружены незаполненные ячейки");
                                return false;
                            }
                            else if (row.Cells[c].Value == null && c == 0)
                            {//замена null в столбце ID на пустую строку
                                values.Add("");
                            }
                            else if (dgEditDB.Columns[c].GetType() == new DataGridViewComboBoxColumn().GetType())
                            {//замена названий из других таблиц на соответсвующие им ID
                                SimpleTable table = new SimpleTable(dataGridView.Columns[c].HeaderText);
                                int k = table.Items.FindIndex(x => x.Name == row.Cells[c].Value.ToString());
                                values.Add(table.Items[k].Id);
                            }

                            else
                            {
                                values.Add(row.Cells[c].Value.ToString().Replace(',','.'));
                            }
                            parametrs.Add(dataGridView.Columns[c].Name);
                        }
                        sqlConnection.Open();


                        // изменение текущих или внесение новых данных в БД
                        if (baseID.Contains(values[0]))
                        {
                            //command = new SqlCommand($@"UPDATE Bank SET Name='{name}' WHERE ID={id}", sqlConnection);
                            command = new SqlCommand(UPDATE_COMMAND(parametrs, values, TableName), sqlConnection);
                            baseID.Remove(values[0]);
                        }
                        else
                        {
                            command = new SqlCommand(INSERT_COMMAND(values, TableName), sqlConnection);
                        }
                        sqlReader = command.ExecuteReader();
                        sqlReader.Close();
                        sqlConnection.Close();
                    }
                }
                //Удаление строк найденых в БД, но отсутствующих в DataGridView
                sqlConnection.Open();
                foreach (string id in baseID)
                {
                    if (cbDeleteRow.Checked)
                    {
                        command = new SqlCommand($@"DELETE FROM {TableName}  
                                                            WHERE ID={id}",
                                                        sqlConnection);

                        sqlReader = command.ExecuteReader();
                        sqlReader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Удаление строк запрещено");
                    }
                }
                sqlConnection.Close();
                ConstructDataGridView(dataGridView, TableName);
                return true;
        }
            catch (Exception ex)
            {
                sqlConnection.Close();
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
}

        /*элементы управления для редактирования БД
         */
        private  void OpenTableButton_Click(object sender, EventArgs e)
        {
            string tableToEdit = cbTableToEdit.SelectedItem.ToString();
            ConstructDataGridView(dgEditDB, tableToEdit);
            saveTableButton.Enabled = false;
            cbTableToEdit.Enabled = true;
            openTableButton.Text = "Открыть";
        }
        private void SaveTableButton_Click(object sender, EventArgs e)
        {
            string tableToEdit = cbTableToEdit.SelectedItem.ToString();
            bool saved = SaveDataFromDataGridViewToDB(dgEditDB, tableToEdit);
            if (saved)
            {
                saveTableButton.Enabled = false;
                cbTableToEdit.Enabled = true;
                openTableButton.Text = "Открыть";
            }
        }
        private void DgEditDB_CurrentCellChanged(object sender, EventArgs e)
        {
            saveTableButton.Enabled = true;
            cbTableToEdit.Enabled = false;
            openTableButton.Text = "Отмена";
        }
        private void СheckBoxDeleteRow_CheckedChanged(object sender, EventArgs e)
        {
            dgEditDB.AllowUserToDeleteRows = cbDeleteRow.Checked;
        }

        /*создание SQL команд 
         */
        string INSERT_COMMAND(List<String> Values, string TableName)
        {
            string command = $@"INSERT INTO {TableName} VALUES (";
            if (Values.Count > 2)
            {
                for (int i = 1; i < Values.Count - 1; i++)
                {
                    command += $@" '{Values[i]}', ";
                }
            }
            command += $@"'{Values[Values.Count-1]}') ";            
           return command;

        }
        string UPDATE_COMMAND(List<String> Parametrs, List<String> Values, string TableName)
        {
            string command = $@"UPDATE {TableName} SET ";
            if (Values.Count > 2)
            {
                for (int i = 1; i < Parametrs.Count - 1; i++)
                {
                    command += $@"{Parametrs[i]} = '{Values[i]}', ";
                }
            }
            command += $@"{Parametrs[Parametrs.Count-1]} = '{Values[Parametrs.Count - 1]}' WHERE {Parametrs[0]} = {Values[0]}";
            return command;

        }


        //вкладка калькулятор

        /* Основной метод для расчёта в кредитном калькуляторе, принимает в качестве аргументов 
         * DatagridView, стоимость, сумму за вычетом скидки и все возможные фильтры, на основе полученных данных создаёт SQL Select,
         * создаёт структуру таблицы, заполняет её данными из полученного запроса, и расчитывает на основе полученных данных недостающие значения
         * на финальном этапе выделяет цветом важные колонки в зависимости от того, что за продукт расчитан в текущей строке
        */
        private void Calculate(DataGridView dataGridView, double cost, double sum, string partnerFilter, string overpaymentFilter, string bankFilter, string productFilter, string periodFilter)
        {
            //создание столбцов для таблицы
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add(ColumnText("Period", "Срок", 70, Color.GreenYellow));
            dataGridView.Columns.Add(ColumnText("Payment", "Платёж", Color.Yellow));
            dataGridView.Columns.Add(ColumnText("PaymentSum", "Сумма выплат"));
            dataGridView.Columns.Add(ColumnText("OverpaymentSum", "Переплата", 110));
            dataGridView.Columns.Add(ColumnText("OverpaymentPercent", "Процент переплаты", 120));
            dataGridView.Columns.Add(ColumnCheckBox("IsOverpayment", "Рассрочка"));
            dataGridView.Columns.Add(ColumnText("LossOfPartner", "Потери организации", 110));
            dataGridView.Columns.Add(ColumnText("CreditSum", "Сумма кредита", 120));
            dataGridView.Columns.Add(ColumnText("Bank", "Банк", 180));
            dataGridView.Columns.Add(ColumnText("Product", "Продукт", 300));

            //изменение стилей используемых в таблице
            dataGridView.Columns["IsOverpayment"].Visible = false;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri Light", 14);
            dataGridView.DefaultCellStyle = new DataGridViewCellStyle
            {
                Padding = new Padding(5),
                Font = new Font("Calibri Light", 14)

            };
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // создание SQL запроса на основе фильтров
            string command = $@"SELECT pv.MinSum, pv.MaxSum, b.Name as Bank, p.Name as Product, pv.Period, pv.Rate, pv.LossOfPartner, pv.IsOverpayment
                                   FROM ProductVersion as pv
                                   JOIN Product as p ON pv.ProductID = p.ID
                                   JOIN Bank as b ON p.BankID = b.ID
								   WHERE pv.MinSum<={sum} and pv.MaxSum>= {sum}";
            if (overpaymentFilter != noFilter)
            {
                bool filter = false;
                if (overpaymentFilter == "Рассрочка") filter = true;
                command += $" and pv.IsOverpayment = '{filter}'";
            }
            if (bankFilter != noFilter)
            {
                command += $" and b.Name = '{bankFilter}'";
            }
            else
            {
                var lst = new List<string>();
                if (partnerFilter != noFilter)
                {
                    var com = new SqlCommand($@"SELECT b.Name
                                FROM Bank as b
                                JOIN Partner_Bank as pb on b.ID = pb.BankID
                                JOIN Partner as p on p.ID = pb.PartnerID
                                WHERE p.Name = '{partnerFilter}'
                                ORDER BY b.ID", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        lst.Add((string)reader[0]);
                    }
                }
                else
                {
                    lst = new SimpleTable("Bank").Names;
                }
                sqlConnection.Close();
                command += $"and (b.Name = '{lst[0]}' ";
                for (int i = 1; i < lst.Count; i++)
                {
                    {
                        command += $" or b.Name = '{lst[i]}'";
                    }

                }
                command += ") ";
            }
            if (productFilter != noFilter)
            {
                command += $" and p.Name = '{productFilter}'";
            }
            else
            {
                if (ProductCB.Items.Count > 1)
                {
                    command += $"and (p.Name = '{ProductCB.Items[1]}' ";
                    for (int i = 2; i < ProductCB.Items.Count; i++)
                    {
                        {
                            command += $" or p.Name = '{ProductCB.Items[i]}'";
                        }

                    }
                    command += ") ";
                }
            }
            if (periodFilter != noFilter)
            {
                command += $" and pv.Period = '{periodFilter}'";
            }
            command += " ORDER BY pv.IsOverpayment DESC, b.ID, p.ID, pv.Period";
            SqlCommand cmd = new SqlCommand(command, sqlConnection);

            //получение данных из таблицы, расчёт недостающих параметров, формирование строки таблицы
            sqlConnection.Open();
            try
            {
                var reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        // получение данных
                        string bank = (string)reader["Bank"];
                        string product = (string)reader["Product"];
                        int period = (int)reader["Period"];
                        double rate = double.Parse(reader["Rate"].ToString());
                        double lossOfPartner = double.Parse(reader["LossOfPartner"].ToString()) / 100;
                        bool isOverpayment = (bool)reader["IsOverpayment"];

                        // расчёты
                        double creditSum = sum - (sum * lossOfPartner);
                        double payment;
                        double paymentSum;
                        if (!isOverpayment)
                        {
                            payment = creditSum * ((rate / 100 / 12) / (1 - Math.Pow(1 + (rate / 100 / 12), -period)));
                            paymentSum = payment * period;
                        }
                        else
                        {
                            payment = sum / period;
                            paymentSum = sum;
                        }
                        double overpaymentSum = paymentSum - cost;
                        double overpaymentPercent = overpaymentSum / cost;

                        //добавление новой строки в таблицу
                        dataGridView.Rows.Add(
                            period,
                            payment.ToString("C0"),
                            paymentSum.ToString("C0"),
                            overpaymentSum.ToString("C0"),
                            overpaymentPercent.ToString("P"),
                            isOverpayment,
                            lossOfPartner.ToString("P1"),
                            creditSum.ToString("C0"),
                            bank,
                            product
                            );
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            sqlConnection.Close();

            //выделение важных элементов таблицы шрифтом и цветом
            List<int> mainPeriods = new List<int> { 6, 12, 24 };
            foreach (DataGridViewRow i in dataGridView.Rows)
            {
                // выделение шрифтом строк с основными вариантами срока кредита
                int currentPeriod = (int)i.Cells["Period"].Value;
                if (mainPeriods.Contains(currentPeriod))
                {
                    i.DefaultCellStyle.Font = new Font(dataGridView.DefaultCellStyle.Font, FontStyle.Bold);
                }

                //выделение цветом важных ячеек в зависимости от того, является ли данная строка расчётом рассрочки или кредита
                bool isCurrentOverpayment = (bool)i.Cells["IsOverpayment"].Value;
                if (isCurrentOverpayment)
                {
                    
                    i.Cells["CreditSum"].Style.BackColor = Color.LightBlue;
                    i.Cells["LossOfPartner"].Style.BackColor = Color.LightBlue;
                }
                else
                {
                    i.Cells["OverpaymentSum"].Style.BackColor = Color.LightBlue;
                    i.Cells["OverpaymentPercent"].Style.BackColor = Color.LightBlue;
                }

                //указание цвета для наименее важных ячеек
                foreach (DataGridViewCell c in i.Cells)
                        if (dataGridView.Columns[c.ColumnIndex].DefaultCellStyle.BackColor.IsEmpty && c.Style.BackColor.IsEmpty)
                        {
                            c.Style.BackColor = Color.LightGray;
                        }
            }
        }
        
        /*Упрощённый вызов метода Calculate, для автоматического указания входных параметров
         */
        private void Calculate()
        {
            double cost = (double)CostNumericUpDown.Value;
            double discont = (double)DiscontNumericUpDown.Value;
            double sum = cost - (cost * discont/100);
            Calculate(calculatorDataGridView, cost, sum, PartnerCB.Text, ProductTypeCB.Text, bankCB.Text, ProductCB.Text, PeriodCB.Text); ;
            calculatorDataGridView.ClearSelection();
        }

        /*События при взаимодействии с пользовательским интерфейсом на вкладке калькулятор
         */
        private void SumTB_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        private void BankCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oldProduct = ProductCB.Text;
            ProductCB.Items.Clear();
            ProductCB.Items.Add(noFilter);
            sqlConnection.Open();
            try
            {
                if (PartnerCB.Text == noFilter)
                {
                    command = new SqlCommand($@"SELECT p.Name
                                                   FROM Product as p
                                                   JOIN Bank as b ON p.BankID = b.ID
                                                   WHERE b.Name='{bankCB.Text}'
                                                   ORDER BY p.ID",
                                                   sqlConnection);
                }
                else if (bankCB.Text!=noFilter)
                {
                    command = new SqlCommand($@"SELECT p.Name
                                                           FROM Partner_Product as pp
                                                           JOIN Partner_Bank as pb on pp.Partner_BankID = pb.ID
                                                           JOIN Bank as b on pb.BankID = b.ID
                                                           JOIN Partner as par on par.ID = pb.PartnerID 
                                                           JOIN Product as p on p.ID = pp.ProductID
                                                           WHERE par.Name = '{PartnerCB.Text}' and b.Name='{bankCB.Text}'",
                                                          sqlConnection);
                }
                else
                {
                    command = new SqlCommand($@"SELECT p.Name
                                                           FROM Partner_Product as pp
                                                           JOIN Partner_Bank as pb on pp.Partner_BankID = pb.ID
                                                           JOIN Bank as b on pb.BankID = b.ID
                                                           JOIN Partner as par on par.ID = pb.PartnerID 
                                                           JOIN Product as p on p.ID = pp.ProductID
                                                           WHERE par.Name = '{PartnerCB.Text}'",
                                      sqlConnection);
                }
                var reader = command.ExecuteReader();
                var lst = new List<string>();

                while (reader.Read())
                {
                    lst.Add((string)reader[0]);
                }
                ProductCB.Items.AddRange(lst.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sqlConnection.Close();
            if (ProductCB.Items.Contains(oldProduct))
            {
                ProductCB.SelectedItem = oldProduct;
            }
            else
            {
                ProductCB.SelectedIndex = 0;
            }
            if (bankCB.Text != noFilter)
            {
                ProductCB.Enabled = true;
            }
            else
            {
                ProductCB.Enabled = false;
                ProductCB.SelectedIndex = 0;
            }
        }
        private void ProductCB_SelectedIndexChanged(object sender, EventArgs e)
        {      
            Calculate();
        }
        private void PeriodCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        private void ProductTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductTypeCB.Text == "Рассрочка")
            {
                DiscontNumericUpDown.Value = 0;
                DiscontNumericUpDown.Enabled = false;
            }
            else
            {
                DiscontNumericUpDown.Enabled = true;
            }
            Calculate();
        }
        private void DiscontNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        private void SumNumericUpDown_KeyDown(object sender, KeyEventArgs e)//отключение звукового сигнала от нажатия на кнопку ENTER при вводе суммы кредита
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

            }
        }
        private void СalculatorDataGridView_SelectionChanged(object sender, EventArgs e)//выделение всей строки вместо выделения одной ячейки в таблице, удобно для быстрого зрительного анализа
        {
            try
            {
                calculatorDataGridView.SelectedCells[0].OwningRow.Selected = true;
            }
            catch { }
        }
        private void CostNumericUpDown_Paint(object sender, PaintEventArgs e)//Кнопки управления у CostNumericUpDown скрыты, это вадёт баг при перерисовки элемета во время переключения вкладок или сворачивания окна
        {
            e.Graphics.Clear(SystemColors.Window);
            base.OnPaint(e);
        }
        private void PartnerCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var oldbank = bankCB.Text;
            bankCB.Items.Clear();
            bankCB.Items.Add(noFilter);
            ProductTypeCB.Items.Clear();
            ProductTypeCB.Items.Add(noFilter);
            if (PartnerCB.Text == noFilter)
            {
                bankCB.Items.AddRange(new SimpleTable("Bank").Names.ToArray());
                ProductTypeCB.Items.Add("Рассрочка");
            }
            else
            {
                sqlConnection.Open();

                try
                {
                    command = new SqlCommand($@"SELECT p.IsAllowOverpayment
                                FROM Partner as p 
                                WHERE p.Name = '{PartnerCB.Text}'", sqlConnection);
                    sqlReader = command.ExecuteReader();
                    sqlReader.Read();
                    bool IsAllowOverpayment = (bool)sqlReader[0];
                  if (IsAllowOverpayment)
                    {
                        ProductTypeCB.Items.Add("Рассрочка");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlReader.Close();
                try
                {
                    command = new SqlCommand($@"SELECT b.Name
                                FROM Bank as b
                                JOIN Partner_Bank as pb on b.ID = pb.BankID
                                JOIN Partner as p on p.ID = pb.PartnerID
                                WHERE p.Name = '{PartnerCB.Text}'
                                ORDER BY b.ID", sqlConnection);
                    sqlReader = command.ExecuteReader();
                    var lst = new List<string>();
                    while (sqlReader.Read())
                    {
                        lst.Add((string)sqlReader[0]);
                    }
                    bankCB.Items.AddRange(lst.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlConnection.Close();
            }
            if (bankCB.Items.Contains(oldbank))
            {
                bankCB.SelectedItem = oldbank;
            }//Попытка выбрать в обновлённом списке банк, выбранный до этого
            else
            {
                bankCB.SelectedIndex = 0;
            }
            ProductTypeCB.Items.Add("Кредит");
            ProductTypeCB.SelectedIndex = 1;
            Calculate();
        }
    }
}