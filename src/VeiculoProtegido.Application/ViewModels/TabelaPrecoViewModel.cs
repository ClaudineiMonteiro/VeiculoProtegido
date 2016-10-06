using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeiculoProtegido.Application.ViewModels
{
	public class TabelaPrecoViewModel
	{
		public TabelaPrecoViewModel()
		{
			TabelaPrecoId = Guid.NewGuid();
			FaixasTabelaPreco = new List<FaixaTabelaPrecoViewModel>();
		}
		#region Attrubutes
		[Key]
		public Guid TabelaPrecoId { get; set; }

		[Required(ErrorMessage = "Preencha o campo Descrição")]
		[MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
		public string Descricao { get; set; }

		[Required(ErrorMessage = "Preencha o campo Tipo FIPE")]
		public byte TipoFipe { get; set; }

		[ScaffoldColumn(false)]
		public DateTime DataHoraCadastro { get; set; }
		[ScaffoldColumn(false)]
		public DateTime DataHoraUltimaAlteracao { get; set; }

		public ICollection<FaixaTabelaPrecoViewModel> FaixasTabelaPreco { get; set; }
		#endregion
	}
}
