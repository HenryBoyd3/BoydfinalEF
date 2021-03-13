using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DataLayer;

namespace presentationLayer
{
    public partial class custaddresses : Form
    {
        CustomerDataContext cdtx = new CustomerDataContext();
        int userId;
        
        public custaddresses(int uId)
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
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
            var newUser = cdtx.Addresses.First(c => c.CustomerId == userId);
            var thisUser = dataGridView1.SelectedRows;
            foreach (DataGridViewRow cell in thisUser)
            {
                if (string.IsNullOrEmpty(streetBox1.Text.ToString())) {}
                else { newUser.Street = streetBox1.Text.ToString(); }
                if (string.IsNullOrEmpty(cityBox.Text.ToString())) {}
                else { newUser.City = cityBox.Text.ToString(); }
                if (string.IsNullOrEmpty(stateBox.Text.ToString())) {}
                else { newUser.State = stateBox.Text.ToString(); }
                if (string.IsNullOrEmpty(zipBox.Text.ToString())) {}
                else { newUser.Zip = zipBox.Text.ToString(); }

            }
            cdtx.SaveChanges();
            updateScreen();
        }
        private void updateScreen()
        {
                dataGridView1.DataSource = cdtx.Addresses.OrderBy(a => a.CustomerId == userId).ToList().Join
                (cdtx.Customers, cId => cId.CustomerId, addId => addId.CustomerId, (addId, cId) => new
                {
                    cId.CustomerId,
                    cId.Firstname,
                    cId.Lastname,
                    addId.Street,
                    addId.City,
                    addId.State,
                    addId.Zip
                }).Where(c => c.CustomerId == userId).ToList();
                dataGridView1.Columns[0].Visible = false;
        }

        private void custaddresses_FormClosed(object sender, FormClosedEventArgs e)
        {
            Start home = new Start();
            home.Show();
            
        }
    }
}
