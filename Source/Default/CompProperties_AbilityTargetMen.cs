using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace TorsionPsycast
{
    public class CompProperties_AbilityTargetBalls : CompProperties_AbilityEffect
    {
        public List<ThingDef> excludeRaces;

        public CompProperties_AbilityTargetBalls()
        {
            compClass = typeof(CompAbilityEffect_TargetBalls);
        }
    }
}
