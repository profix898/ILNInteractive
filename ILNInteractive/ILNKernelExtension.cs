using System.Threading.Tasks;
using ILNInteractive.HtmlFormatters;
using ILNInteractive.PlainTextFormatters;
using ILNumerics;
using ILNumerics.Drawing;
using Microsoft.DotNet.Interactive;
using Microsoft.DotNet.Interactive.CSharp;
using Microsoft.DotNet.Interactive.Formatting;
using static Microsoft.DotNet.Interactive.Formatting.PocketViewTags;

namespace ILNInteractive
{
    public class ILNKernelExtension : IKernelExtension
    {
        #region IKernelExtension Members

        public async Task OnLoadAsync(Kernel kernel)
        {
            // Using Statements
            var kernelCSharp = (CSharpKernel) kernel.FindKernel("csharp");
            await kernelCSharp.SubmitCodeAsync("using ILNInteractive;");
            await kernelCSharp.SubmitCodeAsync("using ILNumerics;");
            await kernelCSharp.SubmitCodeAsync("using ILNumerics.Drawing;");
            await kernelCSharp.SubmitCodeAsync("using ILNumerics.Drawing.Plotting;");
            await kernelCSharp.SubmitCodeAsync("using System.Drawing;");
            await kernelCSharp.SubmitCodeAsync("using static ILNumerics.ILMath;");
            await kernelCSharp.SubmitCodeAsync("using static ILNumerics.Globals;");

            // Formatter: (f)complex
            Formatter.SetPreferredMimeTypeFor(typeof(fcomplex), PlainTextFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(complex), PlainTextFormatter.MimeType);
            Formatter.Register(new PlainTextFComplexFormatter());
            Formatter.Register(new PlainTextComplexFormatter());

            // Formatters: Array
            Formatter.SetPreferredMimeTypeFor(typeof(Array<sbyte>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(Array<short>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(Array<int>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(Array<long>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(Array<float>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(Array<double>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(Array<fcomplex>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(Array<complex>), HtmlFormatter.MimeType);
            Formatter.Register(new HtmlArrayFormatter());

            // Formatters: RetArray
            Formatter.SetPreferredMimeTypeFor(typeof(RetArray<sbyte>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(RetArray<short>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(RetArray<int>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(RetArray<long>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(RetArray<float>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(RetArray<double>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(RetArray<fcomplex>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(RetArray<complex>), HtmlFormatter.MimeType);
            Formatter.Register(new HtmlRetArrayFormatter());

            // Formatters: SceneGraph
            Formatter.SetPreferredMimeTypeFor(typeof(Scene), HtmlFormatter.MimeType);
            Formatter.Register(new HtmlSceneFormatter());

            if (KernelInvocationContext.Current is { } context)
            {
                PocketView view = div(code(nameof(ILNInteractive)), " extension is loaded. It adds math support and visualizations for ILNumerics projects.");
                context.Display(view);
            }
        }

        #endregion
    }
}
