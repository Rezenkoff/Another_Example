using Dapper;
using Microsoft.Extensions.Configuration;
using Monitor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Monitor.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;
        public OrderRepository(IConfiguration config)
        {
            if (config["ConnectionStrings:DefaultConnection"] == null)
                throw new ArgumentNullException("config");

            _connectionString = config["ConnectionStrings:DefaultConnection"];
        }

        public async Task<Dictionary<object, object>> GetDealCountByOrderStatusId()
        {
            var query = @"(SELECT ord.ORD_OST_ID, count(ord.ORD_ID) AS Res
                           FROM [dbo].[ORDER_USER] ord (NOLOCK)
                           INNER JOIN [dbo].[ORDER_STATUS] o_st (NOLOCK) ON ord.ORD_OST_ID = o_st.OST_ID
                           WHERE o_st.OST_ID IN(3, 4, 6, 9, 10)
                           GROUP by ord.ORD_OST_ID) 
                           UNION
                           (SELECT 'ORD_OST_ID' = 7, count(ord.ORD_ID) AS Res
                           FROM[dbo].[ORDER_USER] ord
                           INNER JOIN[dbo].[ORDER_STATUS] o_st ON ord.ORD_OST_ID = o_st.OST_ID
                           WHERE o_st.OST_ID = 7
                           AND (ord.ORD_LAST_UPDATE BETWEEN  DATEADD(DAY, -30, GETDATE()) AND GETDATE()) 
                           AND ord.ORD_DELIVERED_DATE BETWEEN DATEADD(DAY, -5, GETDATE()) AND GETDATE())";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader result = await command.ExecuteReaderAsync();
                Dictionary<object, object> data = new Dictionary<object, object>();

                if (result.HasRows)
                {
                    while (await result.ReadAsync())
                    {
                        data.Add(result["ORD_OST_ID"], result["Res"]);
                    }
                }
                return data;
            }
        }
        public async Task<(int, int, int)> GetSalesByDayAndMonth()
        {
            var query = @"SELECT CAST(COUNT(ord.ORD_ID) AS INT) as res
                          FROM [dbo].[ORDER_USER] ord WITH (NOLOCK) 
                          WHERE ord.ORD_OST_ID IN(3, 4, 6, 7, 10) AND 
                          ord.ORD_ORDER_DATE BETWEEN DATEADD(hh,18,CONVERT(DATETIME,CONVERT(DATE, GETDATE()-1))) AND 
                          DATEADD(hh,18,CONVERT(DATETIME,CONVERT(DATE, GETDATE())))
                          UNION ALL
                          SELECT CAST(ISNULL(SUM(pm.PMN_SUMMA), 0) AS INT) as res
                          FROM [dbo].[Invoice] inv WITH(NOLOCK)
                          LEFT JOIN [dbo].PART_MANAGERS AS pm WITH(NOLOCK) ON pm.PMN_INV_ID = inv.InvoiceId
                          WHERE inv.OrderId IN( SELECT ord.ORD_ID
                          FROM [dbo].[ORDER_USER] ord WITH (NOLOCK) 
                          WHERE ord.ORD_OST_ID IN(3, 4, 6, 7, 10) AND 
                          ord.ORD_ORDER_DATE BETWEEN DATEADD(hh,18,CONVERT(DATETIME,CONVERT(DATE, GETDATE()-1))) AND DATEADD(hh,18,CONVERT(DATETIME,CONVERT(DATE, GETDATE()))))
                          UNION ALL
                          SELECT CAST(ISNULL(SUM(pm.PMN_SUMMA), 0) AS INT) as res
                          FROM [dbo].[Invoice] inv WITH(NOLOCK)
                          LEFT JOIN [dbo].PART_MANAGERS AS pm WITH(NOLOCK) ON pm.PMN_INV_ID = inv.InvoiceId
                          WHERE inv.OrderId IN( SELECT ord.ORD_ID
                          FROM [dbo].[ORDER_USER] ord WITH (NOLOCK) 
                          WHERE ord.ORD_OST_ID IN(3, 4, 6, 7, 10) AND 
                          ord.ORD_ORDER_DATE BETWEEN DATEADD(MONTH,  DATEDIFF(MONTH,0,CURRENT_TIMESTAMP),0) AND DATEADD(MONTH,1+DATEDIFF(MONTH,0,CURRENT_TIMESTAMP),0))";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader result = await command.ExecuteReaderAsync();
                    (int, int, int) salesDayAndMonth = (0, 0, 0);

                    if (result.HasRows)
                    {
                        int i = 0;
                        while (await result.ReadAsync())
                        {
                            switch (i)
                            {
                                case 0:
                                    salesDayAndMonth.Item1 = (int)result["res"];
                                    break;
                                case 1:
                                    salesDayAndMonth.Item2 = (int)result["res"];
                                    break;
                                case 2:
                                    salesDayAndMonth.Item3 = (int)result["res"];
                                    break;
                            }
                            i++;
                        }
                    }
                    return salesDayAndMonth;
                }
                catch (Exception ex)
                {
                    return (0, 0, 0);
                }
            }
        }

        public async Task<int> GetCountOfSalesByMonth()
        {
            var query = @"SELECT CAST(COUNT(ord.ORD_ID) AS INT) as res
                          FROM[dbo].[ORDER_USER] ord WITH(NOLOCK)
                          WHERE ord.ORD_OST_ID IN(3, 4, 6, 7, 10) AND
                          ord.ORD_ORDER_DATE BETWEEN DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP), 0) AND DATEADD(MONTH,1 + DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP),0)";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader result = await command.ExecuteReaderAsync();

                    if (result.HasRows)
                    {
                        while (await result.ReadAsync())
                        {
                            return (int)result["res"];
                        }
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public async Task<int> GetCountOfReturnedByMonth()
        {
            var query = @"SELECT CAST(COUNT(ord.ORD_ID) AS INT) as res
                          FROM[dbo].[ORDER_USER] ord WITH(NOLOCK)
                          WHERE ord.ORD_OST_ID IN(8, 11, 12, 13, 14, 15, 16) AND
                          ord.ORD_ORDER_DATE BETWEEN DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP), 0) AND DATEADD(MONTH,1 + DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP),0)";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader result = await command.ExecuteReaderAsync();

                    if (result.HasRows)
                    {
                        while (await result.ReadAsync())
                        {
                            return (int)result["res"];
                        }
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public async Task<int> GetCountOfAutoReturnedByMonth()
        {
            var query = @"SELECT CAST(COUNT(ord.ORD_ID) AS INT) as res
                          FROM[dbo].[ORDER_USER] ord WITH(NOLOCK)
                          WHERE ord.ORD_OST_ID IN(12) AND
                          ord.ORD_ORDER_DATE BETWEEN DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP), 0) AND DATEADD(MONTH,1 + DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP),0)";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader result = await command.ExecuteReaderAsync();

                    if (result.HasRows)
                    {
                        while (await result.ReadAsync())
                        {
                            return (int)result["res"];
                        }
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public async Task<int> GetCountOfReturnedAndPartReturnedByMonth()
        {
            var query = @"SELECT CAST(COUNT(ord.ORD_ID) AS INT) as res
                          FROM[dbo].[ORDER_USER] ord WITH(NOLOCK)
                          WHERE ord.ORD_OST_ID IN(8, 11, 13) AND
                          ord.ORD_ORDER_DATE BETWEEN DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP), 0) AND DATEADD(MONTH,1 + DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP),0)";

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader result = await command.ExecuteReaderAsync();

                    if (result.HasRows)
                    {
                        while (await result.ReadAsync())
                        {
                            return (int)result["res"];
                        }
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public async Task<Dictionary<int, string>> GetManagers()
        {
            var query = @"SELECT u.CrmId, a.FirstLastName from UserCrm as u
                          INNER JOIN AutodocUser as a
                          ON u.UserId = a.UserId where u.CrmId != 0";

            var managersList = new Dictionary<int, string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader result = await command.ExecuteReaderAsync();

                    if (result.HasRows)
                    {
                        while (await result.ReadAsync())
                        {
                            managersList.Add((int)result["CrmId"], (string)result["FirstLastName"]);
                        }
                    }
                    return managersList;
                }
                catch (Exception ex)
                {
                    return managersList;
                }
            }
        }
    }
}
