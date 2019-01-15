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
    class ModelsAccessSupplierModelMSSQL : IModelsAccess<SupplierModel>
    {
        private masterEntities1 masterEntities;

        public ModelsAccessSupplierModelMSSQL()
        {
            masterEntities = DbAccessHelper.MasterEntities;
        }

        public int AddModel(SupplierModel t)
        {
            Supplier s = new Supplier()
            {
                CompanyName = t.CompanyName,
                ContactName = t.ContactName,
                ContactTitle = t.ContactTitle,
                City = t.City,
                Country = t.Country,
                Phone = t.Phone,
                Fax = t.Fax
            };
            masterEntities.Suppliers.Add(s);
            masterEntities.SaveChanges();
            return s.Id;
        }


        public bool RemoveModel(long id)
        {
            Supplier s = masterEntities.Suppliers.FirstOrDefault(su => su.Id == id);
            if (s == null)
                return false;
            masterEntities.Suppliers.Remove(s);
            masterEntities.SaveChanges();
            return true;

        }
        public bool UpdateModel(SupplierModel NewModel, long oldModelId)
        {
            Supplier s = masterEntities.Suppliers.FirstOrDefault(su => su.Id == oldModelId);
            if (s == null)
                return false;
            s.CompanyName = NewModel.CompanyName;
            s.ContactName = NewModel.ContactName;
            s.ContactTitle = NewModel.ContactTitle;
            s.City = NewModel.City;
            s.Country = NewModel.Country;
            s.Phone = NewModel.Phone;
            s.Fax = NewModel.Fax;
            masterEntities.SaveChanges();
            return true;

        }

        public IEnumerable<SupplierModel> GetAllModels()
        {
            LinkedList<SupplierModel> linkedList = new LinkedList<SupplierModel>();
            foreach (Supplier s in masterEntities.Suppliers)
                linkedList.AddLast(new SupplierModel()
                {
                    Id = s.Id,
                    CompanyName = s.CompanyName,
                    ContactName = s.ContactName,
                    ContactTitle = s.ContactTitle,
                    City = s.City,
                    Country = s.Country,
                    Phone = s.Phone,
                    Fax = s.Fax
                });
            return linkedList;
        }

        public SupplierModel GetModelById(long id)
        {
            Supplier s = masterEntities.Suppliers.FirstOrDefault(su => su.Id == id);
            if (s == null)
                return null;
            return new SupplierModel()
            {
                Id = s.Id,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                ContactTitle = s.ContactTitle,
                City = s.City,
                Country = s.Country,
                Phone = s.Phone,
                Fax = s.Fax
            };

        }
    }
}