using System;
using System.Collections.Generic;
using VeiculoProtegido.Domain.Entities;
using VeiculoProtegido.Domain.Interfaces.Repository;
using VeiculoProtegido.Domain.Interfaces.Service;
using VeiculoProtegido.Domain.Validations.TabelaPreco;

namespace VeiculoProtegido.Domain.Services
{
	public class TabelaPrecoService : ITabelaPrecoService
	{
		#region Attribuilts
		private readonly ITabelaPrecoRepository _tabelaPrecoRepository;
		private readonly IFaixaTabelaPrecoRepository _faixaTabelaPrecoRepository;
		#endregion

		#region Builders
		public TabelaPrecoService(ITabelaPrecoRepository tabelaPrecoRepository, IFaixaTabelaPrecoRepository faixaTabelaPrecoRepository)
		{
			_tabelaPrecoRepository = tabelaPrecoRepository;
			_faixaTabelaPrecoRepository = faixaTabelaPrecoRepository;
		}
		#endregion

		#region Methods
		public TabelaPreco Add(TabelaPreco tabelaPreco)
		{
			if (!tabelaPreco.IsValid())
				return tabelaPreco;

			tabelaPreco.ValidationResult = new TabelaPrecoFitToRegisterValidation(_tabelaPrecoRepository).Validate(tabelaPreco);
			if (tabelaPreco.ValidationResult.IsValid)
				return tabelaPreco;

			tabelaPreco.ValidationResult.Message = "Tabela de Preço cadastrada com sucesso :)";
			return _tabelaPrecoRepository.Add(tabelaPreco);
		}

		public FaixaTabelaPreco AddFaixaTabelaPreco(FaixaTabelaPreco faixaTabelaPreco)
		{
			return _faixaTabelaPrecoRepository.Add(faixaTabelaPreco);
		}

		public void Dispose()
		{
			_tabelaPrecoRepository.Dispose();
			GC.SuppressFinalize(this);
		}

		public IEnumerable<TabelaPreco> GetAll()
		{
			return _tabelaPrecoRepository.GetAll();
		}

		public TabelaPreco GetByDescricao(string descricao)
		{
			return _tabelaPrecoRepository.GetByDescricao(descricao);
		}

		public FaixaTabelaPreco GetByFaixaTabelaPrecoId(Guid id)
		{
			return _faixaTabelaPrecoRepository.GetById(id);
		}

		public TabelaPreco GetById(Guid id)
		{
			return _tabelaPrecoRepository.GetById(id);
		}

		public FaixaTabelaPreco GetByPlanoId(string planoId)
		{
			return _faixaTabelaPrecoRepository.GetByPlanoId(planoId);
		}

		public TabelaPreco GetByTipoFIPE(string tipoFIPE)
		{
			return _tabelaPrecoRepository.GetByTipoFIPE(tipoFIPE);
		}

		public void Remove(Guid id)
		{
			_tabelaPrecoRepository.Remove(id);
		}

		public void RemoveFaixaTabelaPreco(Guid id)
		{
			_faixaTabelaPrecoRepository.Remove(id);
		}

		public TabelaPreco Update(TabelaPreco tabelaPreco)
		{
			return _tabelaPrecoRepository.Update(tabelaPreco);
		}

		public FaixaTabelaPreco UpdateFaixaTabelaPreco(FaixaTabelaPreco faixaTabelaPreco)
		{
			return _faixaTabelaPrecoRepository.Update(faixaTabelaPreco);
		}
		#endregion
	}
}
