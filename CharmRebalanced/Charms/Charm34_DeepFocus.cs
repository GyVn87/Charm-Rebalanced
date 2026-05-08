using UnityEngine.Assertions.Must;

namespace TuyenTuyenTuyen.Charms {
    internal static class Charm34_DeepFocus {
        private static float deepFocusSpeedIncreases = 1.5f;
        internal static void OnFloatMutiply_OnEnter(On.HutongGames.PlayMaker.Actions.FloatMultiply.orig_OnEnter orig, HutongGames.PlayMaker.Actions.FloatMultiply self) {
            if (self.State.Name != "Deep Focus Speed") {
                orig(self);
                return;
            }
            self.multiplyBy.Value = deepFocusSpeedIncreases;
            orig(self);
        }
    }
}
