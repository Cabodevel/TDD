using System.Collections.Generic;
using System.Linq;
using TDD.Core.Entities;
using TDD.Core.Interfaces;

namespace TDD.Core.Services
{
    public class SpeakerService : ISpeakerService
    {
        public List<Speaker> HardCodedSpeakers { get => new List<Speaker>
            {
                new Speaker {Id = 1, Name = "Josh", Location = "Tampa, FL"},
                new Speaker {Id = 2, Name = "Joshua", Location = "Louisville, KY"},
                new Speaker {Id = 3, Name = "Joseph", Location = "Las Vegas, NV"},
                new Speaker {Id = 4, Name = "Bill", Location = "New York, NY"},
            };
        }

        public SpeakerSummary Get(int v)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SpeakerSummary> GetAll()
        {
            return HardCodedSpeakers.Select(speaker => new SpeakerSummary()
            {
                Id = speaker.Id,
                Name = speaker.Name,
                Location = speaker.Location,
            });
        }
    }
}
