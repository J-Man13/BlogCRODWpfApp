using BlogCRODWpfApp.Helpers;
using BlogCRODWpfApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlogCRODWpfApp.Services
{
    public class ProductModelMSSQLModelsAccess : IModelsAccess<ProductModel>
    {

        private masterEntities1 masterEntities;

        public ProductModelMSSQLModelsAccess()
        {
            masterEntities = DbAccessHelper.MasterEntities;
        }

        public int AddModel(ProductModel t)
        {
            Product p = new Product()
            {
                ProductName = t.ProductName,
                UnitPrice = t.UnitPrice,
                Package = t.Package,
                SupplierId = t.SupplierId,
                IsDiscontinued = t.IsDiscontinued
            };
            masterEntities.Products.Add(p);
            masterEntities.SaveChanges();
            return p.Id;
        }

        public bool RemoveModel(long id)
        {

            Product p = masterEntities.Products.First(pr => pr.Id == id);
            if (p == null)
                return false;
            masterEntities.Products.Remove(p);
            masterEntities.SaveChanges();
            return true;
        }

        public bool UpdateModel(ProductModel NewModel, long OldModelId)
        {

            Product pOld = masterEntities.Products.Where(pr => pr.Id == OldModelId).FirstOrDefault();
            if (pOld == null)
                return false;
            pOld.ProductName = NewModel.ProductName;
            pOld.SupplierId = NewModel.SupplierId;
            pOld.UnitPrice = NewModel.UnitPrice;
            pOld.Package = NewModel.Package;
            pOld.IsDiscontinued = NewModel.IsDiscontinued;
            masterEntities.SaveChanges();
            return true;

        }


        public IEnumerable<ProductModel> GetAllModels()
        {

            LinkedList<ProductModel> ls = new LinkedList<ProductModel>();
            foreach (Product pr in masterEntities.Products)
                ls.AddLast(new ProductModel()
                {
                    Id = pr.Id,
                    ProductName = pr.ProductName,
                    SupplierId = pr.SupplierId,
                    UnitPrice = (decimal)pr.UnitPrice,
                    Package = pr.Package,
                    IsDiscontinued = pr.IsDiscontinued
                });
            return ls;

        }

        public ProductModel GetModelById(long id)
        {
            Product p = masterEntities.Products.FirstOrDefault(pr => pr.Id == id);
            if (p == null)
                return null;
            return new ProductModel()
            {
                Id = p.Id,
                ProductName = p.ProductName,
                SupplierId = p.SupplierId,
                UnitPrice = (decimal)(p.UnitPrice),
                Package = p.Package,
                IsDiscontinued = p.IsDiscontinued
            };
        }
    }
}
