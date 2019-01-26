using B03.EE.SchuermansEva.Lib.DTO;
using B03.EE.SchuermansEva.Lib.Models;
using B03.EE.SchuermansEva.WebAPI.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace B03.EE.SchuermansEva.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : CrudBaseController<User, UserRepository>
    {
        public UsersController(UserRepository userRepository) : base(userRepository)
        {
        }

         // GET: api/Users
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetAllInclusive());
        }

        // GET: api/Users/Basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetUserBasic()
        {
            return Ok(await repository.ListBasic());
        }
    }
}