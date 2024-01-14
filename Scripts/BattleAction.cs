using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleAction
{
    public string actionName;
    public int minRange;
    public int maxRange;
    public int aoe;
    public string iconName;
    public int dmg;
    public string type;
    public int mpcost;
    public BattleAction(string newactionName, int newminRange, int newmaxRange, int newaoe, string newiconname, int newdmg, string newtype, int newmp)
    {
        actionName = newactionName; minRange = newminRange; maxRange = newmaxRange; aoe = newaoe; iconName = newiconname; dmg = newdmg; type = newtype; mpcost = newmp;
    }
}
