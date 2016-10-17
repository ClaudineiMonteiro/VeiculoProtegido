using System;
using System.ComponentModel.DataAnnotations;

namespace VeiculoProtegido.Application.ViewModels
{
	public class FaixaTabelaPrecoViewModel
	{
		public FaixaTabelaPrecoViewModel()
		{
			FaixatabelaPrecoId = Guid.NewGuid();
		}
		[Key]
		public Guid FaixatabelaPrecoId { get; set; }
		[Required(ErrorMessage = "Preencha o campo Plano")]
		[MaxLength(3, ErrorMessage = "Máximo {0} caracteres")]
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
		[ScaffoldColumn(false)]
		public Guid TabelaPrecoId { get; set; }
	}
}
