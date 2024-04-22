using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace ContentWarningMod
{
    internal class CWMod : MonoBehaviour
    {
        Player localPlayer;
        string x = "";
        string y = "";
        public void OnGUI()
        {
            Render.Begin("Risk of Tears 1.0.1", 4f, 1f, 180f, 750f, 10f, 20f, 2f);
            Render.Label(x);
            Render.Label(y);
        }
        public void Start()
        {

        }

        public void Update()
        {
            UpdateLocalPlayer();
            localPlayer.data.health = 99999f;
            x = (localPlayer.data.health).ToString();
            y = (localPlayer.data.remainingOxygen).ToString();


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
    }

    
}
