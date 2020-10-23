# Acidic.Extensions.Configuration.Binder ![ci branch parameter](https://github.com/acidicsoftware/dotnet-extensions-configuration-binder/workflows/Continuous%20Integration/badge.svg?branch=trunk)

Acidic.Extensions.Configuration.Binder extends upon Microsoft.Extensions.Configuration.Binder adding new functionality simplifying the process of binding configuration sections to a model.

Your configuration model must implement the interface [Configurations](src/Acidic.Extensions.Configuration.Binder/Configurations.cs).

```csharp
public class SiteConfigurations : Configurations
{
    public string SiteTitle { get; set; }

    public SerilogSettings() : base("Site")
    {
    }
}
```

The configuration model must have a parameterless constructor and it must call the constructor on the base call, that takes a configuration section key as the only argument. The supplied section key will act as the default section key.

Configurations can then be fetched using the `Bind()` method.

```csharp
public class SiteService {
    private readonly IConfiguration configuration;
    
    public SiteService(IConfiguration configuration){
        this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    
    public void SetSiteConfigurations(){
        var siteConfigurations = configuration.Bind<SiteConfigurations>();
        var siteTitle = siteConfigurations.SiteTitle;
    }
}
```

By default, the `Bind()` method will attempt to bind configuraitons based on the default section key defined in the configuration model. This behavior can be overridden by passing a section key as an argument when calling `Bind()`.

```csharp
var siteConfigurations = configuration.Bind<SiteConfigurations>("Generel:Site");
```

! Notice that the default .NET configuration section key format is used in all cases.

*© Copyright 2020 Michel Gammelgaard. All rights reserved. Provided under the [MIT license](LICENSE).*
