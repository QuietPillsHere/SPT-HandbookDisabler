using BepInEx;
using BepInEx.Logging;
using Comfort.Common;
using Diz.LanguageExtensions;
using EFT;
using EFT.HealthSystem;
using EFT.InventoryLogic;
using EFT.UI;
using HarmonyLib;
using SPT.Reflection.Patching;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace SPT.HandbookDisabler.Patch
{
    internal class Patch4DisableHandbookEvent : BasePatchModule
    {
        private static new readonly ManualLogSource Logger = CreateLoggerSource(nameof(Patch4DisableHandbookEvent));

        protected override MethodBase GetTargetMethod()
        {
            Logger.LogInfo("Try To Find Method For Patch");

            return AccessTools.Method(typeof(MenuTaskBar), nameof(MenuTaskBar.method_16));
        }

        [PatchPostfix]
        static void Postfix(MenuTaskBar __instance)
        {
            if (Plugin.DisableHanbookCounter.Value)
            {
                __instance._newNodesObject.SetActive(false);
            }
        }
    }
}
