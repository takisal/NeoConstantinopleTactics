using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSpot : MonoBehaviour
{
    [SerializeField]
    public CSManager csManager;
    [SerializeField]
    public int xCoord;
    [SerializeField]
    public int zCoord;
    [SerializeField]
    public GameObject glowie;
    [SerializeField]
    public GameObject charOnSpot;
    [SerializeField]
    public CharacterStats statsOnSpot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        OnClicky();
    }
    private void OnMouseEnter()
    {
        if ( csManager.queuedSpot == null)
        {
            glowie.SetActive(true);
        }
        
    }
    private void OnMouseExit()
    {
        if ( csManager.queuedSpot == null)
        {
            glowie.SetActive(false);
        }
    }
    public void OnClicky()
    {
        glowie.SetActive(true);
        csManager.queuedSpot = this;
        if ((csManager.queuedChar == null || csManager.queuedChar.SpriteName == null))
        {
        } else
        {
            addCharToSpot();
        }
    }
    public void addCharToSpot()
    {
        if (charOnSpot != null)
        {
            GameManager.instance.SelectedChars.Remove(statsOnSpot);
            Destroy(charOnSpot);
            charOnSpot = null;
            statsOnSpot = null;
            csManager.charCurrent--;
        }
        if (csManager.charCurrent == csManager.charCap)
        {
            glowie.SetActive(false);
            csManager.clearQueue();
            csManager.updateLabel();
            return;
        }
        CharacterStats curChar = csManager.queuedChar;
        GameObject charToSpawn = new GameObject();
        SpriteRenderer spriteRendComp = charToSpawn.AddComponent<SpriteRenderer>();
        spriteRendComp.sprite = Resources.Load<Sprite>(curChar.SpriteName);
        charToSpawn.AddComponent<SpriteBillBoardPure>();
        charToSpawn.transform.position = new Vector3(gameObject.transform.position.x, 5f, gameObject.transform.position.z);
        csManager.clearQueue();
        curChar.X = xCoord;
        curChar.Z = zCoord;
        GameManager.instance.SelectedChars.Add(curChar);
        statsOnSpot = curChar;
        charOnSpot = charToSpawn;
        glowie.SetActive(false);
        csManager.charCurrent++;
        csManager.updateLabel();
    }
}
