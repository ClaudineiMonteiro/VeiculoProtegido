using AutoMapper;
using VeiculoProtegido.Application.ViewModels;
using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.Application.AutoMapper
{
	public class DomainToViewModelMappingProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<Veiculo, VeiculoViewModel>();
			CreateMap<Modelo, VeiculoViewModel>();
			CreateMap<Marca, MarcaViewModel>();
		}
	}
}
