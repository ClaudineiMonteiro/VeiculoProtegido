using AutoMapper;
using VeiculoProtegido.Application.ViewModels;
using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.Application.AutoMapper
{
	public class DomainToViewModelMappingProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<TabelaPreco, TabelaPrecoViewModel>();
			CreateMap<TabelaPreco, TabelaPrecoFaixaTabelaPrecoViewModel>();
			CreateMap<FaixaTabelaPreco, FaixaTabelaPrecoViewModel>();
			CreateMap<FaixaTabelaPreco, TabelaPrecoFaixaTabelaPrecoViewModel>();
		}
	}
}
