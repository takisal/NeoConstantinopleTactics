using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsCharm
{
    public string charmName;
    public string iconName;
    public int defXP;
    public int hpXP;
    public int mpXP;
    public int evaXP;
    public int accXP;
    public int mndXP;
    public int jmp;
    public int resXP;
    public int strXP;
    public int inteXP;
    public int move;

    public StatsCharm(string newequipmentName, int newdef,  string newIconName,  int nhp, int nmp, int neva, int nacc, int nmnd, int njmp, int nres, int nstr, int ninte, int newmove)
    {
        charmName = newequipmentName; defXP = newdef; iconName = newIconName;
        hpXP = nhp;
        mpXP = nmp;
        evaXP = neva;
        accXP = nacc;
        mndXP = nmnd;
        jmp = njmp;
        resXP = nres;
        strXP = nstr;
        inteXP = ninte;
        move = newmove;
    }
}
