using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlogBlazorUI.Utils
{
    public class CustomErrorBoundary:ErrorBoundary
    {

        [Inject]
        private IWebAssemblyHostEnvironment Environment { get; set; }

        protected override Task OnErrorAsync(Exception exception)
        {
            if(Environment.IsProduction())
            {
                return base.OnErrorAsync(exception);
            }
            return Task.CompletedTask;
        }
    }
}
