using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMgr : MonoBehaviour
{
    public static WeaponMgr inst;
    public Weapon selectedWeapon;
    public int selectedWeaponIndex = 0;
    public List<Weapon> weapons;
    public AudioSource switchWeaponsSound;
    public float switchWeaponsDelay;
    public bool canFire = true; //used for one click per shot, default is hold button down for fully automatic
    //public bool mouseButtonUp;
    private void Awake()
    {
        inst = this;
    }
    public void Start()
    {
    }
    public void SelectPreviousWeapon()
    {
        switchWeaponsSound.Play();
        selectedWeaponIndex = (selectedWeaponIndex <= 0 ? weapons.Count - 1 : selectedWeaponIndex - 1);
        selectedWeapon.gameObject.SetActive(false);
        selectedWeapon.gunSprite.SetActive(false);
        selectedWeapon = weapons[selectedWeaponIndex];
        selectedWeapon.timeToFire = Time.time + switchWeaponsDelay;
        selectedWeapon.gameObject.SetActive(true);
        selectedWeapon.gunSprite.SetActive(true);
    }
    public void SelectNextWeapon()
    {
        switchWeaponsSound.Play();
        selectedWeaponIndex = (selectedWeaponIndex >= weapons.Count - 1 ? 0 : selectedWeaponIndex + 1);
        selectedWeapon.gameObject.SetActive(false);
        selectedWeapon.gunSprite.SetActive(false);
        selectedWeapon = weapons[selectedWeaponIndex];
        selectedWeapon.timeToFire = Time.time + switchWeaponsDelay;
        selectedWeapon.gunSprite.SetActive(true);
        selectedWeapon.gameObject.SetActive(true);
    }
    public void NextWave()
    {
        foreach(Weapon weap in weapons)
        {
            weap.clipCount = weap.clipSize;
            weap.ammoCount = (weap.ammoCapacity > weap.ammoCount? weap.ammoCapacity : weap.ammoCount);
        }
    }
}
