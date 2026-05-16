using GlobalEnums;
using UnityEngine;

namespace TuyenTuyenTuyen.Charms {
    internal static class Charm10_DefenderCrest {
        private static readonly float weaknessDebuffMultiplier = 1.1f;
        internal static readonly float weaknessDuration = 1f;

        private static readonly float knightDungTrailDuration = 2f;

        private static readonly Vector3 knightDungTrailScale = new Vector3(1.2f, 1.2f, 1.2f);

        internal static void Load() {
            On.DamageEffectTicker.OnTriggerEnter2D += OnDamageEffectTicker_OnTriggerEnter2D;
            On.HealthManager.TakeDamage += OnHealthManager_TakeDamage;
            On.HutongGames.PlayMaker.Actions.GetOwner.OnEnter += OnGetOwner_OnEnter;
            On.HutongGames.PlayMaker.Actions.Wait.OnEnter += OnWait_OnEnter;
        }

        internal static void Unload() {
            On.DamageEffectTicker.OnTriggerEnter2D -= OnDamageEffectTicker_OnTriggerEnter2D;
            On.HealthManager.TakeDamage -= OnHealthManager_TakeDamage;
            On.HutongGames.PlayMaker.Actions.GetOwner.OnEnter -= OnGetOwner_OnEnter;
            On.HutongGames.PlayMaker.Actions.Wait.OnEnter -= OnWait_OnEnter;
        }

        private static void OnDamageEffectTicker_OnTriggerEnter2D(On.DamageEffectTicker.orig_OnTriggerEnter2D orig, DamageEffectTicker self, Collider2D otherCollider) {
            orig(self, otherCollider);
            WeaknessDebuff weaknessDebuff = otherCollider.gameObject.GetComponent<WeaknessDebuff>();
            if (weaknessDebuff == null)
                otherCollider.gameObject.AddComponent<WeaknessDebuff>();
            else
                weaknessDebuff.RefreshTimer();
        }

        private static void OnHealthManager_TakeDamage(On.HealthManager.orig_TakeDamage orig, HealthManager self, HitInstance hitInstance) {
            WeaknessDebuff debuff = self.gameObject.GetComponent<WeaknessDebuff>();
            if (debuff != null)
                hitInstance.Multiplier *= weaknessDebuffMultiplier;
            orig(self, hitInstance);
            CharmRebalanced.LoadedInstance.Log(Mathf.CeilToInt(hitInstance.DamageDealt * hitInstance.Multiplier)); // debug
        }

        private static void OnGetOwner_OnEnter(On.HutongGames.PlayMaker.Actions.GetOwner.orig_OnEnter orig, HutongGames.PlayMaker.Actions.GetOwner self) {
            orig(self);
            if (self.Owner.name.StartsWith("Knight Dung Trail") && self.Fsm.Name == "Control" && self.State.Name == "Init") 
                self.Owner.gameObject.transform.localScale = knightDungTrailScale;
        }

        private static void OnWait_OnEnter(On.HutongGames.PlayMaker.Actions.Wait.orig_OnEnter orig, HutongGames.PlayMaker.Actions.Wait self) {
            if (self.Owner.name.StartsWith("Knight Dung Trail") && self.Fsm.Name == "Control" && self.State.Name == "Wait")
                self.time.Value = knightDungTrailDuration;
            orig(self);
        }
    }

    public class WeaknessDebuff : MonoBehaviour {
        private float timer = 0f;
        private readonly float duration = Charm10_DefenderCrest.weaknessDuration;

        public void Awake() {
            timer = duration;
        }

        public void RefreshTimer() {
            timer = duration;
        }

        private void Update() {
            timer -= Time.deltaTime;
            if (timer < 0f) {
                Object.Destroy(this);
            }
        }
    }
}
