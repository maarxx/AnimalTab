﻿// Patch_WorkGiver_Train_JobOnThing.cs
// Copyright Karel Kroeze, 2019-2019

using Harmony;
using RimWorld;
using Verse;
using Verse.AI;

namespace AnimalTab
{
    [HarmonyPatch( typeof( WorkGiver_Train ), nameof( WorkGiver_Train.JobOnThing ) )]
    class Patch_WorkGiver_Train_JobOnThing
    {
        public static void Postfix( Pawn pawn, Thing t, ref Job __result )
        {
            if ( __result == null )
                return;

            var target          = t as Pawn;
            var handlerSettings = target?.GetComp<CompHandlerSettings>();

            if ( !handlerSettings.Allows( pawn, out string reason ) )
            {
                JobFailReason.Is( reason );
                __result = null;
            }
        }
    }
}