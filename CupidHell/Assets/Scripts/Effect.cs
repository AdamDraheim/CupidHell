using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{

    protected int effectID;
    protected bool stackable;

    public abstract void UpdateEffect();

    public bool GetStackable()
    {
        return this.stackable;
    }

    public int getID()
    {
        return this.effectID;
    }

    

}
