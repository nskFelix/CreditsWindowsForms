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
        SqlDataAdapter dataAdapter;
        SqlCommand command = null;
        SimpleTable banks = new SimpleTable("Bank");
        SimpleTable BankDevisions = new SimpleTable("BankDevision");
        SimpleTable registrationMethods = new SimpleTable("RegistrationMethod");


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
            private List<SimpleRow> items = new List<SimpleRow>();
            private List<string> iDs = new List<string>();
            private List<string> names = new List<string>();
            private string tableBD;

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

        public void UpdateSimpleTables()
        {
            foreach (SimpleTable i in SimpleTable.Objects)
            {
                i.Update();
            }
        }

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

        DataGridViewTextBoxColumn CreateColumnName()
        {
            DataGridViewTextBoxColumn column = (new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Название",
                Width = 250
            });
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

        public Form1()
        {
            InitializeComponent();
            cbTableToEdit.SelectedIndex = 0;
            dgEditDB.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BankFill();
        }


        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //кнопка открытие выбранной таблицы из БД 
        private  void OpenTableButton_Click(object sender, EventArgs e)
        {
            string tableToEdit = cbTableToEdit.SelectedItem.ToString();
            
            switch (tableToEdit)
            {
                case "Банки":
                    { LoadBanksTodgEditDB(); break; }
                case "Филиалы банков":
                    { LoadBankDevisionTodgEditDB(); break; }
                default: break;
            }
            saveTableButton.Enabled = false;
            cbTableToEdit.Enabled = true;
            openTableButton.Text = "Открыть";
        }
        
        //кнопка сохранение изменений DataGridView dgEditDB в БД
        private void SaveTableButton_Click(object sender, EventArgs e)
        {
            string tableToEdit = cbTableToEdit.SelectedItem.ToString();
            bool saved = false;
            switch (tableToEdit)
            {
                case "Банки":
                    { saved = SaveBankFromdgEditDB(); break; }
                case "Филиалы банков":
                    { saved = SaveBankDevisionFromdgEditDB(); break; }
                default: break;
            }
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

        //сохранение таблицы "Банки" в БД 
        private bool SaveBankFromdgEditDB()
        {
            try
            {
                banks.Update();
                sqlConnection.Open();
                sqlReader = null;
                command=null;

                //Получение индеков, которые были в базе до сохранения
                List<string> baseID = banks.IDs;              


           //перенос данных из DataGridView в БД
                foreach (DataGridViewRow i in dgEditDB.Rows)
                {
                    if (!i.IsNewRow)
                    {
                        string id="";
                        
                        if (i.Cells[0].Value!=null)
                        id = i.Cells[0].Value.ToString(); 

                        string name = i.Cells[1].Value.ToString();


                        if (baseID.Contains(id))
                        {
                            command = new SqlCommand($@"UPDATE Bank SET Name='{name}' WHERE ID={id}", sqlConnection);
                            baseID.Remove(id);
                        }
                        else
                        {
                            command = new SqlCommand($@"INSERT INTO Bank VALUES ('{name}')", sqlConnection);
                        }
                        sqlReader = command.ExecuteReader();
                        sqlReader.Close();
                }
            }

           //Удаление строк найденых в БД, но отсутствующих в DataGridView
                foreach (string id in baseID)
                {
                        command = new SqlCommand($@"DELETE FROM Bank  
                                                            WHERE ID={id}",
                                                            sqlConnection);
                        
                        sqlReader = command.ExecuteReader();
                        sqlReader.Close();
                }

               
                sqlConnection.Close();
                LoadBanksTodgEditDB();
                banks.Update();
                return true;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //сохранение таблицы "Банки" в БД 
        private bool SaveBankDevisionFromdgEditDB()
        {
            try
            {
                UpdateSimpleTables();
                sqlConnection.Open();
                sqlReader = null;
                command = null;

                //Получение индеков, которые были в базе до сохранения
                List<string> baseID = BankDevisions.IDs;


                //перенос данных из DataGridView в БД
                foreach (DataGridViewRow i in dgEditDB.Rows)
                {
                    if (!i.IsNewRow)
                    {
                        string id = "";
                        if (i.Cells[0].Value != null)
                            id = i.Cells[0].Value.ToString();

                        string name = i.Cells[1].Value.ToString();

                        string bankID = "";
                        if (i.Cells[2].Value != null)
                            foreach (var b in banks.Items)
                            {
                            if (i.Cells[2].Value.ToString() == b.Name) bankID = b.Id;
                            }

                        string registrationMethodID = "";
                        if (i.Cells[3].Value != null)
                            foreach (var r in registrationMethods.Items)
                            {
                                if (i.Cells[3].Value.ToString() == r.Name) registrationMethodID = r.Id;
                            }

                        if (baseID.Contains(id))
                        {
                            command = new SqlCommand($@"UPDATE BankDevision SET Name = '{name}', BankID = '{bankID}', RegistrationMethodID = '{registrationMethodID}' WHERE ID={id}", sqlConnection);
                            baseID.Remove(id);
                        }
                        else
                        {
                            command = new SqlCommand($@"INSERT INTO BankDevision VALUES ('{name}','{bankID}','{registrationMethodID}')", sqlConnection);
                        }
                        sqlReader = command.ExecuteReader();
                        sqlReader.Close();
                    }
                }

                //Удаление строк найденых в БД, но отсутствующих в DataGridView
                foreach (string id in baseID)
                {
                    command = new SqlCommand($@"DELETE FROM BankDevision  
                                                            WHERE ID={id}",
                                                        sqlConnection);

                    sqlReader = command.ExecuteReader();
                    sqlReader.Close();
                }


                sqlConnection.Close();
                LoadBankDevisionTodgEditDB();
                BankDevisions.Update();
                return true;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }








        //настройка столбцов DataGridView dgEditDB под ограничения таблицы "Банки" и заполнение этой таблицы данными из БД 
        private void LoadBanksTodgEditDB()
        {
            //создание столбцов таблицы
            dgEditDB.Columns.Clear();

            dgEditDB.Columns.Add(CreateColumnID());

            dgEditDB.Columns.Add(CreateColumnName());

            sqlConnection.Open();
            command = new SqlCommand($@"SELECT b.ID as {dgEditDB.Columns[0].Name}, 
                                               b.Name as {dgEditDB.Columns[1].Name} 
                                        FROM Bank as b ORDER BY b.ID", sqlConnection);
            try
            {
                sqlReader = command.ExecuteReader();
                int i = 0;
                while (sqlReader.Read())
                {
                      dgEditDB.Rows.Add(
                            sqlReader[dgEditDB.Columns[0].Name],
                            sqlReader[dgEditDB.Columns[1].Name]);
                }
                sqlReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sqlConnection.Close();
        }


        //настройка столбцов DataGridView dgEditDB под ограничения таблицы "Филиалы банков" и заполнение этой таблицы данными из БД 
        private void LoadBankDevisionTodgEditDB()
        {
            UpdateSimpleTables();

            //создание столбцов таблицы
            dgEditDB.Columns.Clear();

            dgEditDB.Columns.Add(CreateColumnID());

            dgEditDB.Columns.Add(CreateColumnName());

            dgEditDB.Columns.Add(CreateColumnCombobox("BankName","Назание Банка", banks));

            dgEditDB.Columns.Add(CreateColumnCombobox("RegistrationMethodsName","Метод ввода", registrationMethods));

            sqlConnection.Open();
            command = new SqlCommand($@"SELECT bd.ID as {dgEditDB.Columns[0].Name}, 
                                               bd.Name as {dgEditDB.Columns[1].Name}, 
                                               b.Name as {dgEditDB.Columns[2].Name}, 
                                               reg.Name as {dgEditDB.Columns[3].Name}
                                       FROM BankDevision as bd
                                       JOIN Bank as b ON bd.BankID=b.ID
                                       JOIN RegistrationMethod as reg on bd.RegistrationMethodID = reg.ID", sqlConnection);
            try
            {
                sqlReader = command.ExecuteReader();
                int i = 0;
                while (sqlReader.Read())
                {
                    dgEditDB.Rows.Add(
                        sqlReader[dgEditDB.Columns[0].Name], 
                        sqlReader[dgEditDB.Columns[1].Name],
                        sqlReader[dgEditDB.Columns[2].Name], 
                        sqlReader[dgEditDB.Columns[3].Name]);
                }
                sqlReader.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sqlConnection.Close();
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