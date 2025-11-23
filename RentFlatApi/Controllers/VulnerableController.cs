using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace RentFlatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VulnerableController : ControllerBase
    {
        [HttpGet("files")]
        public IActionResult GetFile(string fileName)
        {
            // VULNERABILITY: Path Traversal
            // This allows reading any file on the system that the process has access to.
            // Example exploit: /api/vulnerable/files?fileName=../../appsettings.json
            var content = System.IO.File.ReadAllText(fileName);
            return Ok(content);
        }
    }
}
