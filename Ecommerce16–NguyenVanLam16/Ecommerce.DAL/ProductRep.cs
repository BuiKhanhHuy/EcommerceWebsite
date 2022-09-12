using Ecommerce.Common.DAL;
using Ecommerce.Common.Rsp;
using Ecommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class ProductRep : GenericRep<EcommerceDbContext, Product>
    {
        public ProductRep() { }

        public override Product Read(int id)
        {
            var res = All.FirstOrDefault(e => e.Id == id);
            return res;
        }

        public List<Product> Read(string? kw = null)
        {
            var res = new List<Product>();
            if (kw == null)
            {
                return base.Read();
            }
            else
            {
                using (var context = new EcommerceDbContext())
                {
                    return res = context.Products.Where(e => e.Name.Contains(kw) || e.Price.ToString() == kw || e.Category.Name.Contains(kw) || e.Manufacturer.Contains(kw) || e.Description.Contains(kw)).ToList();
                }
            }
        }

        public List<Product> ReadByIdCat(int IdCat)
        {
            var res = new List<Product>();
            using (var context = new EcommerceDbContext())
            {
                return res = context.Products.Where(e => e.CategoryId == IdCat).ToList();
            }
        }

        public SingleRsp Update(Product product)
        {
            var res = new SingleRsp();
            Product old = All.FirstOrDefault(e => e.Id == product.Id);
            if (old == null)
            {
                res.SetError("Snack doesn't exist!");
                return res;
            }
            else
            {
                using (var context = new EcommerceDbContext())
                {
                    using (var tran = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var cat = context.Products.Update(product);
                            context.SaveChanges();
                            tran.Commit();
                            res.Data = product;
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            res.SetError(ex.StackTrace);
                        }
                    }
                }
                return res;
            }
        }

        public SingleRsp Delete(int id)
        {
            var res = new SingleRsp();
            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var snack = context.Products.Remove(context.Products.FirstOrDefault(m => m.Id == id));
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp AddProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var cat = context.Products.Add(product);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = product;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
