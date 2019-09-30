using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Fish_JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    Image backGround;
    Image joyStickImg;
    Vector3 inputVector;
    private void Start()
    {
        backGround = GetComponent<Image>();
        joyStickImg = transform.GetChild(0).GetComponent<Image>();

    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backGround.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = pos.x / backGround.rectTransform.sizeDelta.x;
            pos.y = pos.y / backGround.rectTransform.sizeDelta.y;

            inputVector = new Vector3(pos.x * 2, pos.y * 2, 0);
            inputVector = inputVector.magnitude > 1.0f ? inputVector.normalized : inputVector;

            joyStickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * backGround.rectTransform.sizeDelta.x / 3, inputVector.y * backGround.rectTransform.sizeDelta.y / 3);

        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joyStickImg.rectTransform.anchoredPosition = Vector3.zero;

    }

    public float GetHorizontalValue()
    {
        return inputVector.x;
    }
    public float GetVerticalValue()
    {
        return inputVector.y;
    }
}
