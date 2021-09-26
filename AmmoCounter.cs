using System.Collections;
using Comfort.Common;
using EFT;
using UnityEngine;

namespace Kiobu.AmmoDisplay
{
    public class AmmoCounter : MonoBehaviour
    {
        void OnGUI()
        {
            if (InWorld())
            {
                Player player = LocalPlayer();
                var ammo = player.Weapon.GetCurrentMagazine()?.Cartridges.Count;
                var chamber = player.Weapon.ChamberAmmoCount;

                var magmax = player.Weapon.GetCurrentMagazine()?.Cartridges.MaxCount;
                
                if (ammo == null)
                {
                    return;
                }
                else
                {
                    ammo += chamber;
                    var ammoString = ((int)ammo).ToString();
                    GUI.Label(new Rect(Screen.width - 400, Screen.height - 200, 400, 200), "Ammo: " + ammoString + " / " + magmax);
                }
            }
        }

        private static bool InWorld()
        {
            return Singleton<GameWorld>.Instance != null;
        }

        private static Player LocalPlayer()
        {
            if (InWorld())
            {
                return Singleton<GameWorld>.Instance.RegisteredPlayers.Find(p => p.IsYourPlayer);
            }
            return null;
        }
    }
}