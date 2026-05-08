namespace TuyenTuyenTuyen.Charms {
    internal static class Charm21_SoulEater {
        private static int soulCharge = 7;
        private static int soulReserve = 6;

        internal static int OnSoulGain(int orig) {
            PlayerData PD = CharmRebalanced.LoadedInstance.PD;
            if (PD.GetBool("equippedCharm_21")) {
                if (PD.GetInt("MPCharge") < PD.GetInt("maxMP"))
                    orig = orig - 8 + soulCharge;
                else
                    orig = orig - 6 + soulReserve;
            }
            return orig;
        }
    }
}
