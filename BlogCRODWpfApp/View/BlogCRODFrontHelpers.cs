using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRODWpfApp.View
{
    class BlogCRODFrontHelpers
    {
        public static void CleanTab1(BlogCRODFrontDataContext blogCRODFrontDataContext)
        {
            blogCRODFrontDataContext.ProductNameAdd = "";
            blogCRODFrontDataContext.ProductPriceAdd = "";
            blogCRODFrontDataContext.ProductPackageTypeAdd = "";
            blogCRODFrontDataContext.ProductCompanyNameAdd = "";
            blogCRODFrontDataContext.ProductContactNameAdd = "";
            blogCRODFrontDataContext.ProductCityNameAdd = "";
            blogCRODFrontDataContext.ProductCountryNameAdd = "";
            blogCRODFrontDataContext.ProductPhoneFaxAdd = "";
        }
    }
}
