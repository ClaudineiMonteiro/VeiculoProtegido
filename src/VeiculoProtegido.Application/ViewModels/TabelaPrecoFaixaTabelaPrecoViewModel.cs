using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeiculoProtegido.Application.ViewModels
{
	public class TabelaPrecoFaixaTabelaPrecoViewModel
	{
		public TabelaPrecoFaixaTabelaPrecoViewModel()
		{
			TabelaPrecoId = Guid.NewGuid();
			FaixatabelaPrecoId = Guid.NewGuid();
			TipoFipe = (int)VeiculoProtegido.Infra.CrossCutting.Global.TipoFipe.carros;
		}
		[Key]
		public Guid TabelaPrecoId { get; set; }

		[Display(Name = "Descrição")]
		[Required(ErrorMessage = "Preencha o campo Descrição")]
		[MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
		public string Descricao { get; set; }

		[Display(Name = "Tipo da Tabela Fipe")]
		[Required(ErrorMessage = "Preencha o campo Tipo FIPE")]
		public int TipoFipe { get; set; }
		[ScaffoldColumn(false)]
		public DateTime DataHoraCadastro { get; set; }
		[ScaffoldColumn(false)]
		public DateTime? DataHoraUltimaAlteracao { get; set; }
		[ScaffoldColumn(false)]
		public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

		//Faixas de Tabela de Preço
		[Key]
		public Guid FaixatabelaPrecoId { get; set; }

		[Display(Name = "Plano")]
		[Required(ErrorMessage = "Preencha o campo Plano")]
		//[MaxLength(3, ErrorMessage = "Máximo {0} caracteres")]
		public int PlanoId { get; set; }

		[Display(Name = "Valor de")]
		[Required(ErrorMessage = "Preencha o campo Valor De")]
		public decimal ValorDe { get; set; }

		[Display(Name = "Valor até")]
		[Required(ErrorMessage = "Preencha o campo Valor Até")]
		public decimal ValorAte { get; set; }


		[Display(Name = "Valor mensal")]
		[Required(ErrorMessage = "Preencha o campo Valor Mensalidade")]
		public decimal ValorMensal { get; set; }

		[Display(Name = "Valor participação no evento")]
		[Required(ErrorMessage = "Preencha o campo Valor Participação")]
		public decimal ValorParticipacaoEvento { get; set; }

		[Display(Name = "Valor da adesão")]
		[Required(ErrorMessage = "Preencha o campo Valor de Adesão")]
		public decimal ValorAdesao { get; set; }
	}
}
