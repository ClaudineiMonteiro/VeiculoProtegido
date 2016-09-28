using System;
using DomainValidation.Interfaces.Specification;
using VeiculoProtegido.Domain.Entities;
using VeiculoProtegido.Domain.Interfaces.Repository;

namespace VeiculoProtegido.Domain.Specifications.TabelaPreco
{
	public class TabelaPrecoMustHaveDescricaoSingleSpecification : ISpecification<Entities.TabelaPreco>
	{
		private readonly ITabelaPrecoRepository _tabelaPrecoRepository;
		public TabelaPrecoMustHaveDescricaoSingleSpecification(ITabelaPrecoRepository tabelaPrecoRepository)
		{
			_tabelaPrecoRepository = tabelaPrecoRepository;
		}
		public bool IsSatisfiedBy(Entities.TabelaPreco tabelaPreco)
		{
			return _tabelaPrecoRepository.GetByDescricao(tabelaPreco.Descricao) == null;
		}
	}
}
