﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebServices.Controllers
{
    public class ProductsController : ApiController
    {
        public string Get()
        {
            return "Hello World!";
        }
    }
}
