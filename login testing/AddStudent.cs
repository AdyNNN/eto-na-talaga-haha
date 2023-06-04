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

namespace login_testing
{
    public partial class AddStudent : Form
    {
        portal portal = new portal();
        public AddStudent(portal p)
        {
            InitializeComponent();
            portal = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.FullName, "Database1.mdf") + ";Integrated Security=True";
                SqlConnection conn = new SqlConnection(sql);
                conn.Open();
                try
                {
                    String match = "INSERT INTO Student (number, name) VALUES (@number, @name)";
                    SqlCommand cmd = new SqlCommand(match, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@number", SqlDbType.VarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = textBox2.Text;
                    cmd.ExecuteNonQuery();
                    portal.RefreshStudent();
                    MessageBox.Show("Added");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                catch
                {
                    MessageBox.Show("Failed");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
