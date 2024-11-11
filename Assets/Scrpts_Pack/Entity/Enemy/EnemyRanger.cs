using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanger : Enemy
{
    public GameObject player;
    private float distance;
    public override void OnHitWith(Entity player) { }
    public override void Behaviour() 
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

    }
}
