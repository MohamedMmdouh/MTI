using System.Security.Principal;

namespace MTI.Controllers
{
    internal class MyPrincipal
    {
        private GenericIdentity identity;

        public MyPrincipal(GenericIdentity identity)
        {
            this.identity = identity;
        }
    }
}