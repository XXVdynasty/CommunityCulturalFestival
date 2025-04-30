namespace CommunityCulturalFestival
{
    public class ArtParticipant : Participant
    {
        public string ArtMedium { get; set; }
        public string DisplayDimensions { get; set; }

        public ArtParticipant(string name, string category, decimal fee, string contactInfo,
                              string artMedium, string displayDimensions)
            : base(name, category, fee, contactInfo)
        {
            ArtMedium = artMedium;
            DisplayDimensions = displayDimensions;
        }

        public string GetArtDescription()
        {
            return $"{ArtMedium} - Display Size: {DisplayDimensions}";
        }
    }
}
