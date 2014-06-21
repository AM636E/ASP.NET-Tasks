using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUserRepository
    {
        List<Entities.User> GetAll();
        Entities.User GetById(int id);

        void InsertUser(Entities.User user);

        void UpdateUser(Entities.User user);
        void DeleteUser(Entities.User user);
        int GetUsersCount();
        bool DoesUserExists(string username, string password);

        string GetFirstName(string username);

        Entities.User GetByLogin(string login);
    }
}
