using HutongGames.PlayMaker;
using UnityEngine;

namespace TuyenTuyenTuyen.Charms {
    internal static class Charm12_ThornsOfAgony {
        private static readonly float thornDamageMutiplier = 2.0f;

        internal static void OnSetFsmInt_OnEnter(On.HutongGames.PlayMaker.Actions.SetFsmInt.orig_OnEnter orig, HutongGames.PlayMaker.Actions.SetFsmInt self) {
            orig(self);
            if (self.Fsm.Name == "set_thorn_damage" && self.State.Name == "Set") {
                GameObject targetGO = self.Fsm.GetOwnerDefaultTarget(self.gameObject);
                if (targetGO == null) return;
                PlayMakerFSM targetFSM = ActionHelpers.GetGameObjectFsm(targetGO, self.fsmName.Value);
                if (targetFSM == null) return;
                FsmInt fsmInt = targetFSM.FsmVariables.GetFsmInt(self.variableName.Value);
                if (fsmInt == null) return;
                fsmInt.Value = Mathf.CeilToInt((float)self.setValue.Value * thornDamageMutiplier);
            }
        }
    }
}
