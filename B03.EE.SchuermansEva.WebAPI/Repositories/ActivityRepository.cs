using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B03.EE.SchuermansEva.Lib.DTO;
using B03.EE.SchuermansEva.Lib.Models;
using B03.EE.SchuermansEva.WebAPI.Models;
using B03.EE.SchuermansEva.WebAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace B03.EE.SchuermansEva.WebAPI.Repositories
{
    public class ActivityRepository : MappingRepository<Activity>
    {
        public ActivityRepository(ActivityServiceContext context, IMapper mapper) : base(context, mapper)
        {   
        }

        public async Task<List<Activity>> GetAllInclusive()
        {
            return await GetAll()
                .Include(a => a.Category)
                .Include(a => a.Country)
                .ToListAsync();
        }

        public async Task<List<ActivityBasic>> ListBasic()
        {
            // return a list of ActivityBasic DTO-items (Id and Title only) using AutoMapper
            return await db.Activities
                .ProjectTo<ActivityBasic>(mapper.ConfigurationProvider)
                .OrderBy(a => a.Title)
                .ToListAsync();
        }

        public override async Task<Activity> GetById(int id)
        {
            return await db.Activities
                .Include(a => a.Category)
                .Include(a => a.Country)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
