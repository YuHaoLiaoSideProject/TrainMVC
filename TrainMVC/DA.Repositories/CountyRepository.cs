using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TrainMVC.DA.Interfaces;
using TrainMVC.FilterParameter;
using TrainMVC.Models;

namespace TrainMVC.DA.Repositories
{
    public class CountyRepository : BaseRepository, ICountyRepository
    {
        public List<CountyModel> GetAll()
        {
            string sql = $@"
                            SELECT *
                            FROM County";

            using (var conn = new SqlConnection(_DBConn))
            {
                var result = conn.Query<CountyModel>(sql).ToList();
                return result;
            }
        }
    }
}