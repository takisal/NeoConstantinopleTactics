using UnityEngine;
using UnityEngine.EventSystems;

public class PointerEventsController2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject RCTT;
    public EquipRoomManager ERM;
    public bool filled;
    public bool onButton;
    private int inty;
    private string stringy;
    public void setRCTT(GameObject _RCTT, EquipRoomManager _ERM, int _int, string _string)
    {
        RCTT = _RCTT;
        ERM = _ERM;
        inty = _int;
        stringy = _string;
    }
    public void setFilled(bool _filled)
    {
        filled = _filled;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            ERM.Unequip(stringy, inty);
        } 
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        onButton = true;
        if (filled)
        {
            RCTT.SetActive(true);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onButton = false;
        RCTT.SetActive(false);

    }
    void Update()
    {
        
        if (RCTT.activeSelf)
        {
            
            Vector3 mimicPos = Input.mousePosition;
            mimicPos.x += 100.0f;
            mimicPos.y += 12.0f;
            mimicPos.z = RCTT.transform.position.z;
            RCTT.transform.position = mimicPos;
            
        } 
        
    }
}
