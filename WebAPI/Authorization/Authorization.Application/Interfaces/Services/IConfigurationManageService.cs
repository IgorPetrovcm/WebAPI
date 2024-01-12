namespace Authorization.Application.Interfaces.Services;

using Authorization.Domain;

public interface IConfigurationManageService
{
    public string Value { get; }
    
    void SetConfiguration(ConfigurationEntity configEntity);

}