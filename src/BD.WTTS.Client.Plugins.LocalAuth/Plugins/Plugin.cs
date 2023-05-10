namespace BD.WTTS.Plugins;

#if (WINDOWS || MACCATALYST || MACOS || LINUX) && !(IOS || ANDROID)
[CompositionExport(typeof(IPlugin))]
#endif
sealed class Plugin : PluginBase<Plugin>
{
    public override string Name => nameof(TabItemViewModel.TabItemId.LocalAuth);

    public override void ConfigureDemandServices(IServiceCollection services, Startup startup)
    {
        if (startup.HasServerApiClient)
        {
            services.AddSingleton<IAccountPlatformAuthenticatorRepository, AccountPlatformAuthenticatorRepository>();
        }
    }

    public override void ConfigureRequiredServices(IServiceCollection services, Startup startup)
    {
    }

    public override void OnAddAutoMapper(IMapperConfigurationExpression cfg)
    {

    }
}
