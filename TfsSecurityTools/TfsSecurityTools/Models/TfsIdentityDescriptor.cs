﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsSecurityTools.Models
{
    public class TfsIdentityDescriptor
    {
        public string DisplayName { get; set; }

        public Guid TeamFoundationId { get; set; }
    }
}
