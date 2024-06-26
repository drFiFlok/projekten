using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using System.Data.Common;

namespace Projekten
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        readonly static string stdConnection = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        int id;
       
      
        private void frmMain_Load(object sender, EventArgs e)
        {
            InitButtons();
            ReadData();
        }
        private void ReadData()
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(stdConnection))
                {
                    mySqlConnection.Open();
                    MySqlDataAdapter msda = new MySqlDataAdapter("BC_Get_All", mySqlConnection);
                    msda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    msda.Fill(dt);
                    dataGridView.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can't connect to the database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

       
        private void SaveUpdate()
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(stdConnection))
                {
                    mySqlConnection.Open();
                    MySqlCommand sqlCommand = new MySqlCommand("BC_Add_Update", mySqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("_id", id); 
                    sqlCommand.Parameters.AddWithValue("_Company", txtCompany.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("_FirstName", txtFirstname.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("_LastName", txtLastname.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("_Title", txtTitle.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("_Email", txtEmail.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("_Website", txtWebsite.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("_WorkPhone", txtWorkphone.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("_Mobilephone", txtMobilephone.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("_Address", txtAddress.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("_Zipcode", txtZipcode.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("_City", txtCity.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("_Country", txtCountry.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("_Comments", txtComments.Text.Trim());

                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't connect to the database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(ex.Message);
                this.Close(); 
            }
        }


        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = true;
            DataGridToTextBox();
        }
        private void DataGridToTextBox()
        {
            txtID.Text = dataGridView.CurrentRow.Cells["id"].Value.ToString();
            id = Int32.Parse(txtID.Text);

            txtCompany.Text = dataGridView.CurrentRow.Cells["Company"].Value.ToString();
            txtFirstname.Text = dataGridView.CurrentRow.Cells["Firstname"].Value.ToString();
            txtLastname.Text = dataGridView.CurrentRow.Cells["Lastname"].Value.ToString();
            txtTitle.Text = dataGridView.CurrentRow.Cells["Title"].Value.ToString();
            txtEmail.Text = dataGridView.CurrentRow.Cells["Email"].Value.ToString();
            txtWebsite.Text = dataGridView.CurrentRow.Cells["Website"].Value.ToString();
            txtWorkphone.Text = dataGridView.CurrentRow.Cells["Workphone"].Value.ToString();
            txtMobilephone.Text = dataGridView.CurrentRow.Cells["Mobilephone"].Value.ToString();
            txtAddress.Text = dataGridView.CurrentRow.Cells["Address"].Value.ToString();
            txtZipcode.Text = dataGridView.CurrentRow.Cells["Zipcode"].Value.ToString();
            txtCity.Text = dataGridView.CurrentRow.Cells["City"].Value.ToString();
            txtCountry.Text = dataGridView.CurrentRow.Cells["Country"].Value.ToString();
            txtComments.Text = dataGridView.CurrentRow.Cells["Comments"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SaveUpdate();
            clearTextboxes();
            MessageBox.Show("Record is updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReadData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            id = 0;
            txtID.Text = "0";
            clearTextboxes();
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUpdate();
            clearTextboxes();
            ReadData();
            MessageBox.Show("Record is saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearTextboxes();
            InitButtons();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure", "Leave Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
        private void clearTextboxes()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = string.Empty;
            }
        }
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(stdConnection))
            {
                mySqlConnection.Open();
                MySqlDataAdapter msda = new MySqlDataAdapter("BC_Search", mySqlConnection);
                msda.SelectCommand.CommandType = CommandType.StoredProcedure;
                msda.SelectCommand.Parameters.AddWithValue("_SearchValue", txtSearch.Text);
                DataTable dt = new DataTable();
                msda.Fill(dt);
                dataGridView.DataSource = dt;
            }

        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete this record?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                {
                    try
                    {
                        using (MySqlConnection mySqlConnection = new MySqlConnection(stdConnection))
                        {
                            mySqlConnection.Open();
                            MySqlCommand sqlCommand = new MySqlCommand("BC_Delete", mySqlConnection);
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            sqlCommand.Parameters.AddWithValue("_id", id);
                            sqlCommand.ExecuteNonQuery();
                            clearTextboxes();
                            InitButtons();
                            ReadData();
                            MessageBox.Show("Record is deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can't connect to the database", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        
        }
        private void InitButtons()
        {
            btnNew.Enabled = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

    }
}
