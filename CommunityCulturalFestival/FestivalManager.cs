using System;
using System.Collections.Generic;
using System.Linq;

namespace CommunityCulturalFestival
{
    public class FestivalManager
    {
        private List<Participant> participants = new List<Participant>();

        public void AddParticipant(Participant participant)
        {
            if (participant != null && participant.IsValidRegistration())
            {
                participants.Add(participant);
            }
            else
            {
                throw new ArgumentException("Invalid participant data.");
            }
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
        }  }
}
