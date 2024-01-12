namespace Authorization.Domain;

public class ConfigurationEntity
{
    public string SectionName { get; set; } 
    
    public string ValueName { get; set; }
    
    public string PathToFile { get; set; }
}