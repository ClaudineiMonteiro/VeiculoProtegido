using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using VeiculoProtegido.Application.Interfaces;
using VeiculoProtegido.Application.ViewModels;
using VeiculoProtegido.Domain.Entities;
using VeiculoProtegido.Domain.Interfaces.Service;
using VeiculoProtegido.Infra.Data.Interfaces;

namespace VeiculoProtegido.Application
{
	public class TabelaPrecoAppService : ApplicationService, ITabelaPrecoAppService
	{
		#region Attribuilts
		private readonly ITabelaPrecoService _tabelaPrecoService;
		#endregion
		public TabelaPrecoAppService(ITabelaPrecoService tabelaPrecoService, IUnitOfWork uow) : base(uow)
		{
			_tabelaPrecoService = tabelaPrecoService;
		}

		public TabelaPrecoFaixaTabelaPrecoViewModel Add(TabelaPrecoFaixaTabelaPrecoViewModel tabelaPrecoFaixaTabelaPrecoViewModel)
		{
			var tabelaPreco = Mapper.Map<TabelaPrecoFaixaTabelaPrecoViewModel, TabelaPreco>(tabelaPrecoFaixaTabelaPrecoViewModel);
			var tabelaPrecoFaixa = Mapper.Map<TabelaPrecoFaixaTabelaPrecoViewModel, FaixaTabelaPreco>(tabelaPrecoFaixaTabelaPrecoViewModel);

			tabelaPreco.FaixasTabelaPreco.Add(tabelaPrecoFaixa);

			BeginTransaction();

			var tabelaPrecoReturn = _tabelaPrecoService.Add(tabelaPreco);
			tabelaPrecoFaixaTabelaPrecoViewModel = Mapper.Map<TabelaPreco, TabelaPrecoFaixaTabelaPrecoViewModel>(tabelaPrecoReturn);
			if (!tabelaPrecoReturn.ValidationResult.IsValid)
				return tabelaPrecoFaixaTabelaPrecoViewModel;

			Commit();
			return tabelaPrecoFaixaTabelaPrecoViewModel;
		}

		public FaixaTabelaPrecoViewModel AddFaixaTabelaPreco(FaixaTabelaPrecoViewModel faixaTabelaPrecoViewModel)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TabelaPrecoViewModel> GetAll()
		{
			return Mapper.Map<IEnumerable<TabelaPreco>, IEnumerable<TabelaPrecoViewModel>>(_tabelaPrecoService.GetAll());
		}

		public TabelaPrecoViewModel GetByDescricao(string descricao)
		{
			return Mapper.Map<TabelaPreco, TabelaPrecoViewModel>(_tabelaPrecoService.GetByDescricao(descricao));
		}

		public TabelaPrecoViewModel GetById(Guid id)
		{
			return Mapper.Map<TabelaPreco, TabelaPrecoViewModel>(_tabelaPrecoService.GetById(id));
		}

		public FaixaTabelaPrecoViewModel GetByIdFaixaTabelaPreco(Guid id)
		{
			return Mapper.Map<FaixaTabelaPreco, FaixaTabelaPrecoViewModel>(_tabelaPrecoService.GetByFaixaTabelaPrecoId(id));
		}

		public TabelaPrecoViewModel GetByTipoFIPE(byte tipoFipe)
		{
			return Mapper.Map<TabelaPreco,TabelaPrecoViewModel>(_tabelaPrecoService.GetByTipoFIPE(tipoFipe));
		}

		public void Remove(Guid id)
		{
			BeginTransaction();
			_tabelaPrecoService.Remove(id);
			Commit();
		}

		public void RemoveFaixaTabelaPreco(Guid id)
		{
			BeginTransaction();
			_tabelaPrecoService.RemoveFaixaTabelaPreco(id);
			Commit();
		}

		public TabelaPrecoViewModel Update(TabelaPrecoViewModel tabelaPrecoViewModel)
		{
			BeginTransaction();
			_tabelaPrecoService.Update(Mapper.Map<TabelaPrecoViewModel, TabelaPreco>(tabelaPrecoViewModel));
			Commit();
			return tabelaPrecoViewModel;
		}

		public FaixaTabelaPrecoViewModel UpdateFaixaTabelaPreco(FaixaTabelaPrecoViewModel faixaTabelaPrecoViewModel)
		{
			var faixaTabelaPreco = Mapper.Map<FaixaTabelaPrecoViewModel, FaixaTabelaPreco>(faixaTabelaPrecoViewModel);
			BeginTransaction();
			_tabelaPrecoService.UpdateFaixaTabelaPreco(faixaTabelaPreco);
			Commit();
			return faixaTabelaPrecoViewModel;
		}
	}
}
