using Moq;
using System.Collections.Generic;
using System.Linq;
using TDD.Controllers;
using TDD.Core.Interfaces;
using TDD.Core.Services;
using Xunit;

namespace TDD.Tests
{
    public class GetAll
    {
        private readonly List<SpeakerSummary> _speakers;
        private readonly ISpeakerService _speakerService;

        public GetAll(ISpeakerService speakerService)
        {
            //Arrange
            _speakers = new List<SpeakerSummary> { new SpeakerSummary
            {
                Name = "test"
            } };
            _speakerService = speakerService;
        }

        [Fact]
        public void ItHasGetAllMethod()
        {
            var speakerService = new SpeakerService();
            speakerService.GetAll();
        }

        [Fact]
        public void GivenSpeakerServiceThenResultsReturned()
        {
            // Arrange
            var speakers = new List<SpeakerSummary> {
                new SpeakerSummary
                {
                    Name = "Speaker"
                } 
            };

            // Assert
            Assert.Equal(_speakers, speakers);
        }

        [Fact]
        public void ItReturnsCollectionOfSpeakerSummary()
        {
            // Arrange
            // Act
            var speakers = _speakerService.GetAll();
            // Assert
            Assert.NotNull(speakers);
            Assert.IsAssignableFrom<IEnumerable<SpeakerSummary>>(speakers);
        }

        [Fact]
        public void ItReturnsAllSpeakers()
        {
            // Arrange
            // Act
            var speakers = _speakerService.GetAll();
            // Assert
            Assert.NotNull(speakers);
            Assert.IsAssignableFrom<IEnumerable<SpeakerSummary>>(speakers);
            Assert.Equal(_speakerService.HardCodedSpeakers.Count, speakers.Count());
        }

        [Fact]
        public void ItReturnsAllSpeakersWithProperties()
        {
            // Arrange
            // Act
            var speakers = _speakerService.GetAll().ToList();
            // Assert
            Assert.NotNull(speakers);
            Assert.IsAssignableFrom<IEnumerable<SpeakerSummary>>(speakers);
            for (var i = 0; i < speakers.Count; i++)
            {
                Assert.NotNull(_speakerService.HardCodedSpeakers[i].Name);
                Assert.Equal(_speakerService.HardCodedSpeakers[i].Name, speakers[i].Name);
                Assert.Equal(_speakerService.HardCodedSpeakers[i].Id, speakers[i].Id);
                Assert.NotNull(_speakerService.HardCodedSpeakers[i].Location);
                Assert.Equal(_speakerService.HardCodedSpeakers[i].Location,
                speakers[i].Location);
            }
        }
    }
}
