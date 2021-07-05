using System;
using System.IO;
using ILNumerics;
using Microsoft.DotNet.Interactive.Formatting;

namespace ILNInteractive.Formatters
{
    public class HtmlArrayFormatter : HtmlArrayFormatterBase, ITypeFormatter
    {
        #region ITypeFormatter Members

        public string MimeType => "text/html";

        public Type Type => typeof(Array<>);

        public bool Format(FormatContext context, object instance, TextWriter writer)
        {
            var baseArray = instance as BaseArray;
            if (baseArray == null)
                return false;

            FormatTable(context, baseArray, writer);

            return true;
        }

        #endregion
    }
}
