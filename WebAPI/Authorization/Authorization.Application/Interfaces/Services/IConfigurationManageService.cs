namespace Authorization.Application.Interfaces.Services;

public interface IConfigurationManageService
{
    string GetConnectionString(string sectionName, string keyName, string pathToFileString);

}