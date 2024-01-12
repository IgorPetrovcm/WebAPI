namespace Authorization.Infrastructure.Services;

using Authorization.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration; 
    

public class ConfigurationManageService : IConfigurationManageService
{
    public string GetConnectionString(string sectionName,string keyName, string pathToFileString)
    {
        IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile(pathToFileString);

        IConfigurationRoot config = configBuilder.Build();

        return config.GetSection(sectionName)[keyName];
    }
}