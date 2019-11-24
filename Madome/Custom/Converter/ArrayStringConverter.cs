using System;
using System.ComponentModel;
using System.Globalization;

namespace Madome.Custom.Converter {
	public class ArrayStringConverter : TypeConverter {
		public override object ConvertFrom(
			ITypeDescriptorContext context, CultureInfo culture, object value) {
			string list = value as string;
			if (list != null)
				return list.Split(',');

			return base.ConvertFrom(context, culture, value);
		}

		public override bool CanConvertFrom(
			ITypeDescriptorContext context, Type sourceType) {
			if (sourceType == typeof(string))
				return true;

			return base.CanConvertFrom(context, sourceType);
		}
	}
}
