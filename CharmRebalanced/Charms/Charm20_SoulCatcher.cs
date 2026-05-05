namespace TuyenTuyenTuyen.Charms {
    internal static class Charm20_SoulCatcher {
        internal static int soulCharge = 3;
        internal static int soulReserve = 3;

        // Subtracting the vanilla soul gain and adding the new ones.
        // This additive approach allows the mod can work with other mods that affect soul gain.
        internal static int OnSoulGain(int orig) {
            PlayerData PD = CharmRebalanced.LoadedInstance.PD;
            if (PD.GetInt("MPCharge") < PD.GetInt("maxMP")) {
                if (PD.GetBool("equippedCharm_20"))
                    orig = orig - 3 + soulCharge;
                if (PD.GetBool("equippedCharm_21"))
                    orig = orig - 8 + Charm21_SoulEater.soulCharge;
            }
            else {
                if (PD.GetBool("equippedCharm_20"))
                    orig = orig - 2 + soulReserve;
                if (PD.GetBool("equippedCharm_21"))
                    orig = orig - 6 + Charm21_SoulEater.soulReserve;
            }
            return orig;
        }
    }
}
