using RimWorld;
using System.Collections.Generic;
using Verse;

namespace TorsionPsycast
{
    public class CompAbilityEffect_TargetBalls : CompAbilityEffect
    {
        public new CompProperties_AbilityTargetBalls Props => (CompProperties_AbilityTargetBalls)props;

        public override bool Valid(LocalTargetInfo target, bool throwMessages = true)
        {
            if (!base.Valid(target))
                return false;

            Pawn pawn = target.Pawn;

            if (Props.excludeRaces.Contains(pawn.def))
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

        public override bool AICanTargetNow(LocalTargetInfo target)
        {
            return Valid(target);
        }
    }
}