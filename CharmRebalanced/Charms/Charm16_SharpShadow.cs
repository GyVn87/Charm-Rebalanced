namespace TuyenTuyenTuyen.Charms {
    internal static class Charm16_SharpShadow {
        private static readonly float shadowDashSpeedIncrease = 1.3f;
        private static readonly float shadowDashDamageSharp = 2.0f;
        private static readonly float shadowDashDamageMaster = 1.0f;

        internal static void OnCharmUpdate(PlayerData data, HeroController controller) {
            if (data.GetBool("equippedCharm_16"))
                controller.DASH_SPEED_SHARP = controller.DASH_SPEED * shadowDashSpeedIncrease;
            else
                controller.DASH_SPEED_SHARP = controller.DASH_SPEED;
        }

        internal static void OnFloatMultiplyV2_OnEnter(On.HutongGames.PlayMaker.Actions.FloatMultiplyV2.orig_OnEnter orig, HutongGames.PlayMaker.Actions.FloatMultiplyV2 self) {
            if (self.Fsm.Name == "Set Sharp Shadow Damage" && self.State.Name == "Master")
                self.multiplyBy = shadowDashDamageMaster;
            orig(self);
        }

        internal static void OnConvertFloatToInt_OnEnter(On.HutongGames.PlayMaker.Actions.ConvertFloatToInt.orig_OnEnter orig, HutongGames.PlayMaker.Actions.ConvertFloatToInt self) {
            if (self.Fsm.Name == "Set Sharp Shadow Damage" && self.State.Name == "Set") 
                self.floatVariable.Value *= shadowDashDamageSharp;
            orig(self);
        }
    }
}
