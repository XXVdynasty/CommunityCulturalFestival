using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CommunityCulturalFestival
{
    public partial class Form1 : Form
    {
        private FestivalManager manager = new FestivalManager();

        public Form1()
        {
            InitializeComponent();

            // Populate culturally responsive categories
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

        // Register participant
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string category = cmbCategory.SelectedItem?.ToString();
                string contact = txtContact.Text;

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(contact))
                {
                    throw new ArgumentException("All fields are required.");
                }

                decimal fee = CalculateFee(category);

                manager.AddParticipant(new Participant(name, category, fee, contact));
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

        // View all participants
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            lstParticipants.Items.Clear();
            foreach (var p in manager.GetAllParticipants())
            {
                lstParticipants.Items.Add($"{p.Name} - {p.Category} - ${p.Fee} - {p.ContactInfo}");
            }

            // Show total revenue
            decimal total = manager.CalculateTotalFees();
            lstParticipants.Items.Add($"-----------------------------");
            lstParticipants.Items.Add($"Total Fees Collected: ${total}");
        }

        // Search participant by name
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtSearchName.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchName))
            {
                MessageBox.Show("Please enter a name to search.");
                return;
            }

            var result = manager.FindParticipant(searchName);
            lstParticipants.Items.Clear();

            if (result != null)
            {
                lstParticipants.Items.Add($"Found: {result.Name} - {result.Category} - ${result.Fee} - {result.ContactInfo}");
            }
            else
            {
                lstParticipants.Items.Add("Participant not found.");
            }
        }

        // Clear form fields
        private void ClearForm()
        {
            txtName.Clear();
            txtContact.Clear();
            cmbCategory.SelectedIndex = -1;
        }

        // Determine registration fee
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

        // Optional placeholder
        private void button1_Click(object sender, EventArgs e)
        {
            // Reserved for bonus or summary stats
        }
    }
}
