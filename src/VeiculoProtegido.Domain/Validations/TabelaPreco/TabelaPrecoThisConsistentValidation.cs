using DomainValidation.Validation;
using VeiculoProtegido.Domain.Specifications.TabelaPreco;

namespace VeiculoProtegido.Domain.Validations.TabelaPreco
{
	public class TabelaPrecoThisConsistentValidation : Validator<Entities.TabelaPreco>
	{
		public TabelaPrecoThisConsistentValidation()
		{
			var TabelaPrecoDescricao = new TabelaPrecoDescricaoNotNullSpecification();

			base.Add("TabelaPrecoDescricao", new Rule<Entities.TabelaPreco>(TabelaPrecoDescricao, "É obrigatório o preenchimento do campo de Descrição"));
		}
	}
}
