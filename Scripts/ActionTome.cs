using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTome
{
    public string tomeName;
    public BattleAction skillInfo;
    public int price;
    

    public ActionTome(string newTomeName, BattleAction newSkillInfo, int newPrice) {
        tomeName = newTomeName; skillInfo = newSkillInfo; price = newPrice;
    }

}
