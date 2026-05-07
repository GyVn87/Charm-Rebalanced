namespace TuyenTuyenTuyen.Charms {
    internal static class Charm29_Hiveblood {
        private static PlayMakerFSM FSM;
        
        internal static void OnHeroUpdate() {
            if (FSM == null)
                FSM = GameCameras.instance.transform.Find("HudCamera/Hud Canvas/Health").gameObject.LocateMyFSM("Hive Health Regen");
            PlayerData PD = CharmRebalanced.LoadedInstance.PD;
            if ((FSM.ActiveStateName == "Idle") && (PD.GetInt("health") < PD.CurrentMaxHealth))
                FSM.SetState("Start Recovery");
        }
    }
}
