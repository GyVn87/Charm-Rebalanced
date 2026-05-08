using System.Collections.Generic;

namespace TuyenTuyenTuyen.Charms {
    internal static class NewCharmCosts {
        private static Dictionary<string, int> charmCosts = new Dictionary<string, int>() {
            {"charmCost_8", 1},
            {"charmCost_21", 3},
            {"charmCost_27", 2},
            {"charmCost_29", 3},
            {"charmCost_34", 3}
        };

    internal static int OnGetInt(string name, int orig) {
            if (NewCharmCosts.charmCosts.TryGetValue(name, out int newCost))
                return newCost;
            return orig;
        }
    }
}