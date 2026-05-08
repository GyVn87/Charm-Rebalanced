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
			On.PlayerData.MaxHealth += Charm05_BaldurShell.OnPDMaxHealth;
			ModHooks.BeforeAddHealthHook += Charm05_BaldurShell.OnBeforeAddHealth;
			On.PlayerData.UpdateBlueHealth += Charm09_LifebloodCore.OnUpdateBlueHealth;
			ModHooks.SoulGainHook += Charm20_SoulCatcher.OnSoulGain;
            ModHooks.SoulGainHook += Charm21_SoulEater.OnSoulGain;
            On.HUDCamera.OnEnable += Charm23_Heart.OnHCOnEnable;
            ModHooks.CharmUpdateHook += Charm23_Heart.OnCharmUpdate; // this has to be registered before Joni's Blessing hooks to ensure correct health calculation
			On.HutongGames.PlayMaker.Actions.FloatMultiply.OnEnter += Charm25_Strength.OnFloatMutiply_OnEnter;
			ModHooks.CharmUpdateHook += Charm27_JoniBlessing.OnCharmUpdate;
            ModHooks.HeroUpdateHook += Charm29_Hiveblood.OnHeroUpdate;
			On.HutongGames.PlayMaker.Actions.FloatMultiply.OnEnter += Charm34_DeepFocus.OnFloatMutiply_OnEnter;
            ModHooks.GetPlayerIntHook += NewCharmCosts.OnGetInt;
        }

		public void Unload() {
			CharmRebalanced.LoadedInstance = null;

            On.HeroController.Awake -= Charm03_GrubSong.OnHCAwake;
            ModHooks.TakeHealthHook -= Charm03_GrubSong.OnTakeHealth;
            On.HutongGames.PlayMaker.Actions.IntSwitch.OnEnter -= Charm05_BaldurShell.OnIntSwitch_OnEnter;
            On.PlayerData.MaxHealth -= Charm05_BaldurShell.OnPDMaxHealth;
            ModHooks.BeforeAddHealthHook -= Charm05_BaldurShell.OnBeforeAddHealth;
            On.PlayerData.UpdateBlueHealth -= Charm09_LifebloodCore.OnUpdateBlueHealth;
            ModHooks.SoulGainHook -= Charm20_SoulCatcher.OnSoulGain;
            ModHooks.SoulGainHook -= Charm21_SoulEater.OnSoulGain;
            On.HUDCamera.OnEnable -= Charm23_Heart.OnHCOnEnable;
            ModHooks.CharmUpdateHook -= Charm23_Heart.OnCharmUpdate;
            On.HutongGames.PlayMaker.Actions.FloatMultiply.OnEnter -= Charm25_Strength.OnFloatMutiply_OnEnter;
            ModHooks.CharmUpdateHook -= Charm27_JoniBlessing.OnCharmUpdate;
            ModHooks.HeroUpdateHook -= Charm29_Hiveblood.OnHeroUpdate;
            On.HutongGames.PlayMaker.Actions.FloatMultiply.OnEnter -= Charm34_DeepFocus.OnFloatMutiply_OnEnter;
            ModHooks.GetPlayerIntHook -= NewCharmCosts.OnGetInt;
        }
    }
}
