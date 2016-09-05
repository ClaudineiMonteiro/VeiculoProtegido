using AutoMapper;
using VeiculoProtegido.Application.ViewModels;
using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.Application.AutoMapper
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<VeiculoViewModel, Veiculo>();
			CreateMap<VeiculoViewModel, Modelo>();
			CreateMap<MarcaViewModel, Marca>();
		}
	}
}
