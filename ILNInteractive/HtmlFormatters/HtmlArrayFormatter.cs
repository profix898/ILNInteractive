using System;
using ILNumerics;
using Microsoft.DotNet.Interactive.Formatting;
using static ILNumerics.ILMath;

namespace ILNInteractive.HtmlFormatters
{
    public class HtmlArrayFormatter : HtmlArrayFormatterBase, ITypeFormatter
    {
        #region ITypeFormatter Members

        public string MimeType => HtmlFormatter.MimeType;

        public Type Type => typeof(Array<>);

        public bool Format(object instance, FormatContext context)
        {
            switch (instance)
            {
                case Array<sbyte> sbyteArray:
                    FormatTable(context, (Array<sbyte>) squeeze(sbyteArray), context.Writer);
                    return true;
                case Array<short> shortArray:
                    FormatTable(context, (Array<short>) squeeze(shortArray), context.Writer);
                    return true;
                case Array<int> intArray:
                    FormatTable(context, (Array<int>) squeeze(intArray), context.Writer);
                    return true;
                case Array<long> longArray:
                    FormatTable(context, (Array<long>) squeeze(longArray), context.Writer);
                    return true;
                case Array<float> floatArray:
                    FormatTable(context, (Array<float>) squeeze(floatArray), context.Writer);
                    return true;
                case Array<double> doubleArray:
                    FormatTable(context, (Array<double>) squeeze(doubleArray), context.Writer);
                    return true;
                case Array<fcomplex> fcomplexArray:
                    FormatTable(context, (Array<fcomplex>) squeeze(fcomplexArray), context.Writer);
                    return true;
                case Array<complex> complexArray:
                    FormatTable(context, (Array<complex>) squeeze(complexArray), context.Writer);
                    return true;
                default:
                    return false;
            }
        }

        #endregion
    }
}
