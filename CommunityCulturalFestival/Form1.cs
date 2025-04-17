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
        private FestivalManager manager = new FestivalManager();

        public Form1()
        {
            InitializeComponent();

            // ✅ Add culturally responsive categories to ComboBox
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
                decimal fee = CalculateFee(category);

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(contact))
                {
                    throw new ArgumentException("All fields are required.");
                }

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
            // Optional feature placeholder
        }
    }
}
