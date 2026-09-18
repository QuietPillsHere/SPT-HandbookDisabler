using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using Comfort.Common;
using EFT;
using EFT.UI;
using HarmonyLib;
using SPT.HandbookDisabler.Patch;
using System.Reflection;
using UnityEngine;

namespace SPT.HandbookDisabler
{
    [BepInPlugin(PluginInfo.PluginID, PluginInfo.Name, PluginInfo.PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> DisableHanbookButton { get; set; }
        public static ConfigEntry<bool> DisableHanbookCounter { get; set; }

        private void Awake()
        {
            Logger.LogInfo($"Plugin Awake");

            // BepIn Configuration Init
            InitialConfiguration();

            // BepIn Plugin Init
            new Patch4DisableHandbook().Enable();
            new Patch4DisableHandbookEvent().Enable();
        }

        public void InitialConfiguration()
        {
            DisableHanbookButton = Config.Bind(
                "1. Settings",
                "Disable Handbook Button (Require Restart)",
                false
            );

            DisableHanbookCounter = Config.Bind(
                "1. Settings",
                "Disable Handbook Counter",
                true
            );
        }

    }
}
