using UnityEngine;
using UnityEngine.UI;

public class CustomerObject : MonoBehaviour
{
    public bool isAvailable = false;

    [HideInInspector] public RectTransform rectTransform;
    [HideInInspector] public Image customerImage;
    [HideInInspector] public CustomerRequest customerRequest;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        customerImage = GetComponent<Image>();
    }
}
