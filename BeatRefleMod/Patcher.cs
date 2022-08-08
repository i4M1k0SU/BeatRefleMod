using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Orgesta;

namespace BeatRefleMod
{
    // 動かない
    // サンプルとして残す
    public class Patcher
    {
        public static void DoPatching()
        {
            Harmony.DEBUG = true;
            var harmony = new Harmony("jp.i4m1k0su.beatreflehack");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(ControllerIcon))]
    [HarmonyPatch("UpdateKeyIcon")]
    class KeyIconPatch
    {
        static AccessTools.FieldRef<ControllerIcon, FooterKeyMapData.FooterKeyMap> keyMapRef = AccessTools.FieldRefAccess<ControllerIcon, FooterKeyMapData.FooterKeyMap>("keyMap");

        static bool Prefix(ControllerIcon __instance, ref Image ___iconImg)
        {
            if (keyMapRef(__instance) == null)
            {
                return false;
            }

            //Gamepad current = Gamepad.current;
            //if (current == null)
            ___iconImg.sprite = keyMapRef(__instance).pcIcon;
            //else if (current.layout.Contains("XInput"))
            //    ___iconImg.sprite = ___keyMap.xboxIcon;
            //else if (current.layout.Contains("DualShock"))
            //    ___iconImg.sprite = ___keyMap.xboxIcon;
            //else if (current.layout.Contains("SwitchPro") || current.layout.Contains("NPad"))
            //    ___iconImg.sprite = ___keyMap.switchIcon;
            ___iconImg.SetNativeSize();

            return false;
        }
    }
}
