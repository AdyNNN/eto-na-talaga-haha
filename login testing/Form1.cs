using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace login_testing
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void login_Click_1(object sender, EventArgs e)
        {
            string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.FullName, "Database1.mdf") + ";Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            conn.Open();
            String match = "SELECT * FROM PersonTable";
            SqlCommand cmd = new SqlCommand(match, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string user = reader["username"].ToString();
            string pass = reader["password"].ToString();
            string inputUsername = metroTextBoxUsername.Text;
            string inputPassword = metroTextBoxPassword.Text;
            if (user == inputUsername && pass == inputPassword)
            {
                portal f = new portal();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username/password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                metroTextBoxUsername.Text = "";
                metroTextBoxPassword.Text = "";
            }
            conn.Close();
        }
    }
}
