using System.Collections.Generic;
using System.Linq;
using VeiculoProtegido.Infra.CrossCutting.Global;

namespace VeiculoProtegido.Application.ViewModels
{
	public class TipoFIPE
	{
		public int Id { get; set; }
		public string Descricao { get; set; }

		public static List<TipoFIPE> ListarTipoFIPE()
		{
			List<TipoFIPE> tipoFIPEList = new List<TipoFIPE>();
			foreach (var item in ManipulateEnumerable.EnumToList<TipoFipe>().OrderBy(c => (sbyte)c))
			{
				var tipoFIPE = new TipoFIPE();
				tipoFIPE.Id = (int)item;
				tipoFIPE.Descricao = ManipulateEnumerable.BuscarDescricaoEnumerador((TipoFipe)item);
				tipoFIPEList.Add(tipoFIPE);
			}
			return tipoFIPEList;
		}
	}
}
