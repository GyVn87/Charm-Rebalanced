using HutongGames.PlayMaker;
using UnityEngine;


namespace TuyenTuyenTuyen.Charms {
    internal static class Charm39_Weaversong {
        private static readonly int soulGainOnHit = 3;
        private static readonly float weaverlingDamageRatio = 0.33f; // to nail damage

        internal static void OnPlayerDataBoolTest_OnEnter(On.HutongGames.PlayMaker.Actions.PlayerDataBoolTest.orig_OnEnter orig, HutongGames.PlayMaker.Actions.PlayerDataBoolTest self) {
            if (self.Owner.name != "Enemy Damager" || self.Fsm.Name != "Attack" || self.State.Name != "Grubsong") {
                orig(self);
                return;
            }
            FsmEvent isFalseEventDefault = self.isFalse;
            self.isFalse = null;
            orig(self);
            self.isFalse = isFalseEventDefault;

            SetWeaverlingDamage(self);
        }

        internal static void OnCallMethodProper_OnEnter(On.HutongGames.PlayMaker.Actions.CallMethodProper.orig_OnEnter orig, HutongGames.PlayMaker.Actions.CallMethodProper self) {
            if (self.Owner.name != "Enemy Damager" || self.Fsm.Name != "Attack" || self.State.Name != "Grubsong") {
                orig(self);
                return;
            }
            int soulGainDefault = (int)self.parameters[0].GetValue();
            self.parameters[0].SetValue(soulGainOnHit);
            orig(self);
            self.parameters[0].SetValue(soulGainDefault);
        }

        private static void SetWeaverlingDamage(HutongGames.PlayMaker.Actions.PlayerDataBoolTest self) {
            int nailDamage = CharmRebalanced.LoadedInstance.PD.GetInt("nailDamage");
            self.Fsm.Variables.GetFsmInt("Damage").Value = Mathf.CeilToInt((float)nailDamage * weaverlingDamageRatio);
        }
    }
}
