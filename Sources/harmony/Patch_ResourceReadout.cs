using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using NoResourceReadout.defs;
using RimWorld;
using UnityEngine;
using Verse.Sound;

namespace NoResourceReadout.harmony;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[HarmonyPatch(typeof(ResourceReadout))]
public static class Patch_ResourceReadout
{
    /// <summary>
    ///     Totally disables the readout if mod enabled.
    /// </summary>
    [HarmonyPrefix]
    [HarmonyPatch(nameof(ResourceReadout.ResourceReadoutOnGUI))]
    public static bool Prefix()
    {
        if (NoResourceReadoutDefOf.NoResourceReadoutEnabled.KeyDownEvent && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
        {
            NoResourceReadout.Config.ReadoutDisabled = !NoResourceReadout.Config.ReadoutDisabled;
            if (NoResourceReadout.Config.ReadoutDisabled)
                SoundDefOf.Checkbox_TurnedOff.PlayOneShotOnCamera();
            else
                SoundDefOf.Checkbox_TurnedOn.PlayOneShotOnCamera();
        }

        return !NoResourceReadout.Config.ReadoutDisabled;
    }
}