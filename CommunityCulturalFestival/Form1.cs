using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CommunityCulturalFestival
{
    public partial class Form1 : Form
    {
        private FestivalManager manager = new FestivalManager();

        public Form1()
        {
            InitializeComponent();

            cmbCategory.Items.AddRange(new string[]
            {
                "African Drumming",
                "Caribbean Dance",
                "Indigenous Storytelling",
                "Spoken Word",
                "Culinary - Soul Food",
                "Visual Art",
                "Afro-Caribbean Fashion"
            });
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string category = cmbCategory.SelectedItem?.ToString();
                string contact = txtContact.Text;

                if (!ValidateInputs(name, category, contact))
                    return;

                decimal fee = CalculateFee(category);
                RegisterParticipant(name, category, contact, fee);
                MessageBox.Show("Participant registered successfully!");
                ClearForm();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Input Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Error: {ex.Message}");
            }
        }

        private bool ValidateInputs(string name, string category, string contact)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(contact))
            {
                MessageBox.Show("All fields are required.");
                return false;
            }
            return true;
        }

        private void RegisterParticipant(string name, string category, string contact, decimal fee)
        {
            manager.AddParticipant(new Participant(name, category, fee, contact));
        }

        private decimal CalculateFee(string category)
        {
            return category switch
            {
                "African Drumming" => 20m,
                "Caribbean Dance" => 25m,
                "Indigenous Storytelling" => 15m,
                "Spoken Word" => 10m,
                "Culinary - Soul Food" => 30m,
                "Visual Art" => 18m,
                "Afro-Caribbean Fashion" => 22m,
                _ => 0m
            };
        }

        // Overloaded method (might use) this if you want to display category and fee
        private decimal CalculateFee(string category, out string message)
        {
            decimal fee = CalculateFee(category);
            message = $"Calculated Fee for {category}: ${fee}";
            return fee;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtContact.Clear();
            cmbCategory.SelectedIndex = -1;
            txtSearchName.Clear();  // Ensure search box also resets if needed
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            lstParticipants.Items.Clear();
            foreach (var p in manager.GetAllParticipants())
            {
                lstParticipants.Items.Add($"{p.Name} - {p.Category} - ${p.Fee} - {p.ContactInfo}");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Bonus stats or summary
            decimal totalFees = manager.CalculateTotalFees();
            MessageBox.Show($"Total Festival Revenue: ${totalFees}");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchName.Text.Trim();
            lstParticipants.Items.Clear();

            var results = manager.SearchByName(keyword);
            if (results.Count == 0)
            {
                MessageBox.Show("No participants found.");
                return;
            }

            foreach (var p in results)
            {
                lstParticipants.Items.Add($"{p.Name} - {p.Category} - ${p.Fee} - {p.ContactInfo}");
            }
        }
    }
}
