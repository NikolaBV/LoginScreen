using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Logn_Form_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=KOKI;Initial Catalog=LoginWindowsFormsDataBase;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void login_click(object sender, EventArgs e)
        {
            string username, userPassword;
            username = txtUserName.Text;
            userPassword = txtPassword.Text;
            try
            {
                string query = "SELECT * FROM LoginCredentials WHERE username = '" + txtUserName.Text +"' AND password = '"+txtPassword.Text+"'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if(dataTable.Rows.Count > 0)
                {
                    username = txtUserName.Text;
                    userPassword = txtPassword.Text;
                    if(username != "Admin" && userPassword != "Admin")
                    {
                        Menu form2 = new Menu();
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MenuForAdmins menuForAdmins = new MenuForAdmins();
                        menuForAdmins.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid login credentials","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUserName.Clear();
                    txtUserName.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error loging in.");
            }
            finally
            {

            }
        }
    }
}
