using Volo.Abp.Settings;

namespace FlightsApp.Settings;

public class FlightsAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(FlightsAppSettings.MySetting1));
    }
}
