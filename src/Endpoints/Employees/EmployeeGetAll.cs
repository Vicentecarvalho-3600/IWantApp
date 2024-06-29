using Dapper;
using Microsoft.Data.SqlClient;

namespace IWantApp.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;
    public static IResult Action(int? page, int? rows, IConfiguration configuration)
    {
        if (page == null)
            return Results.BadRequest("necessario informar a page"); // procurar melhorar

        if (rows == null)
            return Results.BadRequest("necessario informar a rows"); // procurar melhorar

        var db = new SqlConnection(configuration["ConnectionString:IWantDb"]);
        var query = @"select Email, ClaimValue as Name
                    from AspNetUsers u inner join AspNetUserClaims c
                    on u.Id = c.UserId and claimtype = 'Name'
                    order by Name
                    offset (@page - 1) * @rows rows fetch next @rows rows only";

        var employees = db.Query<EmployeesResponse>(query, new {page, rows});

        return Results.Ok( employees );
    }
}
