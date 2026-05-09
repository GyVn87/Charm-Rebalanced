namespace TuyenTuyenTuyen.Charms {
    internal static class Charm25_Strength {
        private static readonly float strengthMutiplier = 1.35f;

        internal static void OnFloatMutiply_OnEnter(On.HutongGames.PlayMaker.Actions.FloatMultiply.orig_OnEnter orig, HutongGames.PlayMaker.Actions.FloatMultiply self) {
            if (self.Fsm.Name == "nailart_damage" && self.State.Name == "Init") {
                if (CharmRebalanced.LoadedInstance.PD.GetBool("equippedCharm_25"))
                    self.floatVariable.Value *= strengthMutiplier;
            }
            else if (self.State.Name == "Glass Attack Modifier")
                self.multiplyBy.Value = strengthMutiplier;
            orig(self);
        }
    }
}
