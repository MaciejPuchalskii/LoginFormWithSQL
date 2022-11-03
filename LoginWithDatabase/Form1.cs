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

namespace LoginWithDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-QB3JKAQN;Initial Catalog=LoginApp;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            String username, user_password;
            username = loginTextBox.Text;
            user_password = passwordTextBox.Text;


            try
            {
                String querry = "SELECT * FROM Login_new WHERE username = '" + loginTextBox.Text + "' AND password ='" + passwordTextBox.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    username  = loginTextBox.Text;
                    user_password = passwordTextBox.Text;

                    Menuform form2 = new Menuform();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loginTextBox.Clear();
                    passwordTextBox.Clear();

                    loginTextBox.Focus();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid data");
            }
            finally
            {
                conn.Close();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            loginTextBox.Clear();
            passwordTextBox.Clear();

            loginTextBox.Focus();
        }
    }
}
