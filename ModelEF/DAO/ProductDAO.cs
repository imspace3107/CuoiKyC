using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDAO
    {
        private TraQuangLinh db = null;
        public ProductDAO()
        {
            db = new TraQuangLinh();
        }


        public bool Insert(Product entityProduct)
        {
            try
            {
                db.Products.Add(entityProduct);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int ID)
        {
            try
            {
                Product product = Find1(ID);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public Product Find1(int ID)
        {
            return db.Products.Find(ID);
        }

        public Product Find(string ID)
        {
            return db.Products.Find(ID);
        }

        public List<Product> ListAll()
        {
            return db.Products.ToList();
        }

        public IEnumerable<Product> ListWhereAll(string searchKey, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchKey))
            {
                model = model.Where(x => x.Name.Contains(searchKey));
            }
            return model.OrderBy(x => x.Name);
        }

    }
}
