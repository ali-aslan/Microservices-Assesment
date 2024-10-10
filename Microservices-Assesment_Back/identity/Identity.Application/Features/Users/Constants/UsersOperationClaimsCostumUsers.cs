using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Users.Constants;

public class UsersOperationClaimsCostumUsers
{
    private readonly string _section;

    public UsersOperationClaimsCostumUsers(string role)
    {
        _section = role;  
    }

    public string Admin => $"{_section}.Admin";
    public string Read => $"{_section}.Read";
    public string Write => $"{_section}.Write";
    public string Create => $"{_section}.Create";
    public string Update => $"{_section}.Update";
    public string Delete => $"{_section}.Delete";
}
