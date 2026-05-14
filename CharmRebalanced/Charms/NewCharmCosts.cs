using System.Collections.Generic;

namespace TuyenTuyenTuyen.Charms {
    internal static class NewCharmCosts {
        private static readonly Dictionary<string, int> charmCosts = new Dictionary<string, int>() {
            {"charmCost_8", 1},
            {"charmCost_11", 2},
            {"charmCost_21", 3},
            {"charmCost_27", 2},
            {"charmCost_28", 1},
            {"charmCost_29", 3},
            {"charmCost_34", 3},
            {"charmCost_38", 2}
        };

        internal static void Load() {
            ModHooks.GetPlayerIntHook += NewCharmCosts.OnGetInt;
        }

        internal static void Unload() {
            ModHooks.GetPlayerIntHook -= NewCharmCosts.OnGetInt;
        }

        internal static int OnGetInt(string name, int orig) {
            if (NewCharmCosts.charmCosts.TryGetValue(name, out int newCost))
                return newCost;
            return orig;
        }
    }
}