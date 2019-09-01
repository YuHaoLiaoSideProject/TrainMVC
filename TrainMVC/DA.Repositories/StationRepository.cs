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
        public List<StationCountyModel> GetAll()
        {
            string sql = $@"
                            SELECT S.*,scm.CountyNo
	                        FROM Station s
	                        JOIN StationCountyMapping scm ON S.Station = scm.Station";

            using (var conn = new SqlConnection(_DBConn))
            {
                var result = conn.Query<StationCountyModel>(sql).ToList();
                return result;
            }
        }
        
    }
}