using FlightsApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FlightsApp.Permissions;

public class FlightsAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FlightsAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(FlightsAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FlightsAppResource>(name);
    }
}
