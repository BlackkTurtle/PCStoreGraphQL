using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PCStoreGraphQL.API.Types;

public partial class UserType
{
    public string UserName { get; set; } = null!;
    public string? Password { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Father { get; set; }

}
