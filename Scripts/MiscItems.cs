using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscItems
{
    public string itemName;
    public string description;
    public string iconName;
    public int price;
    public int minRange;
    public int maxRange;
    //TODO: add effects
    public int dmg;
    public string type;

    public MiscItems(string newItemName,  int newprice, string newIconName, string newDescription, int newMinRange, int newMaxRange, string newtype, int newDmg)
    {
        itemName = newItemName;  price = newprice; iconName = newIconName; description = newDescription; minRange = newMinRange; maxRange = newMaxRange;  type = newtype;  dmg = newDmg; 
    }
}
