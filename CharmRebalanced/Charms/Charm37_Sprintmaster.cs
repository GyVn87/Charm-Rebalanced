namespace TuyenTuyenTuyen.Charms {
    internal static class Charm37_Sprintmaster {
        private static readonly float runSpeed = 8.3f;
        private static readonly float speedIncrease = 1.25f;
        private static readonly float runSpeedMaster = runSpeed * speedIncrease;
        private static readonly float runSpeedCombo = runSpeedMaster;

        internal static void OnCharmUpdate(PlayerData data, HeroController controller) {
            if (data.GetBool("equippedCharm_37"))
                controller.RUN_SPEED = runSpeedMaster;
            else
                controller.RUN_SPEED = runSpeed;
            controller.RUN_SPEED_CH = runSpeedMaster;
            controller.RUN_SPEED_CH_COMBO = runSpeedCombo;
        }
    }
}
