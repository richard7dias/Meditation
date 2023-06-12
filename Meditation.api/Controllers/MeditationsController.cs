using System;
using Meditation.api.Models;
using Meditation.api.Services;
using Microsoft.AspNetCore.Mvc;


namespace Meditation.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
	public class MeditationsController : ControllerBase
    {
        private readonly MeditationsService _meditationsService;

        public MeditationsController(MeditationsService meditationsService) =>

            _meditationsService = meditationsService;

        [HttpGet]
        public async Task<List<MeditationClass>> Get() =>
            await _meditationsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<MeditationClass>> Get(string id)
        {
            var meditation = await _meditationsService.GetAsync(id);

            if (meditation is null)
            {
                return NotFound();
            }

            return meditation;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MeditationClass newMeditation)
        {
            await _meditationsService.CreateAsync(newMeditation);

            return CreatedAtAction(nameof(Get), new { id = newMeditation._id }, newMeditation);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, MeditationClass updatedMeditation)
        {
            var meditation = await _meditationsService.GetAsync(id);

            if (meditation is null)
            {
                return NotFound();
            }

            updatedMeditation._id = meditation._id;

            await _meditationsService.UpdateAsync(id, updatedMeditation);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var meditation = await _meditationsService.GetAsync(id);

            if (meditation is null)
            {
                return NotFound();
            }

            await _meditationsService.RemoveAsync(id);

            return NoContent();
        }
    }
}