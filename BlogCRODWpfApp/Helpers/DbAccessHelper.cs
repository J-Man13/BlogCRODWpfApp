using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRODWpfApp.Helpers
{
    public class DbAccessHelper
    {
        private static masterEntities1 mE;

        public static masterEntities1 MasterEntities {
            get {
                if (mE == null)
                    mE = new masterEntities1();
                return mE;
            }
        }
    }
}
