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
    internal class Patch4DisableHandbook : BasePatchModule
    {
        private static new readonly ManualLogSource Logger = CreateLoggerSource(nameof(Patch4DisableHandbook));

        protected override MethodBase GetTargetMethod()
        {
            Logger.LogInfo("Try To Find Method For Patch");

            return AccessTools.Method(typeof(MenuTaskBar), nameof(MenuTaskBar.Awake));
        }

        [PatchPostfix]
        static void Postfix(MenuTaskBar __instance, Dictionary<EMenuType, HoverTooltipArea> ____hoverTooltipAreas)
        {
            // Because cave man don't read, they just want to shoot gun, go brrrrrrrrr
            // Blyat man don't read, blyat man shoot gun, blyat man go brrrrrrrrr
            var handbookButton = ____hoverTooltipAreas[EMenuType.Handbook].gameObject;
            if (Plugin.DisableHanbookButton.Value)
            {
                handbookButton.SetActive(false);
            }
            else
            {
                handbookButton.SetActive(true);
            }
            if (Plugin.DisableHanbookCounter.Value)
            {
                __instance._newNodesObject.SetActive(false);
            }
            else
            {
                __instance._newNodesObject.SetActive(true);
            }
        }
    }
}
