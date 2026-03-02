using System.IO;
using System.Xml.Serialization;
using Telt_Homework.Schemas.UserConfig;

namespace Telt_Homework.Main;

public class ConfigLoader
{
    private const string FILENAME = "./config.xml";
    
    public static Config LoadConfig()
    {
        Config config = new Config();
        try
        {
            //config file is in root solution folder 
            string configFile = Path.Combine(Environment.CurrentDirectory, FILENAME);
            string xml = File.ReadAllText(configFile);
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            using StringReader reader = new StringReader(xml);
            config = (Config)serializer.Deserialize(reader)!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return config;
    }
}