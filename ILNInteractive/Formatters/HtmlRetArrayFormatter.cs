using System;
using ILNumerics;
using Microsoft.DotNet.Interactive.Formatting;

namespace ILNInteractive.Formatters
{
    public class HtmlRetArrayFormatter : HtmlArrayBaseFormatter, ITypeFormatter
    {
        #region ITypeFormatter Members

        public override Type Type => typeof(RetArray<>);

        #endregion
    }
}
