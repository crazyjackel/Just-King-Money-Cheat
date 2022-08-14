using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCheat
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        void Awake()
        {
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(ShopData), "SetUpBase")]
    public class StartingGoldPatch
    {
        [HarmonyPostfix]
        public static void Postfix(ShopData __instance)
        {
            __instance.Gold = int.MaxValue / 2;
        }
    }
}
