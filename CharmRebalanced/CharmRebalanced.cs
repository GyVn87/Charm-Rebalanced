using Modding;
using System.Reflection;
using TuyenTuyenTuyen.Charms;
using UnityEngine;
using HutongGames.PlayMaker; // testing

namespace TuyenTuyenTuyen {
	public class CharmRebalanced : Mod, ITogglableMod {
		public static CharmRebalanced LoadedInstance { get; set; }
		/// <summary>
		/// Using expression bodied property ensures that everytime we use pd,
		/// it will recalculate the value which helps us get the most up-to-date data.
		/// </summary>
		public PlayerData PD => PlayerData.instance;
		public GameObject Knight => HeroController.instance.gameObject;

		public override string GetVersion() => Assembly.GetExecutingAssembly().GetName().Version.ToString();

		public override void Initialize() {
			if (CharmRebalanced.LoadedInstance != null) return;
			CharmRebalanced.LoadedInstance = this;

			On.HeroController.Awake += Charm03_GrubSong.OnHCAwake;
            ModHooks.TakeHealthHook += Charm03_GrubSong.OnTakeHealth;
			On.HutongGames.PlayMaker.Actions.IntSwitch.OnEnter += Charm05_BaldurShell.OnIntSwitch_OnEnter;
			On.HutongGames.PlayMaker.Actions.SetMeshRenderer.OnEnter += Charm05_BaldurShell.OnSetMeshRenderer_OnEnter;
			ModHooks.BeforeAddHealthHook += Charm05_BaldurShell.OnBeforeAddHealth;
			ModHooks.SoulGainHook += Charm20_SoulCatcher.OnSoulGain;
            ModHooks.SoulGainHook += Charm21_SoulEater.OnSoulGain;
            ModHooks.HeroUpdateHook += Charm29_Hiveblood.OnHeroUpdate;
            ModHooks.GetPlayerIntHook += NewCharmCosts.OnGetInt;
        }

		public void Unload() {
			CharmRebalanced.LoadedInstance = null;

            On.HeroController.Awake -= Charm03_GrubSong.OnHCAwake;
            ModHooks.TakeHealthHook -= Charm03_GrubSong.OnTakeHealth;
            On.HutongGames.PlayMaker.Actions.IntSwitch.OnEnter -= Charm05_BaldurShell.OnIntSwitch_OnEnter;
            On.HutongGames.PlayMaker.Actions.SetMeshRenderer.OnEnter -= Charm05_BaldurShell.OnSetMeshRenderer_OnEnter;
            ModHooks.BeforeAddHealthHook -= Charm05_BaldurShell.OnBeforeAddHealth;
			ModHooks.SoulGainHook -= Charm20_SoulCatcher.OnSoulGain;
            ModHooks.SoulGainHook -= Charm21_SoulEater.OnSoulGain;
            ModHooks.HeroUpdateHook -= Charm29_Hiveblood.OnHeroUpdate;
            ModHooks.GetPlayerIntHook -= NewCharmCosts.OnGetInt;
        }
    }
}
