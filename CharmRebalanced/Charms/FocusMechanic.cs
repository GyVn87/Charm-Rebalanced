namespace TuyenTuyenTuyen.Charms {
    internal static class FocusMechanic {
        internal static void Load() {
            On.HutongGames.PlayMaker.Actions.IntCompare.OnEnter += OnIntCompare_OnEnter;
        }

        internal static void Unload() {
            On.HutongGames.PlayMaker.Actions.IntCompare.OnEnter -= OnIntCompare_OnEnter;
        }

        private static void OnIntCompare_OnEnter(On.HutongGames.PlayMaker.Actions.IntCompare.orig_OnEnter orig, HutongGames.PlayMaker.Actions.IntCompare self) {
            if (self.Fsm.Name == "Spell Control" && self.State.Name.StartsWith("Full HP?") && self.integer1.Name == "HP") {
                self.Finish();
                return; 
            }
            orig(self);
        }
    }
}
