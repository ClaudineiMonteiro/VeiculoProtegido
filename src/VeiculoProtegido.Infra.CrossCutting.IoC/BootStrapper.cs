using SimpleInjector;
using VeiculoProtegido.Domain.Interfaces.Repository;
using VeiculoProtegido.Infra.Data.Context;
using VeiculoProtegido.Infra.Data.Interfaces;
using VeiculoProtegido.Infra.Data.Repository;
using VeiculoProtegido.Infra.Data.UoW;

namespace VeiculoProtegido.Infra.CrossCutting.IoC
{
	public class BootStrapper
	{
		public static void RegisterServices(Container container)
		{
			//Infra Data
			container.RegisterPerWebRequest<ITabelaPrecoRepository, TabelaPrecoRepository>();
			container.RegisterPerWebRequest<IFaixaTabelaPrecoRepository, FaixaTabelaPrecoRepository>();
			container.RegisterPerWebRequest<IUnitOfWork, UnitOfWork>();
			container.RegisterPerWebRequest<VeiculoProtegidoContext>();
		}
	}
}
