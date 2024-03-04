using AutoMapper;
using WebApi.Entity;
using WebApi.DTOs;

namespace ApiMangas.Mappings;

public class DomainToDTOProfile : Profile
{
    public DomainToDTOProfile()
    {
        CreateMap<Produto, ProdutosDTO>().ReverseMap();
    }
}
