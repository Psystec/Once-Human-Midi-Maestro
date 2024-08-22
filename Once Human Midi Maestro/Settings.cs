using Newtonsoft.Json;
using System;
using System.IO;

namespace Once_Human_Midi_Maestro
{
    public class Settings
    {
        public static Data settings = new Data();

        private static string settingsFile = "settings.json";

        public class Data
        {
            public bool RepeatSong;
            public bool SkipOctave3and5;
            public bool MergeOctave4;
            public bool AlwaysOnTop;
            public int Speed;
            public int ModifierDelay;
            public bool Debug;
        }

        public static void SaveSettings()
        {
            AppSettings.SaveSettings();
        }

        public static void Init()
        {
            AppSettings.Init();
        }

        internal class AppSettings
        {
            internal static void Init()
            {
                if (!File.Exists(settingsFile))
                    File.WriteAllText(settingsFile, JsonConvert.SerializeObject(new Data(), Formatting.Indented));

                LoadSettings();
            }

            internal static void LoadSettings()
            {
                try
                {
                    string appSettings = File.ReadAllText(settingsFile);
                    settings = JsonConvert.DeserializeObject<Data>(appSettings);
                }
                catch (Exception ex)
                {
                    File.Delete(settingsFile);
                }
            }

            internal static void SaveSettings()
            {
                File.WriteAllText(settingsFile, JsonConvert.SerializeObject(settings, Formatting.Indented));
            }
        }
    }
}
