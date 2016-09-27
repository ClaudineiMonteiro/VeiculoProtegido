using System;
using System.Collections.Generic;

namespace VeiculoProtegido.Domain.Entities
{
	public class TabelaPreco
	{
		public Guid TabelaPrecoId { get; set; }
		public string Descricao { get; set; }
		public byte TipoFipe { get; set; }
		public virtual ICollection<FaixaTabelaPreco> FaixasTabelaPreco { get; set; }
		public DateTime DataHoraCadastro { get; set; }
		public DateTime DataHoraUltimaAlteracao { get; set; }
	}
}
