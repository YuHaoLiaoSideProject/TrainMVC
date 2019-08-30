using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TrainMVC.DA.Interfaces;
using TrainMVC.FilterParameter;
using TrainMVC.Models;

namespace TrainMVC.DA.Repositories
{
    public class CountyStationMappingRepository : BaseRepository, ICountyStationMappingRepository
    {
        public List<TrainQueryModel> GetByFilter(StationFilterParameter filter)
        {
            string sql = $@"
                            SELECT 
	                            T1.Train
	                            ,T1.Station StartStation
	                            ,T1.ARRTime StartARRTime
	                            ,T2.Station EndStation
	                            ,T2.ARRTime EndARRTime
                            FROM [dbo].[train] AS T1
                            JOIN train AS T2 ON T1.Train = T2.Train
                            WHERE 
	                            T2.[Order] > T1.[Order]";

            if (filter.StartStation.HasValue)
            {
                sql += " AND T1.Station = @StartStation";
            }
            if (filter.EndStation.HasValue)
            {
                sql += " AND T2.Station = @EndStation";
            }

            sql += " ORDER BY StartARRTime";

            using (var conn = new SqlConnection(_DBConn))
            {
                var result = conn.Query<TrainQueryModel>(sql, filter).ToList();
                return result;
            }
        }
    }
}