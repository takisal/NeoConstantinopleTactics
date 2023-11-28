using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CSManager : MonoBehaviour
{
    [SerializeField]
    public GameObject ScrollingWindow;
    [SerializeField]
    public CharacterStats queuedChar;

    [SerializeField]
    public SelectionSpot queuedSpot;
    [SerializeField]
    public int charCap;
    [SerializeField]
    public int charCurrent;
    [SerializeField]
    public GameObject charLabel;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SelectedChars = new List<CharacterStats>();
        queuedChar = null;
        //load all chars
        List<CharacterStats> allChars = DataSaver.loadDataNewton<List<CharacterStats>>("characters");

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
            newbtnCont.transform.localPosition = new Vector3(-603.0f + (120.0f * i), 10.0f, 0.0f);
            Button btn = newbtnCont.AddComponent<Button>();
            btn.onClick.AddListener(delegate { OnCharClicky(curChar); });
            btn.transform.localPosition = new Vector3(-603.0f + (120.0f * i), 10.0f, 0.0f);
            btn.transform.localScale = new Vector3(1.0f, 1.0f, 1);
            Debug.Log("Spritename: " + curChar.SpriteName);
            btn.targetGraphic = Resources.Load<Image>("clearbg");
            Sprite imgToAdd = Resources.Load<Sprite>(curChar.SpriteName);
            Image imgAdded = newbtnCont.AddComponent<Image>();
            imgAdded.sprite = imgToAdd;
            imgAdded.rectTransform.sizeDelta = new Vector2(120, 120);
            imgAdded.preserveAspect = true;
            imgAdded.useSpriteMesh = true;
        }
        updateLabel();
    }

    public void continueToBattle()
    {
        DataSaver.saveDataNewton(GameManager.instance.SelectedChars, "players");
        SceneManager.LoadScene(GameManager.instance.nextStage);
    }
    
    public void clearQueue()
    {
        queuedChar = null;
        queuedSpot = null;
    }
    public void OnCharClicky(CharacterStats curChar)
    {
        queuedChar = curChar;
        if (queuedSpot != null)
        {
            queuedSpot.addCharToSpot();
        } 
        
    }
    public void updateLabel()
    {
        TextMeshProUGUI txt = charLabel.GetComponent<TextMeshProUGUI>();
        txt.text = charCurrent.ToString() +"/"+charCap.ToString();
        if (charCurrent == charCap)
        {
            txt.color = Color.red;
        } else
        {
            txt.color = Color.black;
        }
    }
}
