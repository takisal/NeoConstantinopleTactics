using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading.Tasks;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField]
    Camera Cam;
    public static int TurnNumber;
    [SerializeField]
    public GameObject MenuObj;
    [SerializeField]
    public Button MoveButton;
    [SerializeField]
    public Button AttackButton;
    [SerializeField]
    public Button SpellsButton;
    [SerializeField]
    public Button ItemsButton;
    [SerializeField]
    public Button DefendButton;
    [SerializeField]
    public GameObject MenuCanvas;
    [SerializeField]
    public GameObject TargetMenu;
    [SerializeField]
    public GameObject HUDPlayerCanvas;
    [SerializeField]
    public GameObject ActiveCharacter;
    [SerializeField]
    public List<GameObject> CharactersInLevel;
    [SerializeField]
    public List<GameObject> ActiveCharactersInLevel;
    [SerializeField]
    public List<GameObject> PlayerCharactersInLevel;
    [SerializeField]
    public List<GameObject> EnemyCharactersInLevel;
    public GameObject TurnTaker;
    [SerializeField]
    public GameObject TargetedCharacter;
    [SerializeField]
    public GameObject AITargetedCharacter;
    [SerializeField]
    public int NumberOfPlayerChars;
    [SerializeField]
    public int NumberOfEnemyChars;
    [SerializeField]
    public GameObject StagePhysical;
    [SerializeField]
    public bool HUDPlayerStatus;
    public StageManager StageMan;
    
    [SerializeField]
    public string nextSceneName;
    [SerializeField]
    public GameObject ActionsDD;
    [SerializeField]
    public GameObject SkillsDD;
    [SerializeField]
    public GameObject ItemsDD;
    
    [SerializeField]
    public GameObject DebugValue;
    
    [SerializeField]
    public bool aiTurn;
    [SerializeField]
    public GameObject HUDPredictDmg;
    [SerializeField]
    public GameObject HUDPredictTxt;
    [SerializeField]
    public GameObject HUDPercentTxt;
    [SerializeField]
    public GameObject HUDPredictArrow;
    [SerializeField]
    public Button UndoMoveButton;
    private int PreviousMoveId;
    [SerializeField]
    public List<string> LevelsThatThisUnlocks;

    [SerializeField]
    private int _movePrepToggle;
    [SerializeField]
    private int _attackPrepToggle;
    private int _skillPrepToggle;
    private int _itemsPrepToggle;
    private int _tav;
    private int _tsv;
    private List<GameObject> _activeGlows;
    private int[,] _coords = new int[4, 2] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
    private int _queuedAttack;
    private MiscItems _temporaryItem;
    private void Awake()
    {
        if (instance == null)
        {
            TurnNumber = 0;
            instance = this;
        }
        StageMan = StagePhysical.GetComponent<StageManager>();

    }
    private void Start()
    {
        _activeGlows = new List<GameObject>();
        StageMan = StagePhysical.GetComponent<StageManager>();
        startAction();

    }
    private async void startAction()
    {
        var task = Task.Run(() => Delafunc());
        Task delay = Task.Delay(500);
        await delay;
        updateActionMenuPosition();
    }
   public void disableMove()
    {
        MoveButton.interactable = false;
    }
    public void disableAttack()
    {
        AttackButton.interactable = false;
    }
    public void disableSpells()
    {
        SpellsButton.interactable = false;
    }
    public void disableItems()
    {
        ItemsButton.interactable = false;
    }
    public void disableDefend()
    {
        DefendButton.interactable = false;
    }
    public void disableUndo()
    {
        UndoMoveButton.interactable = false;
    }
    public void updateActionMenuPosition()
    {
        if (ActiveCharacter != null)
        {
            Vector3 worldPoint = ActiveCharacter.transform.position;
            Vector3 worldPoint2 = ActiveCharacter.transform.position;
            worldPoint.y += 9.0f;
            worldPoint.z += 5.0f;
            worldPoint.x += 12.0f;
            Vector3 screenPosition = Cam.WorldToScreenPoint(worldPoint);
            screenPosition.z = 0;
            MenuObj.transform.position = worldPoint;
            LineRenderer lr = MenuObj.GetComponent<LineRenderer>();
            Vector3[] v3a = new Vector3[] { worldPoint2, worldPoint };
            worldPoint2.y += 5.0f;
            lr.SetPosition(0, worldPoint);
            lr.SetPosition(1, worldPoint2);

        }
    }
    public void UpdateActiveMenu()
    {
        CharacterPage characterPage = ActiveCharacter.GetComponent<CharacterPage>();
        GameObject actionMenu = GameObject.Find("ActiveCharHUD/ActiveHUDBG/TopLabel");
        TextMeshProUGUI actionMenuText = actionMenu.GetComponent<TextMeshProUGUI>();
        actionMenuText.text = ActiveCharacter.name;
        actionMenu = GameObject.Find("ActiveCharHUD/ActiveHUDBG/HPLabel");
        actionMenuText = actionMenu.GetComponent<TextMeshProUGUI>();
        actionMenuText.text = characterPage.Hp.ToString() + "/" + characterPage.MaxHp.ToString();
        actionMenu = GameObject.Find("ActiveCharHUD/ActiveHUDBG/MPLabel");
        actionMenuText = actionMenu.GetComponent<TextMeshProUGUI>();
        actionMenuText.text = characterPage.Mp.ToString() + "/" + characterPage.MaxMp.ToString();
        actionMenu = GameObject.Find("ActiveCharHUD/ActiveHUDBG/ActiveCharPortrait");
        Image actionMenuImage = actionMenu.GetComponent<Image>();
        actionMenuImage.sprite = Resources.Load<Sprite>(ActiveCharacter.GetComponent<CharacterPage>().SpriteName);
    }
    public void NewActive()
    {
        if (ActiveCharacter != null) {
            showMenu();
            setHUDPlayerCanvas(true);
            NewActiveTargetHUD();
            Vector3 worldPoint = ActiveCharacter.transform.position;
            worldPoint.y += 14.0f;
            Vector3 screenPosition = Cam.WorldToScreenPoint(worldPoint);
            screenPosition.z = 0;
            MenuObj.transform.position = screenPosition;
            CharacterPage charPage = ActiveCharacter.GetComponent<CharacterPage>();
            GameObject actionMenu = GameObject.Find("ActiveCharHUD/ActiveHUDBG/TopLabel");
            TextMeshProUGUI actionMenuText = actionMenu.GetComponent<TextMeshProUGUI>();
            actionMenuText.text = ActiveCharacter.name;
            actionMenu = GameObject.Find("ActiveCharHUD/ActiveHUDBG/HPLabel");
             actionMenuText = actionMenu.GetComponent<TextMeshProUGUI>();
            actionMenuText.text = charPage.Hp.ToString() + "/" + charPage.MaxHp.ToString();
            actionMenu = GameObject.Find("ActiveCharHUD/ActiveHUDBG/MPLabel");
             actionMenuText = actionMenu.GetComponent<TextMeshProUGUI>();
            actionMenuText.text = charPage.Mp.ToString() + "/" + charPage.MaxMp.ToString();
            actionMenu = GameObject.Find("ActiveCharHUD/ActiveHUDBG/ActiveCharPortrait");
            Image actionMenuImage = actionMenu.GetComponent<Image>();
            actionMenuImage.sprite = Resources.Load<Sprite>(ActiveCharacter.GetComponent<CharacterPage>().SpriteName);
            Image HPBar = GameObject.Find("ActiveCharHUD/ActiveHUDBG/HPBarActual").GetComponent<Image>();
            Image MPBar = GameObject.Find("ActiveCharHUD/ActiveHUDBG/MPBarActual").GetComponent<Image>();
            HPBar.fillAmount = ((float)charPage.Hp) / ((float)charPage.MaxHp);
            MPBar.fillAmount = ((float)charPage.Mp) / ((float)charPage.MaxMp);
            if (charPage != null)
            {
                if (charPage.PlayerControlled == true)
                {
                    if (ActiveCharacter == TurnTaker)
                    {
                        setFullActiveMenu();
                    }
                    else
                    {
                        setViewMenu();
                    }
                } else
                {
                    hideMenu();
                    Debug.Log("Taking AI turn");
                    aiTurn = true;
                    takeAITurn(charPage);
                }
            }
        }
    }
    public bool getAiTurn()
    {
        return aiTurn;
    }
    public void NewActiveTargetHUD()
    {
        if (TargetedCharacter != null)
        {
            TargetMenu.SetActive(true);
            CharacterPage charPage = TargetedCharacter.GetComponent<CharacterPage>();
            GameObject actionMenu = GameObject.Find("TargetCharHUD/ActiveHUDBG/TopLabel");
            
            TextMeshProUGUI actionMenuText = actionMenu.GetComponent<TextMeshProUGUI>();
            actionMenuText.text = TargetedCharacter.name;
            actionMenu = GameObject.Find("TargetCharHUD/ActiveHUDBG/HPLabel");
            actionMenuText = actionMenu.GetComponent<TextMeshProUGUI>();
            actionMenuText.text = charPage.Hp.ToString() + "/" + charPage.MaxHp.ToString();
            actionMenu = GameObject.Find("TargetCharHUD/ActiveHUDBG/MPLabel");
            actionMenuText = actionMenu.GetComponent<TextMeshProUGUI>();
            actionMenuText.text = charPage.Mp.ToString() + "/" + charPage.MaxMp.ToString();
            actionMenu = GameObject.Find("TargetCharHUD/ActiveHUDBG/TargetCharPortrait");
            Image actionMenuImage = actionMenu.GetComponent<Image>();
            actionMenuImage.sprite = Resources.Load<Sprite>(TargetedCharacter.GetComponent<CharacterPage>().SpriteName);
            Image HPBar = GameObject.Find("TargetCharHUD/ActiveHUDBG/HPBarActual").GetComponent<Image>();
            Image MPBar = GameObject.Find("TargetCharHUD/ActiveHUDBG/MPBarActual").GetComponent<Image>();
            HPBar.fillAmount = ((float)charPage.Hp)/((float)charPage.MaxHp);
            MPBar.fillAmount = ((float)charPage.Mp) / ((float)charPage.MaxMp);
        }
    }
    public void setPrediction(bool pred)
    {
        HUDPredictDmg.SetActive(pred);
    }
    public void setPredictDmg()
    {
        if (TurnTaker != null && TargetedCharacter != null && TurnTaker.GetComponent<CharacterPage>().getPrepAttack())
        {
            (int predictedDmg, int overdmg, int percentChanceOfHit) = TurnTaker.GetComponent<CharacterPage>().CalcDmg(TargetedCharacter.GetComponent<CharacterPage>());
            HUDPredictDmg.SetActive(true);
            predictedDmg *= (-1);
            TextMeshProUGUI predictText = HUDPredictTxt.GetComponent<TextMeshProUGUI>();
            predictText.text = (predictedDmg).ToString();
            TextMeshProUGUI percentText = HUDPercentTxt.GetComponent<TextMeshProUGUI>();
            percentText.text = percentChanceOfHit.ToString()+"%";
            Image predictArrow = HUDPredictArrow.GetComponent<Image>();
            if (predictedDmg <= 0)
            {
                predictText.color = Color.red;
                predictArrow.color = Color.red;
            }
            string pt = TurnTaker.GetComponent<CharacterPage>().PreType;
            if (predictedDmg > 0 || (predictedDmg == 0 && (pt == "heal") || (pt == "potion") || (pt == "food")))
            {

                predictText.text = "+" + predictText.text;
                if (predictedDmg != overdmg)
                {
                    predictText.text+= " (" + overdmg*(-1) + ")";
                }
                
                predictText.color = Color.blue;
                predictArrow.color = Color.blue;
                
            }
            

        } else
        {
            TextMeshProUGUI predictText = HUDPredictTxt.GetComponent<TextMeshProUGUI>();
            predictText.text = "";
            TextMeshProUGUI percentText = HUDPercentTxt.GetComponent<TextMeshProUGUI>();
            percentText.text = "";
            Image predictArrow = HUDPredictArrow.GetComponent<Image>();
            predictArrow.color = Color.white;
            HUDPredictDmg.SetActive(false);
        }
    }
        
    private void defenseMode()
    {
        CharacterPage actCharPag = ActiveCharacter.GetComponent<CharacterPage>();
        actCharPag.Def = (actCharPag.Def * 3) / 2;
    }
    public void defendAndEndTurn()
    {
        _tav = 0;
        SkillsDD.SetActive(false);
        ActionsDD.SetActive(false);
        ItemsDD.SetActive(false);
        unprepareAttack();
        unprepareGlows();
        unprepareMove();
        defenseMode();
        EndTurn();
    }
    public void setTargetMenuEnable(bool status)
    {
        TargetMenu.SetActive(status);
    }
    public void setHUDPlayerCanvas(bool status)
    {
        HUDPlayerCanvas.SetActive(status);
        HUDPlayerStatus = status;
    }
    public void hideMenu()
    {
        MenuObj.SetActive(false);
    }
    public void showMenu()
    {
        MenuObj.SetActive(true);
    }
    void setFullActiveMenu()
    {
        MenuObj.SetActive(true);
        GameObject moveLabel = GameObject.Find("ButtonMove/MoveLabel");
        TextMeshProUGUI moveLabelText = moveLabel.GetComponent<TextMeshProUGUI>();
        moveLabelText.color = Color.black;
         moveLabel = GameObject.Find("ButtonActions/ActionsLabel");
         moveLabelText = moveLabel.GetComponent<TextMeshProUGUI>();
        moveLabelText.color = Color.black;
        moveLabel = GameObject.Find("ButtonSkills/SkillsLabel");
        moveLabelText = moveLabel.GetComponent<TextMeshProUGUI>();
        moveLabelText.color = Color.black;
        moveLabel = GameObject.Find("ButtonItems/ItemsLabel");
        moveLabelText = moveLabel.GetComponent<TextMeshProUGUI>();
        moveLabelText.color = Color.black;
        moveLabel = GameObject.Find("ButtonDefend/DefendLabel");
         moveLabelText = moveLabel.GetComponent<TextMeshProUGUI>();
        moveLabelText.color = Color.black;
         moveLabel = GameObject.Find("ButtonEndTurn/EndTurnLabel");
         moveLabelText = moveLabel.GetComponent<TextMeshProUGUI>();
        moveLabelText.color = Color.black;
       


    }
    void setViewMenu()
    {
        MenuObj.SetActive(true);
        GameObject moveLabel = GameObject.Find("ButtonMove/MoveLabel");
        TextMeshProUGUI moveLabelText = moveLabel.GetComponent<TextMeshProUGUI>();
        moveLabelText.color = Color.grey;
        moveLabel = GameObject.Find("ButtonAttack/AttackLabel");
        moveLabelText = moveLabel.GetComponent<TextMeshProUGUI>();
        moveLabelText.color = Color.grey;
        moveLabel = GameObject.Find("ButtonSkills/SkillsLabel");
        moveLabelText = moveLabel.GetComponent<TextMeshProUGUI>();
        moveLabelText.color = Color.grey;
        moveLabel = GameObject.Find("ButtonItems/ItemsLabel");
        moveLabelText = moveLabel.GetComponent<TextMeshProUGUI>();
        moveLabelText.color = Color.grey;
        moveLabel = GameObject.Find("ButtonDefend/DefendLabel");
        moveLabelText = moveLabel.GetComponent<TextMeshProUGUI>();
        moveLabelText.color = Color.grey;
        moveLabel = GameObject.Find("ButtonEndTurn/EndTurnLabel");
        moveLabelText = moveLabel.GetComponent<TextMeshProUGUI>();
        moveLabelText.color = Color.grey;
        
    }
    public void EndTurn()
    {
        if (TurnTaker == null)
        {
            return;
        }
        if (ActiveCharactersInLevel.Count == 0)
        {
            
            return;
        }

        UndoMoveButton.interactable = false;
        UndoMoveButton.gameObject.SetActive(false);
        MoveButton.interactable = true;
        MoveButton.gameObject.SetActive(true);
        CharacterPage charPage = TurnTaker.GetComponent<CharacterPage>();
        _movePrepToggle = 0;
        _attackPrepToggle = 0;
        _skillPrepToggle = 0;
        _itemsPrepToggle = 0;
        unprepareGlows();
        charPage.prepAttack(false);

        GameObject prevTaker = TurnTaker;
        while (prevTaker == TurnTaker || TurnTaker.GetComponent<CharacterPage>().Hp <= 0)
        {
            TurnNumber++;
            TurnTaker = CharactersInLevel[TurnNumber % (CharactersInLevel.Count)];
        }
        aiTurn = false;
        ActiveCharacter = TurnTaker;
        CharacterPage acp = TurnTaker.GetComponent<CharacterPage>();
        acp.Def = acp.OriginalDef;
        StageMan.FindDistancesWithinX(TurnTaker.GetComponent<CharacterPage>().PlayerSide, TurnTaker.GetComponent<CharacterPage>().MoveDistance, TurnTaker.GetComponent<CharacterPage>().X, TurnTaker.GetComponent<CharacterPage>().Z);
        setTargetMenuEnable(false);
        enableAllActionMenuButtons();
        
        NewActive();
        foreach (Transform child in ActionsDD.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in SkillsDD.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in ItemsDD.transform)
        {
            Destroy(child.gameObject);
        }
        populateActionDD();
        populateSkillsDD();
        populateItemsDD();
        showActionsDD(false);
        showSkillsDD(false);
        showItemsDD(false);
        NewActiveTargetHUD();
        _tav = 0;
        _tsv = 0;
        updateActionMenuPosition();
        PreviousMoveId = 0;
        


    }
    
            
        
    

    public void populateActionDD()
    {
       
        List<BattleAction> actList = TurnTaker.GetComponent<CharacterPage>().getUseableActions();
        for (int i = 0; i < actList.Count; i++) {
            string name = actList[i].actionName;
            string iconName = actList[i].iconName;
            int mpCost = actList[i].mpcost;
            string mpCostStr = mpCost.ToString();
            if (name == "basic")
            {
                mpCostStr = "";
            }
            //add button to dropdown
            GameObject newbtnCont = new GameObject();
            newbtnCont.AddComponent<SpriteBillboard>();
            newbtnCont.transform.SetParent(ActionsDD.transform);
            newbtnCont.transform.localPosition = new Vector3(0.0f, 34 - (30.0f*i), 0.0f);
            BattleAction actionInfo = actList[i];
            Button btn = newbtnCont.AddComponent<Button>();
            int midd = 100 + i;
            btn.onClick.AddListener(delegate { toggleAttackVis(actionInfo.minRange, actionInfo.maxRange, false, actionInfo.dmg, actionInfo.type, "action", actionInfo.mpcost, midd); }) ;
            btn.transform.localPosition = new Vector3(0.0f, 34 - (30.0f * i), 0.0f);
            btn.transform.localScale = new Vector3(1.0f, 0.3f, 1);
            btn.targetGraphic = Resources.Load<Image>("transparentbg");
            Image img = newbtnCont.AddComponent<Image>();
            img.color = new Color(21f / 255f, 103f/255f, 98f/255f, 0.8f);
            img.rectTransform.sizeDelta = new Vector2(118f, 75f);
            //newbtnCont.GetComponent<RectTransform>();
            btn.targetGraphic.rectTransform.sizeDelta = new Vector2(98f, 100f);
            Outline outline = newbtnCont.AddComponent<Outline>();
            outline.effectDistance = new Vector2(0.3f, 2);
            outline.effectColor = new Color(145f/255f, 145f / 255f, 145f / 255f);
            //add textObject to button
            GameObject newtxt = new GameObject();
            TextMeshProUGUI textMesh = newtxt.AddComponent<TextMeshProUGUI>();
            newtxt.transform.SetParent(newbtnCont.transform);
            newtxt.transform.localPosition = new Vector3(-10.0f, 0, 0.0f);
            textMesh.text = name;
            textMesh.enableAutoSizing = true;
            textMesh.fontSizeMax = 720;

            textMesh.rectTransform.sizeDelta = new Vector2(150, 30);
            textMesh.transform.localScale = new Vector3(0.4f, 2.4f, 0.25f);

            GameObject newtxtMP = new GameObject();
            TextMeshProUGUI textMeshMP = newtxtMP.AddComponent<TextMeshProUGUI>();
            newtxtMP.transform.SetParent(newbtnCont.transform);
            newtxtMP.transform.localPosition = new Vector3(70.0f, 0, 0.0f);
            textMeshMP.text = mpCostStr;
            textMeshMP.enableAutoSizing = true;
            textMeshMP.rectTransform.sizeDelta = new Vector2(150, 30);
            textMeshMP.transform.localScale = new Vector3(0.4f, 2.4f, 0.25f);
            textMeshMP.color = Color.black;
            if (mpCostStr != "")
            {
                GameObject newtxtMPL = new GameObject();
                TextMeshProUGUI textMeshMPL = newtxtMPL.AddComponent<TextMeshProUGUI>();
                newtxtMPL.transform.SetParent(newbtnCont.transform);
                newtxtMPL.transform.localPosition = new Vector3(82.0f, 3.0f, 0.0f);
                textMeshMPL.text = "MP";
                textMeshMPL.fontSize = 12;
                textMeshMPL.rectTransform.sizeDelta = new Vector2(150, 30);
                textMeshMPL.transform.localScale = new Vector3(0.4f, 2.4f, 0.25f);
                textMeshMPL.color = new Color(1.0f, 82.0f, 0.0f); //Should be fractions, color is unintended right now
            }
            //add icon to button
            GameObject newimg = new GameObject();
            newimg.transform.SetParent(newbtnCont.transform);
            newimg.transform.localPosition = new Vector3(-50.0f, 0, 0.0f);
            Sprite imgToAdd = Resources.Load<Sprite>(iconName);
            Image imgAdded = newimg.AddComponent<Image>();
            imgAdded.sprite = imgToAdd;
            imgAdded.rectTransform.sizeDelta = new Vector2(40, 40);

            imgAdded.transform.localScale = new Vector3(0.4f, 2.4f, 0.25f);
            if (mpCost > TurnTaker.GetComponent<CharacterPage>().Mp)
            {
                btn.interactable = false;
                img.color = new Color(21f / 255f, 103f / 255f, 98f / 255f, 0.4f);
                textMesh.color = new Color(255f / 255f, 255f / 255f, 252f / 255f, 0.4f);
                imgAdded.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 0.3f);
            }
        }

    }
    public void populateSkillsDD()
    {

        List<SkillInfo> actList = TurnTaker.GetComponent<CharacterPage>().getUseableSkills();
        for (int i = 0; i < actList.Count; i++)
        {
            string name = actList[i].spellName;
            string iconName = actList[i].iconName;
            int mpCost = actList[i].mpcost;
            string mpCostStr = mpCost.ToString();
            if (name == "basic")
            {
                mpCostStr = "";
            }
            //add button to dropdown
            GameObject newbtnCont = new GameObject();
            newbtnCont.AddComponent<SpriteBillboard>();
            newbtnCont.transform.SetParent(SkillsDD.transform);
            newbtnCont.transform.localPosition = new Vector3(0.0f, 34 - (30.0f * i), 0.0f);
            SkillInfo skillinfo = actList[i];
            Button btn = newbtnCont.AddComponent<Button>();
            btn.onClick.AddListener(delegate { toggleAttackVis(skillinfo.minRange, skillinfo.maxRange, false, skillinfo.dmg, skillinfo.type, "skill", skillinfo.mpcost, 200+i); });
            btn.transform.localPosition = new Vector3(0.0f, 34 - (30.0f * i), 0.0f);
            btn.transform.localScale = new Vector3(1.0f, 0.3f, 1);
            btn.targetGraphic = Resources.Load<Image>("transparentbg");
            Image img = newbtnCont.AddComponent<Image>();
            img.color = new Color(21f / 255f, 103f / 255f, 98f / 255f, 0.8f);
            img.rectTransform.sizeDelta = new Vector2(118f, 75f);
            //newbtnCont.GetComponent<RectTransform>();
            btn.targetGraphic.rectTransform.sizeDelta = new Vector2(98f, 100f);
            Outline outline = newbtnCont.AddComponent<Outline>();
            outline.effectDistance = new Vector2(0.3f, 2);
            outline.effectColor = new Color(145f / 255f, 145f / 255f, 145f / 255f);
            //add textObject to button
            GameObject newtxt = new GameObject();
            TextMeshProUGUI textMesh = newtxt.AddComponent<TextMeshProUGUI>();
            newtxt.transform.SetParent(newbtnCont.transform);
            newtxt.transform.localPosition = new Vector3(-10.0f, 0, 0.0f);
            textMesh.text = name;
            textMesh.enableAutoSizing = true;
            textMesh.fontSizeMax = 720;

            textMesh.rectTransform.sizeDelta = new Vector2(150, 30);
            //add icon to button
            GameObject newimg = new GameObject();
            newimg.transform.SetParent(newbtnCont.transform);
            newimg.transform.localPosition = new Vector3(-50.0f, 0, 0.0f);
            Sprite imgToAdd = Resources.Load<Sprite>(iconName);
            Image imgAdded = newimg.AddComponent<Image>();
            imgAdded.sprite = imgToAdd;
            imgAdded.rectTransform.sizeDelta = new Vector2(40, 40);
            textMesh.transform.localScale = new Vector3(0.4f, 2.4f, 0.25f);
            imgAdded.transform.localScale = new Vector3(0.4f, 2.4f, 0.25f);

            GameObject newtxtMP = new GameObject();
            TextMeshProUGUI textMeshMP = newtxtMP.AddComponent<TextMeshProUGUI>();
            newtxtMP.transform.SetParent(newbtnCont.transform);
            newtxtMP.transform.localPosition = new Vector3(70.0f, 0, 0.0f);
            textMeshMP.text = mpCostStr;
            textMeshMP.enableAutoSizing = true;
            textMeshMP.rectTransform.sizeDelta = new Vector2(150, 30);
            textMeshMP.transform.localScale = new Vector3(0.4f, 2.4f, 0.25f);
            textMeshMP.color = Color.black;
            if (mpCostStr != "")
            {
                GameObject newtxtMPL = new GameObject();
                TextMeshProUGUI textMeshMPL = newtxtMPL.AddComponent<TextMeshProUGUI>();
                newtxtMPL.transform.SetParent(newbtnCont.transform);
                newtxtMPL.transform.localPosition = new Vector3(82.0f, 3.0f, 0.0f);
                textMeshMPL.text = "MP";
                textMeshMPL.fontSize = 12;
                textMeshMPL.rectTransform.sizeDelta = new Vector2(150, 30);
                textMeshMPL.transform.localScale = new Vector3(0.4f, 2.4f, 0.25f);
                textMeshMPL.color = new Color(1.0f, 82.0f, 0.0f); //Should be fractions, color is unintended right now
            }
            if (mpCost > TurnTaker.GetComponent<CharacterPage>().Mp)
            {
                btn.interactable = false;
                img.color = new Color(21f / 255f, 103f / 255f, 98f / 255f, 0.4f);
                textMesh.color = new Color(255f / 255f, 255f / 255f, 252f / 255f, 0.4f);
                imgAdded.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 0.3f);
            }
        }

    }
    public void populateItemsDD()
    {

        List<MiscItems> actList = TurnTaker.GetComponent<CharacterPage>().getUseableItems();
        for (int i = 0; i < actList.Count; i++)
        {
            string name = actList[i].itemName;
            string iconName = actList[i].iconName;
            //add button to dropdown
            GameObject newbtnCont = new GameObject();
            newbtnCont.AddComponent<SpriteBillboard>();
            newbtnCont.transform.SetParent(ItemsDD.transform);
            newbtnCont.transform.localPosition = new Vector3(0.0f, 34 - (30.0f * i), 0.0f);
            MiscItems item = actList[i];
            Button btn = newbtnCont.AddComponent<Button>();
            btn.onClick.AddListener(delegate { toggleAttackVisItem(item.minRange, item.maxRange, false, item.dmg, item.type, "item", item, 300+i); });
            btn.transform.localPosition = new Vector3(0.0f, 34 - (30.0f * i), 0.0f);
            btn.transform.localScale = new Vector3(1.0f, 0.3f, 1);
            btn.targetGraphic = Resources.Load<Image>("transparentbg");
            Image img = newbtnCont.AddComponent<Image>();
            img.color = new Color(21f / 255f, 103f / 255f, 98f / 255f, 0.8f);
            img.rectTransform.sizeDelta = new Vector2(98f, 75f);
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
            textMesh.text = name;
            textMesh.enableAutoSizing = true;
            textMesh.fontSizeMax = 720;

            textMesh.rectTransform.sizeDelta = new Vector2(150, 30);
            //add icon to button
            GameObject newimg = new GameObject();
            newimg.transform.SetParent(newbtnCont.transform);
            newimg.transform.localPosition = new Vector3(-30.0f, 0, 0.0f);
            Sprite imgToAdd = Resources.Load<Sprite>(iconName);
            Image imgAdded = newimg.AddComponent<Image>();
            imgAdded.sprite = imgToAdd;
            imgAdded.rectTransform.sizeDelta = new Vector2(40, 40);
            textMesh.transform.localScale = new Vector3(0.4f, 2.4f, 0.25f);
            imgAdded.transform.localScale = new Vector3(0.4f, 2.4f, 0.25f);
        }

    }
    private void enableAllActionMenuButtons()
    {
        MoveButton.interactable = true;
        DefendButton.interactable = true;
        SpellsButton.interactable = true;
        AttackButton.interactable = true;
        ItemsButton.interactable = true;
        UndoMoveButton.interactable = false;
    }
    private void traverseFromCoordsRecur(List<GameObject> spotsTohighlight, int startingX, int startingZ, int distMoved, int maxDist, Hashtable vis, List<(float, float, float, int, int, int)> curList, bool ps, int maxVert, float prevY)
    {
        
        
        string mask = startingX.ToString() + ","+startingZ.ToString();
        List<(float, float, float, int, int, int)>  curListCopy = new List<(float, float, float, int, int, int)>(curList);
        GameObject curObj = StageMan.spotMatrix[startingX, startingZ];
        
        Vector3 mimic = curObj.transform.position;
        //stageMan.spotMatrix[startingX, startingZ].transform.position.y;
        if (curObj.GetComponent<ValidSpot>().characterCanUse == false || Math.Abs(mimic.y - prevY) > maxVert)
        {
            return;
        }
        ValidSpot spotObj = curObj.GetComponent<ValidSpot>();
        if (spotObj.characterIsOnSpot == true)
        {
            if (spotObj.GetCharacterOnSpot().GetComponent<CharacterPage>().PlayerSide != ps)
            {
                return;
            }
        }
           
        curListCopy.Add((mimic.x, mimic.z, mimic.y, startingX, startingZ, 0));
        if (vis.ContainsKey(mask) == false)
        {
            vis.Add(mask, distMoved);
        } else
        {
            
            vis[mask] = distMoved;
        }
        

        
        spotObj.setTrip(curListCopy);
        
            if (curObj != null)
            {
            
            
            spotsTohighlight.Add(curObj);
            }
            
        if (distMoved < maxDist)
        {
            for (int i = 0; i < _coords.GetLength(0); i++)
            {
                int nx = startingX + _coords[i, 0];
                int nz = startingZ + _coords[i, 1];
                if (nz < StageMan.zDist && nx < StageMan.xDist && nz >= 0 && nx >= 0 && ((vis.ContainsKey(nx.ToString()+","+nz.ToString()) == false) || ((int)vis[nx.ToString() + "," + nz.ToString()] > distMoved+1)))
                {
                    traverseFromCoordsRecur(spotsTohighlight, startingX + _coords[i, 0], startingZ + _coords[i, 1],  distMoved + 1, maxDist, vis, curListCopy, ps, maxVert, mimic.y);
                }
               
            }
            
        }
        
    }
    public GameObject QuerySpotMatrix(int xc, int zc)
    {
        return StageMan.spotMatrix[xc, zc];
    }
    
    public void showActionsDD(bool actstat)
    {
        ActionsDD.SetActive(actstat);
    }
    public void showSkillsDD(bool actstat)
    {
        
        
        SkillsDD.SetActive(actstat);
    }
    public void showItemsDD(bool actstat)
    {
        ItemsDD.SetActive(actstat);
    }
    public void toggleActionsPrep()
       
    {
    _tav = 0;
    unprepareAttack();
    showSkillsDD(false);
        showItemsDD(false);
        if (ActiveCharacter == TurnTaker)
        {
            if (_attackPrepToggle % 2 == 0)
        {
                showActionsDD(true);
            //prepareAttack();
        }
        else
        {
                showActionsDD(false);

               unprepareAttack();
        }
            _attackPrepToggle++;
}
    }
    public void toggleSkillsPrep()

    {
    _tav = 0;
    unprepareAttack();
        showActionsDD(false);
        showItemsDD(false);
        if (ActiveCharacter == TurnTaker)
        {
            if (_skillPrepToggle % 2 == 0)
            {
                showSkillsDD(true);
                //prepareAttack();
            }
            else
            {
                showSkillsDD(false);
               unprepareAttack();
            }
            _skillPrepToggle++;
        }
    }
    public void toggleItemsPrep()

    {
    _tav = 0;
    unprepareAttack();
    showActionsDD(false);
        showSkillsDD(false);
        if (ActiveCharacter == TurnTaker)
        {
            if (_itemsPrepToggle % 2 == 0)
            {
                showItemsDD(true);
                //prepareAttack();
            }
            else
            {
                showItemsDD(false);
                unprepareAttack();
            }
            _itemsPrepToggle++;
        }
    }

    public void setMoveToggle(int newToggle)
    {
        _movePrepToggle = newToggle; 
    }
    public void setAttackToggle(int newToggle)
    {
        _attackPrepToggle = newToggle;
    }
    public void toggleMovePrep()
    {
        if (_movePrepToggle%2 == 0)
        {
            prepareMove(true);
        } else
        {
            unprepareMove();
        }
        _movePrepToggle++;
    }
    public void prepareMove(bool ps)
    {
        Hashtable visited = new Hashtable();
        CharacterPage charPage = ActiveCharacter.GetComponent<CharacterPage>();
        int maxMove = charPage.MoveDistance;
        int curX = charPage.X;
        int curZ = charPage.Z;
        List<GameObject> spotsTohighlight = new List<GameObject>();
        List<(float, float, float, int, int, int)> beginList = new List<(float, float, float, int, int, int)>();
        traverseFromCoordsRecur(spotsTohighlight, curX, curZ, 0, maxMove, visited, beginList, ps, charPage.Jump, StageMan.spotMatrix[curX, curZ].transform.position.y);
        for (int i = 0; i < spotsTohighlight.Count; i++)
        {
           GameObject glowie = spotsTohighlight[i].transform.GetChild(0).gameObject;
            ValidSpot vspot = spotsTohighlight[i].GetComponent<ValidSpot>();
            vspot.setActiveBool(true);
            glowie.SetActive(true);

        }
        _activeGlows = spotsTohighlight;
        
    }
    public void cancelMove()
    {
        TurnTaker.GetComponent<CharacterPage>().CancelMove();
        updateActionMenuPosition();
        UndoMoveButton.interactable = false;
        UndoMoveButton.gameObject.SetActive(false);
        MoveButton.interactable = true;
        MoveButton.gameObject.SetActive(true);

    }
    
    public void unprepareMove()
    {
        
        unprepareGlows();
    }
    public void setTav(int newtav)
    {
        _tav = newtav;
    }
    public void setTsv(int newtsv)
    {
        _tsv = newtsv;
    }
    public void toggleAttackVis(int minrange, int maxrange, bool directionalOnly, int dmg, string type, string categ, int cmp, int moveId)
    {
        if (_tav%2 == 1 )
        {
            if (moveId == PreviousMoveId)
            {
                unprepareAttack();
                PreviousMoveId = 0;
                _tav++;
            } else
            {
                unprepareAttack();
                prepareAttack(minrange, maxrange, directionalOnly, dmg, type, categ, cmp);
                PreviousMoveId = moveId;
            }
                
        } else
        {
            prepareAttack(minrange, maxrange, directionalOnly, dmg, type, categ, cmp);
            PreviousMoveId = moveId;
            _tav++;
        }
        
    }
    public void toggleAttackVisItem(int minrange, int maxrange, bool directionalOnly, int dmg, string type, string categ, MiscItems itemc, int moveId)
    {
        if (_tav % 2 == 0)
        {
            _temporaryItem = itemc;
            prepareAttack(minrange, maxrange, directionalOnly, dmg, type, categ, 0);
        }
        else
        {
            unprepareAttack();
        }
        _tav++;
    }

    private int manhattanDist(int x, int z, int xc, int zc)
    {
        return Math.Abs(x-xc)+Math.Abs(z-zc);
    }

    public void prepareAttack(int minrange, int maxrange, bool directionalOnly, int dmg, string type, string categ, int cmp)
    {
        
        CharacterPage charPage = TurnTaker.GetComponent<CharacterPage>();
        charPage.PreDmg = dmg;
        charPage.PreMin = minrange;
        charPage.PreMax = maxrange;
        charPage.PreType = type;
        charPage.PreCateg = categ;
        charPage.PreMp = cmp;
        if (categ == "item")
        {
            charPage.SelectedItem = _temporaryItem;
        }
        charPage.prepAttack(true);
        int curX = charPage.X;
        int curZ = charPage.Z;
        List<GameObject> spotsTohighlight = new List<GameObject>();
        for (int j = 0; j < StageMan.xDist; j++)
        {
            for (int k = 0; k  < StageMan.zDist; k++) {
                int manhattan = manhattanDist(curX, curZ, j, k);
                if ( manhattan >= minrange && manhattan <= maxrange)
                {
                    if (StageMan.spotMatrix[j, k] != null)
                    {
                        spotsTohighlight.Add(StageMan.spotMatrix[j, k]);
                    }
                }
            }
        }
        _activeGlows = spotsTohighlight;
        for (int i = 0; i < spotsTohighlight.Count; i++)
        {
            GameObject glowie = spotsTohighlight[i].transform.GetChild(0).gameObject;
            ValidSpot vspot = spotsTohighlight[i].GetComponent<ValidSpot>();
            vspot.setAttackPrepBool(true);
            glowie.SetActive(true);
        }

    }
    public void unprepareAttack()
    {
        CharacterPage charPage = TurnTaker.GetComponent<CharacterPage>();
        unprepareGlows();
        charPage.prepAttack(false);
        NewActiveTargetHUD();
    }
    public void unprepareGlows()
    {
        for (int i = 0; i < _activeGlows.Count; i++)
        {
            _activeGlows[i].transform.GetChild(0).gameObject.SetActive(false);
            ValidSpot vspot = _activeGlows[i].GetComponent<ValidSpot>();
            vspot.setActiveBool(false);
            vspot.setAttackPrepBool(false);
            vspot.potentialTrip = new List<(float, float, float, int, int, int)>();

        }
        _activeGlows = new List<GameObject>();
    }
    private GameObject ChooseAITarget(List<GameObject> enemyList, int curX, int curZ)
    {
        
        //get mix between lowest distance and lowest defence
        float curPri = 0.0f;
        GameObject curWinner = null;
        for (int i = 0; i < enemyList.Count; i++)
        {
            int curDist = manhattanDist(curX, curZ, enemyList[i].GetComponent<CharacterPage>().X, enemyList[i].GetComponent<CharacterPage>().Z);
            int def = enemyList[i].GetComponent<CharacterPage>().Hp;
            float scopedPri = (1/((float)def)) / (float)curDist;
            if (scopedPri > curPri)
            {
                curPri = scopedPri;
                curWinner = enemyList[i];
            }
        }
        return curWinner;
        //System.Random rnd = new System.Random();
        // return enemyList[rnd.Next(enemyList.Count)];
    }
    (int, int, bool) CheckDescPriorityAttacks(List<uint> attackP, List<GameObject> enemyList)
    {
        for (int p = 0; p < attackP.Count; p++)
        {
            
            
            int curMove = (int)attackP[p];

            int curMoveMinDist = 0; //GameManager.instance.spellList[curMove].minRange;
            int curMoveMaxDist = 0;
            int curMoveDmg = 0;
            int curMoveMp = 0;
            string curMoveType;
            if (curMove >= 10)
            {
                SkillInfo si = TurnTaker.GetComponent<CharacterPage>().SkillsList[curMove - 10];
                curMoveMinDist = si.minRange;
                curMoveMaxDist = si.maxRange;
                curMoveDmg = si.dmg;
                curMoveType = si.type;
                curMoveMp = si.mpcost;
            } else
            {
                BattleAction ba = TurnTaker.GetComponent<CharacterPage>().ActionsList[curMove];
                curMoveMinDist = ba.minRange;
                curMoveMaxDist = ba.maxRange;
                curMoveDmg = ba.dmg;
                curMoveType = ba.type;
                curMoveMp = ba.mpcost;
            }
            //GameManager.instance.spellList[curMove].maxRange;
            if (curMoveType == "heal")
            {
                //heal spell
                continue;
            }
            if (curMoveMp > TurnTaker.GetComponent<CharacterPage>().Mp)
            {
                continue;
            }
            for (int d = 0; d < enemyList.Count; d++)
            {
                int enemyX = enemyList[d].GetComponent<CharacterPage>().X;
                int enemyZ = enemyList[d].GetComponent<CharacterPage>().Z;
                for (int i = 0; i < _activeGlows.Count; i++)
                {
                    int xCoord = (int)((_activeGlows[i].transform.position.x - 4) / 8);
                    int zCoord = (int)((_activeGlows[i].transform.position.z - 4) / 8);
                    GameObject stageTile = _activeGlows[i];
                    ValidSpot vspot = stageTile.GetComponent<ValidSpot>();
                    DebugValue = _activeGlows[i];
                    
                    if ((StageMan.distances[xCoord + "," + zCoord] == null) || (((Hashtable)StageMan.distances[xCoord + "," + zCoord]).ContainsKey(enemyX + "," + enemyZ) == false) || (StageMan.spotMatrix[xCoord, zCoord].GetComponent<ValidSpot>().characterIsOnSpot))
                    {
                        
                    } else { 
                    
                    int potentialDist = ((int)((Hashtable)StageMan.distances[xCoord + "," + zCoord])[enemyX + "," + enemyZ]);
                    
                    if (potentialDist >= curMoveMinDist && potentialDist <= curMoveMaxDist) 
                    {
                        AITargetedCharacter = enemyList[d];
                        _queuedAttack = curMove;
                            Debug.Log("moving to: " + xCoord.ToString() + zCoord.ToString());
                            return (xCoord, zCoord, true);
                    }
                    }
                }
            }
        }
        Debug.Log("didnt find attack");
        _queuedAttack = 6969;
        return (0, 0, false);
    }
    private async void takeAITurn(CharacterPage charPage)
    {
        aiTurn = true;
        Debug.Log("Beggining AI turn");
        bool curTeam = charPage.PlayerSide;
        List<GameObject> allies;
        List<GameObject> enemies;
        if (curTeam == false)
        {
            allies =  EnemyCharactersInLevel;
            enemies = PlayerCharactersInLevel; 
        } else
        {
            allies = PlayerCharactersInLevel;    
            enemies = EnemyCharactersInLevel;
        }
        prepareMove(false);
        //check if can move somewhere when priority 1 attack can happen
        //if not check priority 2, so on
        (int xd, int zd, bool movethere) = CheckDescPriorityAttacks(charPage.MovesPriority, enemies);
        Debug.Log("Looked at potential attacks");
        //if none, move closest to priority target
        if (movethere == false)
        {
            Debug.Log("No immediate attacks");
            //get target
            AITargetedCharacter = ChooseAITarget(enemies, TurnTaker.GetComponent<CharacterPage>().X, TurnTaker.GetComponent<CharacterPage>().Z);
            //move towards target
            Debug.Log("Chose target");

            (int xdc, int zdc, int lowestDist) = GetClosestTo(AITargetedCharacter, charPage.X, charPage.Z);
            Debug.Log("GCT results: " + xd + ", " + zd + ", " + lowestDist);
            xd = xdc;
            zd = zdc;
            if (lowestDist == 100000000)
            {
                var taskc = Task.Run(() => Delafunc());
                Task delayc = Task.Delay(1000);
                await delayc;
                unprepareMove();
                aiTurn = false;
                return;
            }
        }
        Debug.Log("Immediate attack possible");
        var task = Task.Run(() => Delafunc());
        Task delay = Task.Delay(1000);
        await delay;
        Debug.Log("execd");
        ValidSpot spotObj = (StageMan.spotMatrix[xd, zd]).GetComponent<ValidSpot>();
        InitMove(xd, zd, spotObj);
        
        //attack target
        // this is done in move
    }
   
    public async void lastHalfAITurn(CharacterPage charPage)
    {
        
        //TODO: allow AI to use items
        Debug.Log("queuedAttack: " + _queuedAttack.ToString());
        if (_queuedAttack != 6969) {
            TargetedCharacter = AITargetedCharacter;
            NewActiveTargetHUD();
            int minrange;
            int maxrange;
            int dmgI;
            string dmgType;
            string catt;
            int mpc;
            if (_queuedAttack >= 10)
            {
                SkillInfo si = TurnTaker.GetComponent<CharacterPage>().SkillsList[_queuedAttack - 10];
                minrange = si.minRange;
                maxrange = si.maxRange;
                dmgI = si.dmg;
                dmgType = si.type;
                catt = "skill";
                mpc = si.mpcost;
            }
            else
            {
                BattleAction ba = TurnTaker.GetComponent<CharacterPage>().ActionsList[_queuedAttack];
                minrange = ba.minRange;
                maxrange = ba.maxRange;
                dmgI = ba.dmg;
                dmgType = ba.type;
                catt = "action";
                mpc = ba.mpcost;
            }
            
            
            prepareAttack(minrange, maxrange, false, dmgI, dmgType, catt, mpc);
            var taskn = Task.Run(() => Delafunc());
            Task delayn = Task.Delay(1000);
            await delayn;
            Debug.Log("attackd");
            CharacterPage targCharPage = AITargetedCharacter.GetComponent<CharacterPage>();
            int enemyDist = manhattanDist(targCharPage.X, targCharPage.Z, charPage.X, charPage.Z);
        if (enemyDist >= minrange && enemyDist <= maxrange)
            {
                charPage.Attack(targCharPage);
            }
        
        var newtask = Task.Run(() => Delafunc());
            Task newdelay = Task.Delay(1000);
            await newdelay;
        }
        Debug.Log("endd");
            EndTurn();
        
    }
    public void Delafunc()
    {
        return;
    }
    (int, int, int) GetClosestTo(GameObject desDest, int sx, int sz)
    {
        int xa = 0;
        int za = 0;
        int enemyX = desDest.GetComponent<CharacterPage>().X;
        int enemyZ = desDest.GetComponent<CharacterPage>().Z;
        int lowestDist = 100000000;
        for (int i = 0; i < _activeGlows.Count; i++)
        {
            int xCoord = (int)((_activeGlows[i].transform.position.x - 4) / 8);
            int zCoord = (int)((_activeGlows[i].transform.position.z - 4) / 8);
            if (StageMan.distances[xCoord + ","+ zCoord] == null)
            {
                continue;
            }
            if (((Hashtable)StageMan.distances[xCoord + "," + zCoord]).ContainsKey(enemyX + ","+ enemyZ) == false)
            {
                continue;
            }
            if (StageMan.spotMatrix[xCoord , zCoord].GetComponent<ValidSpot>().characterIsOnSpot)
            {
                continue;
            }
            if (((int)((Hashtable)StageMan.distances[xCoord + "," + zCoord])[enemyX + "," + enemyZ]) < lowestDist)
            {
                xa = xCoord;
                za = zCoord;
                lowestDist = ((int)((Hashtable)StageMan.distances[xCoord + "," + zCoord])[enemyX + "," + enemyZ]);
            }
        }
        return (xa, za, lowestDist);
    }
    public void PostMove()
    {
        UndoMoveButton.gameObject.SetActive(true);
        UndoMoveButton.interactable = true;
        MoveButton.gameObject.SetActive(false);
        MoveButton.interactable = false;
    }
    void InitMove(int xc, int zc, ValidSpot spotObj)
    {
        CharacterPage charPage = ActiveCharacter.GetComponent<CharacterPage>();
        charPage.setDest(xc, zc, spotObj.potentialTrip);
        unprepareMove();
        
        _movePrepToggle = 0;
        
    }
    private void Update()
    {
        if (NumberOfPlayerChars == 0)
        {
            SceneManager.LoadScene("Lost");
        } else if (NumberOfEnemyChars == 0)
        {

            DataSaver.saveDataNewton<int>(GameManager.instance.gold, "gold");
            DataSaver.saveDataNewton<List<Weapons>>(GameManager.instance.inventoryWeaponList, "weapons");
            DataSaver.saveDataNewton<List<Equipment>>(GameManager.instance.inventoryEquipmentList, "equipment");
            DataSaver.saveDataNewton<List<MiscItems>>(GameManager.instance.inventoryMiscItemsList, "items");
            DataSaver.saveDataNewton<List<ActionTome>>(GameManager.instance.inventoryActionTomesList, "tomes");
            DataSaver.saveDataNewton<List<CharacterStats>>(GameManager.instance.characters, "characters");
            GameManager.instance.nextSceneName = nextSceneName;
            for (int i = 0; i < LevelsThatThisUnlocks.Count; i++)
            {
                GameManager.instance.AddLevelUnlocked(LevelsThatThisUnlocks[i]);
            }
            SceneManager.LoadScene("Won");
           
        }
    }
}
