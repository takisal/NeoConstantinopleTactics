using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteBillboard : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, 0f);

        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-5.0f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(5.0f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 5.0f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -5.0f);
        }
        */
    }
   
    void OnMouseDown()
    {
        /*
        if (MenuManager.instance.activeCharacter == null)
        {
            MenuManager.instance.setTargetMenuEnable(false);
            MenuManager.instance.activeCharacter = this.gameObject;
            MenuManager.instance.NewActive();
            return;
        }
        MenuManager.instance.targetedCharacter = this.gameObject;
        CharacterPage charPageActive = MenuManager.instance.turnTaker.GetComponent<CharacterPage>();
        CharacterPage charPageTarget = MenuManager.instance.targetedCharacter.GetComponent<CharacterPage>();
        MenuManager.instance.NewActiveTargetHUD();
        if (MenuManager.instance.activeCharacter == MenuManager.instance.turnTaker && charPageActive.getPrepAttack() && this.gameObject != MenuManager.instance.activeCharacter)
        {
          
            charPageActive.Attack(charPageTarget);
        }
        Debug.Log("Sprite Clicked " + this.gameObject.name);
        MenuManager.instance.NewActiveTargetHUD();
        */
    }
}
