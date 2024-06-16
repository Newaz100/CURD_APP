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

namespace CRUD_APP
{
    public partial class Crud : Form
    {
        public Crud()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-UV312E74;Initial Catalog=CRUD_db;Integrated Security=True;Pooling=False");


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CRUDTab values (@ID,@Name,@Age)", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Inserted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("$Error:{ex.Message}");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update CRUDTab set Name=@Name, Age=@Age where ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("$Error:{ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete CRUDTab where ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("$Error:{ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from CRUDTab", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
               

                con.Close();
                MessageBox.Show("Successfully Search");
            }
            catch (Exception ex)
            {
                MessageBox.Show("$Error:{ex.Message}");
            }
        }
    }
}
