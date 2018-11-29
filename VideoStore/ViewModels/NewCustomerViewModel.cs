using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoStore.Models;

namespace VideoStore.ViewModels
{
    public class NewCustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable< MembershipType> MembershipType { get; set; }
        
    }
}