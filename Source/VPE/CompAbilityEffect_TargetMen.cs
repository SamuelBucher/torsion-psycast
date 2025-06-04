using RimWorld;
using System.Collections.Generic;
using Verse;
using VFECore.Abilities;

namespace TorsionPsycast
{
    public class AbilityExtension_TargetBalls : AbilityExtension_AbilityMod
    {
        public List<ThingDef> excludeRaces;

        public override bool ValidateTarget(LocalTargetInfo target, VFECore.Abilities.Ability ability, bool throwMessages = true)
        {
            if (!base.ValidateTarget(target, ability))
                return false;

            Pawn pawn = target.Pawn;

            if (excludeRaces.Contains(pawn.def))
            {
                if (throwMessages)
                {
                    Messages.Message("TorsionPsycast.TargetWrongRace".Translate(pawn), pawn, MessageTypeDefOf.RejectInput, historical: false);
                }
                return false;
            }
            if (pawn.gender != Gender.Male)
            {
                if (throwMessages)
                {
                    Messages.Message("TorsionPsycast.TargetNotMale".Translate(pawn), pawn, MessageTypeDefOf.RejectInput, historical: false);
                }
                return false;
            }
            if (pawn.health.hediffSet.HasHediff(HediffDefOf.Sterilized))
            {
                if (throwMessages)
                {
                    Messages.Message("TorsionPsycast.TargetSterile".Translate(pawn), pawn, MessageTypeDefOf.RejectInput, historical: false);
                }
                return false;
            }
            if (pawn.health.hediffSet.HasHediff(TP_HediffDefOf.TP_Torsion))
            {
                if (throwMessages)
                {
                    Messages.Message("TorsionPsycast.TargetHasTorsion".Translate(pawn), pawn, MessageTypeDefOf.RejectInput, historical: false);
                }
                return false;
            }
            return true;
        }
    }
}