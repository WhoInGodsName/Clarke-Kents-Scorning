using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using static SFX_Player;

namespace ContentWarningMod
{
    internal class CWMod : MonoBehaviour
    {
        Player localPlayer;
        NetworkWalletMoney_1 money;

        string currHealthLabel = "";
        string currOxygenLabel = "";
        string currStamLabel = "";

        //Oxygen and health toggles
        bool healthToggle = false;
        bool oxygenToggle = false;
        bool stamToggle = false;
        bool speedToggle = false;
        bool jumpToggle = false;

        public void OnGUI()
        {
            Render.Begin("CKS 0.0.1", 4f, 1f, 180f, 750f, 10f, 20f, 2f);
            Render.Label($"Health: {currHealthLabel}");
            if (Render.Button("Toggle Godmode")) { healthToggle = !healthToggle; }
            Render.Label($"Oxygen: {currOxygenLabel}");
            if (Render.Button("Toggle Inf Oxygen")) { oxygenToggle = !oxygenToggle; }
            Render.Label($"Stamina: {currStamLabel}");
            if (Render.Button("Toggle Inf Stamina")) { stamToggle = !stamToggle; }
            Render.Label($"Speed: {speedToggle}");
            if (Render.Button("Toggle Speed")) { speedToggle = !speedToggle; }
            if (Render.Button("Toggle Inf Jump")) { jumpToggle = !jumpToggle; }
            if (Render.Button("Sacrifice team </3")) { SacrificeTeam(); }
        }
        public void Awake()
        {
            FNUDiscord();
        }
        public void Start()
        {
            //FNUDiscord();
        }

        public void Update()
        {
            UpdateLocalPlayer();
            UpdateLabels();
            //FNUDiscord();
            if(healthToggle == true)
            {
                localPlayer.data.health = 200f;
            }

            if(oxygenToggle == true)
            {
                localPlayer.data.remainingOxygen = 500f;
            }
            if(stamToggle == true)
            {
                localPlayer.data.currentStamina = 10f;
            }
            if(speedToggle == true)
            {
                localPlayer.data.movementVector *= 50;
                
            }
            if (jumpToggle == true)
            {
                localPlayer.data.isGrounded = true;
            }
            


        }

        public void UpdateLocalPlayer()
        {
            foreach (Player player in Player.FindObjectsOfType(typeof(Player)))
            {
                if (player != null && player.IsLocal)
                {
                    localPlayer = player;
                }
            }
        }

        public void UpdateLabels()
        {
            currHealthLabel = (localPlayer.data.health).ToString();
            currOxygenLabel = (localPlayer.data.remainingOxygen).ToString();
            currStamLabel = (localPlayer.data.currentStamina).ToString();
        }
        public void SacrificeTeam()
        {
            foreach (Player player in Player.FindObjectsOfType(typeof(Player)))
            {
                if (player != null && player.IsLocal)
                {
                    continue;
                }
                player.data.health = 0f;
                player.Die();
                PlayerHandler.instance.playerAlive.Remove(player);
                player.data.dead = true;
                player.RPCA_PlayerDie();
            }
        }

        public void FNUDiscord()
        {
            DiscordButton discButton = FindObjectOfType<DiscordButton>();
            discButton.m_discordLink = "https://discord.gg/adWNsZAx6j";

        }
    } 
}
