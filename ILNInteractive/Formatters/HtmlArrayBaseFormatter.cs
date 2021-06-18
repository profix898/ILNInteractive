using System;
using System.IO;
using ILNumerics;
using Microsoft.DotNet.Interactive.Formatting;

namespace ILNInteractive.Formatters
{
    public abstract class HtmlArrayBaseFormatter
    {
        #region ITypeFormatter Members

        public string MimeType => "text/html";

        public abstract Type Type {get; }

        public bool Format(FormatContext context, object instance, TextWriter writer)
        {
            var baseArray = instance as BaseArray;
            if (baseArray == null)
                return false;

            FormatTable(context, baseArray, writer);

            return true;
        }

        #endregion

        private void FormatTable(FormatContext context, BaseArray array, TextWriter writer)
        {
            writer.Write(array.ShortInfo());

            // TODO: Format HTML table for the array

            //var headers = new List<IHtmlContent>();
            //headers.Add(th(i("index")));
            //headers.AddRange(df.Columns.Select(c => (IHtmlContent)th(c.Name)));

            //var rows = new List<List<IHtmlContent>>();
            //var take = 100;
            //for (var i = 0; i < Math.Min(take, df.Rows.Count); i++)
            //{
            //    var cells = new List<IHtmlContent>();
            //    cells.Add(td(i));

            //    foreach (var obj in df.Rows[i])

            //        cells.Add(td(obj));

            //    rows.Add(cells);
            //}

            //var t = table(thead(headers), tbody(rows.Select(r => tr(r))));

            //writer.Write(t);
            //writer.Write(df.Rows.Count + " x " + df.Columns.Count);
        }
    }
}
