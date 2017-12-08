using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtraConcentratedJuice.KillStreaks
{
    public class KillStreaksConfig : IRocketPluginConfiguration
    {
        public bool enable_restart_persistence;
        public bool remove_streak_on_disconnect;
        public string kill_streak_message;
        public string kill_streak_message_color;
        public int kill_divisor;
        public int kill_streak_threshold;
        public int kill_streak_lost_threshold;
        public string kill_streak_lose_message;
        public string kill_streak_lost_message_color;
        [XmlArrayItem(ElementName = "Group")]
        public List<CommandGroup> CommandGroups;

        public void LoadDefaults()
        {
            enable_restart_persistence = true;
            remove_streak_on_disconnect = false;
            kill_streak_message = "{0} IS ON A KILL STREAK! ({1} kills)";
            kill_streak_message_color = "magenta";
            kill_divisor = 5;
            kill_streak_threshold = 5;
            kill_streak_lost_threshold = 25;
            kill_streak_lose_message = "{0} DIED AND LOST THEIR KILL STREAK OF {1}!";
            kill_streak_lost_message_color = "red";
            CommandGroups = new List<CommandGroup>()
            {
                new CommandGroup { Commands = new List<string>() { "/heal {0}", "/give {0} 8 1", "/say woah" }, KillMin = 4, KillMax = 20 }
            };
        }

        public class CommandGroup
        {
            public CommandGroup()
            {
            }

            [XmlArrayItem(ElementName = "Command")]
            public List<string> Commands;
            public int KillMin;
            public int KillMax;
        }
    }
}
