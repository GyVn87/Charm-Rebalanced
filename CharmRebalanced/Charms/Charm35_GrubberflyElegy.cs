using GlobalEnums;
using UnityEngine;

namespace TuyenTuyenTuyen.Charms {
    internal static class Charm35_GrubberflyElegy {
        private static readonly float baseBeamDamageRatio = 0.64f;

        internal static void Load() {
            ModHooks.AfterAttackHook += OnAfterAttack;
        }

        internal static void Unload() {
            ModHooks.AfterAttackHook -= OnAfterAttack;
        }

        private static void OnAfterAttack(AttackDirection attackDir) {
            PlayerData PD = CharmRebalanced.LoadedInstance.PD;
            HeroController Controller = HeroController.instance;
            GameObject Knight = Controller.gameObject;
            float strengthIncrease = (PD.GetBool("equippedCharm_25") ? Charm25_Strength.strengthMutiplier : 1f);
            PD.SetInt("beamDamage", Mathf.CeilToInt((float)PD.GetInt("nailDamage") * baseBeamDamageRatio * strengthIncrease));
            if (!PD.GetBool("equippedCharm_35") || Controller.cState.wallSliding || !CanCastBeam())
                return;

            GameObject grubberFlyBeam;
            float MANTIS_CHARM_SCALE = 1.35f;
            switch (attackDir) {
                case AttackDirection.normal:
                    if (Knight.transform.localScale.x < 0f) grubberFlyBeam = Controller.grubberFlyBeamPrefabR.Spawn(Knight.transform.position);
                    else grubberFlyBeam = Controller.grubberFlyBeamPrefabL.Spawn(Knight.transform.position);

                    if (PD.GetBool("equippedCharm_13")) grubberFlyBeam.transform.SetScaleY(MANTIS_CHARM_SCALE);
                    else grubberFlyBeam.transform.SetScaleY(1f);
                    break;
                case AttackDirection.upward:
                    grubberFlyBeam = Controller.grubberFlyBeamPrefabU.Spawn(Knight.transform.position);
                    grubberFlyBeam.transform.SetScaleY(Knight.transform.localScale.x);
                    grubberFlyBeam.transform.localEulerAngles = new Vector3(0f, 0f, 270f);
                    if (PD.GetBool("equippedCharm_13"))
                        grubberFlyBeam.transform.SetScaleY(grubberFlyBeam.transform.localScale.y * MANTIS_CHARM_SCALE);
                    break;
                case AttackDirection.downward:
                    grubberFlyBeam = Controller.grubberFlyBeamPrefabD.Spawn(Knight.transform.position);
                    grubberFlyBeam.transform.SetScaleY(Knight.transform.localScale.x);
                    grubberFlyBeam.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
                    if (PD.GetBool("equippedCharm_13")) 
                        grubberFlyBeam.transform.SetScaleY(grubberFlyBeam.transform.localScale.y * MANTIS_CHARM_SCALE);
                    break;
            }
        }

        private static bool CanCastBeam() {
            PlayerData PD = CharmRebalanced.LoadedInstance.PD;
            int currentHP = PD.GetInt("health");
            if (PD.GetBool("equippedCharm_27"))
                return false;
            if (currentHP == 1)
                return false;
            if (!BossSequenceController.BoundShell && currentHP == PD.CurrentMaxHealth)
                return false;
            int beamDamage = NewBeamDamage();
            if (beamDamage <= 1)
                return false;
            PD.SetInt("beamDamage", beamDamage);
            return true;
        }

        private static int NewBeamDamage() {
            PlayerData PD = CharmRebalanced.LoadedInstance.PD;
            int nailDamge = PD.GetInt("nailDamage");
            int currentHP = PD.GetInt("health");
            int currentMaxHP = PD.CurrentMaxHealth;
            int newBeamDamage = -1; 
            if (BossSequenceController.BoundShell && currentHP > currentMaxHP)
                newBeamDamage = Mathf.CeilToInt(Mathf.Pow((float)(currentMaxHP - 1) / (float)(currentMaxHP + 1), 2f) * nailDamge);
            else
                newBeamDamage = Mathf.CeilToInt(Mathf.Pow((float)(currentHP - 1) / (float)(currentMaxHP + 1), 2f) * nailDamge);
            return newBeamDamage;
        }
    }
}
