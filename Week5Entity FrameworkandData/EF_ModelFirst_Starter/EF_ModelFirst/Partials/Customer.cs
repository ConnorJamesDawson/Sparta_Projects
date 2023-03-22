using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst
{
    public partial class Customer
    {
        public override string ToString()
        {
            return $"{CustomerId} - {ContactName} - {City} - {PostalCode}";
        }
    }
}
