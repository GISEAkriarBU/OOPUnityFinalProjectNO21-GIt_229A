using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private int health;
    public int Health { get { return health; } set { health = value; } }
    public Animator anim;
    public Rigidbody2D rb;
    public void Init(int newHealth) { Health = newHealth; }

    public bool Isdead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        return Health <= 0;
    }
    public void TakeDamage(int damage) 
    {
        Health -= damage;
        Debug.Log($"{this.name} took {damage} remaining {this.Health} ");
        Isdead();
    }
}
