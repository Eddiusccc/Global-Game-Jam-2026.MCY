using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ClickableItem : MonoBehaviour, IPointerDownHandler
{

    public Action clickAction;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        clickAction?.Invoke();
        // Additional logic for when the item is clicked can be added here
    }
}