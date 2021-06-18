using System;
using ILNumerics;
using Microsoft.DotNet.Interactive.Formatting;

namespace ILNInteractive.Formatters
{
    public class HtmlArrayFormatter : HtmlArrayBaseFormatter, ITypeFormatter
    {
        #region ITypeFormatter Members

        public override Type Type => typeof(Array<>);

        #endregion
    }
}
