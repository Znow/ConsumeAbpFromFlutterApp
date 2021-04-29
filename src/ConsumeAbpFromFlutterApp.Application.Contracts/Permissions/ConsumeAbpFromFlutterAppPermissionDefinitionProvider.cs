using ConsumeAbpFromFlutterApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ConsumeAbpFromFlutterApp.Permissions
{
    public class ConsumeAbpFromFlutterAppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ConsumeAbpFromFlutterAppPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(ConsumeAbpFromFlutterAppPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ConsumeAbpFromFlutterAppResource>(name);
        }
    }
}
