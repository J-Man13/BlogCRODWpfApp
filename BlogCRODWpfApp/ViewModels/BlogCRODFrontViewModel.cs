using BlogCRODWpfApp.Model;
using BlogCRODWpfApp.Services;
using BlogCRODWpfApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BlogCRODWpfApp.ViewModels
{
    public class BlogCRODFrontViewModel
    {
        public BlogCRODFrontDataContext BlogCRODFrontDataContext { get; set; }

        private IModelsAccess<SupplierModel> SupplierModelsDataAccess;
        private IModelsAccess<ProductModel> ProductModelsDataAccess;

        public BlogCRODFrontViewModel()
        {
            BlogCRODFrontDataContext = new BlogCRODFrontDataContext();
            ProductModelsDataAccess = new ProductModelMSSQLModelsAccess();
            SupplierModelsDataAccess = new ModelsAccessSupplierModelMSSQL();

            try { GetProductSupplierFrontWrapperModels();}
            catch (Exception e) { MessageBox.Show("Db accsess exception : " + e.Message); return; }

            BlogCRODFrontDataContext.SearchProduct = new CommmandFrame((Object obj) =>
            {
                try { GetProductSupplierFrontWrapperModels(); }
                catch (Exception e) { MessageBox.Show("Db accsess exception : " + e.Message); return; }
                BlogCRODFrontDataContext.ObservableCollectionGoodsListBoxTemp
                .Where(x => !(x.ProductModel.ProductName.Trim().ToLower().Contains(BlogCRODFrontDataContext.ProductNameSearch.Trim().ToLower()))).ToList()
                .All(x => BlogCRODFrontDataContext.ObservableCollectionGoodsListBoxTemp.Remove(x));

            }, true);

            BlogCRODFrontDataContext.ClickAddCommmand = new CommmandFrame(AddData,true);

            BlogCRODFrontDataContext.ClickModifyCommand = new CommmandFrame( (Object obj) =>
            {
                if((obj as ProductModel).ProductName.Trim() == "")
                {
                    MessageBox.Show("Product name cannot be empty");
                    return;
                }

                try {
                    Decimal.Parse((obj as ProductModel).UnitPrice.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Inapropriate product price");
                    return;
                }
                try { ProductModelsDataAccess.UpdateModel((obj as ProductModel), (obj as ProductModel).Id); } catch (Exception e) { MessageBox.Show(e.Message); }

            },true);

            BlogCRODFrontDataContext.ClickDeleteCommmand = new CommmandFrame( (Object obj) =>
            {
                try { ProductModelsDataAccess.RemoveModel((obj as ProductSupplierWrapperModel).ProductModel.Id);}
                catch (Exception e) { MessageBox.Show("Db accsess exception : " +e.Message); return; } 
                BlogCRODFrontDataContext.ObservableCollectionGoodsListBoxTemp.Remove(obj as ProductSupplierWrapperModel);
            }, true);

            BlogCRODFrontDataContext.ClickShowCommmand = new CommmandFrame((Object obj) =>
            {
                BlogCRODFrontDataContext.ProductFullInfo = (obj as ProductSupplierWrapperModel).ToString();
            }, true);

        }

        public void AddData(Object obj)
        {
            if (BlogCRODFrontDataContext.ProductNameAdd.Trim() == "" ||
                    BlogCRODFrontDataContext.ProductPriceAdd.Trim() == "" ||
                    BlogCRODFrontDataContext.ProductPackageTypeAdd.Trim() == "" ||
                    BlogCRODFrontDataContext.ProductCompanyNameAdd.Trim() == "" ||
                    BlogCRODFrontDataContext.ProductContactNameAdd.Trim() == "" ||
                    BlogCRODFrontDataContext.ProductCityNameAdd.Trim() == "" ||
                    BlogCRODFrontDataContext.ProductCountryNameAdd.Trim() == "" ||
                    BlogCRODFrontDataContext.ProductPhoneFaxAdd.Trim() == "")
            {
                MessageBox.Show("Not all fields are filled");
                return;
            }

            try
            {
                Decimal.Parse(BlogCRODFrontDataContext.ProductPriceAdd);
            }
            catch (Exception)
            {
                MessageBox.Show("Inapropriate unit price");
                return;
            }

            AddProductAndSupplier();
            BlogCRODFrontHelpers.CleanTab1(BlogCRODFrontDataContext);
        }

        public void AddProductAndSupplier()
        {
            SupplierModel supplierModel = BlogCRODFrontViewModelsInitializer.SupplierModelInitializer(BlogCRODFrontDataContext);
            int supplierModelId = SupplierModelsDataAccess.AddModel(supplierModel);
            supplierModel.Id = supplierModelId;

            ProductModel productModel = BlogCRODFrontViewModelsInitializer.ProductModelInitializer(BlogCRODFrontDataContext, supplierModel.Id);
            int productModelId = ProductModelsDataAccess.AddModel(productModel);
            productModel.Id = productModelId;

            BlogCRODFrontDataContext.ObservableCollectionGoodsListBoxTemp.Add(new ProductSupplierWrapperModel()
            {
                SupplierModel = supplierModel,
                ProductModel = productModel
            });
        }

        public void GetProductSupplierFrontWrapperModels()
        {
            LinkedList<ProductSupplierWrapperModel> productSupplierFrontWrapperModels = new LinkedList<ProductSupplierWrapperModel>();
            LinkedList<ProductModel> products = new LinkedList<ProductModel>(ProductModelsDataAccess.GetAllModels());
            foreach(ProductModel p in products)
            {
                ProductSupplierWrapperModel productSupplierFrontWrapperModel = new ProductSupplierWrapperModel();
                productSupplierFrontWrapperModel.ProductModel = p;
                productSupplierFrontWrapperModel.SupplierModel = SupplierModelsDataAccess.GetModelById(p.SupplierId);
                productSupplierFrontWrapperModels.AddLast(productSupplierFrontWrapperModel);
            }
            BlogCRODFrontDataContext.ObservableCollectionGoodsListBoxTemp = new ObservableCollection<ProductSupplierWrapperModel>(productSupplierFrontWrapperModels);

        }



    }
}
