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
    
    public void SetConfiguration(string sectionName,string keyName, string pathToFileString)
    {
        IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile(pathToFileString);

        IConfigurationRoot config = configBuilder.Build();

        _value = config.GetSection(sectionName)[keyName];
    }
}