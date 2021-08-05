using System;
using ILNumerics;
using Microsoft.DotNet.Interactive.Formatting;

namespace ILNInteractive.Formatters
{
    public class HtmlRetArrayFormatter : HtmlArrayFormatterBase, ITypeFormatter
    {
        #region ITypeFormatter Members

        public string MimeType => "text/html";

        public Type Type => typeof(RetArray<>);

        public bool Format(object instance, FormatContext context)
        {
            switch (instance)
            {
                case RetArray<double> doubleArray:
                    FormatTable(context, (Array<double>) ILMath.squeeze(doubleArray), context.Writer);
                    return true;
                case RetArray<float> floatArray:
                    FormatTable(context, (Array<float>) ILMath.squeeze(floatArray), context.Writer);
                    return true;
                default:
                    return false;
            }
        }

        #endregion
    }
}
