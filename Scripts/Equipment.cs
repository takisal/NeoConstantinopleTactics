using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    public string equipmentName;
    public string location;
    public string iconName;
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
    public int move;
    public int price;
    public List<SkillInfo> addedSkills;
    public List<BattleAction> addedActions;

    public Equipment(string newequipmentName, int newdef, int newprice, string newIconName, string newLocation, int nhp, int nmp, int neva, int nacc, int nmnd, int njmp, int nres, int nstr, int ninte, int newmove)
    {
        equipmentName = newequipmentName; def = newdef; price = newprice; iconName = newIconName; location = newLocation;
        hp = nhp;
        mp = nmp;
        eva = neva;
        acc = nacc;
        mnd = nmnd;
        jmp = njmp;
        res = nres;
        str = nstr;
        inte = ninte;
        move = newmove;
    }
}
