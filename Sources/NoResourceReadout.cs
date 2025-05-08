using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace NoResourceReadout;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class NoResourceReadout : Mod
{
    private const string ModId = "johnson1893.no.resource.readout";

    public NoResourceReadout(ModContentPack content) : base(content)
    {
        // Init the configs
        Config = GetSettings<NoResourceReadoutSettings>();

        // Init the Harmony
        var harmonyInstance = new Harmony(ModId);
        harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
    }

    public static NoResourceReadoutSettings Config { get; private set; } = new();

    public override void DoSettingsWindowContents(Rect inRect)
    {
        Config.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "NoResourceReadout".Translate();
    }
}