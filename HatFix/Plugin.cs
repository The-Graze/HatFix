using BepInEx;
using GorillaNetworking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilla;

namespace HatFix
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        void Start() =>
        GorillaTagger.OnPlayerSpawned(delegate
        {
            Camera useCam = GorillaTagger.Instance.thirdPersonCamera.GetComponentInChildren<Camera>();

            int mask = Camera.main.cullingMask;

            //creates a new layer mask with JUST that layer in it
            int metaReportScreen = 1 << LayerMask.NameToLayer("MetaReportScreen");
            int NoMirror = 1 << LayerMask.NameToLayer("NoMirror");
            int MirrorOnly = 1 << LayerMask.NameToLayer("MirrorOnly");

            //mask &= ~LAYER  takes away the layer
            mask &= ~NoMirror;
            mask &= ~metaReportScreen;

            //mask |= LAYER  adds the layer
            mask |= MirrorOnly;
            useCam.cullingMask = mask;
        });
    }
}
