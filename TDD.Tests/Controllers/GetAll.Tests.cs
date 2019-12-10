
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using TDD.Controllers;
using TDD.Core.Interfaces;
using Xunit;

namespace TDD.Tests.Controllers
{
    public class GetAll
    {
        private readonly SpeakerController _controller;
        private static Mock<ISpeakerService> _speakerServiceMock;
        private readonly List<SpeakerSummary> _speakers;

        public GetAll()
        {
            _speakers = new List<SpeakerSummary> { new SpeakerSummary
            {
                Name = "test"
            } };
            _speakerServiceMock = new Mock<ISpeakerService>();
            _speakerServiceMock.Setup(x => x.GetAll()).Returns(() => _speakers);
            _controller = new SpeakerController(_speakerServiceMock.Object);
        }

        [Fact]
        public void ItExists()
        {
            // Act
            _controller.GetAll();
        }

        [Fact]
        public void ItReturnsCollectionOfSpeakerSummary()
        {
            // Act
            var result = _controller.GetAll() as OkObjectResult;
            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsAssignableFrom<IEnumerable<SpeakerSummary>>(result.Value);
        }

        [Fact]
        public void ItReturnsOkObjectResult()
        {
            // Act
            var result = _controller.GetAll();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ItCallsGetAllServiceOnce()
        {
            // Act
            _controller.GetAll();
            // Assert
            _speakerServiceMock.Verify(mock => mock.GetAll(), Times.Once());
        }
    }
}
