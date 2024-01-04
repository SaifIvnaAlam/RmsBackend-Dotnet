using DAL.Domain.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProductRepo : Repo, IRepo<Product, int, bool>
    {
        public bool Create(Product obj)
        {
            {
                db.Products.Add(obj);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public bool Delete(int id)
        {

           var product= db.Products.FirstOrDefault(c => c.Id == id);
            if (product != null)
            {
                db.Products.Remove(product);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<Product> Read()
        {
            return db.Products.ToList();
        }

        public Product Read(int id)
        {
            return db.Products.Find(id);

        }

        public bool Update(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
