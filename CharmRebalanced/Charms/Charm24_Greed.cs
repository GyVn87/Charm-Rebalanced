using System.Reflection;
using UnityEngine;

namespace TuyenTuyenTuyen.Charms {
    internal static class Charm24_Greed {
        private static readonly float trialRewardIncrease = 1.25f;
        private static readonly float geoGainIncrease = 1.5f;

        private static readonly FieldInfo smallGeoField = typeof(HealthManager).GetField("smallGeoDrops", BindingFlags.Instance | BindingFlags.NonPublic);
        private static readonly FieldInfo mediumGeoField = typeof(HealthManager).GetField("mediumGeoDrops", BindingFlags.Instance | BindingFlags.NonPublic);
        private static readonly FieldInfo largeGeoField = typeof(HealthManager).GetField("largeGeoDrops", BindingFlags.Instance | BindingFlags.NonPublic);

        internal static bool OnFsmDoTransition(On.HutongGames.PlayMaker.Fsm.orig_DoTransition orig, HutongGames.PlayMaker.Fsm self, HutongGames.PlayMaker.FsmTransition transition, bool isGlobal) {
            PlayerData PD = CharmRebalanced.LoadedInstance.PD;
            if (self.Name == "Geo Pool" && transition.EventName == "GIVE GEO") {
                if (PD.GetBool("equippedCharm_24") && !PD.GetBool("brokenCharm_24"))
                    self.Variables.GetFsmInt("Starting Pool").Value = (int)(self.Variables.GetFsmInt("Starting Pool").Value * trialRewardIncrease);
            }
            return orig(self, transition, isGlobal);
        }

        internal static void OnHMDie(On.HealthManager.orig_Die orig, HealthManager self, float? attackDirection, AttackTypes attackType, bool ignoreEvasion) {
            PlayerData PD = CharmRebalanced.LoadedInstance.PD;
            if (PD.GetBool("equippedCharm_24") && !PD.GetBool("brokenCharm_24")) {
                int smallGeoDrops = (int)smallGeoField.GetValue(self);
                smallGeoField.SetValue(self, Mathf.CeilToInt((float)smallGeoDrops * geoGainIncrease));
                int mediumGeoDrops = (int)mediumGeoField.GetValue(self);
                mediumGeoField.SetValue(self, Mathf.CeilToInt((float)mediumGeoDrops * geoGainIncrease));
                int largeGeoDrops = (int)largeGeoField.GetValue(self);
                largeGeoField.SetValue(self, Mathf.CeilToInt((float)largeGeoDrops * geoGainIncrease));
            }
            orig(self, attackDirection, attackType, ignoreEvasion);
        }
    }
}
