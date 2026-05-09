using System;

namespace TuyenTuyenTuyen.Charms {
    internal static class Charm27_JoniBlessing {
        private static readonly float masksIncreases = 1.5f;

        internal static void OnCharmUpdate(PlayerData data, HeroController controller) {
            PlayerData PD = CharmRebalanced.LoadedInstance.PD;
            if (PD.GetBool("equippedCharm_27")) {
                PD.SetInt("joniHealthBlue", (int)(Math.Ceiling((float)PD.GetInt("maxHealth") * masksIncreases)) - 1);
                PD.SetInt("maxHealth", 1);
                controller.MaxHealth();
            }
        }
    }
}
