using AutoMapper;
using VeiculoProtegido.Application.ViewModels;
using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.Application.AutoMapper
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<TabelaPrecoViewModel, TabelaPreco>();
			CreateMap<TabelaPrecoFaixaTabelaPrecoViewModel, TabelaPreco>();
			CreateMap<FaixaTabelaPrecoViewModel, FaixaTabelaPreco>();
			CreateMap<TabelaPrecoFaixaTabelaPrecoViewModel, FaixaTabelaPreco>();
		}
	}
}
