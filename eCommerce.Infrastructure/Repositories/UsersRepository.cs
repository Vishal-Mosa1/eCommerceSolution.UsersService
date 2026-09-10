using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        //Generate a new user id

        user.UserId = Guid.NewGuid();

        string query = "INSERT into public.\"Users\"(\"UserID\",\"Email\",\"PersonName\",\"Gender\",\"Password\")" +
            "VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";

        int rowAffectedCount = await _dbContext.DbConnection.ExecuteAsync(query, user);

        if(rowAffectedCount > 0) 
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = "SELECT * from public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";

        var parameters = new {Email= email, Password = password};
        ApplicationUser? user=await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

        return user;
    }

    public async Task<ApplicationUser?> GetUserById(Guid userId)
    {
        string query = "SELECT * from public.\"Users\" WHERE \"UserID\" = @UserId";

        var parameters = new { UserId = userId };
        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

        return user;
    }
}
