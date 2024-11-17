using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnergyBullet : _Weapon
{
    private float speed;
    public override void OnHitWith(Entity player) { if (player is Player ) { player.TakeDamage(this.Damage); } }
    public override void Move()
    {
        float newLocationX = transform.position.x + speed * Time.fixedDeltaTime;
        float newLocationY = transform.position.y;
        Vector2 newPosition = new Vector2(newLocationX, newLocationY);
        transform.position = newPosition;
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;

    }
}
