using System.Threading.Tasks;
using ILNInteractive.Formatters;
using ILNumerics;
using ILNumerics.Drawing;
using Microsoft.DotNet.Interactive;
using Microsoft.DotNet.Interactive.Formatting;
using static Microsoft.DotNet.Interactive.Formatting.PocketViewTags;

namespace ILNInteractive
{
    public class ILNKernelExtension : IKernelExtension
    {
        #region IKernelExtension Members

        public Task OnLoadAsync(Kernel kernel)
        {
            // Arrays
            //Formatter.SetPreferredMimeTypeFor(typeof(Array<>), "text/html");
            //Formatter.Register(new HtmlArrayFormatter());
            //Formatter.SetPreferredMimeTypeFor(typeof(RetArray<>), "text/html");
            //Formatter.Register(new HtmlRetArrayFormatter());

            //// SceneGraph
            //Formatter.SetPreferredMimeTypeFor(typeof(Scene), "text/html");
            //Formatter.Register(new HtmlSceneFormatter());

            if (KernelInvocationContext.Current is { } context)
            {
                PocketView view = div(code(nameof(ILNInteractive)), " extension is loaded. It adds math support and visualizations for ILNumerics projects.");
                context.Display(view);
            }

            return Task.CompletedTask;
        }

        #endregion
    }
}
