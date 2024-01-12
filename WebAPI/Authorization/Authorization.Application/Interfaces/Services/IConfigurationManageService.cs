namespace Authorization.Application.Interfaces.Services;

public interface IConfigurationManageService
{
    public string Value { get; }
    
    void SetConfiguration(string sectionName, string keyName, string pathToFileString);

    void SetConfiguration();

}