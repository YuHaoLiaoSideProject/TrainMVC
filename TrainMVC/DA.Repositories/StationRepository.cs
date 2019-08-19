using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TrainMVC.DA.Interfaces;
using TrainMVC.FilterParameter;
using TrainMVC.Models;

namespace TrainMVC.DA.Repositories
{
    public class StationRepository : BaseRepository, IStationRepository
    {
        public List<StationModel> GetAll()
        {
            string sql = $@"
                            SELECT *
                            FROM Station";

            using (var conn = new SqlConnection(_DBConn))
            {
                var result = conn.Query<StationModel>(sql).ToList();
                return result;
            }
        }
    }
}