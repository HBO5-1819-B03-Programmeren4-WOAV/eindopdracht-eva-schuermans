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
    public class ActivitiesController : CrudBaseController<Activity, ActivityRepository>
    {
        
        public ActivitiesController(ActivityRepository activityRepository) : base(activityRepository)
        {   
        }

        // GET: api/Activities
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetAllInclusive());
        }

        // GET: api/Activities/Basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetActivityBasic()
        {
            return Ok(await repository.ListBasic());
        }

        // GET: api/Activities/Id
        [HttpGet]
        [Route("Activities/{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            return Ok(await repository.GetById(id));
        }

        [HttpPost]
        public async override Task<IActionResult> Post([FromBody] Activity activity)
        {
            activity.Category = null;
            activity.Country = null;

            return await base.Post(activity);
        }
    }
}