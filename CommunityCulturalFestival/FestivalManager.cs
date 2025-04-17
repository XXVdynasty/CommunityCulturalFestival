using System;
using System.Collections.Generic;
using System.Linq;

namespace CommunityCulturalFestival
{
    public class FestivalManager
    {
        private List<Participant> participants = new List<Participant>();

        public void AddParticipant(Participant p)
        {
            participants.Add(p);
        }

        public List<Participant> GetAllParticipants()
        {
            return participants;
        }

        public List<Participant> SearchByName(string name)
        {
            return participants
                .Where(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        public decimal CalculateTotalFees()
        {
            return participants.Sum(p => p.Fee);
        }

        public bool HasHigherParticipation(int currentCount, int previousYearCount)
        {
            return currentCount > previousYearCount;
        }

        public bool HasLowerParticipation(int currentCount, int previousYearCount)
        {
            return currentCount < previousYearCount;
        }
    }
}
