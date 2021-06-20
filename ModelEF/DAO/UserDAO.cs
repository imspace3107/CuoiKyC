using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDAO
    {
        private TraQuangLinh db = null;
        public UserDAO()
        {
            db = new TraQuangLinh();
        }

        public int postLogin(string user, string pass)
        {
            var kq = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(user) && x.Password.Contains(pass));
            if (kq == null)
            {
                return 0;
            }
            else
            {
                if (kq.UserName == "Admin")
                {
                    return 1;
                }
                return 0;
            }
        }
        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }

        public IEnumerable<UserAccount> ListWhereAll(string searchKey, int page, int pageSize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(searchKey))
            {
                model = model.Where(x => x.UserName.Contains(searchKey));
            }
            return model.OrderBy(x => x.UserName);
        }
        public bool PostDelete(int Id)
        {
            try
            {
                var ID = db.UserAccounts.Find(Id);
                db.UserAccounts.Remove(ID);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //tìm kiếm người dùng
        public UserAccount Find(int Id)
        {
            return db.UserAccounts.Find(Id);
        }
    }
}
