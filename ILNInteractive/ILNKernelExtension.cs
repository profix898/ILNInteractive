using System;
using System.Threading.Tasks;
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
            Formatter.Register<DateTime>((date, writer) => { writer.Write(HtmlImage.DrawNotImplemented()); }, "text/html");

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