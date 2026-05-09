using Modding;
using System.Reflection;
using TuyenTuyenTuyen.Charms;
using UnityEngine;

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

            ModHooks.CharmUpdateHook += Charm31_Dashmaster.OnCharmUpdate; // this has to be registered before Sharp Shadow's logic to ensure correct dash speed calculation

			On.HeroController.Awake += Charm03_GrubSong.OnHCAwake;
            ModHooks.TakeHealthHook += Charm03_GrubSong.OnTakeHealth;
			On.HutongGames.PlayMaker.Actions.IntSwitch.OnEnter += Charm05_BaldurShell.OnIntSwitch_OnEnter;
			On.PlayerData.MaxHealth += Charm05_BaldurShell.OnPDMaxHealth;
			ModHooks.BeforeAddHealthHook += Charm05_BaldurShell.OnBeforeAddHealth;
			On.PlayerData.UpdateBlueHealth += Charm09_LifebloodCore.OnUpdateBlueHealth;
            On.HutongGames.PlayMaker.Actions.FloatMultiplyV2.OnEnter += Charm16_SharpShadow.OnFloatMultiplyV2_OnEnter;
            On.HutongGames.PlayMaker.Actions.ConvertFloatToInt.OnEnter += Charm16_SharpShadow.OnConvertFloatToInt_OnEnter;
            ModHooks.CharmUpdateHook += Charm16_SharpShadow.OnCharmUpdate;
            ModHooks.SoulGainHook += Charm20_SoulCatcher.OnSoulGain;
            ModHooks.SoulGainHook += Charm21_SoulEater.OnSoulGain;
            On.HUDCamera.OnEnable += Charm23_Heart.OnHCOnEnable;
            ModHooks.CharmUpdateHook += Charm23_Heart.OnCharmUpdate; // this has to be registered before Joni's Blessing's logic to ensure correct health calculation
            On.HutongGames.PlayMaker.Fsm.DoTransition += Charm24_Greed.OnFsmDoTransition;
            On.HealthManager.Die += Charm24_Greed.OnHMDie;
			On.HutongGames.PlayMaker.Actions.FloatMultiply.OnEnter += Charm25_Strength.OnFloatMutiply_OnEnter;
			ModHooks.CharmUpdateHook += Charm27_JoniBlessing.OnCharmUpdate;
            ModHooks.HeroUpdateHook += Charm29_Hiveblood.OnHeroUpdate;
			On.HutongGames.PlayMaker.Actions.FloatMultiply.OnEnter += Charm34_DeepFocus.OnFloatMutiply_OnEnter;
            ModHooks.CharmUpdateHook += Charm37_Sprintmaster.OnCharmUpdate;
            ModHooks.GetPlayerIntHook += NewCharmCosts.OnGetInt;
        }

		public void Unload() {
			CharmRebalanced.LoadedInstance = null;
            if (HeroController.instance != null)
                RevertChanges();

            ModHooks.CharmUpdateHook -= Charm31_Dashmaster.OnCharmUpdate;

            On.HeroController.Awake -= Charm03_GrubSong.OnHCAwake;
            ModHooks.TakeHealthHook -= Charm03_GrubSong.OnTakeHealth;
            On.HutongGames.PlayMaker.Actions.IntSwitch.OnEnter -= Charm05_BaldurShell.OnIntSwitch_OnEnter;
            On.PlayerData.MaxHealth -= Charm05_BaldurShell.OnPDMaxHealth;
            ModHooks.BeforeAddHealthHook -= Charm05_BaldurShell.OnBeforeAddHealth;
            On.PlayerData.UpdateBlueHealth -= Charm09_LifebloodCore.OnUpdateBlueHealth;
            On.HutongGames.PlayMaker.Actions.FloatMultiplyV2.OnEnter -= Charm16_SharpShadow.OnFloatMultiplyV2_OnEnter;
            On.HutongGames.PlayMaker.Actions.ConvertFloatToInt.OnEnter -= Charm16_SharpShadow.OnConvertFloatToInt_OnEnter;
            ModHooks.CharmUpdateHook -= Charm16_SharpShadow.OnCharmUpdate;
            ModHooks.SoulGainHook -= Charm20_SoulCatcher.OnSoulGain;
            ModHooks.SoulGainHook -= Charm21_SoulEater.OnSoulGain;
            On.HUDCamera.OnEnable -= Charm23_Heart.OnHCOnEnable;
            ModHooks.CharmUpdateHook -= Charm23_Heart.OnCharmUpdate;
            On.HutongGames.PlayMaker.Fsm.DoTransition -= Charm24_Greed.OnFsmDoTransition;
            On.HealthManager.Die -= Charm24_Greed.OnHMDie;
            On.HutongGames.PlayMaker.Actions.FloatMultiply.OnEnter -= Charm25_Strength.OnFloatMutiply_OnEnter;
            ModHooks.CharmUpdateHook -= Charm27_JoniBlessing.OnCharmUpdate;
            ModHooks.HeroUpdateHook -= Charm29_Hiveblood.OnHeroUpdate;
            On.HutongGames.PlayMaker.Actions.FloatMultiply.OnEnter -= Charm34_DeepFocus.OnFloatMutiply_OnEnter;
            ModHooks.CharmUpdateHook -= Charm37_Sprintmaster.OnCharmUpdate;
            ModHooks.GetPlayerIntHook -= NewCharmCosts.OnGetInt;
        }

        private void RevertChanges() {
            HeroController HC = HeroController.instance;
            HC.GRUB_SOUL_MP = 15;
            HC.GRUB_SOUL_MP_COMBO = 25;
            HC.RUN_SPEED = 8.3f;
            HC.RUN_SPEED_CH = 10.0f;
            HC.RUN_SPEED_CH_COMBO = 11.5f;
            HC.DASH_SPEED = 20.0f;
            HC.DASH_SPEED_SHARP = 28.0f;
            HC.SHADOW_DASH_COOLDOWN = 1.5f;
        }
    }
}
