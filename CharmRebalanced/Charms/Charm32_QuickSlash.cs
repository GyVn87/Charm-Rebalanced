using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuyenTuyenTuyen.Charms {
    internal static class Charm32_QuickSlash {
        private static readonly float attackCooldown = 0.41f;
        private static readonly float attackDuration = 0.35f;
        private static readonly float attackCooldownDecrease = 0.75f; // 33% attack speed increase

        internal static void OnCharmUpdate(PlayerData data, HeroController controller) {
            controller.ATTACK_COOLDOWN_TIME_CH = attackCooldown * attackCooldownDecrease;
            controller.ATTACK_DURATION_CH = attackDuration * attackCooldownDecrease;
        }
    }
}
