using B03.EE.SchuermansEva.Lib.Models;
using B03.EE.SchuermansEva.WebAPI.Models;
using B03.EE.SchuermansEva.WebAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace B03.EE.SchuermansEva.WebAPI.Repositories
{
    public class RegistrationRepository : Repository<Registration>
    {
        public RegistrationRepository(ActivityServiceContext context) : base(context)
        {   
        }

        public async Task<List<Registration>> GetAllInclusive()
        {
            return await GetAll()
                .Include(r => r.Activity)
                .Include(r => r.User)
                .ToListAsync();
        }
    }
}
