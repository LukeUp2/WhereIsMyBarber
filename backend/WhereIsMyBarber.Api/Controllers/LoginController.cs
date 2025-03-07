using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhereIsMyBarber.Application.UseCases.Login;
using WhereIsMyBarber.Communication.Requests;

namespace WhereIsMyBarber.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> DoLogin([FromBody] RequestDoLogin request, [FromServices] IDoLoginUseCase useCase)
        {
            var result = await useCase.Execute(request);

            return Ok(result);
        }
    }
}