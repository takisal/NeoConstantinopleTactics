using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPage : MonoBehaviour
{
    [SerializeField]
    public bool IsMoving;

    [SerializeField]
    public bool IsAttackPrepping;
    [SerializeField]
    public float SpeedScoped;
    public int DestX;
    public int DestZ;
    public int PreDmg;
    public int PreMin;
    public int PreMax;
    public int PreInd;
    public string PreType;
    public int PreMp;
    public string PreCateg;
    public MiscItems SelectedItem;
    
    public (float x, float z, float y, int xfake, int zfake, int yfake) LastCoords;
    public List<(float x, float z, float y, int xfake, int zfake, int yfake)> XZPoints;

    

    public CharacterStats character;
    public bool continuityBool;
    public int preAccMod;

    public Equipment EquippedFootwear
    {
        get { return character.EquippedFootwear; }
        set { character.EquippedFootwear = value; }
    }

    public Equipment EquippedHelmet
    {
        get { return character.EquippedHelmet; }
        set { character.EquippedHelmet = value; }
    }
    public Equipment EquippedChest
    {
        get { return character.EquippedChest; }
        set { character.EquippedChest = value; }
    }
    public int Hp
    {
        get { return character.Hp; }
        set { character.Hp = value; }
    }
    public int Mp
    {
        get { return character.Hp; }
        set { character.Hp = value; }
    }
    public int MaxHp
    {
        get { return character.MaxHp; }
        set { character.MaxHp = value; }
    }
    public int MaxMp
    {
        get { return character.MaxMp; }
        set { character.MaxMp = value; }
    }
    public int Str
    {
        get { return character.Str; }
        set { character.Str = value; }
    }
    public int Mnd
    {
        get { return character.Mnd; }
        set { character.Mnd = value; }
    }
    public string CharacterName
    {
        get { return character.CharacterName; }
        set { character.CharacterName = value; }
    }
    public bool PlayerControlled
    {
        get { return character.PlayerControlled; }
        set { character.PlayerControlled = value; }
    }
    public int X
    {
        get { return character.X; }
        set { character.X = value; }
    }
    public int Z
    {
        get { return character.Z; }
        set { character.Z = value; }
    }
    public string SpriteName
    {
        get { return character.SpriteName; }
        set { character.SpriteName = value; }
    }
    public int MoveDistance
    {
        get { return character.MoveDistance; }
        set { character.MoveDistance = value; }
    }
    public bool PlayerSide
    {
        get { return character.PlayerSide; }
        set { character.PlayerSide = value; }
    }
    public List<BattleAction> ActionsList
    {
        get { return character.ActionsList; }
        set { character.ActionsList = value; }
    }
    public List<SkillInfo> SkillsList
    {
        get { return character.SkillsList; }
        set { character.SkillsList = value; }
    }
    public List<uint> MovesPriority
    {
        get { return character.MovesPriority; }
        set { character.MovesPriority = value; }
    }
    public List<uint> ClassAttackPriority
    {
        get { return character.ClassAttackPriority; }
        set { character.ClassAttackPriority = value; }
    }
    public int Jump
    {
        get { return character.Jump; }
        set { character.Jump = value; }
    }
    public int Def
    {
        get { return character.Def; }
        set { character.Def = value; }
    }
    public int OriginalDef
    {
        get { return character.OriginalDef; }
        set { character.OriginalDef = value; }
    }
    public Weapons EquippedMH
    {
        get { return character.EquippedMH; }
        set { character.EquippedMH = value; }
    }
    public Weapons EquippedOH
    {
        get { return character.EquippedOH; }
        set { character.EquippedOH = value; }
    }
    public MiscItems[] EquippedMiscItems
    {
        get { return character.EquippedMiscItems; }
        set { character.EquippedMiscItems = value; }
    }
    public ActionTome[] EquippedActionTomes
    {
        get { return character.EquippedActionTomes; }
        set { character.EquippedActionTomes = value; }
    }
    public SkillInfo[] EquippedSkills
    {
        get { return character.EquippedSkills; }
        set { character.EquippedSkills = value; }
    }

    public int Res
    {
        get { return character.Res; }
        set { character.Res = value; }
    }
    public int Eva
    {
        get { return character.Eva; }
        set { character.Eva = value; }
    }
    public int Acc
    {
        get { return character.Acc; }
        set { character.Acc = value; }
    }
    public int Int
    {
        get { return character.Int; }
        set { character.Int = value; }
    }
    public List<BattleAction> UseableActions
    {
        get { return character.ActionsList; }
        set { character.ActionsList = value; }
    }
    public List<MiscItems> UseableItems
    {
        get { return character.ItemsList; }
        set { character.ItemsList = value; }
    }
    public List<SkillInfo> UseableSkills
    {
        get { return character.SkillsList; }
        set { character.SkillsList = value; }
    }

    public void removeMiscItemAt(int ind)
    {
        character.EquippedMiscItems[ind] = null;
    }

    public void addAttack(BattleAction ba)
    {
        character.ActionsList.Add(ba);
    }

    public void addSkill(SkillInfo newaction)
    {
        character.SkillsList.Add(newaction);
    }

    public void addMovePriotiy(uint newaction)
    {
        character.MovesPriority.Add(newaction);
    }

    public void addClassAttackPriority(uint newaction)
    {
        character.ClassAttackPriority.Add(newaction);
    }

    public List<MiscItems> getUseableItems()
    {
        return character.ItemsList;
    }

    public List<BattleAction> getUseableActions()
    {
        return character.ActionsList;
    }

    public List<SkillInfo> getUseableSkills()
    {
        return character.SkillsList;
    }

    public MiscItems[] getEquippedItems()
    {
        return character.EquippedMiscItems;
    }

    public ActionTome[] getEquippedActionTomes()
    {
        return character.EquippedActionTomes;
    }

    public SkillInfo[] getEquippedSkills()
    {
        return character.EquippedSkills;
    }

    public void selectItemForAttack(MiscItems itemy)
    {
        SelectedItem = itemy;
    }

    public void sendToBattle()
    {
        X += GameManager.instance.SelectedChars.Count;
        if (GameManager.instance.SelectedChars.Count > 5)
        {
            X += (GameManager.instance.SelectedChars.Count % 5);
            Z += (GameManager.instance.SelectedChars.Count / 5);
        }
        GameManager.instance.SelectedChars.Add(character);
    }

    public void setDest(int xc, int zc, List<(float, float, float, int, int, int)> trip)
    {
        IsMoving = true;
        DestX = xc;
        DestZ = zc;
        XZPoints = trip;
    }

    public void createOrSetCustomChara(
        int hp,
        int maxHp,
        int mp,
        int maxMp,
        int str,
        int mnd,
        int def,
        int res,
        int acc,
        int eva,
        int inte,
        int jump,
        int moveDistance,
        bool playerSide,
        string spriteName,
        string characterName,
        bool playerControlled
    )
    {
        if (character == null)
        {
            character = new CharacterStats(
                hp,
                maxHp,
                mp,
                maxMp,
                str,
                mnd,
                def,
                res,
                acc,
                eva,
                inte,
                jump,
                moveDistance,
                playerSide,
                spriteName,
                characterName,
                playerControlled
            );
        }
        else
        {
            Hp = hp;
            Mp = mp;
            Str = str;
            Mnd = mnd;
            CharacterName = characterName;
            PlayerControlled = playerControlled;
            MaxHp = maxHp;
            MaxMp = maxMp;
            X = 0;
            Z = 0;
            SpriteName = spriteName;
            MoveDistance = moveDistance;
            PlayerSide = playerSide;
            Def = def;
            Res = res;
            Acc = acc;
            Eva = eva;
        }
    }

    public void prepAttack(bool isAttackPrep)
    {
        IsAttackPrepping = isAttackPrep;
    }

    public bool getPrepAttack()
    {
        return IsAttackPrepping;
    }

    private bool inRange(int targX, int targZ, int curX, int curZ)
    {
        int manhattan = Math.Abs(curX - targX) + Math.Abs(curZ - targZ);
        if (manhattan >= PreMin && manhattan <= PreMax)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public (int, int, int) CalcDmg(CharacterPage enemy)
    {
        int enemyHP = enemy.character.Hp;
        int realDmg = 0;
        int enemyEva = enemy.Eva;
        int myAcc = Acc;
        float ratioHolder = 1.0f - ((float)enemyEva) / ((float)((myAcc + preAccMod) * 3));
        int percentChanceOfHit = (int)(ratioHolder * 100.0f);
        int atkval = (Str * 2) / 5;
        if (EquippedMH != null)
        {
            atkval += character.EquippedMH.dmg;
        }
        if (PreType == "physical")
        {
            realDmg = dmgEquation(PreDmg, Str, atkval, enemy.Def);
        }
        else if (PreType == "magical")
        {
            realDmg = dmgEquation(PreDmg, Int, atkval, enemy.Res);
        }
        else if (PreType == "super")
        {
            realDmg = dmgEquation(PreDmg, ((Str + Int) / 2), atkval, (enemy.Res + enemy.Def) / 2);
        }
        else if (PreType == "heal")
        {
            realDmg = -PreDmg * Mnd / 20;
            percentChanceOfHit = 100;
        }
        else if (PreType == "food")
        {
            realDmg = -PreDmg;
            percentChanceOfHit = 100;
        }
        else if (PreType == "potion")
        {
            realDmg = -PreDmg;
            percentChanceOfHit = 100;
        }

        if (enemyHP - realDmg > enemy.MaxHp)
        {
            return (-(enemy.MaxHp - enemyHP), realDmg, Mathf.Min(100, percentChanceOfHit));
        }
        else
        {
            return (realDmg, realDmg, Mathf.Min(100, percentChanceOfHit));
        }
    }

    /*
     *
     *
     Old equation:

                    realDmg = (predmg * getStr()) / enemy.getDef();
                    realDmg = (int)Mathf.Sqrt(realDmg);
                    
                    realDmg *= 100 +(atkval- enemy.getDef());
                    realDmg /= 100;
                    realDmg++;
                    return realDmg;
     
     */
    public int dmgEquation(int dmg, int str, int atk, int def)
    {
        int x = (dmg * str);
        int realDmg = x + (x - def) / 2;

        realDmg *= 100 + (atk - def);
        realDmg /= 2000;
        realDmg++;
        realDmg = Math.Max(1, realDmg);
        return realDmg;
    }

    public void Attack(CharacterPage enemy)
    {
        if (IsAttackPrepping)
        {
            System.Random rnd = new System.Random();
            int enemyX = enemy.X;
            int enemyZ = enemy.Z;
            int enemyHP = enemy.Hp;
            if (inRange(enemyX, enemyZ, X, Z))
            {
                MenuManager.instance.disableAttack();
                MenuManager.instance.disableSpells();
                MenuManager.instance.disableItems();
                MenuManager.instance.disableDefend();
                MenuManager.instance.disableUndo();
                int realDmg = 0;
                Mp = (Mp - PreMp);
                int enemyEva = enemy.Eva;
                int myAcc = Acc;
                float ratioHolder = 1.0f - ((float)enemyEva) / ((float)((myAcc + preAccMod) * 3));
                int percentChanceOfHit = (int)(ratioHolder * 100.0f);
                percentChanceOfHit = Mathf.Min(100, percentChanceOfHit);
                int atkval = (Str * 2) / 5;
                if (EquippedMH != null)
                {
                    atkval = Math.Max(atkval, EquippedMH.dmg);
                }
                //50STR, 10DMG, 20 ATK   vs    50 DEF     =
                if (PreType == "physical")
                {
                    realDmg = dmgEquation(PreDmg, Str, atkval, enemy.Def);
                }
                else if (PreType == "magical")
                {
                    realDmg = dmgEquation(PreDmg, Int, atkval, enemy.Res);
                }
                else if (PreType == "super")
                {
                    //Previous: Math.Max(enemy.getRes(), enemy.getDef()
                    realDmg = dmgEquation(
                        PreDmg,
                        ((Str + Int) / 2),
                        atkval,
                        (enemy.Res + enemy.Def) / 2
                    );
                }
                else if (PreType == "heal")
                {
                    realDmg = -PreDmg * ((Mnd + Int) / 2) / 5;
                    percentChanceOfHit = 100;
                }
                else if (PreType == "food")
                {
                    realDmg = -PreDmg;
                    percentChanceOfHit = 100;
                }
                else if (PreType == "potion")
                {
                    realDmg = -PreDmg;
                    percentChanceOfHit = 100;
                }
                if (PreCateg == "item")
                {
                    character.ItemsList.Remove(SelectedItem);
                    character.EquippedMiscItems[PreInd] = null;
                    percentChanceOfHit = 100;
                }
                int rndResult = rnd.Next(101);
                if (rndResult > percentChanceOfHit)
                {
                    //MISS
                }
                else
                {
                    if (enemyHP - realDmg > enemy.MaxHp)
                    {
                        enemy.Hp = enemy.MaxHp;
                    }
                    else
                    {
                        enemy.Hp = enemyHP - realDmg;
                    }
                }

                MenuManager.instance.UpdateActiveMenu();
                MenuManager.instance.setAttackToggle(0);
                IsAttackPrepping = false;
                MenuManager.instance.unprepareAttack();
                MenuManager.instance.showActionsDD(false);
                MenuManager.instance.showSkillsDD(false);
                MenuManager.instance.showItemsDD(false);
                MenuManager.instance.setTav(0);
                MenuManager.instance.setTsv(0);
                if (enemy.Hp <= 0)
                {
                    enemy.gameObject.SetActive(false);
                    if (enemy.PlayerSide)
                    {
                        MenuManager.instance.NumberOfPlayerChars--;
                        for (int i = 0; i < MenuManager.instance.PlayerCharactersInLevel.Count; i++)
                        {
                            if (enemy.gameObject == MenuManager.instance.PlayerCharactersInLevel[i])
                            {
                                MenuManager.instance.PlayerCharactersInLevel.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    else
                    {
                        MenuManager.instance.NumberOfEnemyChars--;
                        for (int i = 0; i < MenuManager.instance.EnemyCharactersInLevel.Count; i++)
                        {
                            if (enemy.gameObject == MenuManager.instance.EnemyCharactersInLevel[i])
                            {
                                MenuManager.instance.EnemyCharactersInLevel.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < MenuManager.instance.ActiveCharactersInLevel.Count; i++)
                    {
                        if (enemy.gameObject == MenuManager.instance.ActiveCharactersInLevel[i])
                        {
                            MenuManager.instance.ActiveCharactersInLevel.RemoveAt(i);
                            break;
                        }
                    }
                    GameObject spotUnder = MenuManager.instance.QuerySpotMatrix(enemyX, enemyZ);
                    spotUnder.GetComponent<ValidSpot>().characterIsOnSpot = false;
                    spotUnder.GetComponent<ValidSpot>().characterOnSpot = null;
                }
            }
        }
    }

    public void CancelMove()
    {
        GameObject spotUnder = MenuManager.instance.QuerySpotMatrix(X, Z);
        spotUnder.GetComponent<ValidSpot>().characterIsOnSpot = false;
        spotUnder.GetComponent<ValidSpot>().characterOnSpot = null;
        X = LastCoords.Item4;
        Z = LastCoords.Item5;
        spotUnder = MenuManager.instance.QuerySpotMatrix(X, Z);
        spotUnder.GetComponent<ValidSpot>().characterIsOnSpot = true;
        spotUnder.GetComponent<ValidSpot>().characterOnSpot = gameObject;
        Vector3 mimicPosition = gameObject.transform.position;
        mimicPosition.x = LastCoords.Item1;
        mimicPosition.z = LastCoords.Item2;
        mimicPosition.y = LastCoords.Item3;
        gameObject.transform.position = mimicPosition;
    }

    private void Update()
    {
        if (IsMoving)
        {
            MenuManager.instance.disableMove();

            if (continuityBool != true)
            {
                MenuManager.instance.hideMenu();
                continuityBool = true;
                LastCoords = (
                    gameObject.transform.position.x,
                    gameObject.transform.position.z,
                    gameObject.transform.position.y,
                    X,
                    Z,
                    0
                );
            }

            if (XZPoints.Count == 0)
            {
                if (PlayerControlled == false)
                {
                    IsMoving = false;
                    continuityBool = false;
                    MenuManager.instance.lastHalfAITurn(this);
                }
                else
                {
                    IsMoving = false;
                    continuityBool = false;
                    MenuManager.instance.showMenu();
                    MenuManager.instance.updateActionMenuPosition();
                }

                return;
            }
            float curRealX = gameObject.transform.position.x;
            float curRealZ = gameObject.transform.position.z;
            Vector3 mimicPos = gameObject.transform.position;
            float nextX = XZPoints[0].Item1;
            float nextZ = XZPoints[0].Item2;
            float nextY = XZPoints[0].Item3 + 1;
            float xDiff = (nextX - curRealX);
            float zDIff = (nextZ - curRealZ);

            bool yLower = (mimicPos.y < nextY);
            SpeedScoped = 8f;
            float floatDir = -1.0f;

            if (mimicPos.y < nextY)
            {
                floatDir = 1.0f;
            }
            if (mimicPos.y != nextY)
            {
                mimicPos.y += floatDir * SpeedScoped * Time.deltaTime;
                bool nowYLower = mimicPos.y < nextY;
                if (yLower)
                {
                    if (nowYLower == false)
                    {
                        mimicPos.y = nextY;
                    }
                }
                else if (nowYLower)
                {
                    mimicPos.y = nextY;
                }
            }

            bool xLower = (mimicPos.x < nextX);
            SpeedScoped = 8f;
            floatDir = -1.0f;

            if (mimicPos.x < nextX)
            {
                floatDir = 1.0f;
            }
            if (mimicPos.x != nextX)
            {
                mimicPos.x += floatDir * SpeedScoped * Time.deltaTime; //+= new Vector3(floatDir, 0, 0)
                bool nowXLower = mimicPos.x < nextX;
                if (xLower)
                {
                    if (nowXLower == false)
                    {
                        mimicPos.x = nextX;
                    }
                }
                else if (nowXLower)
                {
                    mimicPos.x = nextX;
                }
            }
            bool zLower = mimicPos.z < nextZ;
            if (mimicPos.z != nextZ)
            {
                mimicPos = gameObject.transform.position;
                floatDir = -1.0f;
                if (mimicPos.z < nextZ)
                {
                    floatDir = 1.0f;
                }
                mimicPos.z += floatDir * SpeedScoped * Time.deltaTime;
                bool nowZLower = mimicPos.z < nextZ;
                if (zLower)
                {
                    if (nowZLower == false)
                    {
                        mimicPos.z = nextZ;
                    }
                }
                else if (nowZLower)
                {
                    mimicPos.z = nextZ;
                }
            }
            if ((mimicPos.x == nextX) && (mimicPos.z == nextZ))
            {
                if (XZPoints.Count == 0)
                {
                    Debug.Log("ATTENTION: Should never run!!");
                }
                else
                {
                    GameObject spotUnder = MenuManager.instance.QuerySpotMatrix(X, Z);
                    if (spotUnder.GetComponent<ValidSpot>().characterOnSpot == this.gameObject)
                    {
                        spotUnder.GetComponent<ValidSpot>().characterIsOnSpot = false;
                        spotUnder.GetComponent<ValidSpot>().characterOnSpot = null;
                    }
                    X = XZPoints[0].Item4;
                    Z = XZPoints[0].Item5;
                    spotUnder = MenuManager.instance.QuerySpotMatrix(X, Z);
                    if (spotUnder.GetComponent<ValidSpot>().characterOnSpot == null)
                    {
                        spotUnder.GetComponent<ValidSpot>().characterIsOnSpot = true;
                        spotUnder.GetComponent<ValidSpot>().characterOnSpot = gameObject;
                    }
                    XZPoints.RemoveAt(0);
                }
            }
            gameObject.transform.position = mimicPos;
        }
    }
}
