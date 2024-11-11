using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class Weapon : MonoBehaviour
{
    private int damage;
    public int Damage { get { return damage; } set { damage = value; } }

    public IShoot shooter;
    public abstract void OnHitWith(Entity entity);
    public abstract void Move();
    public void Init(int newDamage, IShoot newOwner)
    {
        Damage = newDamage;
        shooter = newOwner;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Entity>());
        Destroy(this.gameObject, 5f);
    }

    public int GetShootDirection()
    {
        float shootDir = shooter.BulletSpawn.position.x - shooter.BulletSpawn.parent.position.x;
        if (shootDir > 0)
            return 1;
        else return -1;
    }
}
