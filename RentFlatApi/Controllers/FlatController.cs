using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentFlatApi.Contract.FlatDto;
using RentFlatApi.Core.Services;

namespace RentFlatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlatController : ControllerBase
    {
        private readonly IFlatService _flatService;

        public FlatController(IFlatService flatService)
        {
            _flatService = flatService;
        }

        [HttpGet("GetFlat/{Id}")]
        public async Task<IActionResult> GetFlatById(long id)
        {
            try
            {
                var flat = await _flatService.GetById(id);
                return Ok(flat);
            }
            catch (NullReferenceException e)
            {
                return NotFound($"Can't found flat with id = {id}");
            }
        }

        [HttpGet("GetAllFlats")]
        public async Task<IActionResult> GetAllFlats()
        {
            var flats = await _flatService.GetAll();
            return Ok(flats);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlat([FromBody] FlatDto flat)
        {
            if (flat == null)
            {
                return BadRequest();
            }

            await _flatService.Add(flat);
            return Created("Created new flat", flat);
        }

        [HttpPut("UpdateFlat")]
        public async Task<IActionResult> UpdateFlat([FromBody] FlatDto flat)
        {
            if (flat == null)
            {
                return BadRequest();
            }

            await _flatService.Update(flat);
            return Ok($"Updated flat with id = {flat.Id}");
        }

        [HttpDelete("DeleteFlat/{id}")]
        public async Task<IActionResult> DeleteFlat(long id)
        {
            await _flatService.Delete(id);
            return Ok($"Flat with id = {id} deleted");
        }
    }
}