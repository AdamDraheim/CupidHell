using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private int health;

    public int Health { get { return health; } set => health = value; }

    public abstract void Hurt();
}
