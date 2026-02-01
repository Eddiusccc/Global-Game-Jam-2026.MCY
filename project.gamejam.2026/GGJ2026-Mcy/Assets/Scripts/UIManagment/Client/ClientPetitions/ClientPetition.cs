using System;
using UnityEngine;

public class CustomerRequest
{
    public MaskType maskType;
    public GemType gemType;
    public GliphType gliphType;
    
    // public bool 
    //customerRequest

    public void SetNewCustomerRequest(int rng1, int rng2, int rng3)
    {
        maskType = (MaskType)rng1;
        gemType = (GemType)rng2;
        gliphType = (GliphType)rng3;
    }

    public bool MaskValidation()
    {
        return true;
    }
}
