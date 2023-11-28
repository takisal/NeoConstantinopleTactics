using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipRoomManager : MonoBehaviour
{
    [SerializeField]
    public GameObject PEW;
    [SerializeField]
    public GameObject ClosePEWButton;
    [SerializeField]
    public GameObject RCTT;
    [SerializeField]
    public GameObject EquipScreen;
    [SerializeField]
    public GameObject CharPortrait;
    [SerializeField]
    public GameObject ScrollingWindow;
    [SerializeField]
    public GameObject MHButton;
    [SerializeField]
    public GameObject OHButton;
    [SerializeField]
    public GameObject HelmetButton;
    [SerializeField]
    public GameObject ChestButton;
    [SerializeField]
    public GameObject FootwearButton;
    [SerializeField]
    public GameObject MHButtonLabel;
    [SerializeField]
    public GameObject OHButtonLabel;
    [SerializeField]
    public GameObject HelmetButtonLabel;
    [SerializeField]
    public GameObject ChestButtonLabel;
    [SerializeField]
    public GameObject FootwearButtonLabel;
    [SerializeField]
    public GameObject[] TomesButtons;
    [SerializeField]
    public GameObject[] ItemsButtons;
    [SerializeField]
    public GameObject[] SkillsButtons;
    [SerializeField]
    public GameObject[] TomesButtonsLabels;
    [SerializeField]
    public GameObject[] ItemsButtonsLabels;
    [SerializeField]
    public GameObject[] SkillsButtonsLabels;
    [SerializeField]
    public GameObject HPLabel;
    [SerializeField]
    public GameObject MPLabel;
    [SerializeField]
    public GameObject STRLabel;
    [SerializeField]
    public GameObject MNDLabel;
    [SerializeField]
    public GameObject JumpLabel;
    [SerializeField]
    public GameObject DEFLabel;
    [SerializeField]
    public GameObject EVALabel;
    [SerializeField]
    public GameObject ACCLabel;
    [SerializeField]
    public GameObject INTLabel;
    [SerializeField]
    public GameObject ATKLabel;
    [SerializeField]
    public GameObject RESLabel;
    [SerializeField]
    public GameObject MoveLabel;
    [SerializeField]
    public GameObject HPMod;
    [SerializeField]
    public GameObject MPMod;
    [SerializeField]
    public GameObject STRMod;
    [SerializeField]
    public GameObject MNDMod;
    [SerializeField]
    public GameObject JumpMod;
    [SerializeField]
    public GameObject DEFMod;
    [SerializeField]
    public GameObject EVAMod;
    [SerializeField]
    public GameObject ACCMod;
    [SerializeField]
    public GameObject INTMod;
    [SerializeField]
    public GameObject ATKMod;
    [SerializeField]
    public GameObject RESMod;
    [SerializeField]
    public GameObject MoveMod;


    [SerializeField]
    private CharacterStats displayedChar;



    [SerializeField]
    public GameObject InfoPanelWeapon;
    [SerializeField]
    public GameObject InfoPanelEquipment;
    [SerializeField]
    public GameObject InfoPanelItem;
    [SerializeField]
    public GameObject InfoPanelTome;
    [SerializeField]
    public GameObject InfoPanelSkill;






    [SerializeField]
    public TextMeshProUGUI itemTitle;
    [SerializeField]
    public TextMeshProUGUI itemATK;
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
    public TextMeshProUGUI itemINT;
    [SerializeField]
    public TextMeshProUGUI itemHP;
    [SerializeField]
    public TextMeshProUGUI itemMP;
    [SerializeField]
    public TextMeshProUGUI itemRES;
    [SerializeField]
    public TextMeshProUGUI itemJUMP;
    [SerializeField]
    public TextMeshProUGUI itemMOVE;
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
    public TextMeshProUGUI itemINTE;
    [SerializeField]
    public TextMeshProUGUI itemHPE;
    [SerializeField]
    public TextMeshProUGUI itemMPE;
    [SerializeField]
    public TextMeshProUGUI itemRESE;
    [SerializeField]
    public TextMeshProUGUI itemJUMPE;
    [SerializeField]
    public TextMeshProUGUI itemMOVEE;
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
    public TextMeshProUGUI itemATKT;
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
    [SerializeField]
    public TextMeshProUGUI itemTitleS;
    [SerializeField]
    public TextMeshProUGUI itemATKS;
    [SerializeField]
    public TextMeshProUGUI itemDESCS;
    [SerializeField]
    public TextMeshProUGUI itemAOES;
    [SerializeField]
    public TextMeshProUGUI itemRANGES;
    [SerializeField]
    public Image itemSpriteS;
    // Start is called before the first frame update
    void Start()
    {
        //load all chars
        List<CharacterStats> allChars = DataSaver.loadDataNewton<List<CharacterStats>>("characters");
        GameManager.instance.LoadInventory();
        CharacterStats firstChar = allChars[0];
        //display all characters in scrolling canvas
        for (int i = 0; i < allChars.Count; i++)
        {
            CharacterStats curChar = allChars[i];
            if (curChar == null)
            {
                continue;
            }
            GameObject newbtnCont = new GameObject();
            newbtnCont.transform.SetParent(ScrollingWindow.transform);
            //TODO: calibrate position
            newbtnCont.transform.localPosition = new Vector3(-603.0f+(120.0f*i), 76.0f, 0.0f);
            Button btn = newbtnCont.AddComponent<Button>();
            btn.onClick.AddListener(delegate { OnSpriteClicky(curChar); });
            btn.transform.localPosition = new Vector3(-603.0f + (120.0f * i), 76.0f, 0.0f);
            btn.transform.localScale = new Vector3(1.0f, 1.0f, 1);
            btn.targetGraphic = Resources.Load<Image>("clearbg");
            Sprite imgToAdd = Resources.Load<Sprite>(curChar.SpriteName);
            Image imgAdded = newbtnCont.AddComponent<Image>();
            imgAdded.sprite = imgToAdd;
            imgAdded.rectTransform.sizeDelta = new Vector2(120, 120);
            imgAdded.preserveAspect = true;
            imgAdded.useSpriteMesh = true;
        }
        AddPEC2();
        OnSpriteClicky(firstChar);

        
    }
    public void OnPClick(PointerEventData eventData)
    {
        Debug.Log(" clicked");
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right clicked");
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Left clicked");
        }
    }
    private void AddPEC2()
    {
        MHButton.AddComponent<PointerEventsController2>().setRCTT(RCTT, this, 0, "mh");
        OHButton.AddComponent<PointerEventsController2>().setRCTT(RCTT, this, 0, "oh");
        FootwearButton.AddComponent<PointerEventsController2>().setRCTT(RCTT, this, 0, "footwear");
        HelmetButton.AddComponent<PointerEventsController2>().setRCTT(RCTT, this, 0, "helmet");
        ChestButton.AddComponent<PointerEventsController2>().setRCTT(RCTT, this, 0, "chest");
        for (int i = 0; i < 4; i++)
        {
            TomesButtons[i].AddComponent<PointerEventsController2>().setRCTT(RCTT, this, i, "tome");
            ItemsButtons[i].AddComponent<PointerEventsController2>().setRCTT(RCTT, this, i, "item");
            SkillsButtons[i].AddComponent<PointerEventsController2>().setRCTT(RCTT, this, i, "skill");
        }
    }
    public void showAll(bool show)
    {
        MHButton.SetActive(show);
        OHButton.SetActive(show);
        FootwearButton.SetActive(show);
        HelmetButton.SetActive(show);
        ChestButton.SetActive(show);
        for (int i = 0; i < 4; i++)
        {
            TomesButtons[i].SetActive(show);
            ItemsButtons[i].SetActive(show);
            SkillsButtons[i].SetActive(show);
        }
        

    }
    public void ClearComparison()
    {
        TextMeshProUGUI DEFModTXT = DEFMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI STRModTXT = STRMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI EVAModTXT = EVAMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI ACCModTXT = ACCMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI MNDModTXT = MNDMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI JUMPModTXT = JumpMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI INTModTXT = INTMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI MPModTXT = MPMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI HPModTXT = HPMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI ATKModTXT = ATKMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI RESModTXT = RESMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI MOVModTXT = MoveMod.GetComponent<TextMeshProUGUI>();
        DEFModTXT.text = "";
        STRModTXT.text = "";
        EVAModTXT.text = "";
        ACCModTXT.text = "";
        MNDModTXT.text = "";
        JUMPModTXT.text = "";
        INTModTXT.text = "";
        MPModTXT.text = "";
        HPModTXT.text = "";
        ATKModTXT.text = "";
        RESModTXT.text = "";
        MOVModTXT.text = "";
    }
    public void CompareStats(int str, int def, int acc, int eva, int mnd, int jmp, string compareCategory, int inte, int hp, int mp, int atk, int res, int move)
    {
        //TODO: MH/OH
        Weapons mh = displayedChar.EquippedMH;
        Weapons oh = displayedChar.EquippedOH;
        Equipment footwear = displayedChar.EquippedFootwear;
        Equipment helmet = displayedChar.EquippedHelmet;
        Equipment chest = displayedChar.EquippedChest;
        int dif_str = str;
        int dif_def = def;
        int dif_acc = acc;
        int dif_eva = eva;
        int dif_mnd = mnd;
        int dif_jmp = jmp;
        int dif_int = inte;
        int dif_hp = hp;
        int dif_mp = mp;
        int dif_atk = atk;
        int dif_res = res;
        int dif_move = move;
        if (compareCategory == "mh" && mh != null)
        {
            dif_str -= mh.str;
            dif_def -= mh.def;
            dif_acc -= mh.acc;
            dif_eva -= mh.eva;
            dif_mnd -= mh.mnd;
            dif_jmp -= mh.jmp;
            dif_int -= mh.inte;
            dif_hp -= mh.hp;
            dif_mp -= mh.mp;
            dif_atk -= mh.dmg;
            dif_res -= mh.res;
            dif_move -= mh.move;
        } else if (compareCategory == "oh" && oh != null)
        {
            dif_str -= oh.str;
            dif_def -= oh.def;
            dif_acc -= oh.acc;
            dif_eva -= oh.eva;
            dif_mnd -= oh.mnd;
            dif_jmp -= oh.jmp;
            dif_int -= oh.inte;
            dif_hp -= oh.hp;
            dif_mp -= oh.mp;
            dif_res -= oh.res;
            dif_move -= oh.move;
        }
        else if (compareCategory == "footwear" && footwear != null)
        {
            dif_str -= footwear.str;
            dif_def -= footwear.def;
            dif_acc -= footwear.acc;
            dif_eva -= footwear.eva;
            dif_mnd -= footwear.mnd;
            dif_jmp -= footwear.jmp;
            dif_int -= footwear.inte;
            dif_hp -= footwear.hp;
            dif_mp -= footwear.mp;
            dif_res -= footwear.res;
            dif_move -= footwear.move;
        }
        else if (compareCategory == "helmet" && helmet != null)
        {
            dif_str -= helmet.str;
            dif_def -= helmet.def;
            dif_acc -= helmet.acc;
            dif_eva -= helmet.eva;
            dif_mnd -= helmet.mnd;
            dif_jmp -= helmet.jmp;
            dif_int -= helmet.inte;
            dif_hp -= helmet.hp;
            dif_mp -= helmet.mp;
            dif_res -= helmet.res;
            dif_move -= helmet.move;
        }
        else if (compareCategory == "chest" && chest != null)
        {
            dif_str -= chest.str;
            dif_def -= chest.def;
            dif_acc -= chest.acc;
            dif_eva -= chest.eva;
            dif_mnd -= chest.mnd;
            dif_jmp -= chest.jmp;
            dif_int -= chest.inte;
            dif_hp -= chest.hp;
            dif_mp -= chest.mp;
            dif_res -= chest.res;
            dif_move -= chest.move;
        }
        TextMeshProUGUI DEFModTXT = DEFMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI STRModTXT = STRMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI EVAModTXT = EVAMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI ACCModTXT = ACCMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI MNDModTXT = MNDMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI INTModTXT = INTMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI HPModTXT = HPMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI MPModTXT = MPMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI ATKModTXT = ATKMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI JUMPModTXT = JumpMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI RESModTXT = RESMod.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI MOVModTXT = MoveMod.GetComponent<TextMeshProUGUI>();

        if (dif_mnd < 0)
        {
            MNDModTXT.text = dif_mnd.ToString();
            MNDModTXT.color = Color.red;
        } else if (dif_mnd > 0)
        {
            MNDModTXT.text = "+" + dif_mnd.ToString();
            MNDModTXT.color = Color.green;
        }

        if (dif_def < 0)
        {
            DEFModTXT.text = dif_def.ToString();
            DEFModTXT.color = Color.red;
        }
        else if (dif_def > 0)
        {
            DEFModTXT.text = "+" + dif_def.ToString();
            DEFModTXT.color = Color.green;
            
        }

        if (dif_str < 0)
        {
            STRModTXT.text = dif_str.ToString();
            STRModTXT.color = Color.red;
        }
        else if (dif_str > 0)
        {
            STRModTXT.text = "+" + dif_str.ToString();
            STRModTXT.color = Color.green;
        }

        if (dif_eva < 0)
        {
            EVAModTXT.text = dif_eva.ToString();
            EVAModTXT.color = Color.red;
        }
        else if (dif_eva > 0)
        {
            EVAModTXT.text = "+"+dif_eva.ToString();
            EVAModTXT.color = Color.green;
        }

        if (dif_acc < 0)
        {
            ACCModTXT.text = dif_acc.ToString();
            ACCModTXT.color = Color.red;
        }
        else if (dif_acc > 0)
        {
            ACCModTXT.text = "+" + dif_acc.ToString();
            ACCModTXT.color = Color.green;
        }

        if (dif_jmp < 0)
        {
            JUMPModTXT.text = dif_jmp.ToString();
            JUMPModTXT.color = Color.red;
        }
        else if (dif_jmp > 0)
        {
            JUMPModTXT.text = dif_jmp.ToString();
            JUMPModTXT.color = Color.green;
        }

        if (dif_int < 0)
        {
            INTModTXT.text = dif_int.ToString();
            INTModTXT.color = Color.red;
        }
        else if (dif_int > 0)
        {
            INTModTXT.text = dif_int.ToString();
            INTModTXT.color = Color.green;
        }
        if (dif_hp < 0)
        {
            HPModTXT.text = dif_hp.ToString();
            HPModTXT.color = Color.red;
        }
        else if (dif_hp > 0)
        {
            HPModTXT.text = dif_hp.ToString();
            HPModTXT.color = Color.green;
        }
        if (dif_mp < 0)
        {
            MPModTXT.text = dif_mp.ToString();
            MPModTXT.color = Color.red;
        }
        else if (dif_mp > 0)
        {
            MPModTXT.text = dif_mp.ToString();
            MPModTXT.color = Color.green;
        }
        if (dif_atk < 0)
        {
            ATKModTXT.text = dif_atk.ToString();
            ATKModTXT.color = Color.red;
        }
        else if (dif_atk > 0)
        {
            ATKModTXT.text = dif_atk.ToString();
            ATKModTXT.color = Color.green;
        }
        if (dif_res < 0)
        {
            RESModTXT.text = dif_res.ToString();
            RESModTXT.color = Color.red;
        }
        else if (dif_res > 0)
        {
            RESModTXT.text = dif_res.ToString();
            RESModTXT.color = Color.green;
        }
        if (dif_move < 0)
        {
            MOVModTXT.text = dif_move.ToString();
            ATKModTXT.color = Color.red;
        }
        else if (dif_move > 0)
        {
            MOVModTXT.text = dif_move.ToString();
            MOVModTXT.color = Color.green;
        }
    }
    //when sprite in scrolling window is clicked
    public void OnSpriteClicky(CharacterStats curChar)
    {
        displayedChar = curChar;
        Image imgy1 = CharPortrait.GetComponent<Image>();
        imgy1.sprite = Resources.Load<Sprite>(curChar.SpriteName);
        imgy1.preserveAspect = true;
        imgy1.useSpriteMesh = true;
        imgy1.color = Color.white;
        //populate buttons with pictures of equipped items, and names in the labels
        if (curChar.EquippedMH != null)
        {
            
            TextMeshProUGUI textMesh = MHButtonLabel.GetComponent<TextMeshProUGUI>();
            textMesh.text = curChar.EquippedMH.weaponName;
            Image imgy = MHButton.GetComponent<Image>();
            imgy.sprite = Resources.Load<Sprite>(curChar.EquippedMH.iconName);
            MHButton.GetComponent<PointerEventsController2>().setFilled(true);
        }
        else
        {
            TextMeshProUGUI textMesh = MHButtonLabel.GetComponent<TextMeshProUGUI>();
            textMesh.text = "Unequipped";
            Image imgy = MHButton.GetComponent<Image>();
            imgy.sprite = Resources.Load<Sprite>("placeholder");
            MHButton.GetComponent<PointerEventsController2>().setFilled(false);

        }
        if (curChar.EquippedOH != null)
        {
            Image imgy = OHButton.GetComponent<Image>();
            imgy.sprite = Resources.Load<Sprite>(curChar.EquippedOH.iconName);
            TextMeshProUGUI textMesh = OHButtonLabel.GetComponent<TextMeshProUGUI>();
            textMesh.text = curChar.EquippedOH.weaponName;
            OHButton.GetComponent<PointerEventsController2>().setFilled(true);
        } else
        {
            TextMeshProUGUI textMesh = OHButtonLabel.GetComponent<TextMeshProUGUI>();
            textMesh.text = "Unequipped";
            Image imgy = OHButton.GetComponent<Image>();
            imgy.sprite = Resources.Load<Sprite>("placeholder");
            OHButton.GetComponent<PointerEventsController2>().setFilled(false);

        }
        if (curChar.EquippedHelmet != null)
        {
            Image imgy = HelmetButton.GetComponent<Image>();
            imgy.sprite = Resources.Load<Sprite>(curChar.EquippedHelmet.iconName);
            TextMeshProUGUI textMesh = HelmetButtonLabel.GetComponent<TextMeshProUGUI>();
            textMesh.text = curChar.EquippedHelmet.equipmentName;
            HelmetButton.GetComponent<PointerEventsController2>().setFilled(true);
        }
        else
        {
            TextMeshProUGUI textMesh = HelmetButtonLabel.GetComponent<TextMeshProUGUI>();
            textMesh.text = "Unequipped";
            Image imgy = HelmetButton.GetComponent<Image>();
            imgy.sprite = Resources.Load<Sprite>("placeholder");
            HelmetButton.GetComponent<PointerEventsController2>().setFilled(false);

        }
        if (curChar.EquippedChest != null)
        {
            Image imgy = ChestButton.GetComponent<Image>();
            imgy.sprite = Resources.Load<Sprite>(curChar.EquippedChest.iconName);
            TextMeshProUGUI textMesh = ChestButtonLabel.GetComponent<TextMeshProUGUI>();
            textMesh.text = curChar.EquippedChest.equipmentName;
            ChestButton.GetComponent<PointerEventsController2>().setFilled(true);
        }
        else
        {
            TextMeshProUGUI textMesh = ChestButtonLabel.GetComponent<TextMeshProUGUI>();
            textMesh.text = "Unequipped";
            Image imgy = ChestButton.GetComponent<Image>();
            imgy.sprite = Resources.Load<Sprite>("placeholder");
            ChestButton.GetComponent<PointerEventsController2>().setFilled(false);

        }
        if (curChar.EquippedFootwear != null)
        {
            Image imgy = FootwearButton.GetComponent<Image>();
            imgy.sprite = Resources.Load<Sprite>(curChar.EquippedFootwear.iconName);
            TextMeshProUGUI textMesh = FootwearButtonLabel.GetComponent<TextMeshProUGUI>();
            textMesh.text = curChar.EquippedFootwear.equipmentName;
            FootwearButton.GetComponent<PointerEventsController2>().setFilled(false);
        }
        else
        {
            TextMeshProUGUI textMesh = FootwearButtonLabel.GetComponent<TextMeshProUGUI>();
            textMesh.text = "Unequipped";
            Image imgy = FootwearButton.GetComponent<Image>();
            imgy.sprite = Resources.Load<Sprite>("placeholder");
            FootwearButton.GetComponent<PointerEventsController2>().setFilled(false);

        }
        for (int i = 0; i < curChar.EquippedActionTomes.Length; i++)
        {
            if (curChar.EquippedActionTomes[i] != null)
            {
                Image imgy = TomesButtons[i].GetComponent<Image>();
                imgy.sprite = Resources.Load<Sprite>(curChar.EquippedActionTomes[i].skillInfo.iconName);
                TextMeshProUGUI textMesh = TomesButtonsLabels[i].GetComponent<TextMeshProUGUI>();
                textMesh.text = curChar.EquippedActionTomes[i].tomeName;
                TomesButtons[i].GetComponent<PointerEventsController2>().setFilled(true);
            }
            else
            {
                TextMeshProUGUI textMesh = TomesButtonsLabels[i].GetComponent<TextMeshProUGUI>();
                textMesh.text = "Unequipped";
                Image imgy = TomesButtons[i].GetComponent<Image>();
                imgy.sprite = Resources.Load<Sprite>("placeholder");
                TomesButtons[i].GetComponent<PointerEventsController2>().setFilled(false);

            }
        }
        for (int i = 0; i < curChar.EquippedMiscItems.Length; i++)
        {
            if (curChar.EquippedMiscItems[i] != null)
            {
                Image imgy = ItemsButtons[i].GetComponent<Image>();
                imgy.sprite = Resources.Load<Sprite>(curChar.EquippedMiscItems[i].iconName);
                TextMeshProUGUI textMesh = ItemsButtonsLabels[i].GetComponent<TextMeshProUGUI>();
                textMesh.text = curChar.EquippedMiscItems[i].itemName;
                ItemsButtons[i].GetComponent<PointerEventsController2>().setFilled(true);
            }
            else
            {
                TextMeshProUGUI textMesh = ItemsButtonsLabels[i].GetComponent<TextMeshProUGUI>();
                textMesh.text = "Unequipped";
                Image imgy = ItemsButtons[i].GetComponent<Image>();
                imgy.sprite = Resources.Load<Sprite>("placeholder");
                ItemsButtons[i].GetComponent<PointerEventsController2>().setFilled(false);

            }
        }
        for (int i = 0; i < curChar.EquippedSkills.Length; i++)
        {
            if (curChar.EquippedSkills[i] != null)
            {
                Image imgy = SkillsButtons[i].GetComponent<Image>();
                imgy.sprite = Resources.Load<Sprite>(curChar.EquippedSkills[i].iconName);
                TextMeshProUGUI textMesh = SkillsButtonsLabels[i].GetComponent<TextMeshProUGUI>();
                textMesh.text = curChar.EquippedSkills[i].spellName;
                SkillsButtons[i].GetComponent<PointerEventsController2>().setFilled(true);
            }
            else
            {
                TextMeshProUGUI textMesh = SkillsButtonsLabels[i].GetComponent<TextMeshProUGUI>();
                textMesh.text = "Unequipped";
                Image imgy = SkillsButtons[i].GetComponent<Image>();
                imgy.sprite = Resources.Load<Sprite>("placeholder");
                SkillsButtons[i].GetComponent<PointerEventsController2>().setFilled(false);

            }
        }



        //update stats
        UpdateStats(curChar);

    }
    
    private void UpdateStats(CharacterStats curChar)
    {
        TextMeshProUGUI textMesh = HPLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = curChar.MaxHp.ToString();
        textMesh = MPLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = curChar.MaxMp.ToString();
        textMesh = STRLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = curChar.Str.ToString();
        textMesh = MNDLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = curChar.Mnd.ToString();
        textMesh = JumpLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = curChar.Jump.ToString();
        textMesh = DEFLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = curChar.Def.ToString();
        textMesh = ACCLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = curChar.Acc.ToString();
        textMesh = EVALabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = curChar.Eva.ToString();
        textMesh = INTLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = curChar.Int.ToString();
        textMesh = HPLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = curChar.Hp.ToString();
        textMesh = MPLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = curChar.Mp.ToString();
        textMesh = MoveLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = curChar.MoveDistance.ToString();
        textMesh = RESLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = curChar.Res.ToString();
        textMesh = ATKLabel.GetComponent<TextMeshProUGUI>();
        int atkval = ((curChar.Str * 2) / 5);
        if (displayedChar.EquippedMH != null)
        {
            atkval += displayedChar.EquippedMH.dmg;
        } 
            textMesh.text = atkval.ToString();
        
        saveInventory();
        saveChars();

    }
    //all clicks for equipment buttons call this function with relevant args
    public void popItemsWindow(int ind)
    {
        openAndPopulatePotentialEquipmentWindow("item", ind);
    }
    public void popTomesWindow(int ind)
    {
        openAndPopulatePotentialEquipmentWindow("action", ind);
    }
    public void popSkillsWindow(int ind)
    {
        openAndPopulatePotentialEquipmentWindow("skill", ind);
    }
    public void popNormalWindow(string categ)
    {
        openAndPopulatePotentialEquipmentWindow(categ, 0);
    }
    public void openAndPopulatePotentialEquipmentWindow(string categ, int ind)
    {
        
        int iterNum = 0;
        Debug.Log("Categ: " + categ);
        PEW.SetActive(true);
        List<Weapons> mhWeapons = new List<Weapons>();
        List<Weapons> ohWeapons = new List<Weapons>();
        List<Equipment>helmets = new List<Equipment>();
        List<Equipment>chests = new List<Equipment>();
        List<Equipment>footwears = new List<Equipment>();
        List<MiscItems> miscItems = new List<MiscItems>();
        miscItems = GameManager.instance.inventoryMiscItemsList;
        List<ActionTome> actionTomes = new List<ActionTome>();
        actionTomes = GameManager.instance.inventoryActionTomesList;
        List<SkillInfo> charsSkills = displayedChar.AllSkills;
        for (int i = 0; i < GameManager.instance.inventoryWeaponList.Count; i++)
        {
            //TOOD: if mh or if oh
            mhWeapons.Add(GameManager.instance.inventoryWeaponList[i]);
            ohWeapons.Add(GameManager.instance.inventoryWeaponList[i]);
        }
        for (int i = 0; i < GameManager.instance.inventoryEquipmentList.Count; i++)
        {
            string armortype = GameManager.instance.inventoryEquipmentList[i].location;
            if (armortype == "Head")
            {
                Debug.Log(i);
                helmets.Add(GameManager.instance.inventoryEquipmentList[i]);
            }
            else if (armortype == "Chest")
            {
                chests.Add(GameManager.instance.inventoryEquipmentList[i]);
            }
            else if (armortype == "Feet")
            {
                footwears.Add(GameManager.instance.inventoryEquipmentList[i]);
            }
        }
        string titley = "";
        switch (categ)
        {
            case "helmet":
                iterNum = helmets.Count;
                titley = "Headwear";
                break;
            case "chest":
                iterNum = chests.Count;
                titley = "Chestwear";
                break;
            case "footwear":
                iterNum = footwears.Count;
                titley = "Footwear";
                break;
            case "mh":
                iterNum = mhWeapons.Count;
                titley = "Weapons";
                break;
            case "oh":
                iterNum = ohWeapons.Count;
                titley = "Weapons";
                break;
            case "item":
                iterNum = miscItems.Count;
                titley = "Items";
                break;
            case "action":
                iterNum = actionTomes.Count;
                titley = "Tomes";
                Debug.Log(actionTomes);
                break;
            case "skill":
                iterNum = charsSkills.Count;
                titley = "Skills";
                break;
            default:
                break;
        }
        GameObject newtitle = new GameObject();
        newtitle.transform.SetParent(PEW.transform);
        TextMeshProUGUI titletext = newtitle.AddComponent<TextMeshProUGUI>();
        titletext.text = titley;
        titletext.color = Color.black;
        titletext.transform.localPosition = new Vector3(0.0f, 358, 0.0f);
        titletext.alignment = TextAlignmentOptions.Center;
        for (int i = 0; i < actionTomes.Count; i++)
        {
            Debug.Log(actionTomes[i]);
        }
            for (int i = 0; i < iterNum; i++)
        {
            
            GameObject newbtnCont = new GameObject();
            newbtnCont.transform.SetParent(PEW.transform);
            newbtnCont.transform.localPosition = new Vector3(0.0f, 310 - (56.0f * i), 0.0f);
            Button btn = newbtnCont.AddComponent<Button>();
            PointerEventsController PEC = btn.AddComponent<PointerEventsController>();
            string iconName = "";
            string nameNode = "";
            string rangeStr = "";
            if (categ == "mh")
            {
                Weapons weapon = mhWeapons[i];
                nameNode = weapon.weaponName;
                iconName = weapon.iconName;
               
                if (weapon.maxRange == weapon.minRange)
                {
                    rangeStr = weapon.maxRange.ToString();
                }
                else
                {
                    rangeStr = weapon.minRange.ToString() + "-" + weapon.maxRange.ToString();
                }
                btn.onClick.AddListener(delegate { equipMH(weapon); });
                PEC.setInfoPanel(InfoPanelWeapon, itemTitle, itemATK, itemACC, itemEVA, itemDEF, itemMND, weapon.weaponName, weapon.dmg, weapon.acc, weapon.eva, weapon.def, weapon.mnd, weapon.iconName, itemSprite, "", itemDESC, weapon.str, itemSTR, weapon.aoe, itemAOE, "weapon", null, null, true, "mh", itemINT, weapon.inte, itemHP, weapon.hp, itemMP, weapon.mp, itemRES, weapon.res, itemMOVE, weapon.move, itemJUMP, weapon.jmp, itemRANGE, rangeStr);

            }
            else if (categ == "oh")
            {
                Weapons weapon = ohWeapons[i];
                nameNode = weapon.weaponName;
                iconName = weapon.iconName;
                if (weapon.maxRange == weapon.minRange)
                {
                    rangeStr = weapon.maxRange.ToString();
                }
                else
                {
                    rangeStr = weapon.minRange.ToString() + "-" + weapon.maxRange.ToString();
                }
                btn.onClick.AddListener(delegate { equipOH(weapon); });
                PEC.setInfoPanel(InfoPanelWeapon, itemTitle, itemATK, itemACC, itemEVA, itemDEF, itemMND, weapon.weaponName, weapon.dmg, weapon.acc, weapon.eva, weapon.def, weapon.mnd, weapon.iconName, itemSprite, "", itemDESC, weapon.str, itemSTR, weapon.aoe, itemAOE, "weapon", null, null, true, "oh", itemINT, weapon.inte, itemHP, weapon.hp, itemMP, weapon.mp, itemRES, weapon.res, itemMOVE, weapon.move, itemJUMP, weapon.jmp, itemRANGE, rangeStr);
            }
            else if (categ == "helmet")
            {
                Equipment helmet = helmets[i];
                nameNode = helmet.equipmentName;
                iconName = helmet.iconName;
                btn.onClick.AddListener(delegate { equipHelmet(helmet); });
                PEC.setInfoPanel(InfoPanelEquipment, itemTitleE, null, itemACCE, itemEVAE, itemDEFE, itemMNDE, helmet.equipmentName, 0, helmet.acc, helmet.eva, helmet.def, helmet.mnd, helmet.iconName, itemSpriteE, "", itemDESCE, 0, itemSTRE, 0, null, "equipment", null, null, true, "helmet", itemINTE, helmet.inte, itemHPE, helmet.hp, itemMPE, helmet.mp, itemRESE, helmet.res, itemMOVEE, helmet.move, itemJUMPE, helmet.jmp, null, "");

            }
            else if (categ == "chest")
            {
                Equipment chest = chests[i];
                nameNode = chest.equipmentName;
                iconName = chest.iconName;
                btn.onClick.AddListener(delegate { equipChest(chest); });
                PEC.setInfoPanel(InfoPanelEquipment, itemTitleE, null, itemACCE, itemEVAE, itemDEFE, itemMNDE, chest.equipmentName, 0, chest.acc, chest.eva, chest.def, chest.mnd, chest.iconName, itemSpriteE, "", itemDESCE, 0, itemSTRE, 0, null, "equipment", null, null, true, "chest", itemINTE, chest.inte, itemHPE, chest.hp, itemMPE, chest.mp, itemRESE, chest.res, itemMOVEE, chest.move, itemJUMPE, chest.jmp, null, "");

            }
            else if (categ == "footwear")
            {
                Equipment footwear = footwears[i];
                nameNode = footwear.equipmentName;
                iconName = footwear.iconName;
                btn.onClick.AddListener(delegate { equipFootwear(footwear); });
                PEC.setInfoPanel(InfoPanelEquipment, itemTitleE, null, itemACCE, itemEVAE, itemDEFE, itemMNDE, footwear.equipmentName, 0, footwear.acc, footwear.eva, footwear.def, footwear.mnd, footwear.iconName, itemSpriteE, "", itemDESCE, 0, itemSTRE, 0, null, "equipment", null, null, true, "footwear", itemINTE, footwear.inte, itemHPE, footwear.hp, itemMPE, footwear.mp, itemRESE, footwear.res, itemMOVEE, footwear.move, itemJUMPE, footwear.jmp, null, "");

            }
            else if (categ == "item")
            {
                MiscItems item = miscItems[i];
                nameNode = item.itemName;
                iconName = item.iconName;
                btn.onClick.AddListener(delegate { equipItem(item, ind); });
                PEC.setInfoPanel(InfoPanelItem, itemTitleI, null, null, null, null, null, item.itemName, item.dmg, 0, 0, 0, 0, item.iconName, itemSpriteI, item.description, itemDESCI, 0, null, 0, null, "item", null, null, true, "item", null, 0, null, 0, null, 0, null, 0, null, 0, null, 0, null, "");
            }
            else if (categ == "action")
            {
                ActionTome tome = actionTomes[i];
                nameNode = tome.tomeName;
                iconName = tome.skillInfo.iconName;
                if (tome.skillInfo.maxRange == tome.skillInfo.minRange)
                {
                    rangeStr = tome.skillInfo.maxRange.ToString();
                }
                else
                {
                    rangeStr = tome.skillInfo.minRange.ToString() + "-" + tome.skillInfo.maxRange.ToString();
                }
                btn.onClick.AddListener(delegate { equipTome(tome, ind); });
                PEC.setInfoPanel(InfoPanelTome, itemTitleT, itemATKT, null, null, null, null, tome.skillInfo.actionName, tome.skillInfo.dmg, 0, 0, 12, 0, tome.skillInfo.iconName, itemSpriteT, "", itemDESCT, 0, null, tome.skillInfo.aoe, itemAOET, "tome", itemTomeTitle, tomeSprite, true, "action", null, 0,  null, 0, null, 0, null, 0, null, 0, null, 0,  itemRANGET, rangeStr);
            }
            else if (categ == "skill")
            {
                SkillInfo skill = charsSkills[i];
                nameNode = skill.spellName;
                iconName = skill.iconName;
                if (skill.maxRange == skill.minRange)
                {
                    rangeStr = skill.maxRange.ToString();
                }
                else
                {
                    rangeStr = skill.minRange.ToString() + "-" + skill.maxRange.ToString();
                }
                btn.onClick.AddListener(delegate { equipSkill(skill, ind); });
                PEC.setInfoPanel(InfoPanelSkill, itemTitleS, itemATKS, null, null, null, null, skill.spellName, skill.dmg, 0, 0, 12, 0, skill.iconName, itemSpriteS, "", itemDESCS, 0, null, skill.aoe, itemAOES, "skill", null, null, true, "skill", null, 0, null, 0, null, 0, null, 0, null, 0, null, 0, itemRANGES, rangeStr);
            }
            btn.transform.localPosition = new Vector3(0.0f, 310 - (56.0f * i), 0.0f);
            btn.transform.localScale = new Vector3(1.0f, 0.3f, 1);
            btn.targetGraphic = Resources.Load<Image>("transparentbg");
            Image img = newbtnCont.AddComponent<Image>();
            img.color = new Color(21f / 255f, 103f / 255f, 98f / 255f, 0.8f);
            img.rectTransform.sizeDelta = new Vector2(948f, 120f);
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
            //add icon to button
            GameObject newimg = new GameObject();
            newimg.transform.SetParent(newbtnCont.transform);
            newimg.transform.localPosition = new Vector3(-420.0f, 0, 0.0f);
            Sprite imgToAdd = Resources.Load<Sprite>(iconName);
            Image imgAdded = newimg.AddComponent<Image>();
            imgAdded.sprite = imgToAdd;
            imgAdded.rectTransform.sizeDelta = new Vector2(28, 28);
        }
    }
    public void equipMH(Weapons newMh)
    {
        Weapons oldMh = displayedChar.EquippedMH;
        displayedChar.EquippedMH = newMh;
        GameManager.instance.inventoryWeaponList.Remove(newMh);
        if (oldMh != null)
        {
            displayedChar.Str -= oldMh.str;
            displayedChar.Hp -= oldMh.hp;
            displayedChar.Mp -= oldMh.mp;
            displayedChar.Int -= oldMh.inte;
            displayedChar.Eva -= oldMh.eva;
            displayedChar.Jump -= oldMh.jmp;
            displayedChar.Def -= oldMh.def;
            displayedChar.Mnd -= oldMh.mnd;
            displayedChar.Res -= oldMh.res;
            displayedChar.Acc -= oldMh.acc;
            displayedChar.MoveDistance -= oldMh.move;
            GameManager.instance.inventoryWeaponList.Add(oldMh);
        }
        displayedChar.Str += newMh.str;
        displayedChar.Hp += newMh.hp;
        displayedChar.Mp += newMh.mp;
        displayedChar.Int += newMh.inte;
        displayedChar.Eva += newMh.eva;
        displayedChar.Jump += newMh.jmp;
        displayedChar.Def += newMh.def;
        displayedChar.Mnd += newMh.mnd;
        displayedChar.Res += newMh.res;
        displayedChar.Acc += newMh.acc;
        displayedChar.MoveDistance += newMh.move;

        //update stats
        UpdateStats(displayedChar);
        closePEW();
        TextMeshProUGUI textMesh = MHButtonLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = newMh.weaponName;
        Button btn = MHButton.GetComponent<Button>();
        Image imgy = MHButton.GetComponent<Image>();
        imgy.sprite = Resources.Load<Sprite>(newMh.iconName);
        MHButton.GetComponent<PointerEventsController2>().setFilled(true);


    }
    public void Unequip(string categ, int ind)
    {
        if (categ == "mh") { 
        Weapons oldMh = displayedChar.EquippedMH;
        if (oldMh != null)
        {
            displayedChar.EquippedMH = null;
            GameManager.instance.inventoryWeaponList.Add(oldMh);
            displayedChar.Str -= oldMh.str;
            displayedChar.Hp -= oldMh.hp;
            displayedChar.Mp -= oldMh.mp;
            displayedChar.Int -= oldMh.inte;
            displayedChar.Eva -= oldMh.eva;
            displayedChar.Jump -= oldMh.jmp;
            displayedChar.Def -= oldMh.def;
            displayedChar.Mnd -= oldMh.mnd;
            displayedChar.Res -= oldMh.res;
            displayedChar.Acc -= oldMh.acc;
            displayedChar.MoveDistance -= oldMh.move;
                UpdateStats(displayedChar);
                TextMeshProUGUI textMesh = MHButtonLabel.GetComponent<TextMeshProUGUI>();
                textMesh.text = "Unequipped";
                Image imgy = MHButton.GetComponent<Image>();
                imgy.sprite = Resources.Load<Sprite>("placeholder");
                MHButton.GetComponent<PointerEventsController2>().setFilled(false);
            }
        } else if (categ == "oh")
        {
            Weapons oldOh = displayedChar.EquippedMH;
            if (oldOh != null)
            {
                displayedChar.EquippedOH = null;
                GameManager.instance.inventoryWeaponList.Add(oldOh);
                displayedChar.Str -= oldOh.str;
                displayedChar.Hp -= oldOh.hp;
                displayedChar.Mp -= oldOh.mp;
                displayedChar.Int -= oldOh.inte;
                displayedChar.Eva -= oldOh.eva;
                displayedChar.Jump -= oldOh.jmp;
                displayedChar.Def -= oldOh.def;
                displayedChar.Mnd -= oldOh.mnd;
                displayedChar.Res -= oldOh.res;
                displayedChar.Acc -= oldOh.acc;
                displayedChar.MoveDistance -= oldOh.move;
                UpdateStats(displayedChar);
                TextMeshProUGUI textMesh = OHButtonLabel.GetComponent<TextMeshProUGUI>();
                textMesh.text = "Unequipped";
                Image imgy = OHButton.GetComponent<Image>();
                imgy.sprite = Resources.Load<Sprite>("placeholder");
                OHButton.GetComponent<PointerEventsController2>().setFilled(false);
            }
        }
        else if (categ == "footwear")
        {
            Equipment equipment = displayedChar.EquippedFootwear;
            if (equipment != null)
            {
                displayedChar.EquippedFootwear = null;
                GameManager.instance.inventoryEquipmentList.Add(equipment);
                displayedChar.Str -= equipment.str;
                displayedChar.Hp -= equipment.hp;
                displayedChar.Mp -= equipment.mp;
                displayedChar.Int -= equipment.inte;
                displayedChar.Eva -= equipment.eva;
                displayedChar.Jump -= equipment.jmp;
                displayedChar.Def -= equipment.def;
                displayedChar.Mnd -= equipment.mnd;
                displayedChar.Res -= equipment.res;
                displayedChar.Acc -= equipment.acc;
                displayedChar.MoveDistance -= equipment.move;
                UpdateStats(displayedChar);
                TextMeshProUGUI textMesh = FootwearButtonLabel.GetComponent<TextMeshProUGUI>();
                textMesh.text = "Unequipped";
                Image imgy = FootwearButton.GetComponent<Image>();
                imgy.sprite = Resources.Load<Sprite>("placeholder");
                FootwearButton.GetComponent<PointerEventsController2>().setFilled(false);
            }
        }
        else if (categ == "helmet")
        {
            Equipment equipment = displayedChar.EquippedFootwear;
            if (equipment != null)
            {
                displayedChar.EquippedFootwear = null;
                GameManager.instance.inventoryEquipmentList.Add(equipment);
                displayedChar.Str -= equipment.str;
                displayedChar.Hp -= equipment.hp;
                displayedChar.Mp -= equipment.mp;
                displayedChar.Int -= equipment.inte;
                displayedChar.Eva -= equipment.eva;
                displayedChar.Jump -= equipment.jmp;
                displayedChar.Def -= equipment.def;
                displayedChar.Mnd -= equipment.mnd;
                displayedChar.Res -= equipment.res;
                displayedChar.Acc -= equipment.acc;
                displayedChar.MoveDistance -= equipment.move;
                UpdateStats(displayedChar);
                TextMeshProUGUI textMesh = HelmetButtonLabel.GetComponent<TextMeshProUGUI>();
                textMesh.text = "Unequipped";
                Image imgy = HelmetButton.GetComponent<Image>();
                imgy.sprite = Resources.Load<Sprite>("placeholder");
                HelmetButton.GetComponent<PointerEventsController2>().setFilled(false);
            }
        }
        else if (categ == "chest")
        {
            Equipment equipment = displayedChar.EquippedChest;
            if (equipment != null)
            {
                displayedChar.EquippedChest = null;
                GameManager.instance.inventoryEquipmentList.Add(equipment);
                displayedChar.Str -= equipment.str;
                displayedChar.Hp -= equipment.hp;
                displayedChar.Mp -= equipment.mp;
                displayedChar.Int -= equipment.inte;
                displayedChar.Eva -= equipment.eva;
                displayedChar.Jump -= equipment.jmp;
                displayedChar.Def -= equipment.def;
                displayedChar.Mnd -= equipment.mnd;
                displayedChar.Res -= equipment.res;
                displayedChar.Acc -= equipment.acc;
                displayedChar.MoveDistance -= equipment.move;
                UpdateStats(displayedChar);
                TextMeshProUGUI textMesh = ChestButtonLabel.GetComponent<TextMeshProUGUI>();
                textMesh.text = "Unequipped";
                Image imgy = ChestButton.GetComponent<Image>();
                imgy.sprite = Resources.Load<Sprite>("placeholder");
                ChestButton.GetComponent<PointerEventsController2>().setFilled(false);
            }
        } else if (categ == "skill")
        {
            SkillInfo oldSkill = displayedChar.EquippedSkills[ind];
            displayedChar.EquippedSkills[ind] = null;
            if (oldSkill != null)
            {
                displayedChar.SkillsList.Remove(oldSkill);
            }
            displayedChar.AllSkills.Add(oldSkill);
            UpdateStats(displayedChar);
            TextMeshProUGUI textMesh = SkillsButtonsLabels[ind].GetComponent<TextMeshProUGUI>();
            textMesh.text = "Unequipped";
            Image imgy = SkillsButtons[ind].GetComponent<Image>();
            imgy.sprite = Resources.Load<Sprite>("placeholder");
            SkillsButtons[ind].GetComponent<PointerEventsController2>().setFilled(false);
        }
        else if (categ == "item")
        {
            MiscItems oldItem = displayedChar.EquippedMiscItems[ind];
            displayedChar.EquippedMiscItems[ind] = null;
            if (oldItem != null)
            {
                displayedChar.ItemsList.Remove(oldItem);
            }
            GameManager.instance.inventoryMiscItemsList.Add(oldItem);
            UpdateStats(displayedChar);
            TextMeshProUGUI textMesh = ItemsButtonsLabels[ind].GetComponent<TextMeshProUGUI>();
            textMesh.text = "Unequipped";
            Image imgy = ItemsButtons[ind].GetComponent<Image>();
            imgy.sprite = Resources.Load<Sprite>("placeholder");
            ItemsButtons[ind].GetComponent<PointerEventsController2>().setFilled(false);
        }
        else if (categ == "tome")
        {
            ActionTome oldTome = displayedChar.EquippedActionTomes[ind];
            displayedChar.EquippedActionTomes[ind] = null;
            if (oldTome != null)
            {
                displayedChar.ActionsList.Remove(oldTome.skillInfo);
            }
            GameManager.instance.inventoryActionTomesList.Add(oldTome);
            UpdateStats(displayedChar);
            TextMeshProUGUI textMesh = TomesButtonsLabels[ind].GetComponent<TextMeshProUGUI>();
            textMesh.text = "Unequipped";
            Image imgy = TomesButtons[ind].GetComponent<Image>();
            imgy.sprite = Resources.Load<Sprite>("placeholder");
            TomesButtons[ind].GetComponent<PointerEventsController2>().setFilled(false);
        }
    }
    public void equipOH(Weapons newOh)
    {
        Weapons oldOh = displayedChar.EquippedOH;
        displayedChar.EquippedOH = newOh;
        GameManager.instance.inventoryWeaponList.Remove(newOh);
        if (oldOh != null)
        {
            displayedChar.Str -= oldOh.str;
            displayedChar.Hp -= oldOh.hp;
            displayedChar.Mp -= oldOh.mp;
            displayedChar.Int -= oldOh.inte;
            displayedChar.Eva -= oldOh.eva;
            displayedChar.Jump -= oldOh.jmp;
            displayedChar.Def -= oldOh.def;
            displayedChar.Mnd -= oldOh.mnd;
            displayedChar.Res -= oldOh.res;
            displayedChar.Acc -= oldOh.acc;
            displayedChar.MoveDistance -= oldOh.move;
            GameManager.instance.inventoryWeaponList.Add(oldOh);
        }
        displayedChar.Str += newOh.str;
        displayedChar.Hp += newOh.hp;
        displayedChar.Mp += newOh.mp;
        displayedChar.Int += newOh.inte;
        displayedChar.Eva += newOh.eva;
        displayedChar.Jump += newOh.jmp;
        displayedChar.Def += newOh.def;
        displayedChar.Mnd += newOh.mnd;
        displayedChar.Res += newOh.res;
        displayedChar.Acc += newOh.acc;
        displayedChar.MoveDistance += newOh.move;
        //update stats
        UpdateStats(displayedChar);
        closePEW();
        TextMeshProUGUI textMesh = OHButtonLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = newOh.weaponName;
        Image imgy = OHButton.GetComponent<Image>();
        imgy.sprite = Resources.Load<Sprite>(newOh.iconName);
        OHButton.GetComponent<PointerEventsController2>().setFilled(true);

    }
    public void equipFootwear(Equipment newFootwear)
    {
        Equipment oldFootwear = displayedChar.EquippedFootwear;
        displayedChar.EquippedFootwear = newFootwear;
        GameManager.instance.inventoryEquipmentList.Remove(newFootwear);
        
        if (oldFootwear != null)
        {
            displayedChar.Str -= oldFootwear.str;
            displayedChar.Hp -= oldFootwear.hp;
            displayedChar.Mp -= oldFootwear.mp;
            displayedChar.Int -= oldFootwear.inte;
            displayedChar.Eva -= oldFootwear.eva;
            displayedChar.Jump -= oldFootwear.jmp;
            displayedChar.Def -= oldFootwear.def;
            displayedChar.Mnd -= oldFootwear.mnd;
            displayedChar.Res -= oldFootwear.res;
            displayedChar.Acc -= oldFootwear.acc;
            displayedChar.MoveDistance -= newFootwear.move;
            GameManager.instance.inventoryEquipmentList.Add(oldFootwear);
        }
        displayedChar.Str += newFootwear.str;
        displayedChar.Hp += newFootwear.hp;
        displayedChar.Mp += newFootwear.mp;
        displayedChar.Int += newFootwear.inte;
        displayedChar.Eva += newFootwear.eva;
        displayedChar.Jump += newFootwear.jmp;
        displayedChar.Def += newFootwear.def;
        displayedChar.Mnd += newFootwear.mnd;
        displayedChar.Res += newFootwear.res;
        displayedChar.Acc += newFootwear.acc;
        displayedChar.MoveDistance += newFootwear.move;
        //update stats
        UpdateStats(displayedChar);
        closePEW();
        TextMeshProUGUI textMesh = FootwearButtonLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = newFootwear.equipmentName;
        Image imgy = FootwearButton.GetComponent<Image>();
        imgy.sprite = Resources.Load<Sprite>(newFootwear.iconName);
        FootwearButton.GetComponent<PointerEventsController2>().setFilled(true);

    }
    public void equipItem(MiscItems newItem, int ind)
    {
      
        MiscItems oldItem = displayedChar.EquippedMiscItems[ind];
        displayedChar.EquippedMiscItems[ind] = newItem;
        GameManager.instance.inventoryMiscItemsList.Remove(newItem);
        
        if (oldItem != null)
        {
            displayedChar.ItemsList.Remove(oldItem);
            GameManager.instance.inventoryMiscItemsList.Add(oldItem);
        }
        displayedChar.ItemsList.Add(newItem);
        //update stats
        UpdateStats(displayedChar);
        closePEW();
        TextMeshProUGUI textMesh = ItemsButtonsLabels[ind].GetComponent<TextMeshProUGUI>();
        textMesh.text = newItem.itemName;
        Image imgy = ItemsButtons[ind].GetComponent<Image>();
        imgy.sprite = Resources.Load<Sprite>(newItem.iconName);
        ItemsButtons[ind].GetComponent<PointerEventsController2>().setFilled(true);
    }
    public void equipSkill(SkillInfo newSkill, int ind)
    {

        SkillInfo oldSkill = displayedChar.EquippedSkills[ind];
        displayedChar.EquippedSkills[ind] = newSkill;
        displayedChar.AllSkills.Remove(newSkill);
        if (oldSkill != null)
        {
            displayedChar.SkillsList.Remove(oldSkill);
            displayedChar.AllSkills.Add(oldSkill);
        }
        displayedChar.SkillsList.Add(newSkill);
        //update stats
        UpdateStats(displayedChar);
        closePEW();
        TextMeshProUGUI textMesh = SkillsButtonsLabels[ind].GetComponent<TextMeshProUGUI>();
        textMesh.text = newSkill.spellName;
        Image imgy = SkillsButtons[ind].GetComponent<Image>();
        imgy.sprite = Resources.Load<Sprite>(newSkill.iconName);
        SkillsButtons[ind].GetComponent<PointerEventsController2>().setFilled(true);
    }
    public void equipTome(ActionTome newTome, int ind)
    {

        ActionTome oldTome = displayedChar.EquippedActionTomes[ind];
        displayedChar.EquippedActionTomes[ind] = newTome;
        GameManager.instance.inventoryActionTomesList.Remove(newTome);
        if (oldTome != null)
        {
            displayedChar.ActionsList.Remove(oldTome.skillInfo);
        }
        GameManager.instance.inventoryActionTomesList.Add(oldTome);
        displayedChar.ActionsList.Add(newTome.skillInfo);
        //update stats
        UpdateStats(displayedChar);
        closePEW();
        TextMeshProUGUI textMesh = TomesButtonsLabels[ind].GetComponent<TextMeshProUGUI>();
        textMesh.text = newTome.tomeName;
        Image imgy = TomesButtons[ind].GetComponent<Image>();
        imgy.sprite = Resources.Load<Sprite>(newTome.skillInfo.iconName);
        TomesButtons[ind].GetComponent<PointerEventsController2>().setFilled(true);
    }
    public void equipHelmet(Equipment newHelmet)
    {
        Equipment oldHelmet = displayedChar.EquippedHelmet;
        displayedChar.EquippedHelmet = newHelmet;
        GameManager.instance.inventoryEquipmentList.Remove(newHelmet);
        
        if (oldHelmet != null)
        {
            displayedChar.Str -= oldHelmet.str;
            displayedChar.Hp -= oldHelmet.hp;
            displayedChar.Mp -= oldHelmet.mp;
            displayedChar.Int -= oldHelmet.inte;
            displayedChar.Eva -= oldHelmet.eva;
            displayedChar.Jump -= oldHelmet.jmp;
            displayedChar.Def -= oldHelmet.def;
            displayedChar.Mnd -= oldHelmet.mnd;
            displayedChar.Res -= oldHelmet.res;
            displayedChar.Acc -= oldHelmet.acc;
            displayedChar.MoveDistance -= oldHelmet.move;
            GameManager.instance.inventoryEquipmentList.Add(oldHelmet);
        }
        displayedChar.Str += newHelmet.str;
        displayedChar.Hp += newHelmet.hp;
        displayedChar.Mp += newHelmet.mp;
        displayedChar.Int += newHelmet.inte;
        displayedChar.Eva += newHelmet.eva;
        displayedChar.Jump += newHelmet.jmp;
        displayedChar.Def += newHelmet.def;
        displayedChar.Mnd += newHelmet.mnd;
        displayedChar.Res += newHelmet.res;
        displayedChar.Acc += newHelmet.acc;
        displayedChar.MoveDistance += newHelmet.move;
        //update stats
        UpdateStats(displayedChar);
        closePEW();
        TextMeshProUGUI textMesh = HelmetButtonLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = newHelmet.equipmentName;
        Image imgy = HelmetButton.GetComponent<Image>();
        imgy.sprite = Resources.Load<Sprite>(newHelmet.iconName);
        HelmetButton.GetComponent<PointerEventsController2>().setFilled(true);

    }
    public void equipChest(Equipment newChest)
    {
        Equipment oldChest = displayedChar.EquippedChest;
        displayedChar.EquippedChest = newChest;
        GameManager.instance.inventoryEquipmentList.Remove(newChest);
        if (oldChest != null)
        {
            GameManager.instance.inventoryEquipmentList.Add(oldChest);
            displayedChar.Str -= oldChest.str;
            displayedChar.Hp -= oldChest.hp;
            displayedChar.Mp -= oldChest.mp;
            displayedChar.Int -= oldChest.inte;
            displayedChar.Eva -= oldChest.eva;
            displayedChar.Jump -= oldChest.jmp;
            displayedChar.Def -= oldChest.def;
            displayedChar.Mnd -= oldChest.mnd;
            displayedChar.Res -= oldChest.res;
            displayedChar.Acc -= oldChest.acc;
            displayedChar.MoveDistance -= oldChest.move;
        }

        displayedChar.Str += newChest.str;
        displayedChar.Hp += newChest.hp;
        displayedChar.Mp += newChest.mp;
        displayedChar.Int += newChest.inte;
        displayedChar.Eva += newChest.eva;
        displayedChar.Jump += newChest.jmp;
        displayedChar.Def += newChest.def;
        displayedChar.Mnd += newChest.mnd;
        displayedChar.Res += newChest.res;
        displayedChar.Acc += newChest.acc;
        displayedChar.MoveDistance += newChest.move;
        //update stats
        UpdateStats(displayedChar);
        closePEW();
        TextMeshProUGUI textMesh = ChestButtonLabel.GetComponent<TextMeshProUGUI>();
        textMesh.text = newChest.equipmentName;
        Image imgy = ChestButton.GetComponent<Image>();
        imgy.sprite = Resources.Load<Sprite>(newChest.iconName);
        ChestButton.GetComponent<PointerEventsController2>().setFilled(true);
    }
    public void closePEW()
    {
        foreach (Transform child in PEW.transform)
        {
            if (child.gameObject != ClosePEWButton)
            {
                Destroy(child.gameObject);
            }
            
        }
        InfoPanelEquipment.SetActive(false);
        InfoPanelWeapon.SetActive(false);
        InfoPanelItem.SetActive(false);
        InfoPanelTome.SetActive(false);
        InfoPanelSkill.SetActive(false);
        PEW.SetActive(false);
        saveChars();
        saveInventory();
        ClearComparison();
    }
    private void saveChars()
    {
        if (displayedChar != null)
        {
            for (int i = 0; i < GameManager.instance.characters.Count; i++)
            {
                if (GameManager.instance.characters[i].CharacterName == displayedChar.CharacterName)
                {
                    GameManager.instance.characters[i] = displayedChar; break;
                }
            }
        }
        DataSaver.saveDataNewton<List<CharacterStats>>(GameManager.instance.characters, "characters");
    }
    private void saveInventory()
    {
        DataSaver.saveDataNewton<List<Weapons>>(GameManager.instance.inventoryWeaponList, "weapons");
        DataSaver.saveDataNewton<List<Equipment>>(GameManager.instance.inventoryEquipmentList, "equipment");
        DataSaver.saveDataNewton<List<MiscItems>>(GameManager.instance.inventoryMiscItemsList, "items");
        DataSaver.saveDataNewton<List<ActionTome>>(GameManager.instance.inventoryActionTomesList, "tomes");
    }
    public void closeEquipScreen()
    {
        saveInventory();
        saveChars();
        EquipScreen.SetActive(false);
    }
}
