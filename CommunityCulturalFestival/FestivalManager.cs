using System;
using System.Collections.Generic;
using System.Linq;

namespace CommunityCulturalFestival
{
    public class FestivalManager
    {
        private List<Participant> participants = new List<Participant>();

        // Adds a participant with duplicate check and registration validation
        public void AddParticipant(Participant participant)
        {
            if (participant != null && participant.IsValidRegistration())
            {
                bool isDuplicate = participants.Any(p =>
                    p.Name.Equals(participant.Name, StringComparison.OrdinalIgnoreCase) &&
                    p.ContactInfo.Equals(participant.ContactInfo, StringComparison.OrdinalIgnoreCase));

                if (!isDuplicate)
                {
                    participants.Add(participant);
                }
                else
                {
                    throw new ArgumentException("Participant already registered.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid participant data.");
            }
        }

        // Returns all participants unsorted
        public List<Participant> GetAllParticipants()
        {
            return participants;
        }

        // Returns participants sorted alphabetically by name
        public List<Participant> GetAllParticipantsSorted()
        {
            return participants.OrderBy(p => p.Name).ToList();
        }

        // Case-insensitive search
        public List<Participant> SearchByName(string name)
        {
            return participants
                .Where(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        // Sums all registration fees
        public decimal CalculateTotalFees()
        {
            return participants.Sum(p => p.Fee);
        }
    }
}
