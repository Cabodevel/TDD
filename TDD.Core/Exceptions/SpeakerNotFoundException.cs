using System;

namespace TDD.Core.Exceptions
{
    public class SpeakerNotFoundException : Exception
    {
        public SpeakerNotFoundException() : base("Speaker Not Found")
        {
        }
    }
}
