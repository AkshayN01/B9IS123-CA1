// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using IdentityServer4.Services;
using Lighthouse.IdentityServer.Quickstart.Home;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerHost.Quickstart.UI
{
    [SecurityHeaders]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration, IIdentityServerInteractionService interaction, IWebHostEnvironment environment, ILogger<HomeController> logger)
        {
            _interaction = interaction;
            _environment = environment;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            //if (_environment.IsDevelopment())
            //{
            //    // only show in development
            //    return View();
            //}
            var user = HttpContext.User.Identity as ClaimsIdentity;

            var clients = _configuration.GetSection("Clients").Get<List<Client>>();
            var model = new DiagnosticsViewModel(await HttpContext.AuthenticateAsync());

            var vm = new HomeViewModel()
            {
                AllClients = clients.Where(x => x.AllowedGrantTypes.Contains("authorization_code")).ToList(),
                AuthenticatedClients = clients.Where(x => model.Clients.Any(clientId => clientId == x.ClientId)).ToList()
            };
            return View(vm);
        }

        /// <summary>
        /// Shows the error page
        /// </summary>
        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;

                if (!_environment.IsDevelopment())
                {
                    // only show in development
                    message.ErrorDescription = null;
                }
            }

            return View("Error", vm);
        }
    }
}