using B03.EE.SchuermansEva.Lib.Models;
using B03.EE.SchuermansEva.WebAPI.Models;
using B03.EE.SchuermansEva.WebAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace B03.EE.SchuermansEva.WebAPI.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(ActivityServiceContext context) : base(context)
        {   
        }

        public async Task<List<Category>> GetAllInclusive()
        {
            return await GetAll()
                .Include(c => c.Activities)
                .ToListAsync();
        }
    }
}
