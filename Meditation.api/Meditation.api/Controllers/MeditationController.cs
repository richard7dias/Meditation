using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meditation.api.Models;
using Meditation.infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Meditation.api.Controllers
{
    [Route("api/[controller]")]
    public class MeditationController : Controller
    {
        private IMeditationRepository _meditationRepository;

        public MeditationController(IMeditationRepository meditationRepository)
        {
            _meditationRepository = meditationRepository;
        }

        // GET: api/meditation
        [HttpGet]
        public IActionResult Get()
        {
            var meditations = _meditationRepository.FindMeditation();
            return Ok(meditations);
        }

        // GET api/meditation/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var meditation = _meditationRepository.FindId(id);

            if (meditation == null)
            {
                return NotFound();
            }

            return Ok(meditation);
        }

        // POST api/meditation
        [HttpPost]
        public IActionResult Post([FromBody] MeditationClass newMeditation)
        {
            _meditationRepository.Add(newMeditation);
            return Created("", newMeditation);
        }

        // PUT api/meditation/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] MeditationClass meditationPut)
        {
            var meditation = _meditationRepository.FindId(id);

            if (meditation == null)
            {
                return NotFound();
            }

            meditation.UpdateMeditation(meditationPut._pageNumber, meditationPut._text, meditationPut._dateDisplay, meditationPut._dateTemp, meditationPut._date, meditationPut._title, meditationPut._verseText, meditationPut._verseRef);
            
            _meditationRepository.Update(id, meditation);

            return Ok(meditation);
        }

        // DELETE api/meditation/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var meditation = _meditationRepository.FindId(id);

            if (meditation == null)
            {
                return NotFound();
            }

            _meditationRepository.Remove(id);

            return NoContent();
        }
    }
}

