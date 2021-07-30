using System.Threading.Tasks;
using ILNInteractive.Formatters;
using ILNumerics;
using ILNumerics.Drawing;
using Microsoft.DotNet.Interactive;
using Microsoft.DotNet.Interactive.Commands;
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
            await kernelCSharp.SubmitCodeAsync("using static ILNumerics.ILMath;");
            await kernelCSharp.SubmitCodeAsync("using static ILNumerics.Globals;");

            // Formatters: Arrays
            Formatter.SetPreferredMimeTypeFor(typeof(Array<double>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(Array<float>), HtmlFormatter.MimeType);
            Formatter.Register(new HtmlArrayFormatter());
            Formatter.SetPreferredMimeTypeFor(typeof(RetArray<double>), HtmlFormatter.MimeType);
            Formatter.SetPreferredMimeTypeFor(typeof(RetArray<float>), HtmlFormatter.MimeType);
            Formatter.Register(new HtmlRetArrayFormatter());
            Formatter.SetPreferredMimeTypeFor(typeof(Array<float>), "text/html");
            Formatter.SetPreferredMimeTypeFor(typeof(RetArray<float>), "text/html");
            Formatter.SetPreferredMimeTypeFor(typeof(Array<long>), "text/html");
            Formatter.SetPreferredMimeTypeFor(typeof(RetArray<long>), "text/html");
            Formatter.SetPreferredMimeTypeFor(typeof(Array<bool>), "text/html");
            Formatter.SetPreferredMimeTypeFor(typeof(RetArray<bool>), "text/html");

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
