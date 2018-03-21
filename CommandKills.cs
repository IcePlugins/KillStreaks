using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace ExtraConcentratedJuice.KillStreaks
{
    public class CommandKills : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "kills";

        public string Help => "Get your kills.";

        public string Syntax => "";

        public List<string> Aliases => new List<string> { "killstreak" };

        public List<string> Permissions => new List<string> { "killstreaks.kills" };

        public void Execute(IRocketPlayer caller, string[] args)
        {
            UnturnedPlayer uPlayer = (UnturnedPlayer)caller;

            if (KillStreaks.instance.killCount.TryGetValue(uPlayer.Id, out int killerKillCount))
            {
                UnturnedChat.Say(caller, KillStreaks.instance.Translations.Instance.Translate("killstreak_count", killerKillCount), UnityEngine.Color.green);
            }
            else
            {
                KillStreaks.instance.killCount[uPlayer.Id] = 0;
                UnturnedChat.Say(caller, KillStreaks.instance.Translations.Instance.Translate("killstreak_count", 0), UnityEngine.Color.green);
            }
        }
    }
}