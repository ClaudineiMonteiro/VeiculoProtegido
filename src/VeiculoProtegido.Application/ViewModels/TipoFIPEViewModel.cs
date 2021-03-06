﻿using System.Collections.Generic;
using System.Linq;
using VeiculoProtegido.Infra.CrossCutting.Global;

namespace VeiculoProtegido.Application.ViewModels
{
	public class TipoFIPEViewModel
	{
		public int Id { get; set; }
		public string Descricao { get; set; }

		public List<TipoFIPEViewModel> TipoFIPEViewModels { get; set; }
		public TipoFIPEViewModel(int? tipoFIPEId)
		{
			Id = tipoFIPEId.Value;
			TipoFIPEViewModels = new List<TipoFIPEViewModel>();
			foreach (var item in ManipulateEnumerable.EnumToList<TipoFipe>().OrderBy(c => (sbyte)c))
			{
				var tipoFIPE = new TipoFIPEViewModel();
				tipoFIPE.Id = (int)item;
				tipoFIPE.Descricao = ManipulateEnumerable.BuscarDescricaoEnumerador((TipoFipe)item);
				TipoFIPEViewModels.Add(tipoFIPE);
			}
		}
		public TipoFIPEViewModel()
		{

		}
		//public static List<TipoFIPEViewModel> ListTipoFIPE()
		//{
		//	List<TipoFIPEViewModel> tipoFIPEList = new List<TipoFIPEViewModel>();
		//	foreach (var item in ManipulateEnumerable.EnumToList<TipoFipe>().OrderBy(c => (sbyte)c))
		//	{
		//		var tipoFIPE = new TipoFIPEViewModel();
		//		tipoFIPE.Id = (int)item;
		//		tipoFIPE.Descricao = ManipulateEnumerable.BuscarDescricaoEnumerador((TipoFipe)item);
		//		tipoFIPEList.Add(tipoFIPE);
		//	}
		//	return tipoFIPEList;
		//}
	}
}
