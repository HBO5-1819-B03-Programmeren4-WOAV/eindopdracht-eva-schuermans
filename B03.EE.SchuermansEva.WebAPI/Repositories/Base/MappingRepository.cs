using AutoMapper;
using B03.EE.SchuermansEva.Lib.Models;
using B03.EE.SchuermansEva.WebAPI.Models;

namespace B03.EE.SchuermansEva.WebAPI.Repositories.Base
{
    public class MappingRepository<T> : Repository<T> where T : EntityBase
    {
        protected readonly IMapper mapper;

        public MappingRepository(ActivityServiceContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }
    }
}
