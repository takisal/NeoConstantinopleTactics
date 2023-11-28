using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class PointerEventsController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject InfoPanel;
    public TextMeshProUGUI ItemTitle;
    public TextMeshProUGUI ItemATK;
    public TextMeshProUGUI ItemACC;
    public TextMeshProUGUI ItemEVA;
    public TextMeshProUGUI ItemDEF;
    public TextMeshProUGUI ItemMND;
    public TextMeshProUGUI ItemDESC;
    public TextMeshProUGUI ItemSTR;
    public TextMeshProUGUI ItemAOE;
    public TextMeshProUGUI ItemINT;
    public TextMeshProUGUI ItemHP;
    public TextMeshProUGUI ItemMP;
    public TextMeshProUGUI ItemRES;
    public TextMeshProUGUI ItemMOVE;
    public TextMeshProUGUI ItemJUMP;
    public TextMeshProUGUI ItemRANGE;
    public TextMeshProUGUI ItemTomeTitle;
    public int itematk;
    public int itemacc;
    public int itemeva;
    public int itemdef;
    public int itemmnd;
    public int itemstr;
    public int itemaoe;
    public int itemint;
    public int itemmp;
    public int itemhp;
    public int itemres;
    public int itemmove;
    public int itemjump;
    public string itemrange;
    public string itemdesc;
    public string itemtitle;
    public string itemsprite;
    public Image ItemSprite;
    public Image TomeSprite;
    public string categ;
    public string categ2;
    public bool isEquipWindow;
    public EquipRoomManager father;
    public void setInfoPanel(GameObject infoPanel, TextMeshProUGUI itemTitle, TextMeshProUGUI itemATK, TextMeshProUGUI itemACC, TextMeshProUGUI itemEVA, TextMeshProUGUI itemDEF, TextMeshProUGUI itemMND, string title, int atk, int acc, int eva, int def, int mnd, string spritedest, Image spriteDest, string desc, TextMeshProUGUI itemDESC, int str, TextMeshProUGUI itemSTR, int aoe, TextMeshProUGUI itemAOE, string catego, TextMeshProUGUI tomet, Image tomesprite, bool inEqu, string catego2, TextMeshProUGUI itemINT, int inte, TextMeshProUGUI itemHP, int hp, TextMeshProUGUI itemMP, int mp, TextMeshProUGUI itemRES, int res, TextMeshProUGUI itemMOVE, int move, TextMeshProUGUI itemJUMP, int jump, TextMeshProUGUI itemRANGE, string range)
    {
        InfoPanel = infoPanel;
        
        ItemTitle = itemTitle;
        ItemATK = itemATK;
        ItemACC = itemACC;
        ItemEVA = itemEVA;
        ItemDEF = itemDEF;
        ItemMND = itemMND;
        ItemDESC = itemDESC;
        ItemSTR = itemSTR;
        ItemAOE = itemAOE;
        ItemINT = itemINT;
        ItemHP = itemHP;
        ItemMP = itemMP;
        ItemMOVE = itemMOVE;
        ItemJUMP = itemJUMP;
        ItemRES = itemRES;
        ItemRANGE = itemRANGE;
        ItemSprite = spriteDest;
        itemtitle = title;
        itemsprite = spritedest;
        itematk = atk;
        itemacc = acc;
        itemdef = def;
        itemeva = eva;
        itemmnd = mnd;
        itemstr = str;
        itemdesc = desc;
        itemaoe = aoe;
        itemint = inte;
        itemhp = hp;
        itemmp = mp;
        itemres = res;
        itemmove = move;
        itemjump = jump;
        categ = catego;
        ItemTomeTitle = tomet;
        TomeSprite = tomesprite;
        isEquipWindow = inEqu;
        categ2 = catego2;
        itemrange = range;
        if (isEquipWindow)
        {
            father = GameObject.Find("EquipRoomManager").GetComponent<EquipRoomManager>();
        }


    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(categ);
        InfoPanel.SetActive(true);
        if (isEquipWindow)
        {
            Vector3 mimicPos = eventData.position;
            mimicPos.x += 200.0f;
            InfoPanel.transform.position = mimicPos;
        }
        if (categ == "weapon")
        {
            ItemATK.text = itematk.ToString();
            ItemACC.text = itemacc.ToString();
            ItemEVA.text = itemeva.ToString();
            ItemDEF.text = itemdef.ToString();
            ItemMND.text = itemmnd.ToString();
            ItemDESC.text = itemdesc.ToString();
            ItemSTR.text = itemstr.ToString();
            ItemAOE.text = itemaoe.ToString();
            ItemINT.text = itemint.ToString();
            ItemHP.text = itemhp.ToString();
            ItemMP.text = itemmp.ToString();
            ItemRES.text = itemres.ToString();
            ItemMOVE.text = itemmove.ToString();
            ItemJUMP.text = itemjump.ToString();
            ItemRANGE.text = itemrange;
            Sprite imgToAdd = Resources.Load<Sprite>(itemsprite);
            ItemSprite.sprite = imgToAdd;
            ItemTitle.text = itemtitle;
        } else if (categ == "equipment")
        {
            ItemACC.text = itemacc.ToString();
            ItemEVA.text = itemeva.ToString();
            ItemDEF.text = itemdef.ToString();
            ItemMND.text = itemmnd.ToString();
            ItemDESC.text = itemdesc.ToString();
            ItemSTR.text = itemstr.ToString();
            ItemINT.text = itemint.ToString();
            ItemHP.text = itemhp.ToString();
            ItemMP.text = itemmp.ToString();
            ItemRES.text = itemres.ToString();
            ItemMOVE.text = itemmove.ToString();
            ItemJUMP.text = itemjump.ToString();
            Sprite imgToAdd = Resources.Load<Sprite>(itemsprite);
            ItemSprite.sprite = imgToAdd;
            ItemTitle.text = itemtitle;
        } else if (categ == "item")
        {
            ItemDESC.text = itemdesc.ToString();
            Sprite imgToAdd = Resources.Load<Sprite>(itemsprite);
            ItemSprite.sprite = imgToAdd;
            ItemTitle.text = itemtitle;
        } else if (categ == "tome")
        {
            ItemTomeTitle.text = itemtitle + " Tome";
            ItemTitle.text = itemtitle;
            ItemATK.text = itematk.ToString();
            Sprite imgToAdd = Resources.Load<Sprite>("Tome");
            TomeSprite.sprite = imgToAdd;
            ItemDESC.text = itemdesc.ToString();
            ItemAOE.text = itemaoe.ToString();
            ItemRANGE.text = itemrange;
            Sprite imgToAdd2 = Resources.Load<Sprite>(itemsprite);
            ItemSprite.sprite = imgToAdd2;
        }
        else if (categ == "skill")
        {
            ItemTitle.text = itemtitle;
            ItemATK.text = itematk.ToString();
            ItemDESC.text = itemdesc.ToString();
            ItemAOE.text = itemaoe.ToString();
            ItemRANGE.text = itemrange;
            Sprite imgToAdd2 = Resources.Load<Sprite>(itemsprite);
            ItemSprite.sprite = imgToAdd2;
        }
        // Vector3 mimicPos = eventData.position;
        //mimicPos.x = eventData.position.x+180.0f;
        //InfoPanel.transform.position = mimicPos;
        if (isEquipWindow && (categ == "equipment" || categ == "weapon"))
        {
            father.CompareStats(itemstr, itemdef, itemacc, itemeva, itemmnd, itemjump, categ2, itemint, itemhp, itemmp, itematk, itemres, itemmove);
        }
        

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        InfoPanel.SetActive(false);
        if (isEquipWindow)
        {
            father.ClearComparison();
        }
        
    }
    public void Update()
    {
        if (isEquipWindow) { 
        if (InfoPanel.activeInHierarchy)
        {
            Vector3 mimicPos = Input.mousePosition;
            mimicPos.x += 200.0f;
            if (mimicPos.y >= 590)
            {
                mimicPos.y = 590.0f;
            }
            if (mimicPos.y <= 258)
            {
                mimicPos.y = 258.0f;
            }
            InfoPanel.transform.position = mimicPos;
        }
        }
    }
}
