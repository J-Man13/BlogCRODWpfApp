using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRODWpfApp.Services
{
    interface IModelsAccess<T>
    {
        int AddModel(T t);
        bool RemoveModel(long id);
        bool UpdateModel(T NewModel, long oldModelId);
        T GetModelById(long id);
        IEnumerable<T> GetAllModels();
    }
}
