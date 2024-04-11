using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [ProtectedPersonalData]
    public string FirtName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

}
