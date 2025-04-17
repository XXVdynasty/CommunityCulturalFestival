using System;
using System.Collections.Generic;
using System.Linq;

namespace CommunityCulturalFestival
{
    public class FestivalManager
    {
        public string FestivalName { get; set; } = "Community Cultural Festival";
        public int Year { get; set; } = DateTime.Now.Year;

        private List<Participant> participants = new List<Participant>();

        public void AddParticipant(Participant p)
        {
            participants.Add(p);
        }

        public Participant FindParticipant(string name)
        {
            return participants.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public decimal CalculateTotalFees()
        {
            return participants.Sum(p => p.Fee);
        }

        public List<Participant> GetAllParticipants()
        {
            return participants;
        }
    }
}
