using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned;
using Rocket.Core;
using UnityEngine;
using Rocket.Unturned.Plugins;
using Rocket.Unturned.Logging;
using SDG;
using Rocket.Unturned.Util;

namespace DeathMessages
{
    public class PlayerDeath : RocketPlugin<DeathMessages.PlayerDeath.DeathMessagesConfig1>
    {
        public static PlayerDeath Instance;
        protected override void Load()
        {
            Instance = this;
            Rocket.Unturned.Logging.Logger.Log("Sadusko's Death Messages has been loaded!");
            #region Event
            Rocket.Unturned.Events.RocketPlayerEvents.OnPlayerDeath += RocketPlayerEvents_OnPlayerDeath;
            Rocket.Unturned.Events.RocketPlayerEvents.OnPlayerUpdateHealth += RocketPlayerEvents_OnPlayerUpdateHealth;
            #endregion

            if (this.Configuration.suicidemsg)
            {
                Logger.LogError("Suicide messages are enabled!");
            }
            else
            {
                Logger.LogError("Suicide messages are disabled!");
            }

            if (this.Configuration.warningmsg)
            {
                Logger.LogError("Health warning messages are enabled!");
            }
        }

        private void RocketPlayerEvents_OnPlayerDeath(Rocket.Unturned.Player.RocketPlayer player, SDG.Unturned.EDeathCause cause, SDG.Unturned.ELimb limb, Steamworks.CSteamID murderer)
        {
            if (player.Permissions.Contains("deathmessage"))
            {
                if (cause.ToString() == "ZOMBIE")
                {
                    RocketChat.Say(player.CharacterName + " " + DeathMessages.PlayerDeath.Instance.Configuration.zombie + " ", Color.red);
                }
                else if (cause.ToString() == "GUN")
                {
                    RocketChat.Say(Rocket.Unturned.Player.RocketPlayer.FromCSteamID(murderer).CharacterName + " " + DeathMessages.PlayerDeath.Instance.Configuration.gun + " " + player.CharacterName + "!", Color.red);
                }
                else if (cause.ToString() == "MELEE")
                {
                    RocketChat.Say(Rocket.Unturned.Player.RocketPlayer.FromCSteamID(murderer).CharacterName + " " + DeathMessages.PlayerDeath.Instance.Configuration.melee + " " + player.CharacterName + " " + DeathMessages.PlayerDeath.Instance.Configuration.melee2, Color.red);
                }
                else if (cause.ToString() == "PUNCH")
                {
                    RocketChat.Say(Rocket.Unturned.Player.RocketPlayer.FromCSteamID(murderer).CharacterName + " " + DeathMessages.PlayerDeath.Instance.Configuration.punch + " " + player.CharacterName + " " + DeathMessages.PlayerDeath.Instance.Configuration.punch2, Color.red);
                }
                else if (cause.ToString() == "ROADKILL")
                {
                    RocketChat.Say(Rocket.Unturned.Player.RocketPlayer.FromCSteamID(murderer).CharacterName + " " + DeathMessages.PlayerDeath.Instance.Configuration.roadkill + " " + player.CharacterName + "!", Color.red);
                }
                else if (cause.ToString() == "VEHICLE")
                {
                    RocketChat.Say(player.CharacterName + " " + DeathMessages.PlayerDeath.Instance.Configuration.vehicle, Color.red);
                }
                else if (cause.ToString() == "FOOD")
                {
                    RocketChat.Say(player.CharacterName + " " + DeathMessages.PlayerDeath.Instance.Configuration.food, Color.red);
                }
                else if (cause.ToString() == "WATER")
                {
                    RocketChat.Say(player.CharacterName + " " + DeathMessages.PlayerDeath.Instance.Configuration.water, Color.red);
                }
                else if (cause.ToString() == "INFECTION")
                {
                    RocketChat.Say(player.CharacterName + " " + DeathMessages.PlayerDeath.Instance.Configuration.infection, Color.red);
                }
                else if (cause.ToString() == "BLEEDING")
                {
                    RocketChat.Say(player.CharacterName + " " + DeathMessages.PlayerDeath.Instance.Configuration.bleeding, Color.red);
                }
                else if (cause.ToString() == "SUICIDE" && this.Configuration.suicidemsg)
                {
                    RocketChat.Say(player.CharacterName + " " + DeathMessages.PlayerDeath.Instance.Configuration.suicide, Color.red);

                }
            }
        }
        protected override void Unload()
        {
            base.Unload();
        }

        void RocketPlayerEvents_OnPlayerUpdateHealth(Rocket.Unturned.Player.RocketPlayer player, byte health)
        {
            if (this.Configuration.warningmsg)
            {
                if (health == 25)
                {
                    RocketChat.Say(player, this.Configuration.warning1, Color.yellow);
                    RocketChat.Say(player, this.Configuration.warning2, Color.yellow);
                }
            }
        }

        public class DeathMessagesConfig1 : IRocketPluginConfiguration
        {
            public bool suicidemsg;
            public bool warningmsg;
            public string warning1;
            public string warning2;
            public string zombie;
            public string gun;
            public string melee;
            public string melee2;
            public string punch;
            public string punch2;
            public string roadkill;
            public string vehicle;
            public string food;
            public string water;
            public string infection;
            public string bleeding;
            public string suicide;


            public IRocketPluginConfiguration DefaultConfiguration
            {
                get
                {
                    return new DeathMessagesConfig1()
                    {
                        suicidemsg = true,
                        warningmsg = true,
                        warning1 = "WARNING: You are about to die!",
                        warning2 = "We recommend you to patch yourself up!",
                        zombie = "has been mauled by a zombie!",
                        gun = "shot and killed",
                        melee = "has melee'd",
                        melee2 = "to death!",
                        punch = "has punched",
                        punch2 = "to death!",
                        roadkill = "ran over",
                        vehicle = "has died due to an explosion of a vehicle!",
                        food = "has starved to death!",
                        water = "has dehydrated to death!",
                        infection = "has become a zombie himself!",
                        bleeding = "has bled to death!",
                        suicide = "has killed himself!",
                    };
                }
            }
        }
    }
}
