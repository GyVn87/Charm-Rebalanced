namespace TuyenTuyenTuyen.Charms {
    internal static class Charm09_LifebloodCore {
        private static readonly int blueHealthIncreases = 6;

        internal static void OnUpdateBlueHealth(On.PlayerData.orig_UpdateBlueHealth orig, PlayerData self) {
            orig(self);
            if (self.GetBool("equippedCharm_9"))
                self.SetInt("healthBlue", self.GetInt("healthBlue") - 4 + blueHealthIncreases);
        }
    }
}
