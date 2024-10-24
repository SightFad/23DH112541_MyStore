using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _23DH112541_MyStore.Models.ViewModel
{
    public class ProductSearchVM
    {
        public string SearchTerm { get; set; }
        public List<Product> Products { get; set; }
    }
}