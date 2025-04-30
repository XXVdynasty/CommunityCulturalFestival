using System.Linq;

namespace CommunityCulturalFestival
{
    public class Participant
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Fee { get; set; }
        public string ContactInfo { get; set; }

        public Participant(string name, string category, decimal fee, string contactInfo)
        {
            Name = name;
            Category = category;
            Fee = fee;
            ContactInfo = contactInfo;
        }

        public bool IsValidRegistration()
        {
            bool hasValidContact =
                ContactInfo.Contains("@") ||                    // checks for email
                ContactInfo.All(char.IsDigit) ||                // If allll digits its likely a phone number
                ContactInfo.Any(char.IsDigit) &&                // At least has digits and
                ContactInfo.Replace("-", "").Replace(" ", "").All(char.IsDigit); // Accepts dashes/spaces in numbers

            return !string.IsNullOrWhiteSpace(Name)
                && !string.IsNullOrWhiteSpace(Category)
                && !string.IsNullOrWhiteSpace(ContactInfo)
                && Fee >= 0
                && hasValidContact;
        }
    }
}
