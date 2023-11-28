using Unity.VisualScripting;
using UnityEngine;

public class CameraControllerScipt : MonoBehaviour
{
    public float speed = 25.0f;
    public float sensitivity = 5.0f;
    private int overheadToggle = 0;
    // Update is called once per frame
    void Update()
    {
        // Move the camera forward, backward, left, and right
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            float ypos = transform.position.y;
            
            transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.position += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            Vector3 newPos = transform.position;
            newPos.y = ypos;
            transform.position = newPos;
            MenuManager.instance.updateActionMenuPosition();
        }
        
        // Rotate the camera based on the mouse movement
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.eulerAngles += new Vector3(0, 5.0f, 0);
            MenuManager.instance.updateActionMenuPosition();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.eulerAngles += new Vector3(0, -5.0f, 0);
            MenuManager.instance.updateActionMenuPosition();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {

            if (overheadToggle%2 == 0)
            {
                GameObject mainCamera = GameObject.Find("CameraController/MainCamera");
                Debug.Log(mainCamera.transform.eulerAngles.x.ToString());
                transform.eulerAngles = new Vector3(90.0f - (mainCamera.transform.eulerAngles.x - transform.eulerAngles.x), 0, 0);
                transform.position = new Vector3(0, 50.0f, 0);
            } else
            {
                transform.eulerAngles = new Vector3(10.0f, 0, 0);
                transform.position = new Vector3(0, 30.0f, -51.0f);
            }
            overheadToggle++;
            MenuManager.instance.updateActionMenuPosition();

        }
        /*
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);
        */
    }
}
