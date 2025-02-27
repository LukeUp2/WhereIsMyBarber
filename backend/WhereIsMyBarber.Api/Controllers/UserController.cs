using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhereIsMyBarber.Application.UseCases.User.Register;
using WhereIsMyBarber.Communication.Requests;

namespace WhereIsMyBarber.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(RequestRegisterUser request, [FromServices] IRegisterUserUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Created(string.Empty, result);
        }
    }
}