using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;

namespace presentationLayer
{
    public partial class Start : Form
    {
        CustomerDataContext cdx = new CustomerDataContext();
        int cutId;
        public Start()
        {
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {

            updateScreen();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
            cutId = (Int32)dataGridView1.SelectedRows[0].Cells[0].Value;
            customeredit edit = new customeredit(cutId);
            edit.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
            cutId = (Int32)dataGridView1.SelectedRows[0].Cells[0].Value;
            custaddresses addEdit = new custaddresses(cutId);
            addEdit.Show();
            this.Hide();
        }

        private void updateScreen()
        {
            CustomerDataContext cdx = new CustomerDataContext();
            dataGridView1.DataSource = cdx.Customers.Join(cdx.Addresses, cId => cId.CustomerId, addId => addId.Customer.CustomerId,
                (cId, addId) => new
                {
                    cId.CustomerId,
                    cId.Firstname,
                    cId.Lastname,
                    addId.Street,
                    addId.City,
                    addId.State,
                    addId.Zip
                }
                ).ToList().AsReadOnly();
            dataGridView1.Columns[0].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateScreen();
        }
    }
}
