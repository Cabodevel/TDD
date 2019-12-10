using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TDD.Core.Exceptions;
using TDD.Core.Interfaces;

namespace TDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerService _speakerService;

        public SpeakerController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        public IActionResult GetAll()
        {
            _speakerService.GetAll();
            return Ok(new List<SpeakerSummary>());
        }

        public IActionResult Get(int id)
        {
            try
            {
                var speaker = _speakerService.Get(id);
                return Ok(speaker);
            }
            catch (SpeakerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}