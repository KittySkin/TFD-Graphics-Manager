using IniParser.Exceptions;
using IniParser;
using IniParser.Model;
using System.Collections.Generic;
using System.IO;

namespace TFDGraphicsManager;

class SettingsManager
{
    // Dictionary to store the retrieved values
    public Dictionary<string, int> settingsValues = new Dictionary<string, int>();

    public void GetSettingsValues()
    {
        // Construct the path to the INI file
        string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string iniFilePath = Path.Combine(localAppDataPath, "M1", "Saved", "Config", "Windows", "GameUserSettings.ini");

        // List of settings to retrieve
        List<string> settingsToRetrieve = new List<string>
        {
            "ViewDistance",
            "AntiAliasing",
            "PostProcessing",
            "Shadows",
            "GlobalIllumination",
            "Reflections",
            "Textures",
            "Effects",
            "Foliage",
            "Shading",
            "Mesh",
            "Physics",
            "RayTracingQuality"
        };

        try
        {
            // Create an INI file parser
            var parser = new FileIniDataParser();
            parser.Parser.Configuration.AllowDuplicateKeys = true;

            // Load the INI file
            IniData data = parser.ReadFile(iniFilePath);

            // The section header to look for
            string sectionHeader = "/Script/M1.M1GameUserSettings";

            // Check if the section exists
            if (data.Sections.ContainsSection(sectionHeader))
            {
                // Retrieve settings from the section
                foreach (string setting in settingsToRetrieve)
                {
                    if (data[sectionHeader].ContainsKey(setting))
                    {
                        string valueStr = data[sectionHeader][setting];

                        if (int.TryParse(valueStr, out int value))
                        {
                            // Ensure the value is within the acceptable range
                            if (value >= 0 && value <= 4)
                            {
                                settingsValues[setting] = value;
                            }
                        }
                    }
                }
            }

            // Output the retrieved settings
            Console.WriteLine("Retrieved settings:");
            foreach (var entry in settingsValues)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading INI file: {ex.Message}");
        }
    }
}

public class GraphicsSetting
{
    public static Dictionary<int, string> ViewDistanceMapping = new Dictionary<int, string>
    {
        { 0, "Low" },
        { 1, "Medium" },
        { 2, "High" },
        { 3, "Ultra" },
        { 4, "Cinematic" }
    };

    public static Dictionary<int, string> AntiAliasingMapping = new Dictionary<int, string>
    {
        { 0, "Low" },
        { 1, "Medium" },
        { 2, "High" },
        { 3, "Ultra" },
        { 4, "Cinematic" }
    };
    public static Dictionary<int, string> PostProcessingMapping = new Dictionary<int, string>
    {
        { 0, "Low" },
        { 1, "Medium" },
        { 2, "High" },
        { 3, "Ultra" },
        { 4, "Cinematic" }
    };
    public static Dictionary<int, string> ShadowsMapping = new Dictionary<int, string>
    {
        { 0, "Low" },
        { 1, "Medium" },
        { 2, "High" },
        { 3, "Ultra" },
        { 4, "Cinematic" }
    };
    public static Dictionary<int, string> GlobalIlluminationMapping = new Dictionary<int, string>
    {
        { 0, "Low" },
        { 1, "Medium" },
        { 2, "High" },
        { 3, "Ultra" },
        { 4, "Cinematic" }
    };
    public static Dictionary<int, string> ReflectionsMapping = new Dictionary<int, string>
    {
        { 0, "Low" },
        { 1, "Medium" },
        { 2, "High" },
        { 3, "Ultra" },
        { 4, "Cinematic" }
    };
    public static Dictionary<int, string> TexturesMapping = new Dictionary<int, string>
    {
        { 0, "Low" },
        { 1, "Medium" },
        { 2, "High" },
        { 3, "Ultra" },
        { 4, "Cinematic" }
    };
    public static Dictionary<int, string> EffectsMapping = new Dictionary<int, string>
    {
        { 0, "Low" },
        { 1, "Medium" },
        { 2, "High" },
        { 3, "Ultra" },
        { 4, "Cinematic" }
    };
    public static Dictionary<int, string> FoliageMapping = new Dictionary<int, string>
    {
        { 0, "Low" },
        { 1, "Medium" },
        { 2, "High" },
        { 3, "Ultra" },
        { 4, "Cinematic" }
    };
    public static Dictionary<int, string> ShadingMapping = new Dictionary<int, string>
    {
        { 0, "Low" },
        { 1, "Medium" },
        { 2, "High" },
        { 3, "Ultra" },
        { 4, "Cinematic" }
    };
    public static Dictionary<int, string> MeshMapping = new Dictionary<int, string>
    {
        { 0, "Low" },
        { 1, "Medium" },
        { 2, "High" },
        { 3, "Ultra" },
        { 4, "Cinematic" }
    };
    public static Dictionary<int, string> PhysicsMapping = new Dictionary<int, string>
    {
        { 0, "Low" },
        { 1, "Medium" },
        { 2, "High" },
        { 3, "Ultra" },
        { 4, "Cinematic" }
    };
    public static Dictionary<int, string> RayTracingQualityMapping = new Dictionary<int, string>
    {
        { 0, "Disabled" },
        { 1, "Medium" },
        { 2, "High" },
        { 3, "Ultra" },
        { 4, "Cinematic" }
    };
}