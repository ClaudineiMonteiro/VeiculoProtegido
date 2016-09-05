using System.Collections.Generic;
using VeiculoProtegido.Application.ViewModels;

namespace VeiculoProtegido.Application.Interfaces
{
	public interface IMarcaAppService
	{
		IEnumerable<MarcaViewModel> GetForType(string type);
	}
}
