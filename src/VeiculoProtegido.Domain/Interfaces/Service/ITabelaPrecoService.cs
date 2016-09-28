using System;
using System.Collections.Generic;
using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.Domain.Interfaces.Service
{
	public interface ITabelaPrecoService : IDisposable
	{
		TabelaPreco Add(TabelaPreco tabelaPreco);
		TabelaPreco GetById(Guid id);
		TabelaPreco GetByDescricao(string descricao);
		TabelaPreco GetByTipoFIPE(byte tipoFIPE);
		IEnumerable<TabelaPreco> GetAll();
		TabelaPreco Update(TabelaPreco tabelaPreco);
		void Remove(Guid id);
		FaixaTabelaPreco AddFaixaTabelaPreco(FaixaTabelaPreco faixaTabelaPreco);
		FaixaTabelaPreco UpdateFaixaTabelaPreco(FaixaTabelaPreco faixaTabelaPreco);
		FaixaTabelaPreco GetByFaixaTabelaPrecoId(Guid id);
		FaixaTabelaPreco GetByPlanoId(byte planoId);
		void RemoveFaixaTabelaPreco(Guid id);
	}
}
