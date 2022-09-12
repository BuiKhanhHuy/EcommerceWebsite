using Ecommerce.Common.BLL;
using Ecommerce.Common.Req;
using Ecommerce.DAL;
using Ecommerce.DAL.Models;
using QLBH.Common.Rsp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL
{
    public class ProductSvc: GenericSvc<ProductRep, Product>
    {
        private ProductRep productRep;

        public ProductSvc()
        {
            productRep = new ProductRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var product = _rep.Read(id);
            if (product != null)
            {
                res.Data = product;
            }
            else
            {
                res.SetError("Can not found any item!");
            }
            return res;
        }

        public MultipleRsp Read(string? kw=null)
        {
            var res = new MultipleRsp();
            var resList = _rep.Read(kw);
            if ((resList != null) && (resList.Any()))
            {
                resList.ForEach(e => res.SetData(e.Id.ToString(), e));
            }
            else
            {
                res.SetError("Can not found any item!");
            }
            return res;
        }

        public MultipleRsp ReadByIdCat(int IdCat)
        {
            var res = new MultipleRsp();
            var resList = new List<Product>();
            resList = _rep.ReadByIdCat(IdCat);
            if ((resList != null) && (resList.Any()))
            {
                resList.ForEach(e => res.SetData(e.Id.ToString(), e));
            }
            else
            {
                res.SetError("Can not found any item!");
            }
            return res;
        }

        public SingleRsp Update(int Id, ProductAddOrUpdateReq productUpdateReq)
        {
            Product product = new Product();
            product.Id = Id;
            product.Name = productUpdateReq.Name;
            product.Description = productUpdateReq.Description;
            product.Price = productUpdateReq.Price;
            product.Manufacturer = productUpdateReq.Manufacturer;
            product.Image = productUpdateReq.Image;
            product.CategoryId = productUpdateReq.CategoryId;
            return _rep.Update(product);
        }

        public override SingleRsp Delete(int id)
        {
            return _rep.Delete(id); ;
        }

        public SingleRsp AddProdcut(ProductAddOrUpdateReq productAddReq)
        {
            Product product = new Product();
            product.Name = productAddReq.Name;
            product.Price = productAddReq.Price;
            product.Description = productAddReq.Description;
            product.Manufacturer = productAddReq.Manufacturer;
            product.Image = productAddReq.Image;
            product.CategoryId = productAddReq.CategoryId;
            return _rep.AddProduct(product);
        }
    }
}
