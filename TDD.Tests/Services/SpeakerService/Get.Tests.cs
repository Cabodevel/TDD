using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TDD.Controllers;
using TDD.Core.Interfaces;
using Xunit;

namespace TDD.Tests.Services.SpeakerService
{
    public class Get
    {
        private readonly SpeakerController _controller;
        private static Mock<ISpeakerService> _speakerServiceMock;
        private readonly List<SpeakerSummary> _speakers;

        public Get()
        {
            //Arrange
            _speakers = new List<SpeakerSummary> { new SpeakerSummary
            {
                Name = "test"
            } };
            _speakerServiceMock = new Mock<ISpeakerService>();
            _speakerServiceMock.Setup(x => x.GetAll()).Returns(() => _speakers);
            _speakerServiceMock.Setup(x => x.Get(-1)).Returns(() => throw new SpeakerNotFoundException());
            _controller = new SpeakerController(_speakerServiceMock.Object);
        }

        [Fact]
        public void GivenSpeakerNotFoundExceptionThenNotFoundObjectResult()
        {
            // Arrange
           
            // Act
            var result = _controller.Get(-1);
            // Assert
            Assert.IsAssignableFrom<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GivenSpeakerNotFoundExceptionThenMessageReturned()
        {
            // Act
            var result = _controller.Get(-1) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Speaker Not Found", result.Value);
        }
    }
    }
