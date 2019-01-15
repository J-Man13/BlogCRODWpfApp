using BlogCRODWpfApp.Helpers;
using BlogCRODWpfApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRODWpfApp.View
{
    public class BlogCRODFrontDataContext : ObservableObject
    {
        private String productNameAdd;
        public String ProductNameAdd{ get{ return productNameAdd;} set { Set(ref productNameAdd,value);}}

        private String productPriceAdd;
        public String ProductPriceAdd { get { return productPriceAdd; } set { Set(ref productPriceAdd, value); } }

        private String productPackageTypeAdd;
        public String ProductPackageTypeAdd { get {return productPackageTypeAdd;} set { Set(ref productPackageTypeAdd, value);} }

        private String productCompanyNameAdd;
        public String ProductCompanyNameAdd { get {return productCompanyNameAdd; } set { Set(ref productCompanyNameAdd, value);} }

        private String productContactNameAdd;
        public String ProductContactNameAdd { get { return productContactNameAdd; } set {Set(ref productContactNameAdd, value);} }

        private String productCityNameAdd;
        public String ProductCityNameAdd { get {return productCityNameAdd;} set {Set(ref productCityNameAdd, value);} }

        private String productCountryNameAdd;
        public String ProductCountryNameAdd { get { return productCountryNameAdd; } set { Set(ref productCountryNameAdd, value); }}

        private String productPhoneFaxAdd;
        public String ProductPhoneFaxAdd { get { return productPhoneFaxAdd;}  set { Set(ref productPhoneFaxAdd, value); } }



        private bool isDiscounted;
        public bool IsDiscounted { get {return isDiscounted;} set { Set(ref isDiscounted, value); } }

        private String productNameSearch;
        public String ProductNameSearch { get { return productNameSearch; } set {Set(ref productNameSearch, value);} }

        private ObservableCollection<ProductSupplierWrapperModel> observableCollectionGoodsListBoxTemp;

        public ObservableCollection<ProductSupplierWrapperModel> ObservableCollectionGoodsListBoxTemp{
            get
            {
                return observableCollectionGoodsListBoxTemp;
            }
            set
            {
                Set(ref observableCollectionGoodsListBoxTemp, value);
            }
        }

        private String productFullInfo;
        public String ProductFullInfo { get { return productFullInfo; } set { Set(ref productFullInfo,value);} }



        public BlogCRODFrontDataContext()
        {
            ProductNameAdd = "";
            ProductPriceAdd = "";
            ProductPackageTypeAdd = "";
            ProductCompanyNameAdd = "";
            ProductContactNameAdd = "";
            ProductCityNameAdd = "";
            ProductCountryNameAdd = "";
            ProductPhoneFaxAdd = "";
            ProductNameSearch = "";
            ObservableCollectionGoodsListBoxTemp = null;
            ProductFullInfo = "";
            IsDiscounted = false;
        }

        private CommmandFrame searchProduct;
        public CommmandFrame SearchProduct
        {
            get
            {
                return searchProduct;
            }
            set
            {
                Set(ref searchProduct, value);
            }

        }



        private CommmandFrame clickAddCommmand;
        public CommmandFrame ClickAddCommmand
        {
            get
            {
                return clickAddCommmand;
            }
            set
            {
                Set(ref clickAddCommmand , value);
            }
        }

        private CommmandFrame clickModifyCommand;
        public CommmandFrame ClickModifyCommand
        {
            get
            {
                return clickModifyCommand;
            }
            set
            {
                Set(ref clickModifyCommand, value);
            }
        }


        private CommmandFrame clickDeleteCommmand;
        public CommmandFrame ClickDeleteCommmand
        {
            get
            {
                return clickDeleteCommmand;
            }
            set
            {
                Set(ref clickDeleteCommmand, value);
            }
        }

        private CommmandFrame clickShowCommmand;
        public CommmandFrame ClickShowCommmand
        {
            get
            {
                return clickShowCommmand;
            }
            set
            {
                Set(ref clickShowCommmand, value);
            }
        }

        

    }
}
