using System.ComponentModel;

namespace VeiculoProtegido.Infra.CrossCutting.Global
{
	#region Geral
	public enum TipoFipe
	{
		[Description("Carros")]
		carros,
		[Description("Motos")]
		motos,
		[Description("Caminhões")]
		caminhoes
	}
	#endregion
}
