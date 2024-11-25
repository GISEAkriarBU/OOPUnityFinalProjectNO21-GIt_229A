using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemyrampter : Enemy //override มาจาก Enemy
{
    public GameObject player;
    public float Speed;
    private float distance;
    private void Start()
    {
        this.DamageHit = 10;
        Debug.Log($" enemy chase at you");
        Init(20);
    }
    private void FixedUpdate()
    {
        Behaviour();
    }
    
    public override void OnHitWith(Entity entity) { if (entity is Player) { entity.TakeDamage(this.DamageHit);} }
    
    public override void Behaviour() 
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Speed * Time.deltaTime);
    }
   
}
