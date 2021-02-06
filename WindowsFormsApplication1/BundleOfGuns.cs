using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class BundleOfGuns
    {
        Weapon None = new Weapon(10, 9, 1, "None", 0);
        Weapon ButterKnife = new Weapon(1, 10, 5, "Butter Knife", 200);
        Weapon SlingShot = new Weapon(15, 8, 1, "Slingshot", 1000);
        Weapon HuntingKnife = new Weapon(20, 8, 1, "Hunting Knife", 2000);
        Weapon HandGun = new Weapon(20, 7, 3, "Handgun", 4500);
        Weapon SMG = new Weapon(28, 5, 6, "P90", 8000);
        Weapon Grenade = new Weapon(70, 6, 3, "Grenades", 12000);
        Weapon Bazooka = new Weapon(100, 6, 1, "Bazooka", 15000);
        Weapon Sniper = new Weapon(100, 9, 1, "Sniper Rifle", 20000);
        Weapon PlasmaRifle = new Weapon(200, 10, 1, "Plasma Rifle", 40000);

        public Weapon WeaponNone
        {
            get { return None; }
            set { None = value; }
        }

        public Weapon WeaponButterKnife
        {
            get { return ButterKnife; }
            set { ButterKnife = value; }
        }
        public Weapon WeaponSlingShot
        {
            get { return SlingShot; }
            set { SlingShot = value; }
        }
        public Weapon WeaponHuntingKnife
        {
            get { return HuntingKnife; }
            set { HuntingKnife = value; }
        }
        public Weapon WeaponHandGun
        {
            get { return HandGun; }
            set { HandGun = value; }
        }
        public Weapon WeaponSMG
        {
            get { return SMG; }
            set { SMG = value; }
        }
        public Weapon WeaponGrenade
        {
            get { return Grenade; }
            set { Grenade = value; }
        }
        public Weapon WeaponBazooka
        {
            get { return Bazooka; }
            set { Bazooka = value; }
        }
        public Weapon WeaponSniper
        {
            get { return Sniper; }
            set { Sniper = value; }
        }
        public Weapon WeaponPlasmaRifle
        {
            get { return PlasmaRifle; }
            set { PlasmaRifle = value; }
        }
    }
}
