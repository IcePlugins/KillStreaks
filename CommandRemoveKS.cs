using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace ExtraConcentratedJuice.KillStreaks
{
    public class CommandRemoveKS : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "removeks";

        public string Help => "Reset your killstreak.";

        public string Syntax => "";

        public List<string> Aliases => new List<string> { };

        public List<string> Permissions => new List<string>() { "killstreaks.remove" };

        public void Execute(IRocketPlayer caller, string[] args)
        {
            UnturnedPlayer uPlayer = (UnturnedPlayer)caller;
            KillStreaks.instance.killCount[uPlayer.Id] = 0;
            UnturnedChat.Say(uPlayer, KillStreaks.instance.Translations.Instance.Translate("killstreak_remove"), UnityEngine.Color.green);
        }
    }
}