using System.Threading.Tasks;
using DiModelBindingExample.Models;
using DiModelBindingExample.Models.Commands;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DiModelBindingExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        [HttpPost("AddEntityCommand")]
        [SwaggerOperation("Add Entity")]
        public Task<ActionResult<SomeEntity>> AddEntityn(AddEntityCommand command) =>
            Task.Run<ActionResult<SomeEntity>>(() => Ok(command.Execute().Result));
    }
}
