using Microsoft.AspNetCore.Authorization;

namespace FamilyStore.Services.Attributes;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permission permission) : base(policy:permission.ToString())
    {
    }
}