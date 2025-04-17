using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CommunityCulturalFestival
{
    public partial class Form1 : Form
    {
        private FestivalManager manager = new FestivalManager();  // ✅ New Manager

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string category = cmbCategory.SelectedItem?.ToString();
            string contact = txtContact.Text;  // ✅ New field
            decimal fee = CalculateFee(category);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(contact))
            {
                MessageBox.Show("Please enter all required fields.");
                return;
            }

            manager.AddParticipant(new Participant(name, category, fee, contact));  // ✅ Updated constructor
            MessageBox.Show("Participant registered successfully!");
            ClearForm();
        }

        private decimal CalculateFee(string category)
        {
            return category switch
            {
                "Music" => 20m,
                "Dance" => 15m,
                "Art" => 10m,
                "Culinary" => 25m,
                _ => 0m
            };
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtContact.Clear();  // ✅ Clear contact too
            cmbCategory.SelectedIndex = -1;
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            lstParticipants.Items.Clear();
            foreach (var p in manager.GetAllParticipants())  // ✅ Use manager’s list
            {
                lstParticipants.Items.Add($"{p.Name} - {p.Category} - ${p.Fee} - {p.ContactInfo}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Optional feature button placeholder
        }
    }
}
