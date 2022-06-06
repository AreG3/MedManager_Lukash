using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MedManager.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MedManagerUser class
public class MedManagerUser : IdentityUser
{
    public string Nick { get; set; }
}

