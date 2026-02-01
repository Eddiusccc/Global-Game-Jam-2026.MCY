using System;
using UnityEngine;

public class CustomerSpritesHandler : MonoBehaviour
{
    public Customer[] customers;

    void OnValidate()
    {
        for (int i = 0; i < customers.Length; i++)
        {
            customers[i].SetNames();
        }
    }
}
[Serializable]
public class Customer
{
    public string customerName;
    public CustomerFace[] customerFaces;


    public Sprite ReturnSpriteByGliph(GliphType _gliphType)
    {
        for (int i = 0; i < customerFaces.Length; i++)
        {
            if(customerFaces[i].gliphType == _gliphType)
            {
                return customerFaces[i].sprite;
            }
        }
        return null;
    }
    public void SetNames()
    {
        for (int i = 0; i < customerFaces.Length; i++)
        {
            customerFaces[i].SetName();
        }
    }
}

[Serializable]
public class CustomerFace
{
    public string name;
    public Sprite sprite;
    public GliphType gliphType;

    public void SetName()
    {
        name = gliphType.ToString();
    }

}
