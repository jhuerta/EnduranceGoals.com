using System;
using System.Data;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Objects;
using System.IO;
using System.Web.Mvc;
using EnduranceGoals.Models;

namespace EnduranceGoals.Controllers
{
    public class EFControllerBase : Controller
    {
        protected EnduranceGoalsEntities entity = new EnduranceGoalsEntities();


        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            entity.SaveChanges();
        }

        public void ExecuteSql(string sql)
        {
            var entityConnection = (System.Data.EntityClient.EntityConnection)entity.Connection;
            DbConnection conn = entityConnection.StoreConnection;

            ConnectionState initialState = conn.State;
            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();  // open connection if not already open 
                using (DbCommand cmd = conn.CreateCommand())
                {
                    //get the full location of the assembly with DaoTests in it
                    string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

                    //get the folder that's in
                    string theDirectory = Path.GetDirectoryName(fullPath);

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
                catch(Exception ex)
                {
                    var m = ex.InnerException.Message;
                }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close(); // only close connection if not initially open 
            }
        }
    }
}