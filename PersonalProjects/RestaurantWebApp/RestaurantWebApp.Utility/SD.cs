using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApp.Utility
{
    public static class SD
    {
        public const string ManagerRole = "Manager";
        public const string KitchenRole = "Kitchen";
        public const string FrontDeskRole = "Front";
        public const string CustomerRole = "Customer";

        public const string StatusPending = "Submitted Pending Payment";
        public const string StatusSubmitted = "Submitted Payment Approved";
        public const string StatusRejected = "Payment Rejected";
        public const string StatusInProcess = "In Process of Being Prepared";
        public const string StatusReady = "Ready";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";
        public const string SessionCart = "SessionCart";
    }
}
