using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ILNumerics;
using Microsoft.AspNetCore.Html;
using Microsoft.DotNet.Interactive.Formatting;
using static Microsoft.DotNet.Interactive.Formatting.PocketViewTags;

namespace ILNInteractive.HtmlFormatters
{
    public abstract class HtmlArrayFormatterBase
    {
        protected void FormatTable<T>(FormatContext context, BaseArray<T> array, TextWriter writer)
        {
            var maxElements = ILNInteractiveOptions.MaxArrayElements;

            // Warning: More than 2 dimensions
            if (array.S.NumberOfDimensions > 2)
                writer.WriteLine(i($"Note: Array with {array.S.NumberOfDimensions} dimensions. Table shows first 2 dimensions. Use ILNumerics indexers to select elements, e.g. a[\":;:;1\"]."));

            // Build table header
            var headers = new List<IHtmlContent>();
            headers.Add(th(i("index")));
            for (var i = 0; i < Math.Min(maxElements, array.S[1]); i++)
                headers.Add(th(i));

            // Build table body (rows/cols)
            var rows = new List<List<IHtmlContent>>();
            for (var i = 0; i < Math.Min(maxElements, array.S[0]); i++)
            {
                var cells = new List<IHtmlContent>();
                cells.Add(th(i));

                for (var j = 0; j < Math.Min(maxElements, array.S[1]); j++)
                    cells.Add(td(array.GetValue(i, j).ToDisplayString()));

                rows.Add(cells);
            }

            // Write table to output
            writer.WriteLine($"Dims: {array.S[0]} x {array.S[1]} (ElementType: {array.GetElementType().FullName})");
            writer.Write(table(thead(headers), tbody(rows.Select(r => tr(r)))));

            // Warning: Table truncated at MaxArrayElements
            if (array.S[0] > maxElements || array.S[1] > maxElements)
                writer.WriteLine(b($"Note: Table truncated at {maxElements} elements."));
        }
    }
}
