using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public List<Entities.User> GetAll()
        {
            using (DbContext context = new DbContext(this._connectionString))
            {
                return context.Set<Entities.User>().ToList();
            }
        }

        public Entities.User GetById(int id)
        {
            using (Entities.TodoListEntities context = new Entities.TodoListEntities())
            {
                return context.Users.Find(id);
            }
        }

        public void InsertUser(Entities.User user)
        {
            using (Entities.TodoListEntities context = new Entities.TodoListEntities())
            {
                user.Disabled = false;
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void UpdateUser(Entities.User user)
        {
            using (Entities.TodoListEntities context = new Entities.TodoListEntities())
            {
                try
                {
                    context.Users.Attach(user);
                    var entry = context.Entry(user);
                    entry.Property("FirstName").IsModified = true;
                    entry.Property("SurName").IsModified = true;
                    entry.Property("Email").IsModified = true;
                    entry.Property("Pass").IsModified = true;
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceWarning("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }
        }

        public void DeleteUser(Entities.User user)
        {
            using (Entities.TodoListEntities context = new Entities.TodoListEntities())
            {
                context.Users.Attach(user);
                foreach (var task in user.Tasks)
                {
                    context.Tasks.Attach(task);
                    context.Tasks.Remove(task);
                }
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public int GetUsersCount()
        {
            return this.GetAll().Count;
        }


        public bool DoesUserExists(string username, string password)
        {
            using (Entities.TodoListEntities context = new Entities.TodoListEntities())
            {
                return context.Users.Any(r => r.Login == username && r.Pass == password);
            }
        }


        public string GetFirstName(string username)
        {
            return this.GetByLogin(username).FirstName;
        }


        public Entities.User GetByLogin(string login)
        {
            using (Entities.TodoListEntities context = new Entities.TodoListEntities())
            {
                return context.Users.Where(e => e.Login == login).First();
            }
        }
    }
}
