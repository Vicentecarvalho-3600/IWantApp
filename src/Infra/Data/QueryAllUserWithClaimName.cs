using Dapper;
using IWantApp.Endpoints.Employees;
using Microsoft.Data.SqlClient;

namespace IWantApp.Infra.Data;

public class QueryAllUserWithClaimName
{
    private readonly IConfiguration configuration;
    public QueryAllUserWithClaimName(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public IEnumerable<EmployeesResponse> Execute(int page, int rows)
    {
        var db = new SqlConnection(configuration["ConnectionString:IWantDb"]);
        var query = @"select Email, ClaimValue as Name
                    from AspNetUsers u inner join AspNetUserClaims c
                    on u.Id = c.UserId and claimtype = 'Name'
                    order by Name
                    offset (@page - 1) * @rows rows fetch next @rows rows only";

        return db.Query<EmployeesResponse>(query, new { page, rows });
    }

    
}
