using System;
using DG.Tweening;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager instance;
    CustomerSpritesHandler customerSpritesHandler;
    public CustomerObject[] customerObjects;
    public RectTransform initialPosition, endPosition, talkPosition;
    public float transitionDuration;
    public CustomerObject currentCustomerObject;
    void Awake()
    {
        instance = this;
        customerSpritesHandler = GetComponent<CustomerSpritesHandler>();
    }
    void Start()
    {
        for (int i = 0; i < customerObjects.Length; i++)
        {
            customerObjects[i].rectTransform.anchoredPosition = initialPosition.anchoredPosition;
        }
    }

    public void SetNewCustomer(CustomerRequest customerRequest, Action onFinish)
    {
        int rng = UnityEngine.Random.Range(0, customerSpritesHandler.customers.Length);
        Customer customer = customerSpritesHandler.customers[rng];
        CustomerObject customerObject = ReturnObjectAvailable();
        customerObject.customerImage.sprite = customer.ReturnSpriteByGliph(customerRequest.gliphType);
        customerObject.customerRequest = customerRequest;

        currentCustomerObject = customerObject;
        MoveCustomerToArea(CustomerArea.TalkPosition, customerObject, onFinish);
    }

    public void MoveCustomerToArea(CustomerArea customerArea, CustomerObject co, Action onFinish)
    {
        RectTransform area = initialPosition;
        float delay = 0f;
        switch (customerArea)
        {
            case CustomerArea.Initial:
                delay = 0f;
                area = initialPosition;
                break;
            case CustomerArea.TalkPosition:
                delay = transitionDuration;
                area = talkPosition;
                break;
            case CustomerArea.End:
                delay = transitionDuration;
                area = endPosition;
                break;
        }

        co.rectTransform.DOAnchorPosX(area.anchoredPosition.x, delay).OnComplete(() =>
        {
            if (onFinish != null)
            {
                onFinish?.Invoke();
            }
        });
    }

    public void ValidateCustomer()
    {
        if (currentCustomerObject.customerRequest.MaskValidation())
        {
            Sequence seq = DOTween.Sequence();
            //cliente satisfecho
            seq.Append(ChatController.instance.FinalCustomerLine(true));
            seq.AppendCallback(() =>
            {
                MoveCustomerToArea(CustomerArea.End, currentCustomerObject, ResetCurrentCustomer);
                PointsManager.instance.GainMoney(0);
            });
            seq.AppendInterval(transitionDuration * 2);
            seq.AppendCallback(() =>
            {
                ResetCurrentCustomer();
                ChatController.instance.MakeNewRequest();
            });
        }
    }
    public void ResetCurrentCustomer()
    {
        currentCustomerObject.customerRequest = null;
        MoveCustomerToArea(CustomerArea.Initial, currentCustomerObject, null);
        currentCustomerObject.isAvailable = true;
    }
    public CustomerObject ReturnObjectAvailable()
    {
        for (int i = 0; i < customerObjects.Length; i++)
        {
            if (customerObjects[i].isAvailable)
            {
                customerObjects[i].isAvailable = false;
                return customerObjects[i];
            }
        }
        return null;
    }


}

public enum CustomerArea
{
    Initial, TalkPosition, End
}
