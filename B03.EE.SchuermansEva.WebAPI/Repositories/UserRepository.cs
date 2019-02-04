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
    public class UserRepository : MappingRepository<User>
    {
        public UserRepository(ActivityServiceContext context, IMapper mapper) : base(context, mapper)
        {   
        }

        public async Task<List<User>> GetAllInclusive()
        {
            return await GetAll()  
                .ToListAsync();
        }

        public async Task<List<UserBasic>> ListBasic()
        {
            return await db.Users
                .ProjectTo<UserBasic>(mapper.ConfigurationProvider)
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        public override async Task<User> GetById(int id)
        {
            return await db.Users  
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
