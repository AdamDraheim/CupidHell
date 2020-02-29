using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    public Dictionary<int, Effect> effectDict;

    private int currentID = 0;

    // Start is called before the first frame update
    void Start()
    {
        effectDict = new Dictionary<int, Effect>();
    }

    public void Update()
    {
        IterateEffects();

    }

    public int AddEffect(Effect effect)
    {

        currentID++;
        effectDict.Add(currentID, effect);
        return currentID;
    }

    private void IterateEffects()
    {
        foreach(Effect effect in effectDict.Values)
        {
            effect.UpdateEffect();
        }
    }



}
