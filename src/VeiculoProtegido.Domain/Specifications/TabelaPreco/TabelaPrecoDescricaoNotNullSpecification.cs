using System;
using DomainValidation.Interfaces.Specification;
using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.Domain.Specifications.TabelaPreco
{
	public class TabelaPrecoDescricaoNotNullSpecification : ISpecification<Entities.TabelaPreco>
	{
		public bool IsSatisfiedBy(Entities.TabelaPreco tabelaPreco)
		{
			return tabelaPreco.Descricao.Length > 0;
		}
	}
}
