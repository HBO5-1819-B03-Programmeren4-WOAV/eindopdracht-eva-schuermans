using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B03.EE.SchuermansEva.Lib.DTO;
using B03.EE.SchuermansEva.Lib.Models;
using B03.EE.SchuermansEva.WebAPI.Models;
using B03.EE.SchuermansEva.WebAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace B03.EE.SchuermansEva.WebAPI.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ActivityServiceContext context) : base(context)
        {   
        }

        public async Task<List<User>> GetAllInclusive()
        {
            return await GetAll()
                .Include(u => u.Registrations)
                .ToListAsync();
        }

        public async Task<List<UserBasic>> ListBasic()
        {
            var users = await db.Users.Select(u => new UserBasic
            {
                Id = u.Id,
                Name = $"{u.LastName} {u.FirstName}"

            }).ToListAsync();
            return users;
        }

        public override async Task<User> GetById(int id)
        {
            return await db.Users 
                .Include(a => a.Registrations)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
