using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CommunityCulturalFestival
{
    public partial class Form1 : Form
    {
        private FestivalManager manager = new FestivalManager();

        public Form1()
        {
            InitializeComponent();

            // Background color - rich black to give depth
            this.BackColor = Color.FromArgb(25, 25, 25);

            // ComboBox items
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

            // Style buttons with Afro-Caribbean flavor
            StyleButton(btnRegister, Color.DarkRed);
            StyleButton(btnViewAll, Color.DarkGreen);
            StyleButton(btnSearch, Color.Goldenrod);
            StyleButton(btnSummary, Color.Teal);

            // ToolTips for accessibility
            ToolTip tips = new ToolTip();
            tips.SetToolTip(txtName, "Enter participant's full name.");
            tips.SetToolTip(cmbCategory, "Select a cultural category.");
            tips.SetToolTip(txtContact, "Enter email or phone number.");
            tips.SetToolTip(btnRegister, "Register participant.");
            tips.SetToolTip(btnViewAll, "Show all registered participants.");
            tips.SetToolTip(btnSearch, "Search for a participant by name.");
            tips.SetToolTip(btnSummary, "View total collected fees.");

            this.AcceptButton = btnRegister; // Pressing Enter triggers register
        }

        private void StyleButton(Button btn, Color backColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string category = cmbCategory.SelectedItem?.ToString();
                string contact = txtContact.Text;
                decimal fee = CalculateFee(category);

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(contact))
                {
                    throw new ArgumentException("All fields are required.");
                }

                if (fee < 0)
                {
                    throw new ArgumentOutOfRangeException("Fee cannot be negative.");
                }

                manager.AddParticipant(new Participant(name, category, fee, contact));
                MessageBox.Show("Participant registered successfully!");
                ClearForm();

                // Visual feedback
                HighlightInputs();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Input Error: {ex.Message}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please ensure all entries are valid.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error: " + ex.Message);
            }
        }

        private void HighlightInputs()
        {
            txtName.BackColor = Color.LightGreen;
            txtContact.BackColor = Color.LightGreen;
            cmbCategory.BackColor = Color.LightGreen;

            var timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {
                txtName.BackColor = SystemColors.Window;
                txtContact.BackColor = SystemColors.Window;
                cmbCategory.BackColor = SystemColors.Window;
                timer.Stop();
            };
            timer.Start();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            try
            {
                lstParticipants.Items.Clear();
                foreach (var p in manager.GetAllParticipants())
                {
                    lstParticipants.Items.Add($"{p.Name} - {p.Category} - ${p.Fee} - {p.ContactInfo}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing participants: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearchName.Text.Trim();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    MessageBox.Show("Please enter a name to search.");
                    return;
                }

                var results = manager.SearchByName(keyword);
                lstParticipants.Items.Clear();

                if (results.Count > 0)
                {
                    foreach (var p in results)
                    {
                        lstParticipants.Items.Add($"{p.Name} - {p.Category} - ${p.Fee} - {p.ContactInfo}");
                    }
                }
                else
                {
                    MessageBox.Show("No participants found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            try
            {
                decimal totalFees = manager.CalculateTotalFees();
                MessageBox.Show($"Total revenue collected: ${totalFees}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fee calculation error: " + ex.Message);
            }
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
        private void ClearForm()
        {
            txtName.Clear();
            txtContact.Clear();
            cmbCategory.SelectedIndex = -1;
            txtSearchName.Clear();
        }
    }
}
