using AutoMapper;
using Libertese.Domain.Entities.Financeiro;

namespace Libertese.Web.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Despesa, DespesaDTO>();
        }
    }
}
