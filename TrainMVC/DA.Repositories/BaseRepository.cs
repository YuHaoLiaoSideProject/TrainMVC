using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainMVC.DA.Repositories
{
    public class BaseRepository
    {
        protected string _DBConn = System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"]?.ConnectionString;
    }
}