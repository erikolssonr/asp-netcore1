using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class AccountDetailsViewModel
    {
        public AccountBasicInfo BasicInfo { get; set; } = null!;
        public AccountAddressInfo AddressInfo { get; set; } = null!;
    }
}
