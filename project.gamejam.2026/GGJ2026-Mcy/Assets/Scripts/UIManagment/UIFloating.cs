using DG.Tweening;
using UnityEngine;

public class UIFloating : MonoBehaviour
{
    public float extension;
    public float delay;


    void Start()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.DOAnchorPosY(rect.anchoredPosition.y + extension, delay).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
