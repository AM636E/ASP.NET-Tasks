using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Objects;

namespace DataAccess
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _connectionString;
        public TaskRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public List<Entities.Task> GetAll()
        {
            using (DbContext context = new DbContext(this._connectionString))
            {
                return context.Set<Entities.Task>().OrderBy(s=>s.Priority).OrderBy(s=>s.IsDone).ToList();
            }
        }

        public Entities.Task GetById(int id)
        {
            using (Entities.TodoListEntities context = (new Entities.TodoListEntities()))
            {
                var task = context.Tasks.Find(id);
                context.Users.Attach(task.User);

                return task;
            }
        }

        public void UpdateTask(Task task)
        {
            throw new NotImplementedException();
        }

        public void InsertTask(Entities.Task task)
        {
            using (DbContext context = new DbContext(this._connectionString))
            {
                task.Created = DateTime.Now;
                task.User_Id = 6;
                context.Set<Entities.Task>().Add(task);
                context.SaveChanges();
            }
        }

        public void DeleteTask(Entities.Task task)
        {           
            using (Entities.TodoListEntities context = (new Entities.TodoListEntities()))
            {
                context.Tasks.Attach(task);
                context.Tasks.Remove(task);
                context.SaveChanges();
            }
        }

        public int GetTaskCount()
        {
            using (DbContext context = new DbContext(this._connectionString))
            {
                return context.Set<Entities.Task>().ToList().Count;
            }
        }

        public void UpdateTask(Entities.Task task)
        {
            using (Entities.TodoListEntities context = (new Entities.TodoListEntities()))
            {
                context.Tasks.Attach(task);
                var entry = context.Entry(task);
                entry.Property(e => e.Text).IsModified = true;
                entry.Property(e => e.Title).IsModified = true;
                entry.Property(e => e.IsDone).IsModified = true;
                entry.Property(e => e.Deadline).IsModified = true;
                context.SaveChanges();
            }       
        }
    }
}
