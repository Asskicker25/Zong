using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Weapons
{
    [CreateAssetMenu(fileName = "BaseWeaponConfig", menuName = "Configs/Weapons/BaseWeaponConfig")]
    public class BaseWeaponConfig : ScriptableObject
    {
        public string weaponName = "Unnamed Weapon";
        public Sprite uiImage;
        public BaseWeapon weapon;

    }
}
