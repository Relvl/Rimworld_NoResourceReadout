using UnityEngine;
using Verse;

namespace NoResourceReadout;

public class NoResourceReadoutSettings : ModSettings
{
    public bool ReadoutDisabled;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref ReadoutDisabled, "ReadoutDisabled", true, true);
    }

    public void DoSettingsWindowContents(Rect inRect)
    {
        var list = new Listing_Standard(GameFont.Small);
        list.Begin(inRect);
        list.Label("NoResourceReadout.Config.Info".Translate());
        list.CheckboxLabeled("NoResourceReadout.Config.ReadoutDisabled".Translate(), ref ReadoutDisabled, "NoResourceReadout.Config.ReadoutDisabled.Desc".Translate());
        list.End();
    }
}