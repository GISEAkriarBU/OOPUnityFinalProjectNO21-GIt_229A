﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BlueEnergyBullet : _Weapon //override มาจาก _Weapon  
{
    private float speed;
    public override void OnHitWith(Entity enemy) //polymorph
    { if (enemy is Enemy) { enemy.TakeDamage(this.Damage); Destroy(this.gameObject); } else if (enemy is not Enemy){ Destroy(this.gameObject); } }

    private void Start()
    {
        speed = 10.0f ;
    }

    private void FixedUpdate()
    {

        Move();
    }
    
    

    public override void Move()//polymorph
    {
        
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
    


}
