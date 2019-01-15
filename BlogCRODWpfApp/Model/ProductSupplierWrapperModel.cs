using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRODWpfApp.Model
{
    public class ProductSupplierWrapperModel
    {
        public ProductModel ProductModel { get; set; }
        public SupplierModel SupplierModel { get; set; }

        public ProductSupplierWrapperModel()
        {
            ProductModel = null;
            SupplierModel = null;
        }

        public override string ToString()
        {
            return ProductModel.ToString() + SupplierModel.ToString();
        }
    }
}
