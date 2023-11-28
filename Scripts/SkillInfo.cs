using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInfo
{
    public string spellName;
    public int minRange;
    public int maxRange;
    public int aoe;
    public string iconName;
    public int dmg;
    public string type;
    public int mpcost;
    public SkillInfo(string newspellName, int newminRange, int newmaxRange, int newaoe, string newiconname, int newdmg, string newtype, int newmp)
    {
        spellName = newspellName; minRange = newminRange; maxRange = newmaxRange; aoe = newaoe; iconName = newiconname; dmg = newdmg; type = newtype; mpcost = newmp;
    }
}
