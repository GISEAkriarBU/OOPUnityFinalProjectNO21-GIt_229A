using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BlueEnergyBullet : _Weapon
{
    private float speed;
    public override void OnHitWith(Entity enemy) { if (enemy is Enemy) { enemy.TakeDamage(this.Damage); } }
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
    private void Start()
    {
        speed = 4.0f * GetShootDirection();
    }

    private void FixedUpdate()
    {

        Move();
    }


}
