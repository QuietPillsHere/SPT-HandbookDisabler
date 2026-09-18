using BepInEx.Logging;
using EFT;
using EFT.InventoryLogic;
using EFT.UI.DragAndDrop;
using HarmonyLib;
using SPT.Reflection.Patching;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using LoggerInstance = BepInEx.Logging.Logger;

namespace SPT.HandbookDisabler.Patch
{
    internal class BasePatchModule : ModulePatch
    {
        protected override MethodBase GetTargetMethod() 
        {
            throw new NotImplementedException();
        }

        public static ManualLogSource CreateLoggerSource(string sourceName)
        {
            return LoggerInstance.CreateLogSource($"{PluginInfo.Name}.{sourceName}");
        }
    }
}
