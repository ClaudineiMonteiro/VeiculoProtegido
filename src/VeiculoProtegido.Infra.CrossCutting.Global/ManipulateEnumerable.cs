using System;
using System.Collections.Generic;

namespace VeiculoProtegido.Infra.CrossCutting.Global
{
	public static class ManipulateEnumerable
	{
		public static IEnumerable<T> EnumToList<T>()
		{
			Type enumType = typeof(T);
			if (enumType.BaseType != typeof(Enum))
				throw new ArgumentException("T não é um Enumerador");

			Array enumValArray = Enum.GetValues(enumType);
			List<T> enumValList = new List<T>(enumValArray.Length);
			foreach (int val in enumValArray)
			{
				enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
			}
			return enumValList;
		}
	}
}
