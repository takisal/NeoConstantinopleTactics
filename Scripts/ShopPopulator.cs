
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopPopulator : MonoBehaviour
{
    public List<int> WeaponsAtShop = new List<int>();
    public List<int> EquipmentAtShop = new List<int>();
    public List<int> ItemsAtShop = new List<int>();
    public List<int> TomesAtShop = new List<int>();
    [SerializeField]
    public GameObject mainShoppingWindow;
    [SerializeField]
    public GameObject buyButton;
    [SerializeField]
    public GameObject sellButton;
    [SerializeField]
    public GameObject equipButton;
    [SerializeField]
    public GameObject weaponsButton;
    [SerializeField]
    public GameObject armorButton;
    [SerializeField]
    public GameObject itemButton;
    [SerializeField]
    public GameObject tomeButton;
    [SerializeField]
    public GameObject backButton;
    [SerializeField]
    public GameObject equipRoom;
    [SerializeField]
    public GameObject shopRoom;
    [SerializeField]
    public GameObject InfoPanelWeapon;
    [SerializeField]
    public GameObject InfoPanelEquipment;
    [SerializeField]
    public GameObject InfoPanelItem;
    [SerializeField]
    public GameObject InfoPanelTome;
    private bool buyToggle;
    [SerializeField]
    public TextMeshProUGUI itemTitle;
    [SerializeField]
    public TextMeshProUGUI itemDMG;
    [SerializeField]
    public TextMeshProUGUI itemEVA;
    [SerializeField]
    public TextMeshProUGUI itemMND;
    [SerializeField]
    public TextMeshProUGUI itemDEF;
    [SerializeField]
    public TextMeshProUGUI itemACC;
    [SerializeField]
    public TextMeshProUGUI itemDESC;
    [SerializeField]
    public TextMeshProUGUI itemSTR;
    [SerializeField]
    public TextMeshProUGUI itemAOE;
    [SerializeField]
    public TextMeshProUGUI itemHP;
    [SerializeField]
    public TextMeshProUGUI itemMP;
    [SerializeField]
    public TextMeshProUGUI itemINT;
    [SerializeField]
    public TextMeshProUGUI itemMOVE;
    [SerializeField]
    public TextMeshProUGUI itemJUMP;
    [SerializeField]
    public TextMeshProUGUI itemRES;
    [SerializeField]
    public TextMeshProUGUI itemRANGE;
    [SerializeField]
    public Image itemSprite;
    [SerializeField]
    public TextMeshProUGUI itemTitleE;
    [SerializeField]
    public TextMeshProUGUI itemEVAE;
    [SerializeField]
    public TextMeshProUGUI itemMNDE;
    [SerializeField]
    public TextMeshProUGUI itemDEFE;
    [SerializeField]
    public TextMeshProUGUI itemACCE;
    [SerializeField]
    public TextMeshProUGUI itemDESCE;
    [SerializeField]
    public TextMeshProUGUI itemSTRE;
    [SerializeField]
    public TextMeshProUGUI itemHPE;
    [SerializeField]
    public TextMeshProUGUI itemMPE;
    [SerializeField]
    public TextMeshProUGUI itemINTE;
    [SerializeField]
    public TextMeshProUGUI itemMOVEE;
    [SerializeField]
    public TextMeshProUGUI itemJUMPE;
    [SerializeField]
    public TextMeshProUGUI itemRESE;
    [SerializeField]
    public Image itemSpriteE;
    [SerializeField]
    public TextMeshProUGUI itemTitleI;
    [SerializeField]
    public TextMeshProUGUI itemDESCI;
    [SerializeField]
    public Image itemSpriteI;
    [SerializeField]
    public TextMeshProUGUI itemTitleT;
    [SerializeField]
    public TextMeshProUGUI itemTomeTitle;
    [SerializeField]
    public TextMeshProUGUI itemDMGT;
    [SerializeField]
    public TextMeshProUGUI itemDESCT;
    [SerializeField]
    public TextMeshProUGUI itemAOET;
    [SerializeField]
    public TextMeshProUGUI itemRANGET;
    [SerializeField]
    public Image itemSpriteT;
    [SerializeField]
    public Image tomeSprite;
    // Start is called before the first frame update
    void Start()
    {
        UpdateDisplayedGoldBal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenEquipRoom()
    {
        equipRoom.SetActive(true);
    }
    public void BackButtonPress()
    {
        armorButton.SetActive(false);
        weaponsButton.SetActive(false);
        armorButton.SetActive(false);
        sellButton.SetActive(true);
        equipButton.SetActive(true);
        buyButton.SetActive(true);
        backButton.SetActive(false);
        itemButton.SetActive(false);
        tomeButton.SetActive(false);
        foreach (Transform child in mainShoppingWindow.transform)
        {
            Destroy(child.gameObject);
        }
        mainShoppingWindow.SetActive(false);
    }
    
    public void FirstButtonPress(bool buyp)
    {
        buyToggle = buyp;
        buyButton.SetActive(false);
        sellButton.SetActive(false);
        equipButton.SetActive(false);
        weaponsButton.SetActive(true);
        armorButton.SetActive(true);
        itemButton.SetActive(true);
        backButton.SetActive(true);
        tomeButton.SetActive(true);
    }
    
    
    public void buyOrSellWeapon(Weapons weapon)
    {
        if (buyToggle == false)
        {
            GameManager.instance.gold += weapon.price;
            for (int i = 0; i < GameManager.instance.inventoryWeaponList.Count; i++)
            {
                if (weapon == GameManager.instance.inventoryWeaponList[i])
                {
                    GameManager.instance.inventoryWeaponList.RemoveAt(i);
                }
            }
            //TODO: make sell effect
            UpdateDisplayedGoldBal();
            return;
        }
        if (GameManager.instance.gold < weapon.price)
        {
            //TODO: show error
            return;
        }
        GameManager.instance.gold -= weapon.price;
        GameManager.instance.inventoryWeaponList.Add(weapon);
        //TODO: make buy effect
        UpdateDisplayedGoldBal();
    }
    public void buyOrSellEquipment(Equipment equipment)
    {
        if (buyToggle == false)
        {
            GameManager.instance.gold += equipment.price;
            for (int i = 0; i < GameManager.instance.inventoryEquipmentList.Count; i++)
            {
                if (equipment == GameManager.instance.inventoryEquipmentList[i])
                {
                    GameManager.instance.inventoryEquipmentList.RemoveAt(i);
                }
            }
            //TODO: make sell effect
            UpdateDisplayedGoldBal();
            return;
        }
        if (GameManager.instance.gold < equipment.price)
        {
            //TODO: show error
            return;
        }
        GameManager.instance.gold -= equipment.price;
        GameManager.instance.inventoryEquipmentList.Add(equipment);
        //TODO: make buy effect
        UpdateDisplayedGoldBal();
    }
    public void buyOrSellItem(MiscItems item)
    {
        if (buyToggle == false)
        {
            GameManager.instance.gold += item.price;
            for (int i = 0; i < GameManager.instance.inventoryMiscItemsList.Count; i++)
            {
                if (item == GameManager.instance.inventoryMiscItemsList[i])
                {
                    GameManager.instance.inventoryMiscItemsList.RemoveAt(i);
                }
            }
            //TODO: make sell effect
            UpdateDisplayedGoldBal();
            return;
        }
        if (GameManager.instance.gold < item.price)
        {
            //TODO: show error
            return;
        }
        GameManager.instance.gold -= item.price;
        GameManager.instance.inventoryMiscItemsList.Add(item);
        //TODO: make buy effect
        UpdateDisplayedGoldBal();
    }
    
    public void buyOrSellTome(ActionTome tome)
    {
        if (buyToggle == false)
        {
            GameManager.instance.gold += tome.price;
            for (int i = 0; i < GameManager.instance.inventoryActionTomesList.Count; i++)
            {
                if (tome == GameManager.instance.inventoryActionTomesList[i])
                {
                    GameManager.instance.inventoryActionTomesList.RemoveAt(i);
                }
            }
            //TODO: make sell effect
            UpdateDisplayedGoldBal();
            return;
        }
        if (GameManager.instance.gold < tome.price)
        {
            //TODO: show error
            return;
        }
        GameManager.instance.gold -= tome.price;
        GameManager.instance.inventoryActionTomesList.Add(tome);
        //TODO: make buy effect
        UpdateDisplayedGoldBal();
    }
    public void CloseShopWindow()
    {
        mainShoppingWindow.SetActive(false);
    }
    private void SaveAll()
    {
        DataSaver.saveDataNewton<int>(GameManager.instance.gold, "gold");
        DataSaver.saveDataNewton<List<Weapons>>(GameManager.instance.inventoryWeaponList, "weapons");
        DataSaver.saveDataNewton<List<Equipment>>(GameManager.instance.inventoryEquipmentList, "equipment");
        DataSaver.saveDataNewton<List<MiscItems>>(GameManager.instance.inventoryMiscItemsList, "items");
        DataSaver.saveDataNewton<List<ActionTome>>(GameManager.instance.inventoryActionTomesList, "tomes");
        DataSaver.saveDataNewton<List<CharacterStats>>(GameManager.instance.characters, "characters");
    }
    private void UpdateDisplayedGoldBal()
    {
        GameObject goldlabel = GameObject.Find("Canvas/GoldLabel");
        TextMeshProUGUI textLabel = goldlabel.GetComponent<TextMeshProUGUI>();
        textLabel.text = "Gold: " + GameManager.instance.gold.ToString();
        DataSaver.saveDataNewton<int>(GameManager.instance.gold, "gold");
        SaveAll();
    }
    public void PopulateShopWindow(string categ)
    {
        foreach (Transform child in mainShoppingWindow.transform)
        {
            Destroy(child.gameObject);
        }
        mainShoppingWindow.SetActive(true);
        List<MiscItems> itemToDisplayList = new List<MiscItems>();
        List<Equipment> equipmentToDisplayList = new List<Equipment>();
        List<Weapons> weaponToDisplayList = new List<Weapons>();
        List<ActionTome> tomeToDisplayList = new List<ActionTome>();
        if (buyToggle == true)
        {
            for (int i = 0; i < EquipmentAtShop.Count; i++)
            {
                int ind = EquipmentAtShop[i];
                Equipment item = GameManager.instance.equipmentList.ElementAt(ind);
                equipmentToDisplayList.Add(item);
            }
            for (int i = 0; i < ItemsAtShop.Count; i++)
            {
                int ind = EquipmentAtShop[i];
                MiscItems item = GameManager.instance.miscItemsList.ElementAt(ind);
                itemToDisplayList.Add(item);
            }
            for (int i = 0; i < WeaponsAtShop.Count; i++)
            {
                int ind = EquipmentAtShop[i];
                Weapons item = GameManager.instance.weaponList.ElementAt(ind);
                weaponToDisplayList.Add(item);
            }
            for (int i = 0; i < TomesAtShop.Count; i++)
            {
                int ind = EquipmentAtShop[i];
                ActionTome item = GameManager.instance.tomeList.ElementAt(ind);
                tomeToDisplayList.Add(item);
            }
            
        } else
        {
            for (int i = 0; i < GameManager.instance.inventoryEquipmentList.Count; i++)
            {
                equipmentToDisplayList.Add(GameManager.instance.inventoryEquipmentList[i]);
            }
            for (int i = 0; i < GameManager.instance.inventoryMiscItemsList.Count; i++)
            {
                itemToDisplayList.Add(GameManager.instance.inventoryMiscItemsList[i]);
            }
            for (int i = 0; i < GameManager.instance.inventoryWeaponList.Count; i++)
            {
                weaponToDisplayList.Add(GameManager.instance.inventoryWeaponList[i]);
            }
            for (int i = 0; i < GameManager.instance.inventoryActionTomesList.Count; i++)
            {
                tomeToDisplayList.Add(GameManager.instance.inventoryActionTomesList[i]);
            }
            
        }
        
            for (int i = 0; i < itemToDisplayList.Count; i++)
            {
          
                GameObject newbtnCont = new GameObject();
                newbtnCont.transform.SetParent(mainShoppingWindow.transform);
                //TODO: calibrate position
                newbtnCont.transform.localPosition = new Vector3(0.0f, 34 - (30.0f * i), 0.0f);
                Button btn = newbtnCont.AddComponent<Button>();
            PointerEventsController PEC = btn.AddComponent<PointerEventsController>();

            //GameObject newinfoPanel = Instantiate(InfoPanel);
            //newinfoPanel.transform.parent = GameObject.Find("Canvas").transform;
            // newinfoPanel.transform.position = InfoPanel.transform.position;
            int priceNode = 0;
            string iconName = "";
            string nameNode = "";
            if (categ == "Weapons")
            {
                Weapons weapon = weaponToDisplayList[i];
                nameNode = weapon.weaponName;
                iconName = weapon.iconName;
                priceNode = weapon.price;
                string rangeStr = "";
                if (weapon.maxRange == weapon.minRange)
                {
                    rangeStr = weapon.maxRange.ToString();
                } else
                {
                    rangeStr = weapon.minRange.ToString() + "-"+weapon.maxRange.ToString();
                }
                btn.onClick.AddListener(delegate { buyOrSellWeapon(weapon); });
                PEC.setInfoPanel(InfoPanelWeapon, itemTitle, itemDMG, itemACC, itemEVA, itemDEF, itemMND, weapon.weaponName, weapon.dmg, 0, 0, 12, 0, weapon.iconName, itemSprite, "", itemDESC, weapon.str, itemSTR, weapon.aoe, itemAOE, "weapon", null, null, false, "", itemINT, weapon.inte, itemHP, weapon.hp, itemMP, weapon.mp, itemRES, weapon.res, itemMOVE, weapon.move, itemJUMP, weapon.jmp, itemRANGE, rangeStr);
            } else if (categ == "Equipment")
            {
                Equipment equipment = equipmentToDisplayList[i];
                
                 nameNode = equipment.equipmentName;
                iconName = equipment.iconName;
                priceNode = equipment.price;
                btn.onClick.AddListener(delegate { buyOrSellEquipment(equipment); });
                PEC.setInfoPanel(InfoPanelEquipment, itemTitleE, null, itemACCE, itemEVAE, itemDEFE, itemMNDE, equipment.equipmentName, 0, 0,0,  equipment.def, 12, equipment.iconName, itemSpriteE, "", itemDESCE, 0, itemSTRE, 0, null, "equipment", null, null, false, "", itemINTE, equipment.inte, itemHPE, equipment.hp, itemMPE, equipment.mp, itemRES, equipment.res, itemMOVE, equipment.move, itemJUMP, equipment.jmp, null, "");
            } else if (categ == "Items")
            {
                MiscItems item = itemToDisplayList[i]; ;
               
                 nameNode = item.itemName;
                iconName = item.iconName;
                priceNode = item.price;
                btn.onClick.AddListener(delegate { buyOrSellItem(item); });
                PEC.setInfoPanel(InfoPanelItem, itemTitleI, null, null, null, null, null, item.itemName, item.dmg, 0, 0, 0, 0, item.iconName, itemSpriteI, item.description, itemDESCI, 0, null, 0, null, "item", null, null, false, "", null, 0, null, 0, null, 0, null, 0, null, 0, null, 0, null, "");
            } else if (categ == "Tomes")
            {
                ActionTome item = tomeToDisplayList[i]; ;

                nameNode = item.tomeName;
                iconName = item.skillInfo.iconName;
                priceNode = item.price;
                string rangeStr = "";
                if (item.skillInfo.maxRange == item.skillInfo.minRange)
                {
                    rangeStr = item.skillInfo.maxRange.ToString();
                }
                else
                {
                    rangeStr = item.skillInfo.minRange.ToString() + "-" + item.skillInfo.maxRange.ToString();
                }
                btn.onClick.AddListener(delegate { buyOrSellTome(item); });
                PEC.setInfoPanel(InfoPanelTome, itemTitleT, itemDMGT, null, null, null, null, item.skillInfo.actionName, item.skillInfo.dmg, 0, 0, 12, 0, item.skillInfo.iconName, itemSpriteT, "", itemDESCT, 0, null, item.skillInfo.aoe, itemAOET, "tome", itemTomeTitle, tomeSprite, false, "", null, 0, null, 0, null, 0, null, 0, null, 0, null, 0, itemRANGET, rangeStr);

            }
            Debug.Log(nameNode);
            btn.transform.localPosition = new Vector3(0.0f, 34 - (30.0f * i), 0.0f);
                btn.transform.localScale = new Vector3(1.0f, 0.3f, 1);
                btn.targetGraphic = Resources.Load<Image>("transparentbg");
                Image img = newbtnCont.AddComponent<Image>();
                img.color = new Color(21f / 255f, 103f / 255f, 98f / 255f, 0.8f);
                img.rectTransform.sizeDelta = new Vector2(548f, 75f);
                //newbtnCont.GetComponent<RectTransform>();
                btn.targetGraphic.rectTransform.sizeDelta = new Vector2(98f, 100f);
                Outline outline = newbtnCont.AddComponent<Outline>();
                outline.effectDistance = new Vector2(0.3f, 2);
                outline.effectColor = new Color(145f / 255f, 145f / 255f, 145f / 255f);
                //add textObject to button
                GameObject newtxt = new GameObject();
                TextMeshProUGUI textMesh = newtxt.AddComponent<TextMeshProUGUI>();
                newtxt.transform.SetParent(newbtnCont.transform);
                newtxt.transform.localPosition = new Vector3(10.0f, 0, 0.0f);
                textMesh.text = nameNode;
                textMesh.enableAutoSizing = true;
                textMesh.fontSizeMax = 720;
                textMesh.rectTransform.sizeDelta = new Vector2(200f, 25f);
            GameObject newtxtPrice = new GameObject();
            TextMeshProUGUI textMeshPrice = newtxtPrice.AddComponent<TextMeshProUGUI>();
            newtxtPrice.transform.SetParent(newbtnCont.transform);
            newtxtPrice.transform.localPosition = new Vector3(200.0f, 0, 0.0f);
            textMeshPrice.text = priceNode.ToString();
            textMeshPrice.enableAutoSizing = true;
            textMeshPrice.rectTransform.sizeDelta = new Vector2(50f, 25f);
            textMeshPrice.alignment = TextAlignmentOptions.Right;
            //add icon to button
            GameObject newimg = new GameObject();
                newimg.transform.SetParent(newbtnCont.transform);
                newimg.transform.localPosition = new Vector3(-220.0f, 0, 0.0f);
                Sprite imgToAdd = Resources.Load<Sprite>(iconName);
                Image imgAdded = newimg.AddComponent<Image>();
                imgAdded.sprite = imgToAdd;
                imgAdded.rectTransform.sizeDelta = new Vector2(28, 28);
            GameObject newimgMoney = new GameObject();
            newimgMoney.transform.SetParent(newbtnCont.transform);
            newimgMoney.transform.localPosition = new Vector3(240.0f, 0, 0.0f);
            Sprite imgToAddMoney = Resources.Load<Sprite>("coin");
            Image imgAddedMoney = newimgMoney.AddComponent<Image>();
            imgAddedMoney.sprite = imgToAddMoney;
            imgAddedMoney.rectTransform.sizeDelta = new Vector2(24, 24);
        }
        
        
        

    }
    public void ExitShop()
    {
        DataSaver.saveDataNewton<int>(GameManager.instance.gold, "gold");
        DataSaver.saveDataNewton<List<Weapons>>(GameManager.instance.inventoryWeaponList, "weapons");
        DataSaver.saveDataNewton<List<Equipment>>(GameManager.instance.inventoryEquipmentList, "equipment");
        DataSaver.saveDataNewton<List<MiscItems>>(GameManager.instance.inventoryMiscItemsList, "items");
        DataSaver.saveDataNewton<List<ActionTome>>(GameManager.instance.inventoryActionTomesList, "tomes");
        DataSaver.saveDataNewton<List<CharacterStats>>(GameManager.instance.characters, "characters");
        SceneManager.LoadScene("Overworld");
    }
}
