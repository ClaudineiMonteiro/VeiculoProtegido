using SimpleInjector;

namespace VeiculoProtegido.Infra.CrossCutting.IoC
{
	public class BootStrapper
	{
		public static void RegisterServices(Container container)
		{
			//Domain
			//container.RegisterPerWebRequest<IEmpresaService, EmpresaService>();
		}
	}
}
