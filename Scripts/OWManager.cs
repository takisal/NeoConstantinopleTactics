using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OWManager : MonoBehaviour
{
    [SerializeField]
    public GameObject owchar;
    [SerializeField]
    private float destX = -675.0f;
    [SerializeField]
    private float destY = -359.0f;
    private bool clickedSpot;
    private string queuedLev;
    // Start is called before the first frame update
    void Start()
    {
       
        Vector3 startSpot = new Vector3(GameManager.instance.owX, GameManager.instance.owY, owchar.transform.localPosition.z);
        if (startSpot.x == 0 && startSpot.z == 0 )
        {
            (float newdestX, float newdestY) = DataSaver.loadDataNewton<(float, float)>("OWSpot");
            startSpot.x = newdestX;
            startSpot.y = newdestY;
        }
        
        clickedSpot = false;
        destX = startSpot.x;
        destY = startSpot.y;
        owchar.transform.localPosition = startSpot;
        Debug.Log(owchar.transform.localPosition);
    }

    // Update is called once per frame
    void Update()
    {
        bool noneUpdated = true;
        Vector3 mimc = owchar.transform.localPosition;
        if (owchar.transform.localPosition.x < destX)
        {
                owchar.transform.localPosition = mimc + (new Vector3(1f, 0.0f, 0.0f));
            if (owchar.transform.localPosition.x > destX)
            {
                owchar.transform.localPosition = new Vector3(destX, owchar.transform.localPosition.y, owchar.transform.localPosition.z);
            }
            noneUpdated = false;
        }
        if (owchar.transform.localPosition.x > destX)
        {
            owchar.transform.localPosition = mimc + (new Vector3(-1f, 0.0f, 0.0f));
            if (owchar.transform.localPosition.x < destX)
            {
                owchar.transform.localPosition = new Vector3(destX, owchar.transform.localPosition.y, owchar.transform.localPosition.z);
            }
            noneUpdated = false;
        }
        mimc = owchar.transform.localPosition;
        if (owchar.transform.localPosition.y < destY)
        {
            owchar.transform.localPosition = mimc + (new Vector3(0.0f, 1f, 0.0f));
            if (owchar.transform.localPosition.y > destY)
            {
                owchar.transform.localPosition = new Vector3(owchar.transform.localPosition.x, destY, owchar.transform.localPosition.z);
            }
            noneUpdated = false;
        }
        if (owchar.transform.localPosition.y > destY)
        {
            owchar.transform.localPosition = mimc + (new Vector3(0.0f, -1f, 0.0f) ) ;
            if (owchar.transform.localPosition.y < destY)
            {
                owchar.transform.localPosition = new Vector3(owchar.transform.localPosition.x, destY, owchar.transform.localPosition.z);
            }
            noneUpdated = false;
        }
        if (noneUpdated == true && clickedSpot)
        {
            GameManager.instance.owX = owchar.transform.localPosition.x;
            GameManager.instance.owY = owchar.transform.localPosition.y;
            SceneManager.LoadScene(queuedLev);
        }
    }
    public void LocationClicked(int spot)
    {
        switch (spot)
        {
            case 1:
                if (GameManager.instance.CheckIfLevelUnlocked("Shop1") == false)
                {
                    return;
                }
                clickedSpot = true;
                destX = -660.0f;
                destY = -231.0f;
                DataSaver.saveDataNewton<(float, float)>((destX, destY), "OWSpot");
                queuedLev = "Shop1";
                break;
            case 2:
                if (GameManager.instance.CheckIfLevelUnlocked("Level1") == false)
                {
                    return;
                }
                clickedSpot = true;
                destX = -568.0f;
                destY = -49.0f;
                GameManager.instance.owX = destX;
                GameManager.instance.owY = destY;
                DataSaver.saveDataNewton<(float, float)>((destX, destY), "OWSpot");
                queuedLev = "CharSelect";
                GameManager.instance.numOfEnemies = 5;
                GameManager.instance.enemyLev = 1;
                GameManager.instance.nextStage = "Level1";
                break;
            case 3:
                if (GameManager.instance.CheckIfLevelUnlocked("Shop2") == false)
                {
                    return;
                }
                clickedSpot = true;
                destX = -440.0f;
                destY = -147.0f;
                DataSaver.saveDataNewton<(float, float)>((destX, destY), "OWSpot");
                queuedLev = "Shop2";
                break;
            case 4:
                if (GameManager.instance.CheckIfLevelUnlocked("Level2") == false)
                {
                    return;
                }
                clickedSpot = true;
                destX = -298.0f;
                destY = -297.0f;
                GameManager.instance.owX = destX;
                GameManager.instance.owY = destY;
                DataSaver.saveDataNewton<(float, float)>((destX, destY), "OWSpot");
                queuedLev = "CharSelect";
                GameManager.instance.numOfEnemies = 5;
                GameManager.instance.enemyLev = 4;
                GameManager.instance.nextStage = "Level2";
                break;
            default:
                break;
        }
    }
}
