using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwinInterface = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;


namespace OWINWebApi
{
    internal class WebApiModule
    {
        private readonly OwinInterface _next;
        public WebApiModule(OwinInterface next)
        {
            if (next == null)
            {
                throw new ArgumentNullException("next");
            }
            this._next = next;
        }
        public Task Invoke(IDictionary<string, object> env)
        {
            try
            {
                var request = new OwinRequest(env);
                var path = request.Path.Value.TrimEnd(new[] { '/' });
                if (path.Equals("/contacts", StringComparison.OrdinalIgnoreCase))
                {
                    var response = new OwinResponse(env);
                    return response.WriteAsync("My email: ramirkiev@gmail.com, phone: 0503310816");
                }
                Debug.WriteLine("{0} Request: {1}", env["owin.RequestPath"]);
            }
            catch (Exception ex)
            {
                var tcs = new TaskCompletionSource<object>();
                tcs.SetException(ex);
                return tcs.Task;
            }
            return this._next(env);
        }
    }
}
