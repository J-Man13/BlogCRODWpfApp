using BlogCRODWpfApp.Model;
using BlogCRODWpfApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRODWpfApp.View
{
    public class BlogCRODFrontViewModelsInitializer
    {
        public static SupplierModel SupplierModelInitializer(BlogCRODFrontDataContext blogCRODFrontDataContext) 
        {
            SupplierModel supplierModel = new SupplierModel();
            supplierModel.CompanyName = blogCRODFrontDataContext.ProductCompanyNameAdd;
            supplierModel.ContactName = blogCRODFrontDataContext.ProductContactNameAdd;
            supplierModel.ContactTitle = blogCRODFrontDataContext.ProductContactNameAdd;
            supplierModel.City = blogCRODFrontDataContext.ProductCityNameAdd;
            supplierModel.Country = blogCRODFrontDataContext.ProductCountryNameAdd;
            supplierModel.Phone = blogCRODFrontDataContext.ProductPhoneFaxAdd;
            return supplierModel;
        }

        public static ProductModel ProductModelInitializer(BlogCRODFrontDataContext blogCRODFrontDataContext, int supplierId)
        {
            ProductModel productModel = new ProductModel();
            productModel.ProductName = blogCRODFrontDataContext.ProductCompanyNameAdd;
            productModel.SupplierId = supplierId;
            productModel.UnitPrice = Decimal.Parse(blogCRODFrontDataContext.ProductPriceAdd);            
            productModel.Package = blogCRODFrontDataContext.ProductPackageTypeAdd;
            productModel.IsDiscontinued = blogCRODFrontDataContext.IsDiscounted;
            return productModel;
        }         
    }
}
