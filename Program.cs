using UnityEngine;

namespace Kiobu.AmmoDisplay
{
    internal class Program
    {
        private static GameObject hookObject;
        public static void Main(string[] args)
        {
            Debug.LogError("Loading Kiobu's ammo display mod.");
            hookObject = new GameObject();
            hookObject.AddComponent<AmmoCounter>();
            Object.DontDestroyOnLoad(hookObject);
        }
    }
}