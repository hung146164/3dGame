using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponManager : MonoBehaviour
{
    public Weapon[] weapons;

    public string weaponActive;
    public void ActiveWeapon(string _name)
    {
        foreach (var weapon in weapons)
        {
            if(weapon.nameWeapon==_name)
            {
                weapon.Deactive();
                
            }
            if (weapon.nameWeapon == _name) {
                weapon.Active();
            }
        }
    }
}
