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

			Charm31_Dashmaster.Load();  // has to be called before Sharp Shadow'
			Charm03_GrubSong.Load();
			Charm05_BaldurShell.Load();
			Charm09_LifebloodCore.Load();
			Charm11_Flukenest.Load();
			Charm12_ThornsOfAgony.Load();
			Charm15__HeavyBlow.Load();
			Charm16_SharpShadow.Load();
			Charm19_ShamanStone.Load();
			Charm20_SoulCatcher.Load();
			Charm21_SoulEater.Load();
			Charm23_Heart.Load();  // has to be called before Joni's Blessing
			Charm24_Greed.Load();
			Charm25_Strength.Load();
			Charm27_JoniBlessing.Load();
			Charm29_Hiveblood.Load();  
			Charm32_QuickSlash.Load();
			Charm34_DeepFocus.Load();
			Charm35_GrubberflyElegy.Load();
			Charm37_Sprintmaster.Load();
			Charm38_Dreamshield.Load();
			Charm39_Weaversong.Load(); 
			Charm40_Grimmchild.Load();
			NewCharmCosts.Load();
		}

		public void Unload() {
			CharmRebalanced.LoadedInstance = null;
			if (HeroController.instance != null)
				RevertChanges();

			Charm31_Dashmaster.Unload();
			Charm03_GrubSong.Unload();
			Charm05_BaldurShell.Unload();
			Charm09_LifebloodCore.Unload();
			Charm11_Flukenest.Unload();
			Charm12_ThornsOfAgony.Unload();
			Charm15__HeavyBlow.Unload();
			Charm16_SharpShadow.Unload();
			Charm19_ShamanStone.Unload();
			Charm20_SoulCatcher.Unload();
			Charm21_SoulEater.Unload();
			Charm23_Heart.Unload();
			Charm24_Greed.Unload();
			Charm25_Strength.Unload();
			Charm27_JoniBlessing.Unload();
			Charm29_Hiveblood.Unload();
			Charm32_QuickSlash.Unload();
			Charm34_DeepFocus.Unload();
			Charm35_GrubberflyElegy.Unload();
			Charm37_Sprintmaster.Unload();
			Charm38_Dreamshield.Unload();
			Charm39_Weaversong.Unload();
			Charm40_Grimmchild.Unload();
			NewCharmCosts.Unload();
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
			HC.ATTACK_COOLDOWN_TIME = 0.41f;
			HC.ATTACK_COOLDOWN_TIME_CH = 0.25f;
			HC.ATTACK_DURATION = 0.35f;
			HC.ATTACK_DURATION_CH = 0.28f;
		}
	}
}
