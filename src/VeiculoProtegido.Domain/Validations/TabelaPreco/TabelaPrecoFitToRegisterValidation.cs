using DomainValidation.Validation;
using VeiculoProtegido.Domain.Interfaces.Repository;
using VeiculoProtegido.Domain.Specifications.TabelaPreco;

namespace VeiculoProtegido.Domain.Validations.TabelaPreco
{
	public class TabelaPrecoFitToRegisterValidation : Validator<Entities.TabelaPreco>
	{
		public TabelaPrecoFitToRegisterValidation(ITabelaPrecoRepository tabelaPrecoRepository)
		{
			var TabelaPrecoDescricao = new TabelaPrecoMustHaveDescricaoSingleSpecification(tabelaPrecoRepository);

			base.Add("TabelaPrecoDescricao", new Rule<Entities.TabelaPreco>(TabelaPrecoDescricao, "Descrição já cadastrada!"));
		}
	}
}
