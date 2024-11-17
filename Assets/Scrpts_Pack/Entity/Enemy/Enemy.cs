using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class Enemy : MonoBehaviour
{
    private int damagehit;
    public int DamageHit { get { return damagehit; } set { damagehit = value; } }
    public abstract void OnHitWith(Entity entity);
    public abstract void Behaviour();
    private void Start () { Behaviour(); }
}
