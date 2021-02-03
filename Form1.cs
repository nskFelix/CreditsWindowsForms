using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CreditsWindowsForms
{
    public partial class Form1 : Form
    {
        public static string conncetionString = @"Data Source=WORKNOTEBOOK\SQLEXPRESS;Initial Catalog=Credits;Integrated Security=True";
        public SqlConnection sqlConnection = new SqlConnection(conncetionString);

        public Form1()
        {
            InitializeComponent();
            cbTableToEdit.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BankFill();
        }


        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //открытие выбранной таблицы из БД 
        private  void OpenTableButton_Click(object sender, EventArgs e)
        {
            string tableToEdit = cbTableToEdit.SelectedItem.ToString();
            
            switch (tableToEdit)
            {
                case "Банки":
                    { LoadBanksTodgEditDB(); break; }
                default: break;
            }
            saveTableButton.Enabled = false;
            cbTableToEdit.Enabled = true;
            openTableButton.Text = "Открыть";
        }
        
        //Сохранение изменений DataGridView dgEditDB в БД
        private void SaveTableButton_Click(object sender, EventArgs e)
        {
            string tableToEdit = cbTableToEdit.SelectedItem.ToString();
            bool saved = false;
            switch (tableToEdit)
            {
                case "Банки":
                    { saved = SaveBankFromdgEditDB(); break; }
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
                sqlConnection.Open();
                SqlDataReader sqlReader = null;
                SqlCommand command=null;

                //Получение индеков, которые были в базе до сохранения
                    List<string> baseID = new List<string>();
                    command = new SqlCommand(@"SELECT BankID FROM Bank", sqlConnection);
                    sqlReader = command.ExecuteReader();
                    while (sqlReader.Read()) { baseID.Add(sqlReader["BankID"].ToString()); }
                    sqlReader.Close();


           //перенос данных из DataGridView в БД
                foreach (DataGridViewRow i in dgEditDB.Rows)
                {
                    if (!i.IsNewRow)
                    {
                        
                        string id = i.Cells[0].Value.ToString();
                        string name = i.Cells[1].Value.ToString();

                        if (baseID.Contains(id))
                        {
                            command = new SqlCommand($@"UPDATE Bank SET Name='{name}' WHERE BankID={id}", sqlConnection);
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
                                                            WHERE BankID={id}",
                                                            sqlConnection);
                        
                        sqlReader = command.ExecuteReader();
                        sqlReader.Close();
                }

               
                sqlConnection.Close();
                LoadBanksTodgEditDB();
                return true;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //загрузка таблицы "Банки" из БД и настройка столбцов DataGridView dgEditDB под ограничения этой таблицы 
        private  void LoadBanksTodgEditDB()
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(@"SELECT * 
                                                  FROM Bank
                                                  ORDER BY BankID",
                                                  sqlConnection);
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dgEditDB.DataSource = ds.Tables[0];
                dgEditDB.Columns[0].ReadOnly = true;
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

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand(@"SELECT Name 
                                                  FROM Bank
                                                  ORDER BY BankID",
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

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand($@"SELECT bd.Name
                                                   FROM BankDevision as bd
                                                   JOIN Bank as b ON b.BankID=bd.BankID
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