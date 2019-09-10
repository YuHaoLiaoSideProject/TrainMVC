using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TrainMVC.DA.Interfaces;
using TrainMVC.FilterParameter;
using TrainMVC.Models;

namespace TrainMVC.DA.Repositories
{
    public class GetTrainIFORepository : BaseRepository, IGetTrainIFORepository
    {
        public List<GetTrainIFOModel> GetByFilter(GetTrainIFOFilterParameter filter)
        {
            string sql = $@"
                            SELECT 
                            T2.StationCTName
                            ,T1.ARRTime

                            FROM [dbo].[Train] AS T1
                           JOIN Station AS T2 ON T1.Station = T2.Station";

            if (filter.Train.HasValue)
            {
                sql += " AND T1.train = @Train";
            }


            sql += " ORDER BY T1.[Order]";

            using (var conn = new SqlConnection(_DBConn))
            {
                var result = conn.Query<GetTrainIFOModel>(sql, filter).ToList();
                return result;
            }
        }
    }
}