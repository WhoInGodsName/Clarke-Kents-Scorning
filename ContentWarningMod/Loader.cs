using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ContentWarningMod
{
    public class Loader : MonoBehaviour
    {
        public static void Init()
        {
            Loader.Load = new GameObject();
            Loader.Load.AddComponent<CWMod>();
            UnityEngine.Object.DontDestroyOnLoad(Loader.Load);
        }

        public static void Unload()
        {
            _Unload();
        }

        private static void _Unload()
        {
            GameObject.Destroy(Load);
        }

        private static GameObject Load;
    }
}
