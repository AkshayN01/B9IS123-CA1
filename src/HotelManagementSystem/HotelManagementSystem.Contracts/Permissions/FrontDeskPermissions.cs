using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Contracts.Permissions
{
    public static class FrontDeskPermissions
    {
        public const string AddBooking = "frontdesk:booking:add";
        public const string ViewBooking = "frontdesk:booking:view";
        public const string ApproveBooking = "frontdesk:booking:approve";
        public const string DeclineBooking = "frontdesk:booking:decline";
        public const string EditBooking = "frontdesk:booking:edit";


        public const string AddRoom = "frontdesk:room:add";
        public const string ViewRoom = "frontdesk:room:view";
    }
}
