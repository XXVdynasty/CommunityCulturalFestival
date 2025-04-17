namespace CommunityCulturalFestival
{
    public class Participant
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Fee { get; set; }
        public string ContactInfo { get; set; }  // 👈 NEW!

        public Participant(string name, string category, decimal fee, string contactInfo)
        {
            Name = name;
            Category = category;
            Fee = fee;
            ContactInfo = contactInfo;
        }
    }
}

