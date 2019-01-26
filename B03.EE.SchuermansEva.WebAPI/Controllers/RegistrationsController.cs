using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using B03.EE.SchuermansEva.Lib.Models;
using B03.EE.SchuermansEva.WebAPI.Repositories;

namespace B03.EE.SchuermansEva.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : CrudBaseController<Registration, RegistrationRepository>
    {
        public RegistrationsController(RegistrationRepository registrationRepository) : base(registrationRepository)
        {   
        }

        // GET: api/Registrations
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetAllInclusive());
        }
    }
}       