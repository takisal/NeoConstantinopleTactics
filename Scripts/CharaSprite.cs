using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSprite : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, 0f);


    }
}
