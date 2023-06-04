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
    public partial class portal : MetroFramework.Forms.MetroForm
    {
        string num;
        public portal()
        {
            InitializeComponent();

            RefreshStudent();
        }

        private void portal_Load(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                num = dataGridView3.Rows[e.RowIndex].Cells["number"].Value.ToString();
            }
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            AddStudent a = new AddStudent(this);
            a.ShowDialog();
        }

        private void metroTabPage4_Click(object sender, EventArgs e)
        {

        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.FullName, "Database1.mdf") + ";Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            conn.Open();
            try
            {
                String match = "DELETE FROM Student WHERE number = @number";
                SqlCommand cmd = new SqlCommand(match, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@number", SqlDbType.VarChar).Value = num;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted");
            }
            catch
            {
                MessageBox.Show("Failed");
            }
            finally
            {
                conn.Close();
            }
            RefreshStudent();
        }

        public void RefreshStudent()
        {
            string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.Combine(Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.FullName, "Database1.mdf") + ";Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            conn.Open();
            string data = "SELECT * FROM Student";
            SqlCommand cmd = new SqlCommand(data, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            dataGridView3.DataSource = dt;
            conn.Close();
        }

        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            RefreshStudent();
        }
    }
}
