// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;

namespace IdentityServerHost.Quickstart.UI
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string Username { get; set; }
        public string ReturnUrl { get; set; }
        public bool IsConfirmationPage { get; set; }
        public bool IsPasswordRequestSuccess { get; set; }
    }
}