using Dapper;
using IWantApp.Infra.Data;
using Microsoft.Data.SqlClient;

namespace IWantApp.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;
    public static IResult Action(int? page, int? rows, QueryAllUserWithClaimName query)
    {
        if (page == null)
            return Results.BadRequest("necessario informar a page"); // procurar melhorar

        if (rows == null)
            return Results.BadRequest("necessario informar a rows"); // procurar melhorar

        return Results.Ok(query.Execute(page.Value, rows.Value));
    }
}
