using HomeFinances.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.Model.Repositories
{
    public class CategoryRepository : DapperRepository<Category>
    {
        public CategoryRepository() : base("Categories")
        {

        }
    }
}
