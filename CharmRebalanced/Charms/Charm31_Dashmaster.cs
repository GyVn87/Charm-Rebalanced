namespace TuyenTuyenTuyen.Charms {
    internal static class Charm31_Dashmaster {
        private static readonly float dashSpeed = 20.0f;
        private static readonly float dashSpeedIncrease = 1.1f;
        private static readonly float dashSpeedMaster = dashSpeed * dashSpeedIncrease;

        private static readonly float shadowDashCooldown = 1.5f;
        private static readonly float shadowDashCooldownDecrease = 0.9f;
        private static readonly float shadowDashCooldownMaster = shadowDashCooldown * shadowDashCooldownDecrease;

        internal static void Load() {
            ModHooks.CharmUpdateHook += Charm31_Dashmaster.OnCharmUpdate;
        }

        internal static void Unload() {
            ModHooks.CharmUpdateHook -= Charm31_Dashmaster.OnCharmUpdate;
        }

        private static void OnCharmUpdate(PlayerData data, HeroController controller) {
            if (data.GetBool("equippedCharm_31")) {
                controller.DASH_SPEED = dashSpeedMaster;
                controller.SHADOW_DASH_COOLDOWN = shadowDashCooldownMaster;
            }
            else {
                controller.DASH_SPEED = dashSpeed;
                controller.SHADOW_DASH_COOLDOWN = shadowDashCooldown;
            }
        }
    }
}
