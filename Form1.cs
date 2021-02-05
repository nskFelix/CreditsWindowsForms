using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace CreditsWindowsForms
{
    public partial class Form1 : Form
    {
        public static string conncetionString = @"Data Source=WORKNOTEBOOK\SQLEXPRESS;Initial Catalog=Credits;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(conncetionString);
        SqlDataReader sqlReader = null;
        SqlCommand command = null;

        class SimpleRow
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

        class SimpleTable
        {
            private readonly List<SimpleRow> items = new List<SimpleRow>();
            private readonly List<string> iDs = new List<string>();
            private readonly List<string> names = new List<string>();
            private readonly string tableBD;

            public List<SimpleRow> Items { get => items;}
            public List<string> IDs { get => iDs; }
            public List<string> Names { get => names; }

            public static List<SimpleTable> Objects = new List<SimpleTable>();

            public SimpleTable(string tableBD)
            {
                this.tableBD = tableBD;
                Objects.Add(this);
                Update();
            }


            public void Update()
            {
                this.items.Clear();
                this.iDs.Clear();
                this.names.Clear();
                sqlConnection.Open();

                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand($@"SELECT t.ID, t.Name
                                                   FROM {tableBD} as t
                                                   ORDER BY t.ID",
                                                       sqlConnection);

                try
                {
                    sqlReader =  command.ExecuteReader();
                    while ( sqlReader.Read())
                    {
                        string ID = sqlReader["ID"].ToString();
                        string Name = sqlReader["Name"].ToString();
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


        /*
         * Методы для создания столбцов в DataGridView разных видов, используя разные форматы для этих видов
         */
        DataGridViewTextBoxColumn CreateColumnID()
        {
            DataGridViewTextBoxColumn column = (new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "ID",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.LightGray
                }
            });
            return column;
        }
        DataGridViewTextBoxColumn CreateColumnText(string columnName, string columnHeader)
        {
            DataGridViewTextBoxColumn column = (new DataGridViewTextBoxColumn
            {
                Name = columnName,
                HeaderText = columnHeader,
            });
            return column;
        }
        DataGridViewTextBoxColumn CreateColumnText()
        {
            DataGridViewTextBoxColumn column = CreateColumnText("Name", "Название");
            column.Width = 250;
           return column;
        }
        DataGridViewComboBoxColumn CreateColumnCombobox(string columnName, string columnHeader, SimpleTable t)
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
        DataGridViewCheckBoxColumn CreateColumnCheckBox(string columnName, string columnHeader)
        {
            DataGridViewCheckBoxColumn column = (new DataGridViewCheckBoxColumn
            {
                Name = columnName,
                HeaderText = columnHeader,
                IndeterminateValue = false
            }); ;
            return column;
        }



        /*
         * Создание структуры DataGridView под данные из БД, и заполнение этими данными, 
         * колонки содержащие ID из других таблиц заменяются на соответсвующие им значения из им таблиц 
         * для корректной работы замещенные столбцы создаются с типом ComboBoxColumn, в качестве источника данных для таких столбцов 
         * используется класс SimpleTable 
         */
        private void ConstructDataGridView(DataGridView dataGridView, string TableName)
        {
            // создание структуры БД
                SqlCommand cmd = new SqlCommand($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{TableName}'", sqlConnection);
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
                dataGridView.Columns.Clear();
                var simpleTableCollection = new SimpleTable[lst.Count];
                foreach (var i in lst)
                {
                    switch (i)
                    {
                        case "ID":
                            { dataGridView.Columns.Add(CreateColumnID()); break; }
                        case "Name":
                            { dataGridView.Columns.Add(CreateColumnText()); break; }
                        default:
                        { 
                            if (i.Contains("ID"))
                            {
                               string x=i.TrimEnd(new Char[] { 'I', 'D' });
                                SimpleTable sourse = new SimpleTable(x);
                                dataGridView.Columns.Add(CreateColumnCombobox(i, x, sourse));
                                simpleTableCollection[dataGridView.Columns.Count - 1] = sourse;
                                
                            }
                            else if (i.StartsWith("Is"))
                            {
                                dataGridView.Columns.Add(CreateColumnCheckBox(i,i));
                            }
                            else
                            {
                                dataGridView.Columns.Add(CreateColumnText(i, i));

                            }
                            
                            
                            
                            break; 
                        }

                    }

                }

            // Заполнение созданной таблицы данными из БД
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM {TableName} ORDER BY ID", sqlConnection);
            //try
            //{

                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    List<string> parametrs = new List<string>();
                    for (int i = 0; i < dataGridView.ColumnCount; i++)
                    {
                        if (dataGridView.Columns[i].Name.Contains("ID") && (dataGridView.Columns[i].Name != "ID"))
                        {
                            int indexID =  simpleTableCollection[i].Items.FindIndex(x => x.Id == sqlReader[dataGridView.Columns[i].Name].ToString());
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


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            sqlConnection.Close();

        }

        /*
       * Сохранение данных из DataGridView в БД,  
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
                            {
                                if (row.Cells[c].Value == null)
                                { row.Cells[c].Value = false; }
                            }
                            if (row.Cells[c].Value == null && c != 0)
                            {
                                MessageBox.Show("Обнаружены незаполненные ячейки");
                                return false;
                            }
                            else if (row.Cells[c].Value == null)
                            {
                                values.Add("");
                            }
                            else if (dgEditDB.Columns[c].GetType() == new DataGridViewComboBoxColumn().GetType())
                            {
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
                    command = new SqlCommand($@"DELETE FROM {TableName}  
                                                            WHERE ID={id}",
                                                        sqlConnection);

                    sqlReader = command.ExecuteReader();
                    sqlReader.Close();
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

        public Form1()
        {
            InitializeComponent();
            dgEditDB.AutoGenerateColumns = false;
            // Загрузка списка доступных для редактирования таблиц в БД 
            {
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
        }
        //закгрузка окна
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        // Закрытие окна
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //кнопка открытие выбранной таблицы из БД 
        private  void OpenTableButton_Click(object sender, EventArgs e)
        {
            string tableToEdit = cbTableToEdit.SelectedItem.ToString();
            ConstructDataGridView(dgEditDB, tableToEdit);
            saveTableButton.Enabled = false;
            cbTableToEdit.Enabled = true;
            openTableButton.Text = "Открыть";
        }
        
        //кнопка сохранение изменений DataGridView dgEditDB в БД
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

        //обнаружены изменения в DataGridView dgEditDB 
        private void DgEditDB_CurrentCellChanged(object sender, EventArgs e)
        {
            saveTableButton.Enabled = true;
            cbTableToEdit.Enabled = false;
            openTableButton.Text = "Отмена";
        }


        /*
         * Методы для создания SQL команд 
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













































        private void Button1_Click(object sender, EventArgs e)
        {
            BankFill();
        }

        private async void BankFill()
        {
            bankCB.Items.Clear();
            await sqlConnection.OpenAsync();

            sqlReader = null;
            command = new SqlCommand(@"SELECT Name 
                                                  FROM Bank
                                                  ORDER BY ID",
                                                  sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    bankCB.Items.Add(sqlReader["Name"]);
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
            try
            {
                bankCB.SelectedIndex = 0;
            }
            catch { }
        }

        private async void DevisionFill(string bankName)
        {
            devisionCB.Items.Clear();
            await sqlConnection.OpenAsync();

            sqlReader = null;
            command = new SqlCommand($@"SELECT bd.Name
                                                   FROM BankDevision as bd
                                                   JOIN Bank as b ON b.ID=bd.BankID
                                                   WHERE b.Name='{bankName}'",
                                                   sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    devisionCB.Items.Add(sqlReader["Name"]);
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
            try
            {
                devisionCB.SelectedIndex = 0;
            }
            catch { }
        }

        private void BankCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevisionFill(bankCB.Text.ToString());
        }
    }
}