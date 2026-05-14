using System;

namespace TuyenTuyenTuyen.Charms {
    internal static class Charm27_JoniBlessing {
        private static readonly float masksIncreases = 1.5f;

        internal static void Load() {
            ModHooks.CharmUpdateHook += Charm27_JoniBlessing.OnCharmUpdate;
        }

        internal static void Unload() {
            ModHooks.CharmUpdateHook -= Charm27_JoniBlessing.OnCharmUpdate;
        }

        private static void OnCharmUpdate(PlayerData data, HeroController controller) {
            if (data.GetBool("equippedCharm_27")) {
                data.SetInt("joniHealthBlue", (int)(Math.Ceiling((float)data.GetInt("maxHealth") * masksIncreases)) - 1);
                data.SetInt("maxHealth", 1);
                controller.MaxHealth();
            }
        }
    }
}
