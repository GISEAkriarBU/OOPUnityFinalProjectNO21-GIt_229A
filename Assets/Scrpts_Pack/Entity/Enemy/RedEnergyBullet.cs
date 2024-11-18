using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnergyBullet : _Weapon
{
    [SerializeField] private Rigidbody2D rb2d;
    private float speed;

    public override void OnHitWith(Entity player) { if (player is Player) { player.TakeDamage(this.Damage); Destroy(this.gameObject); }  else if (player is not Player) { Destroy(this.gameObject); } }

    private void Start()
    {
        Damage = 10;
        speed = 4.0f ;
    }

    private void FixedUpdate()
    {

        Move();
    }
    public override void Move()
    {
        float newLocationX = transform.position.x - speed * Time.fixedDeltaTime;
        float newLocationY = transform.position.y;
        Vector2 newPosition = new Vector2(newLocationX, newLocationY);
        transform.position = newPosition;
    }
    
}
