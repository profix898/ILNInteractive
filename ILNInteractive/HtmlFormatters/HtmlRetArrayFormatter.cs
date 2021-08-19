using System;
using ILNumerics;
using Microsoft.DotNet.Interactive.Formatting;
using static ILNumerics.ILMath;

namespace ILNInteractive.HtmlFormatters
{
    public class HtmlRetArrayFormatter : HtmlArrayFormatterBase, ITypeFormatter
    {
        #region ITypeFormatter Members

        public string MimeType => HtmlFormatter.MimeType;

        public Type Type => typeof(RetArray<>);

        public bool Format(object instance, FormatContext context)
        {
            switch (instance)
            {
                case RetArray<sbyte> sbyteArray:
                    FormatTable(context, (Array<sbyte>) squeeze(sbyteArray), context.Writer);
                    return true;
                case RetArray<short> shortArray:
                    FormatTable(context, (Array<short>) squeeze(shortArray), context.Writer);
                    return true;
                case RetArray<int> intArray:
                    FormatTable(context, (Array<int>) squeeze(intArray), context.Writer);
                    return true;
                case RetArray<long> longArray:
                    FormatTable(context, (Array<long>) squeeze(longArray), context.Writer);
                    return true;
                case RetArray<float> floatArray:
                    FormatTable(context, (Array<float>) squeeze(floatArray), context.Writer);
                    return true;
                case RetArray<double> doubleArray:
                    FormatTable(context, (Array<double>) squeeze(doubleArray), context.Writer);
                    return true;
                case RetArray<fcomplex> fcomplexArray:
                    FormatTable(context, (Array<fcomplex>) squeeze(fcomplexArray), context.Writer);
                    return true;
                case RetArray<complex> complexArray:
                    FormatTable(context, (Array<complex>) squeeze(complexArray), context.Writer);
                    return true;
                default:
                    return false;
            }
        }

        #endregion
    }
}
