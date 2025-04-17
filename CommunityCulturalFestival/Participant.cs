namespace CommunityCulturalFestival
{
    public class Participant
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Fee { get; set; }

        public Participant(string name, string category, decimal fee)
        {
            Name = name;
            Category = category;
            Fee = fee;
        }
    }
}
