// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;

namespace IdentityServerHost.Quickstart.UI
{
    public class ResetPasswordViewModel
    {
        public bool IsNewUser { get; set; }
        [Required]
        public string PasswordResetToken { get; set; }
        public string ReturnUrl { get; set; }
        public bool IsPasswordResetSuccess { get; set; }
        public bool IsPasswordResetTokenValid { get; set; }
        public string PasswordResetValidationMessage { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}