using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons
{
    public string weaponName;
    public int minRange;
    public int maxRange;
    public int aoe;
    public string iconName;
    public int dmg;
    public int def;
    public int hp;
    public int mp;
    public int eva;
    public int acc;
    public int mnd;
    public int jmp;
    public int res;
    public int str;
    public int inte;
    public int price;
    public int move;
    public List<SkillInfo> addedSkills;
    public List<BattleAction> addedActions;

    public Weapons(string newweaponName, int newminRange, int newmaxRange, int newaoe, string newiconname, int newdmg, int newstr, int newprice, int nhp, int nmp, int neva, int nacc, int nmnd, int njmp, int nres, int ndef, int ninte, int newmove)
    {
        weaponName = newweaponName; minRange = newminRange; maxRange = newmaxRange; aoe = newaoe; iconName = newiconname; dmg = newdmg; price = newprice; str = newstr;
        hp = nhp;
        mp = nmp;
        eva = neva;
        acc = nacc;
        mnd = nmnd;
        jmp = njmp;
        res = nres;
        def = ndef;
        inte = ninte;
        move = newmove;
    }
}
