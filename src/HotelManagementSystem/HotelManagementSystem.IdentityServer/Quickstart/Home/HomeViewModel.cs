using IdentityServer4.Models;
using System.Collections.Generic;

namespace Lighthouse.IdentityServer.Quickstart.Home
{
    public class HomeViewModel
    {
        public List<Client> AllClients { get; set; }
        public List<Client> AuthenticatedClients { get; set; }
    }
}
