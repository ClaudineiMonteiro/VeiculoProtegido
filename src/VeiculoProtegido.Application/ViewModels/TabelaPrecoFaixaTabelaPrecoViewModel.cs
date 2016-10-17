using System;
using System.ComponentModel.DataAnnotations;

namespace VeiculoProtegido.Application.ViewModels
{
	public class TabelaPrecoFaixaTabelaPrecoViewModel
	{
		public TabelaPrecoFaixaTabelaPrecoViewModel()
		{
			TabelaPrecoId = Guid.NewGuid();
			//FaixasTabelaPreco = new List<FaixaTabelaPrecoViewModel>();

		}
		[Key]
		public Guid TabelaPrecoId { get; set; }

		[Required(ErrorMessage = "Preencha o campo Descrição")]
		[MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
		public string Descricao { get; set; }

		[Required(ErrorMessage = "Preencha o campo Tipo FIPE")]
		public int TipoFipe { get; set; }
		//public virtual ICollection<FaixaTabelaPreco> FaixasTabelaPreco { get; set; }
		[ScaffoldColumn(false)]
		public DateTime DataHoraCadastro { get; set; }
		[ScaffoldColumn(false)]
		public DateTime DataHoraUltimaAlteracao { get; set; }
		[ScaffoldColumn(false)]
		public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

		//Faixas de Tabela de Preço
		[Key]
		public Guid FaixatabelaPrecoId { get; set; }
		[Required(ErrorMessage = "Preencha o campo Plano")]
		//[MaxLength(3, ErrorMessage = "Máximo {0} caracteres")]
		public int PlanoId { get; set; }
		[Required(ErrorMessage = "Preencha o campo Valor De")]
		public decimal ValorDe { get; set; }
		[Required(ErrorMessage = "Preencha o campo Valor Até")]
		public decimal ValorAte { get; set; }
		[Required(ErrorMessage = "Preencha o campo Valor Mensalidade")]
		public decimal ValorMensal { get; set; }
		[Required(ErrorMessage = "Preencha o campo Valor Participação")]
		public decimal ValorParticipacaoEvento { get; set; }
		[Required(ErrorMessage = "Preencha o campo Valor de Adesão")]
		public decimal ValorAdesao { get; set; }
	}
}
