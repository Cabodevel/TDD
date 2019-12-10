using System.Collections.Generic;
using TDD.Core.Entities;

namespace TDD.Core.Interfaces
{
    public interface ISpeakerService
    {
        List<Speaker> HardCodedSpeakers { get; }

        IEnumerable<SpeakerSummary> GetAll();
        SpeakerSummary Get(int v);
    }
}
