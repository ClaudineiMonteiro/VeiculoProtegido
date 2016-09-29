using System;
using System.Collections.Generic;
using VeiculoProtegido.Application.ViewModels;

namespace VeiculoProtegido.Application.Interfaces
{
	public interface ITabelaPrecoAppService : IDisposable
	{
		TabelaPrecoFaixaTabelaPrecoViewModel Add(TabelaPrecoFaixaTabelaPrecoViewModel tabelaPrecoFaixaTabelaPrecoViewModel);
		TabelaPrecoViewModel GetById(Guid id);
		TabelaPrecoViewModel GetByTipoFIPE(byte tipoFipe);
		TabelaPrecoViewModel GetByDescricao(string descricao);
		IEnumerable<TabelaPrecoViewModel> GetAll();
		TabelaPrecoViewModel Update(TabelaPrecoViewModel tabelaPrecoViewModel);
		void Remove(Guid id);
		FaixaTabelaPrecoViewModel AddFaixaTabelaPreco(FaixaTabelaPrecoViewModel faixaTabelaPrecoViewModel);
		FaixaTabelaPrecoViewModel UpdateFaixaTabelaPreco(FaixaTabelaPrecoViewModel faixaTabelaPrecoViewModel);
		FaixaTabelaPrecoViewModel GetByIdFaixaTabelaPreco(Guid id);
		void RemoveFaixaTabelaPreco(Guid id);
	}
}
