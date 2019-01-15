using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRODWpfApp.Model
{
    public class SupplierModel
    {
        public int Id { get; set; }
        public String CompanyName { get; set; }
        public String ContactName { get; set; }
        public String ContactTitle { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String Phone { get; set; }
        public String Fax{ get; set; }

        public SupplierModel()
        {
        }

        public override string ToString()
        {
            return "Supplier Info\n"+"Company name - " + CompanyName + "\n" +
                   "Contact name - " + ContactName + "\n" +
                   "Contact title - " + ContactTitle + "\n" +
                   "City - " + City + "\n" +
                   "Country - " + Country + "\n" +
                   "Phone - " + Phone + "\n" +
                   "Fax - " + Fax + "\n";
        }

    }
}
