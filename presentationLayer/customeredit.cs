using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DataLayer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace presentationLayer
{
    public partial class customeredit : Form
    {
        CustomerDataContext cdtx = new CustomerDataContext();
        int userId;
        public customeredit(int uId)
        {
            InitializeComponent();
            userId = uId;
            updateScreen();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var paramiters = new[]
            { new SqlParameter("upId", userId),
              new SqlParameter("firstname", textBox1.Text.ToString())
            };

            var test = cdtx.Database.ExecuteSqlRaw("EXECUTE dbo.updateFirstNamenotlast @upId, @firstname", paramiters);
            //cdtx.Customers.FromSqlRaw("EXECUTE dbo.updateFirstNamenotlast @upId, @firstname", paramiters).AsEnumerable().ToList();
            updateScreen();

        }
        private void updateScreen()
        {
            cdtx = new CustomerDataContext();
            dataGridView1.DataSource = cdtx.Customers.Where(c => c.CustomerId == userId).ToList().AsReadOnly();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
        }

        private void customeredit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Start home = new Start();
            home.Show();
        }
    }
}
