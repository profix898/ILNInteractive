using System;
using ILNumerics;
using Microsoft.DotNet.Interactive.Formatting;

namespace ILNInteractive.Formatters
{
    public class HtmlArrayFormatter : HtmlArrayFormatterBase, ITypeFormatter
    {
        #region ITypeFormatter Members

        public string MimeType => "text/html";

        public Type Type => typeof(Array<double>);

        public bool Format(object instance, FormatContext context)
        {
            var baseArray = instance as BaseArray;
            if (baseArray == null)
                return false;

            FormatTable(context, baseArray, context.Writer);

            return true;
        }

        #endregion
    }
}
