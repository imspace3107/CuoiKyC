using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDAO
    {
        private TraQuangLinh db = null;
        public CategoryDAO()
        {
            db = new TraQuangLinh();
        }

        public bool Insert(Category entityCat)
        {

            db.Categories.Add(entityCat);
            db.SaveChanges();
            return true;
        }

        public Category Find(string ID)
        {
            return db.Categories.Find(ID);
        }

        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }

        public bool Update(Category entityCat)
        {
            try
            {
                var catID = Find(entityCat.ID.ToString());
                if (!string.IsNullOrEmpty(entityCat.Name))
                {
                    catID.Name = entityCat.Name;
                }
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool Delete(string ID)
        {
            try
            {
                Category category = db.Categories.Find(ID);
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
