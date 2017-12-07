using Rocket.API;

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


        public void LoadDefaults()
        {
            enable_restart_persistence = true;
            remove_streak_on_disconnect = false;
            kill_streak_message = "{0} IS ON A KILL STREAK! ({1} kills)";
            kill_streak_message_color = "magenta";
            kill_divisor = 5;
            kill_streak_threshold = 5;
        }
    }
}
