using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BlueEnergyBullet : Weapon
{
    private float speed;
    public override void OnHitWith(Entity enemyObject) { if (enemyObject is Enemy) { enemyObject.TakeDamage(this.Damage); } }
    public override void Move() 
    {
        float newLocationX = transform.position.x + speed * Time.fixedDeltaTime;
        float newLocationY = transform.position.y;
        Vector2 newPosition = new Vector2(newLocationX, newLocationY);
        transform.position = newPosition;

    }
}
