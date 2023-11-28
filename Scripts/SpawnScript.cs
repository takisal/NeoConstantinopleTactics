using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField]
    public int xMod;
    [SerializeField]
    public int zMod;
    [SerializeField]
    public List<int> xModEnemy;
    [SerializeField]
    public List<int> zModEnemy;
    private System.Random rnd = new System.Random();
    void Start()
    {
        //take selectedCharacters list from gameManager and load all of them
        //List<CharacterStats> loadedData = DataSaver.loadDataNewton<List<CharacterStats>>("players");
        List<CharacterStats> loadedData = GameManager.instance.SelectedChars;
        //take enemyCharacters list from gameManager and load all of them

        //List <CharacterStats> loadedEnemyData = DataSaver.loadDataNewton<List<CharacterStats>>("enemies");
        
        List<CharacterStats>  loadedEnemyData = GenEnemies(GameManager.instance.enemyLev, GameManager.instance.numOfEnemies);
        if (loadedData == null || loadedEnemyData == null)
        {
            Debug.Log("Nothing Loaded");
        } else
        {
            Debug.Log("Loaded: " + loadedData.Count.ToString() + " characters");
            Debug.Log("Loaded: " + loadedEnemyData.Count.ToString() + " characters");
            for (int i = 0; i < loadedData.Count; i++)
            {
                spawnChar(loadedData[i], i);
            }
            for (int i = 0; i < loadedEnemyData.Count; i++)
            {
                spawnChar(loadedEnemyData[i], i);
            }
            MenuManager.instance.TurnTaker = MenuManager.instance.CharactersInLevel[0];
            MenuManager.instance.ActiveCharacter = MenuManager.instance.CharactersInLevel[0];
            MenuManager.instance.setTargetMenuEnable(false);
            MenuManager.instance.NewActive();
            MenuManager.instance.populateActionDD();
            MenuManager.instance.populateSkillsDD();
            MenuManager.instance.populateItemsDD();
        }
    }
    private int scaleHP(int level)
    {
        int hp = 100 + (level * 3);
        hp += rnd.Next(1, level * 5);
        return hp;
    }
    private int scaleMP(int level)
    {
        int mp = 100 + (level * 3);
        mp += rnd.Next(1, level * 5) ;
        return mp;
    }
    private int scaleSTR(int level)
    {
        int str = 30 + (level * 3);
        str += rnd.Next(1, (level * 3) + 5);
        return str;
    }
    private int scaleMND(int level)
    {
        int mnd = 30 + (level*3);
        mnd += rnd.Next(1, (level * 3) + 5);
        return mnd;
    }
    private int scaleDEF(int level)
    {
        int def = 30 + (level * 3);
        def += rnd.Next(1, (level * 3)+5);
        return def;
    }
    private int scaleRES(int level)
    {
        int res = 10 + (level * 3);
        res += rnd.Next(1, (level * 3) + 5);
        return res;
    }
    private int scaleACC(int level)
    {
        int acc = 40 + (level * 3);
        acc += rnd.Next(1, (level * 3) + 5);
        return acc;
    }
    private int scaleEVA(int level)
    {
        int eva = 20 + (level * 3);
        eva += rnd.Next(1, (level * 3) + 5);
        return eva;
    }
    private int scaleINT(int level)
    {
        int inte = 10 + (level * 3);
        inte += rnd.Next(1, (level * 3) + 5);
        return inte;
    }
    private int scaleMOVE(int level)
    {
        
        int movedis;
        if (level < 20)
        {
            movedis = rnd.Next(3, 4);
        } else
        {
            movedis = rnd.Next(3, 5);
        }
        return movedis;
    }
    private int scaleJMP(int level)
    {
        int jmp;
        if (level < 20)
        {
            jmp = 8;
        } else if (level < 40)
        {
            jmp = 16;
        } else
        {
            jmp = rnd.Next(16, 48);
        }
        return jmp;
    }
    
    private string randomName()
    {
        string[] randNames = { "Marloe", "Trikessa", "Voyako", "Kaname", "Misaka", "Gareda", "Tsukimio", "Mio", "Adara", "Pipia", "Koko", "Varresi", "Lodivea" };
        return randNames[rnd.Next(randNames.Length)];
    }
    private string randomEnemySprite()
    {
        //TODO: add enemy sprites
        string[] spriteAr = { "enemy1", "enemy2", "enemy3", "enemy4", "enemy5"};
        return spriteAr[rnd.Next(spriteAr.Length)];
    }
    private void AddActionsAndSpells(CharacterStats curEnemy, int enemyLev, int numOfActions)
    {
        uint actCount = 1;
        uint skillCount = 0;
        for (int i = 0; i < numOfActions; i++)
        {
            int nextAct = rnd.Next(6);
                if (nextAct < 3)
                {
                    
                    if (actCount == 1)
                    {
                        curEnemy.ActionsList.Add(new BattleAction("fireysword", 1, 1, 1, "fireysword", 18, "super", 25));
                    } else if (actCount == 2)
                    {
                        curEnemy.ActionsList.Add(new BattleAction("iceysword", 1, 1, 1, "iceysword", 18, "super", 25));
                    } else
                    {
                        continue;
                    }
                curEnemy.MovesPriority.Add(actCount);
                actCount++;


                } else
                {
                    
                    if (skillCount == 0)
                    {
                        curEnemy.SkillsList.Add(new SkillInfo("fireball", 1, 1, 1, "placeholder", 15, "magical", 25));
                    }
                    else if (skillCount == 1)
                    {
                        curEnemy.SkillsList.Add(new SkillInfo("cure", 0, 3, 1, "cure", 20, "heal", 25));
                    }
                    else
                    {
                        continue;
                    }
                curEnemy.MovesPriority.Add(10 + skillCount);
                skillCount++;
                }
                
               
        }
        return;
    }
    private List<CharacterStats> GenEnemies(int enemyLev, int numOfEnemies)
    {
        List<CharacterStats> tempEnemyData = new List<CharacterStats>();
        for (int i = 0; i < numOfEnemies; i++)
        {
            //TODO: ideally, create different classes and gen based on assigned class
            int hp = scaleHP(enemyLev);
            int mp = scaleMP(enemyLev);
            int str = scaleSTR(enemyLev);
            int mnd = scaleMND(enemyLev);
            int moveDistance = scaleMOVE(enemyLev);
            int jump = scaleJMP(enemyLev);
            int def = scaleDEF(enemyLev);
            int res = scaleRES(enemyLev);
            int acc = scaleACC(enemyLev);
            int eva = scaleEVA(enemyLev);
            int inte = scaleINT(enemyLev);
            string spriteName = randomEnemySprite();
            string characterName = randomName();
            CharacterStats curEnemy = new CharacterStats(hp, hp, mp, mp, str, mnd, def, res, acc, eva, inte, jump, moveDistance, false, spriteName, characterName, false);
            curEnemy.ActionsList.Add(new BattleAction("basic", 1, 1, 1, "basic", 10, "physical", -10));
            //TODO: change moves priority
            AddActionsAndSpells(curEnemy, enemyLev, rnd.Next(3));
            curEnemy.MovesPriority.Add(0);
            tempEnemyData.Add(curEnemy);
        }
        return tempEnemyData;
    }
    private void spawnChar(CharacterStats loadedChar, int iternum)
    {
        GameObject charToSpawn = new GameObject();
        SpriteRenderer spriteRendComp = charToSpawn.AddComponent<SpriteRenderer>();
        spriteRendComp.sortingOrder = 1;
        //GameObject cardInstance = GameObject.Find("GenericCharacter");
        charToSpawn.AddComponent<CharacterPage>();
        CharacterPage charPage = charToSpawn.GetComponent<CharacterPage>();

        charPage.createOrSetCustomChara(loadedChar.Hp, loadedChar.MaxHp, loadedChar.Mp, loadedChar.MaxMp, loadedChar.Str, loadedChar.Mnd, loadedChar.Def, loadedChar.Res, loadedChar.Acc, loadedChar.Eva, loadedChar.Int, loadedChar.Jump, loadedChar.MoveDistance, loadedChar.PlayerSide, loadedChar.SpriteName, loadedChar.CharacterName, loadedChar.PlayerControlled);
        if (loadedChar.PlayerSide)
        {
            MenuManager.instance.NumberOfPlayerChars++;
            loadedChar.X += xMod;
            loadedChar.Z += zMod;
        }
        else
        {
            MenuManager.instance.NumberOfEnemyChars++;
            loadedChar.X = xModEnemy[iternum];
            loadedChar.Z = zModEnemy[iternum];
        }
        charPage.X = loadedChar.X;
        charPage.Z = loadedChar.Z;
        
        
        charPage.EquippedMiscItems = loadedChar.EquippedMiscItems;
        charPage.EquippedActionTomes = loadedChar.EquippedActionTomes;
        charPage.EquippedSkills = loadedChar.EquippedSkills;
        charPage.UseableActions = loadedChar.ActionsList;
        charPage.UseableItems = loadedChar.ItemsList;
        charPage.UseableSkills = loadedChar.SkillsList;
        if (loadedChar.EquippedMH != null)
        {
            charPage.EquippedMH = (loadedChar.EquippedMH);
        }
        if (loadedChar.EquippedOH != null)
        {
            charPage.EquippedOH = loadedChar.EquippedOH;
        }
        if (loadedChar.EquippedHelmet != null)
        {
            charPage.EquippedHelmet = loadedChar.EquippedHelmet;
        }
        if (loadedChar.EquippedChest != null)
        {
            charPage.EquippedChest = loadedChar.EquippedChest;
        }
        if (loadedChar.EquippedFootwear != null)
        {
            charPage.EquippedFootwear = loadedChar.EquippedFootwear;
        }
        if (loadedChar.MovesPriority != null )
        {
            for (int i = 0; i < loadedChar.MovesPriority.Count; i++)
            {
                charPage.addMovePriotiy(loadedChar.MovesPriority[i]);
            }
        }
        if (loadedChar.ClassAttackPriority != null)
        {
            for (int i = 0; i < loadedChar.ClassAttackPriority.Count; i++)
            {
                charPage.addClassAttackPriority(loadedChar.ClassAttackPriority[i]);
            }
        }

        spriteRendComp.sprite = Resources.Load<Sprite>(loadedChar.SpriteName);
        charToSpawn.transform.position = new Vector3((4.0f) + ((float)loadedChar.X * 8), 1.5f, (4.0f) + ((float)loadedChar.Z * 8));

        charToSpawn.AddComponent<SpriteBillboard>();
        charToSpawn.AddComponent<BoxCollider2D>();
        charToSpawn.name = loadedChar.CharacterName;
        MenuManager.instance.CharactersInLevel.Add(charToSpawn);
        MenuManager.instance.ActiveCharactersInLevel.Add(charToSpawn);
        if (loadedChar.PlayerSide)
        {
            MenuManager.instance.PlayerCharactersInLevel.Add(charToSpawn);
        } else
        {
            MenuManager.instance.EnemyCharactersInLevel.Add(charToSpawn);
        }
    }
}
