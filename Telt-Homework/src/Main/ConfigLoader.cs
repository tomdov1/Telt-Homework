using System.IO;
using System.Xml.Serialization;
using Telt_Homework.Schemas.UserConfig;

namespace Telt_Homework.Main;

public class ConfigLoader
{
    private const string DefaultFilename = "config.xml";

    public static Config LoadConfig()
    {
        string configFile = Path.Combine(Environment.CurrentDirectory, DefaultFilename);
        return LoadConfig(configFile);
    }

    public static Config LoadConfig(string configFile)
    {
        if (string.IsNullOrWhiteSpace(configFile))
        {
            throw new ArgumentException("Config file path is required.", nameof(configFile));
        }

        try
        {
            string xml = File.ReadAllText(configFile);
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            using StringReader reader = new StringReader(xml);
            return (Config)serializer.Deserialize(reader)!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
