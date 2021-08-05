using System;
using System.Collections.Generic;
using System.IO;
using ILNumerics;
using Microsoft.AspNetCore.Html;
using Microsoft.DotNet.Interactive.Formatting;
using System.Linq;
using static ILNumerics.ILMath;
using static ILNumerics.Globals;
using static Microsoft.DotNet.Interactive.Formatting.PocketViewTags;

namespace ILNInteractive.Formatters
{
    public abstract class HtmlArrayFormatterBase
    {
        protected void FormatTable<T>(FormatContext context, BaseArray<T> array, TextWriter writer)
        {

            var headers = new List<IHtmlContent>();
            headers.Add(th(i("index")));
            // headers.AddRange(arr(c => (IHtmlContent)th(c.Name)));//df.Columns.Select

            for (var i = 0; i < array.S[1]; i++)
            {
                headers.Add(th(i));
            }

            var rows = new List<List<IHtmlContent>>();
            var take = 100;
            for (var i = 0; i < Math.Min(take, array.S[0]); i++)
            {
                var cells = new List<IHtmlContent>();
                cells.Add(th(i));

                for (var j = 0; j < array.S[1]; j++)
                {
                    cells.Add(td(array.GetValue(i,j)));
                }

                rows.Add(cells);
            }

            var t = table(thead(headers), tbody(rows.Select(r => tr(r))));

            writer.Write(t);
            writer.Write("Size: " + array.S[0] + " x " + array.S[1]);
        }
    }
}
