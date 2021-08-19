using System;
using ILNumerics;
using Microsoft.DotNet.Interactive.Formatting;

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
                    FormatTable(context, (Array<sbyte>) ILMath.squeeze(sbyteArray), context.Writer);
                    return true;
                case RetArray<short> shortArray:
                    FormatTable(context, (Array<short>) ILMath.squeeze(shortArray), context.Writer);
                    return true;
                case RetArray<int> intArray:
                    FormatTable(context, (Array<int>) ILMath.squeeze(intArray), context.Writer);
                    return true;
                case RetArray<long> longArray:
                    FormatTable(context, (Array<long>) ILMath.squeeze(longArray), context.Writer);
                    return true;
                case RetArray<float> floatArray:
                    FormatTable(context, (Array<float>) ILMath.squeeze(floatArray), context.Writer);
                    return true;
                case RetArray<double> doubleArray:
                    FormatTable(context, (Array<double>) ILMath.squeeze(doubleArray), context.Writer);
                    return true;
                case RetArray<fcomplex> fcomplexArray:
                    FormatTable(context, (Array<fcomplex>) ILMath.squeeze(fcomplexArray), context.Writer);
                    return true;
                case RetArray<complex> complexArray:
                    FormatTable(context, (Array<complex>) ILMath.squeeze(complexArray), context.Writer);
                    return true;
                default:
                    return false;
            }
        }

        #endregion
    }
}
