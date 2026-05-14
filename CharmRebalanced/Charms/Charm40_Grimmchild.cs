    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuyenTuyenTuyen.Charms {
    internal static class Charm40_Grimmchild {
        private static readonly float newSpread = 0f; // the lower, the more accurate Grimmchild's shot is
        private static readonly int lv2Damage = 11;
        private static readonly int lv3Damage = 16;
        private static readonly int lv4Damage = 21;

        internal static void Load() {
            On.HutongGames.PlayMaker.Actions.FireAtTarget.OnEnter += Charm40_Grimmchild.OnFireAtTarget_OnEnter;
            On.HutongGames.PlayMaker.Actions.SetIntValue.OnEnter += Charm40_Grimmchild.OnSetIntValue_OnEnter;
        }

        internal static void Unload() {
            On.HutongGames.PlayMaker.Actions.FireAtTarget.OnEnter -= Charm40_Grimmchild.OnFireAtTarget_OnEnter;
            On.HutongGames.PlayMaker.Actions.SetIntValue.OnEnter -= Charm40_Grimmchild.OnSetIntValue_OnEnter;
        }

        private static void OnFireAtTarget_OnEnter(On.HutongGames.PlayMaker.Actions.FireAtTarget.orig_OnEnter orig, HutongGames.PlayMaker.Actions.FireAtTarget self) {
            string ownerName = self.Owner?.name;
            if (!ownerName.StartsWith("Grimmchild") || self.Fsm.Name != "Control" || self.State.Name != "Shoot") {
                orig(self);
                return;
            }

            float defaultSpread = self.spread.Value;
            self.spread.Value = newSpread;
            orig(self);
            self.spread.Value = defaultSpread;
        }

        private static void OnSetIntValue_OnEnter(On.HutongGames.PlayMaker.Actions.SetIntValue.orig_OnEnter orig, HutongGames.PlayMaker.Actions.SetIntValue self) {
            string ownerName = self.Owner?.name;
            string stateName = self.State.Name;
            if (!ownerName.StartsWith("Grimmchild") || self.Fsm.Name != "Control" || !stateName.StartsWith("Level ")) {
                orig(self);
                return;
            }

            orig(self);
            if (stateName == "Level 2")
                self.intVariable.Value = lv2Damage;
            else if (stateName == "Level 3")
                self.intVariable.Value = lv3Damage;
            else if (stateName == "Level 4")
                self.intVariable.Value = lv4Damage;
        }
    }
}
