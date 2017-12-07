using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace ExtraConcentratedJuice.KillStreaks
{
    public class CommandIncrement : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "increment";

        public string Help => "Increment your kills.";

        public string Syntax => "";

        public List<string> Aliases => new List<string> { };

        public List<string> Permissions => new List<string>() { "killstreaks.increment" };

        public void Execute(IRocketPlayer caller, string[] args)
        {
            UnturnedPlayer uPlayer = (UnturnedPlayer)caller;

            if (KillStreaks.instance.killCount.TryGetValue(uPlayer.Id, out int killerKillCount))
            {
                KillStreaks.instance.killCount[uPlayer.Id] = killerKillCount + 1;
                UnturnedChat.Say(caller, KillStreaks.instance.Translations.Instance.Translate("killstreak_increment"), UnityEngine.Color.green);

            }
            else
            {
                KillStreaks.instance.killCount[uPlayer.Id] = 1;
                UnturnedChat.Say(caller, KillStreaks.instance.Translations.Instance.Translate("killstreak_increment"), UnityEngine.Color.red);
            }
        }
    }
}