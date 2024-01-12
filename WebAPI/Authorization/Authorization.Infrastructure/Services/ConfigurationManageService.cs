using Authorization.Domain;

namespace Authorization.Infrastructure.Services;

using Authorization.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration; 
    

public class ConfigurationManageService : IConfigurationManageService
{
    private string _value;
    public string Value
    {
        get { return _value; }
    } 

    public void SetConfiguration(ConfigurationEntity configEntity)
    {
        IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile(configEntity.PathToFile);

        IConfigurationRoot config = configBuilder.Build();

        _value = config.GetSection(configEntity.SectionName)[configEntity.ValueName];
    }
}