using System.Collections.Generic;

namespace TuyenTuyenTuyen.Charms {
    internal static class NewCharmCosts {
        internal static Dictionary<string, int> charmCosts = new Dictionary<string, int>() {
            {"charmCost_21", 3}
        };

    internal static int OnGetInt(string name, int orig) {
            if (NewCharmCosts.charmCosts.TryGetValue(name, out int newCost))
                return newCost;
            return orig;
        }
    }
}