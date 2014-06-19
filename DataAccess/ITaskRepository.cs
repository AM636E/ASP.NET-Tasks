using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Represents task repository.
    /// Exposes methods to manage tasks in db.
    /// </summary>
    interface ITaskRepository
    {
        /// <summary>
        /// Get all entities from repository.
        /// </summary>
        /// <returns></returns>
        List<Entities.Task> GetAll();

        /// <summary>
        /// Get task by id.
        /// </summary>
        /// <param name="id">Id of task</param>
        /// <returns></returns>
        Entities.Task GetById(int id);

        /// <summary>
        /// Update task in database.
        /// </summary>
        /// <param name="task">Task to update</param>
        void UpdateTask(Entities.Task task);

        /// <summary>
        /// Insert new task into repository.
        /// </summary>
        /// <param name="task">Task to insert</param>
        void InsertTask(Entities.Task task);

        /// <summary>
        /// Delete task from repository.
        /// </summary>
        /// <param name="id">Id of task to delete</param>
        void DeleteTask(Entities.Task id);

        /// <summary>
        /// Task count
        /// </summary>
        /// <returns></returns>
        int GetTaskCount();
    }
}
