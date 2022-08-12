using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OWINWebApi.Controllers
{
    internal class HomeController : ApiController
    {
        public IEnumerable<int> GetValues()
        {
            return Enumerable.Range(0, 100);
        }
    }
}
