using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PDS2_Store.Models
{
    public class Admin : IdentityUser
    {
    }

    public class RequestStatus
    {
        public int RequestStatusId { get; set; }
        public string Estado { get; set; }
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }
    }
}