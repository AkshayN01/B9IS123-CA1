using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Contracts.APIModels.Admin
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public string UserGuid { get; set; } = string.Empty;
        public List<string> Permissions { get; set; } = new List<string>();
        public List<string> Roles { get; set; } = new List<string>();

    }
}
