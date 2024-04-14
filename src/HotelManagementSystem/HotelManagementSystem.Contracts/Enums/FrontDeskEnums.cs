using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Contracts.Enums
{
    public enum BookinStatusEnum
    {
        Pending = 1,
        Approved = 2,
        Declined = 3
    }

    public enum RoomStatusEnum
    {
        Booked = 1,
        Vacant = 2,
        CleaningInProgress = 3
    }
}
