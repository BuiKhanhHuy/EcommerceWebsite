using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Common.BLL;
using Ecommerce.Common.Req;
using Ecommerce.Common.Rsp;
using Ecommerce.DAL;
using Ecommerce.DAL.Models;

namespace Ecommerce.BLL
{
    public class CategorySvc : GenericSvc<CategoryRep, Category>
    {
        private CategoryRep categoryRep;

        public CategorySvc()
        {
            this.categoryRep = new CategoryRep();
        }

        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = categoryRep.Read(id);

            return res;
        }

        #endregion

        #region -- Methods
        public SingleRsp AddCategory(CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            Category category = new Category();

            category.Name = categoryReq.Name;
            category.Description = categoryReq.Description;
            res = categoryRep.AddCategory(category);

            return res;
        }

        public SingleRsp UpdateCategory(int id, CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            Category category = new Category();

            category.Id = id;
            category.Name = categoryReq.Name;
            category.Description = categoryReq.Description;
            res = categoryRep.UpdateCategory(category);

            return res;
        }

        public SingleRsp DeleteCategory(int id)
        {
            var res = new SingleRsp();

            res = categoryRep.DeleteCategory(id);

            return res;
        }
        #endregion
    }
}
