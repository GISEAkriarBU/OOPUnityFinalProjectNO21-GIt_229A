using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class Enemy : Entity //ใช้เป็นแม่ฐานเพื่อให้ตัวลูก 3 ตัว overriding
{
    private int damagehit;
    public int DamageHit { get { return damagehit; } set { damagehit = value; } }
    public abstract void OnHitWith(Entity entity);
    public abstract void Behaviour();
    private void Start () { Behaviour();  }
}
