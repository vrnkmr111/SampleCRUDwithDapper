﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleCRUDwithDapper.ViewModels
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string Addess1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}