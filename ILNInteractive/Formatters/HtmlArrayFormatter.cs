using System;
using ILNumerics;
using Microsoft.DotNet.Interactive.Formatting;

namespace ILNInteractive.Formatters
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
                case Array<double> doubleArray:
                    FormatTable(context, (Array<double>) ILMath.squeeze(doubleArray), context.Writer);
                    return true;
                case Array<float> floatArray:
                    FormatTable(context, (Array<float>) ILMath.squeeze(floatArray), context.Writer);
                    return true;
                default:
                    return false;
            }
        }

        #endregion
    }
}
