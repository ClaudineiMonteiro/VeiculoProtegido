using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

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

		public static string BuscarDescricaoEnumerador(Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			DescriptionAttribute[] attributes =
				(DescriptionAttribute[])fi.GetCustomAttributes(
				typeof(DescriptionAttribute),
				false);

			if (attributes != null &&
				attributes.Length > 0)
				return attributes[0].Description;
			else
				return value.ToString();
		}
	}
}
