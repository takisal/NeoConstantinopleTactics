using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ValidSpot : MonoBehaviour
{
    public List<(float, float, float, int, int, int)> potentialTrip;
    public bool isActive;
    public bool isAttackPrep;
    public bool characterIsOnSpot;
    public GameObject characterOnSpot;
    [SerializeField]
    public bool characterCanUse;
    [SerializeField]
    public int fakeX;
    [SerializeField]
    public int fakeZ;
    [SerializeField]
    public GameObject glowie;
    [SerializeField]
    public GameObject hoverspot;
    // Start is called before the first frame update
    public void setTrip(List<(float, float, float, int, int, int)> newtrip) { potentialTrip = newtrip; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {

        if (MenuManager.instance.getAiTurn() == false)
        {
            if (!characterIsOnSpot)
            {
                MenuManager.instance.TargetedCharacter = null;
                MenuManager.instance.setTargetMenuEnable(false);
                
            }
            else
            {
                
                MenuManager.instance.setTargetMenuEnable(true);
                MenuManager.instance.TargetedCharacter = characterOnSpot;
                MenuManager.instance.NewActiveTargetHUD();
                MenuManager.instance.setPredictDmg();
            }
        }
        hoverspot.SetActive(true);
    }
    private void OnMouseExit()
    {
        //unshow targethut
        if (MenuManager.instance.getAiTurn() == false)
        {
            MenuManager.instance.TargetedCharacter = null;
            MenuManager.instance.setTargetMenuEnable(false);
            MenuManager.instance.setPrediction(false);
        }
        hoverspot.SetActive(false);
            
    }
    public void setFakeZ(int newfake)
    {
        fakeZ = newfake;
    }
    public void setFakeX(int newfake)
    {
        fakeX = newfake;
    }
    public GameObject GetCharacterOnSpot()
    {
        return characterOnSpot;
    }
    public void setCharacterOnSpot(GameObject charOnSpot)
    {
        characterOnSpot = charOnSpot;
    }
    public void setCharacterIsOnSpot(bool charOnSpot)
    {
        characterIsOnSpot = charOnSpot;
    }
    public void setActiveBool(bool isAct)
    {
        isActive = isAct;
    }
    public void setAttackPrepBool(bool isAct)
    {
        isAttackPrep = isAct;
    }
    public bool getActive()
    {
        return isActive;
    }
    void OnMouseDown()
    {
        if (MenuManager.instance.getAiTurn() == true) {
            return;
         }
        
        if (isActive)
        {
            if (!characterOnSpot)
            {
                CharacterPage charPage = MenuManager.instance.ActiveCharacter.GetComponent<CharacterPage>();
                int xCoord = (int)((this.gameObject.transform.position.x - 4) / 8);
                int zCoord = (int)((this.gameObject.transform.position.z - 4) / 8);
                MenuManager.instance.PostMove();
                charPage.setDest(xCoord, zCoord, potentialTrip);
                MenuManager.instance.unprepareMove();
                MenuManager.instance.setMoveToggle(0);
            }
        } else if (isAttackPrep && characterOnSpot)
        {
            CharacterPage charPageActive = MenuManager.instance.TurnTaker.GetComponent<CharacterPage>();
            if (charPageActive.IsAttackPrepping)
            {
                CharacterPage charPageTarget = MenuManager.instance.TargetedCharacter.GetComponent<CharacterPage>();
                if (MenuManager.instance.ActiveCharacter == MenuManager.instance.TurnTaker && charPageActive.getPrepAttack() && this.gameObject != MenuManager.instance.ActiveCharacter)
                {
                    charPageActive.Attack(charPageTarget);
                }
            }
        }
        MenuManager.instance.NewActiveTargetHUD();
    }
}
