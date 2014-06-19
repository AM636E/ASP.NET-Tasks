﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
namespace TodoList
{
    public partial class Tasks : System.Web.UI.Page
    {
        private TaskRepository _repository;

        protected void Page_Init(object sender, EventArgs e)
        {
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvTask_Sorting(object sender, GridViewSortEventArgs e)
        {
            var grid = (GridView)sender;
            var tasks = (IEnumerable<Entities.Task>)grid.DataSource;
            
            if(e.SortDirection == SortDirection.Ascending)
            {
                tasks = tasks.OrderBy(s => { 
                    return s.Id; 
                }
                    );
            }
            else
            {
                tasks = tasks.OrderByDescending(s => s.Id);
            }
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static Entities.Task GetTask(int taskId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TodoListEntities"].ConnectionString;
            TaskRepository repository = new TaskRepository(connectionString);

            var task = repository.GetById(taskId);

            return task;
        }
    }
}