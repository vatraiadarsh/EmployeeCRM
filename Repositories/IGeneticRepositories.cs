using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adarsh.EmployeeCRM.Web.Repositories
{
    public interface IGeneticRepositories<TModel> where TModel : class
    {
        List<TModel> GetAll();
        TModel GetById(int id);
        int Insert(TModel model);

       



    }
}