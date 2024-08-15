using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WindowsInput.Native;

namespace Once_Human_Midi_Maestro
{
    public static class MidiKeyMap
    {
        private static Dictionary<int, List<VirtualKeyCode>> _midiToKeyMap;

        static MidiKeyMap()
        {
            _midiToKeyMap = new Dictionary<int, List<VirtualKeyCode>>();
        }

        public static void LoadFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var tempDict = JsonSerializer.Deserialize<Dictionary<int, List<string>>>(json);

            _midiToKeyMap = new Dictionary<int, List<VirtualKeyCode>>();

            foreach (var kvp in tempDict)
            {
                var virtualKeyCodes = new List<VirtualKeyCode>();
                foreach (var key in kvp.Value)
                {
                    if (Enum.TryParse(key, out VirtualKeyCode vkc))
                    {
                        virtualKeyCodes.Add(vkc);
                    }
                    else
                    {
                        Console.WriteLine($"Warning: {key} is not a valid VirtualKeyCode.");
                    }
                }
                _midiToKeyMap[kvp.Key] = virtualKeyCodes;
            }
        }

        public static IEnumerable<KeyValuePair<int, List<VirtualKeyCode>>> MidiToKeyMapEnumerable => _midiToKeyMap;
        public static Dictionary<int, List<VirtualKeyCode>> MidiToKey => _midiToKeyMap;
        public static bool ContainsKey(int midiKey) => _midiToKeyMap.ContainsKey(midiKey);
    }
}
