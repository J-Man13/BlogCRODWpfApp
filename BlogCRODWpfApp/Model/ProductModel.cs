using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRODWpfApp.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public String ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public String Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public ProductModel()
        {

        }
        public override string ToString()
        {
            return "Product Info\n"+"Product name - " + ProductName + "\n" +
                   "Unit price - " + UnitPrice + "\n" +
                   "Package type - " + Package + "\n" +
                   "Is discounted - " + IsDiscontinued + "\n";
        }
    }
}
