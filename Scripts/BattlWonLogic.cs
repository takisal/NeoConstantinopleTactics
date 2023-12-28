using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattlWonLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnContinueButton()
    {
        SceneManager.LoadScene(GameManager.instance.nextSceneName);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
