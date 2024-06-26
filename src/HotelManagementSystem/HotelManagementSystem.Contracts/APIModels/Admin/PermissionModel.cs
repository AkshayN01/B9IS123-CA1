using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Contracts.APIModels.Admin
{
    public class PermissionModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}