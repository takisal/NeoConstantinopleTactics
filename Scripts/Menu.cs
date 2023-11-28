using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    public int numOfEnemiesG;

    [SerializeField]
    public int enemyLevelG;

    private List<CharacterStats> CreateNewParty()
    {
        BattleAction ba0 = new BattleAction("basic", 1, 1, 1, "basic", 10, "physical", -10);
        SkillInfo sk1 = new SkillInfo("Fireblade", 1, 1, 1, "fireysword", 10, "super", 25);
        SkillInfo sk2 = new SkillInfo("Iceblade", 1, 1, 1, "iceysword", 10, "super", 25);
        SkillInfo sk3 = new SkillInfo("Reach Attack", 1, 2, 1, "placeholder", 5, "physical", 25);
        SkillInfo sk4 = new SkillInfo("Heal", 1, 3, 1, "cure", 10, "heal", 25);
        List<CharacterStats> retList = new List<CharacterStats>();
        

        CharacterStats char1 = new CharacterStats(
            hp: 140,
            mp: 120,
            str: 45,
            mnd: 24,
            spriteName: "mainchara",
            characterName: "Venocha",
            playerControlled: true,
            maxHp: 140,
            maxMp: 120,
            moveDistance: 3,
            playerSide: true,
            jump: 8,
            def: 54,
            res: 36,
            acc: 51,
            eva: 43,
            inte: 38
        );
        char1.ActionsList.Add(ba0);
        char1.AllSkills.Add(sk3);
        retList.Add(char1);

       

        CharacterStats char2 = new CharacterStats(
            hp: 134,
            mp: 120,
            str: 36,
            mnd: 24,
            spriteName: "mainchara1",
            characterName: "Rerissa",
            playerControlled: true,
            maxHp: 134,
            maxMp: 120,
            moveDistance: 4,
            playerSide: true,
            jump: 8,
            def: 42,
            res: 36,
            acc: 44,
            eva: 45,
            inte: 34
        );
        char2.ActionsList.Add(ba0);
        char2.AllSkills.Add(sk1);
        retList.Add(char2);


        CharacterStats char3 = new CharacterStats(
            hp: 124,
            maxHp: 124,
            mp: 140,
            maxMp: 140,
            str: 39,
            mnd: 54,
            spriteName: "mainchara1",
            characterName: "Rerissa",
            playerControlled: true,
            moveDistance: 3,
            playerSide: true,
            jump: 8,
            def: 42,
            res: 36,
            acc: 46,
            eva: 47,
            inte: 35
        );
        char3.ActionsList.Add(ba0);
        char3.AllSkills.Add(sk2);
        retList.Add(char3);

       
        
        CharacterStats char4 = new CharacterStats(
            hp: 164,
            maxHp: 164,
            mp: 92,
            maxMp: 92,
            spriteName: "mainchara3",
            characterName: "Eclie",
            playerControlled: true,
            playerSide: true,
            moveDistance: 3,
            jump: 8,
            str: 39,
            mnd: 24,
            def: 54,
            res: 36,
            acc: 48,
            eva: 46,
            inte: 32
        );
        char4.ActionsList.Add(ba0);
        char4.AllSkills.Add(sk3);
        retList.Add(char4);

       

        CharacterStats char5 = new CharacterStats(
            hp: 111,
            maxHp: 111,
            mp: 133,
            maxMp: 133,
            spriteName: "mainchara4",
            characterName: "Momoya",
            playerControlled: true,
            playerSide: true,
            moveDistance: 3,
            jump: 8,
            str: 34,
            mnd: 54,
            def: 30,
            res: 48,
            acc: 39,
            eva: 55,
            inte: 42
        );
        char5.ActionsList.Add(ba0);
        char5.AllSkills.Add(sk1);
        char5.AllSkills.Add(sk2);
        retList.Add(char5);

       

        CharacterStats char6 = new CharacterStats(
            hp: 89,
            maxHp: 89,
            mp: 92,
            maxMp: 92,
            spriteName: "mainchara5",
            characterName: "Holokia",
            playerControlled: true,
            playerSide: true,
            moveDistance: 4,
            jump: 8,
            str: 24,
            mnd: 54,
            def: 36,
            res: 54,
            acc: 48,
            eva: 50,
            inte: 52
        );
        char6.ActionsList.Add(ba0);
        char6.AllSkills.Add(sk4);
        retList.Add(char6);

        return retList;
    }

    public void OnNewGameButton(string sceneName)
    {
        //TODO: create new party
        GameManager.instance.characters = CreateNewParty();
        DataSaver.saveDataNewton(GameManager.instance.characters, "characters");
        //create gold
        GameManager.instance.gold = 1000;

        saveInventory();
        Debug.Log("Created new file and saved");
        SceneManager.LoadScene(sceneName);
    }

    private void saveInventory()
    {
        DataSaver.saveDataNewton<List<Weapons>>(
            GameManager.instance.inventoryWeaponList,
            "weapons"
        );
        DataSaver.saveDataNewton<List<ActionTome>>(
            GameManager.instance.inventoryActionTomesList,
            "tomes"
        );
        DataSaver.saveDataNewton<List<Equipment>>(
            GameManager.instance.inventoryEquipmentList,
            "equipment"
        );
        DataSaver.saveDataNewton<List<MiscItems>>(
            GameManager.instance.inventoryMiscItemsList,
            "items"
        );
        DataSaver.saveDataNewton(GameManager.instance.gold, "gold");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
