using Microsoft.AspNetCore.Mvc;

namespace NV_ProjectLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectLab_panel : ControllerBase
    {
        [HttpGet("my")]
        public string myFunc()
        {
            return ("qsqs");
        }
    }
}
