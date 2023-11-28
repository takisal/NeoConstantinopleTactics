using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //State
    public static GameManager instance;

    //Location information
    public int enemyLev;
    public int numOfEnemies;
    public string nextStage;
    public string nextSceneName;
    public float owX = -675.0f;
    public float owY = -359.0f;
    public List<int> xMods = new List<int>();
    public List<int> yMods = new List<int>();
    private Hashtable openLevels;

    //Party information
    [SerializeField]
    public List<CharacterStats> characters;
    public int gold;
    public List<CharacterStats> SelectedChars = new List<CharacterStats>();
    public List<Weapons> weaponList = new List<Weapons>();
    public List<Equipment> equipmentList = new List<Equipment>();
    public List<MiscItems> miscItemsList = new List<MiscItems>();
    public List<ActionTome> tomeList = new List<ActionTome>();
    public List<Weapons> inventoryWeaponList = new List<Weapons>();
    public List<Equipment> inventoryEquipmentList = new List<Equipment>();
    public List<MiscItems> inventoryMiscItemsList = new List<MiscItems>();
    public List<ActionTome> inventoryActionTomesList = new List<ActionTome>();
    public List<StatsCharm> inventoryCharmsList = new List<StatsCharm>();

    //Misc
    public bool prepMoveOrAttack;
    
    

    public bool CheckIfLevelUnlocked(string levName)
    {
        bool isOpen = openLevels.ContainsKey(levName);
        return isOpen;
    }
    public void AddLevelUnlocked(string levName)
    {
       openLevels.Add(levName, true);
    }
    public void RemoveLevelUnlocked(string levName)
    {
        openLevels.Remove(levName);
    }
    private void Awake()
    {
        if (instance == null)
        {
            openLevels = new Hashtable();
            instance = this;
            DontDestroyOnLoad(gameObject);
            openLevels.Add("Shop1", true);
            openLevels.Add("Level1", true);
            //TODO: Populate with more items  
            instance.weaponList.Add(new Weapons("Bamboo Sword", 1, 1, 1, "placeholder", 12, 2, 15, 0,0,0,4,0,0,0,0, 0, 0));
            instance.weaponList.Add(new Weapons("Plastic Sword", 1, 1, 1, "plastic", 11, 1, 10, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0));
            instance.equipmentList.Add(new Equipment("Shirt", 1, 15, "placeholder", "Chest", 5, 5, 1, 1, 0, 0, 2, 0, 1, 0));
            instance.equipmentList.Add(new Equipment("Tennis Shoes", 1, 8, "placeholder", "Feet", 0, 4, 1, 0, 0, 0, 1, 0, 0, 0));
            instance.equipmentList.Add(new Equipment("Hat", 1, 15, "placeholder", "Head", 0, 0, 1, 0, 0, 0, 2, 0, 2, 0));
            instance.miscItemsList.Add(new MiscItems("Red Bull", 2, "redbull", "Energy Drink", 0, 1, "potion", 10));
            instance.miscItemsList.Add(new MiscItems("Carrot", 3, "placeholder", "Fresh carrot", 0, 1, "food", 10));
            instance.tomeList.Add(new ActionTome("Lightning Tome", new BattleAction("Lightning Attack", 1, 3, 1, "placeholder", 15, "magical", 35), 100));
            instance.tomeList.Add(new ActionTome("Gust Tome", new BattleAction("Gust Attack", 1, 3, 1, "placeholder", 15, "magical", 35), 100));
            
            if (SceneManager.GetActiveScene().name != "Menu")
            {
                LoadAllChars();
                LoadInventory();
                //For testing reasons ONLY
                SelectedChars = DataSaver.loadDataNewton<List<CharacterStats>>("players");
            }
            
        } 
        else
        {
            Destroy(gameObject);
        }
    }
    private void LoadAllChars()
    {
        characters = DataSaver.loadDataNewton<List<CharacterStats>>("characters");
    }
    private void LoadGold()
    {
        gold = DataSaver.loadDataNewton<int>("gold");
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishLoading;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishLoading;
    }
    public void LoadInventory()
    {
        //take posessed weapons  from savefile and load all of them
        List<Weapons> loadedWeapons = DataSaver.loadDataNewton<List<Weapons>>("weapons");
        //take posessed equipment from savefile  and load all of them
        List<Equipment> loadedEquipment = DataSaver.loadDataNewton<List<Equipment>>("equipment");
        //take posessed items from savefile and load all of them
        List<MiscItems> loadedItem = DataSaver.loadDataNewton<List<MiscItems>>("items");

        List<ActionTome> loadedTome = DataSaver.loadDataNewton<List<ActionTome>>("tomes");

        List<StatsCharm> loadedCharm = DataSaver.loadDataNewton<List<StatsCharm>>("charms");

        if (loadedItem == null)
        {
            loadedItem = new List<MiscItems>();
        }
        if (loadedWeapons == null)
        {
            loadedWeapons = new List<Weapons>();
        }
        if (loadedEquipment == null)
        {
            loadedEquipment = new List<Equipment>();
        }
        if (loadedTome == null)
        {
            loadedTome = new List<ActionTome>();
        }
        if (loadedCharm == null)
        {
            loadedCharm = new List<StatsCharm>();
        }
        int loadedGold = DataSaver.loadDataNewton<int>("gold");
        inventoryMiscItemsList = loadedItem;
        inventoryEquipmentList = loadedEquipment;
        inventoryWeaponList = loadedWeapons;
        inventoryActionTomesList = loadedTome;
        inventoryCharmsList = loadedCharm;
        if (loadedGold < 0)
        {
            loadedGold = 0;
        }
        gold = loadedGold;
    }
    void OnLevelFinishLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            for (int i = 0; i < SelectedChars.Count; i++)
            {
              //  Instantiate(SelectedChars[i]);
            }
            
        } else if (scene.name == "CharSelect")
        {
        } else if (scene.name == "Won")
        {
            //For special custscenes
           
        } else if (scene.name == "Shop")
        {
            GameObject goldlabel = GameObject.Find("Canvas/GoldLabel");
            TextMeshProUGUI textLabel = goldlabel.GetComponent<TextMeshProUGUI>();
            textLabel.text = "Gold: " + gold.ToString();
        } else if (scene.name == "Level1")
        {
            
        }
    }
}
