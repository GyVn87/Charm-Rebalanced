using System;
using UnityEngine;

namespace TuyenTuyenTuyen.Charms {
    internal static class Charm05_BaldurShell {
        private static readonly int newBlockerHits = 6;
        private static readonly int brokenStage1 = 4; // Equal to when vanilla Baldur Shell takes 1 hit
        private static readonly int brokenStage2 = 2; // Equal to when vanilla Baldur Shell takes 2 hits

        internal static int OnBeforeAddHealth(int amount) {
            PlayerData PD = CharmRebalanced.LoadedInstance.PD;
            if (!PD.GetBool("equippedCharm_5"))
                return amount;
            if (PD.blockerHits == newBlockerHits)
                return amount;
            if (PD.GetInt("health") >= PD.CurrentMaxHealth) {
                GameObject Knight = CharmRebalanced.LoadedInstance.Knight;
                PlayMakerFSM FSM = Knight.transform.Find("Charm Effects").Find("Blocker Shield").GetComponent<PlayMakerFSM>();
                if (PD.blockerHits + amount >= newBlockerHits) {
                    FSM.Fsm.SetState("HUD Icon Up");
                    FSM.Fsm.SetState("Focus End");
                    CharmRebalanced.LoadedInstance.PD.SetInt("blockerHits", Math.Min(newBlockerHits, PD.blockerHits + amount));
                }
                else {
                    CharmRebalanced.LoadedInstance.PD.SetInt("blockerHits", Math.Min(newBlockerHits, PD.blockerHits + amount));
                    PD.blockerHits++; // Since blockerHits will be decremented by 1 in "Blocker Hit" state, so this line will be netraulized
                    FSM.Fsm.SetState("Blocker Hit");
                }
            }
            return amount;
        }

        /// <summary>
        /// override IntSwitch.OnEnter() method of state "Blocker Hit" of FSM Blocker Shield
        /// </summary>
        internal static void OnIntSwitch_OnEnter(On.HutongGames.PlayMaker.Actions.IntSwitch.orig_OnEnter orig, HutongGames.PlayMaker.Actions.IntSwitch self) {
            if (self.State.Name != "Blocker Hit" || self.Owner.name != "Blocker Shield") {
                orig(self);
                return;
            }
            int blockHits = self.intVariable.Value;
            // update the texture of the Baldur Shell icon on the up left of the screen
            if (blockHits >= brokenStage1)
                self.Fsm.Event("3"); // STAGE 1
            else if (blockHits >= brokenStage2)
                self.Fsm.Event("2"); // STAGE 2
            else
                self.Fsm.Event("1"); // STAGE 3
        }

        internal static void OnPDMaxHealth(On.PlayerData.orig_MaxHealth orig, PlayerData self) {
            orig(self);
            self.SetInt("blockerHits", newBlockerHits);
        }
    }
}
