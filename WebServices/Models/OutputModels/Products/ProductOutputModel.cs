using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models.OutputModels.Products
{
    public class ProductOutputModel
    {
        /// <summary>
        /// Id produktu
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nazwa produktu
        /// </summary>
        public string Name { get; set; }
    }
}