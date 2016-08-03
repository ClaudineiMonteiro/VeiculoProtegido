using SimpleInjector;
using VeiculoProtegido.Domain.Interfaces.Service;
using VeiculoProtegido.Domain.Services;

namespace VeiculoProtegido.Infra.CrossCutting.IoC
{
	public class BootStrapper
	{
		public static void RegisterServices(Container container)
		{
			//Domain
			container.RegisterPerWebRequest<IEmpresaService, EmpresaService>();
		}
	}
}
