using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Mvc;
using RentFlatApi.Contract.FlatDto;
using RentFlatApi.Core.Services;
using RentFlatApi.Infrastructure.Model;
using RentFlatApi.Infrastructure.Repository;

namespace RentFlatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IFlatService _flatService;

        public ValuesController(IFlatService flatService)
        {
            _flatService = flatService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("addFlat")]
        public async Task<IActionResult> AddFlat([FromBody] FlatDto flat)
        {
            if (flat == null)
            {
                return BadRequest();
            }

            await _flatService.Add(flat);
            return Created("AddFlat", flat);
        }

        [HttpPost("updateFlat")]
        public async Task<IActionResult> UpdateFlat([FromBody] FlatDto flat)
        {
            if (flat == null)
            {
                return BadRequest();
            }

            await _flatService.Update(flat);
            return Created("Updated", flat);
        }
        [HttpGet("GetAllFlats")]
        public async Task<IActionResult> GetAllFlats()
        {
            var flats = await _flatService.GetAll();
            return Ok(flats);
        }
    }
}