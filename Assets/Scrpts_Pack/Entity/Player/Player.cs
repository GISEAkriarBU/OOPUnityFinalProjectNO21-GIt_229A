using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity,IShoot
{
    [SerializeField]
    private Transform bulletSpawn;
    public Transform BulletSpawn { get { return bulletSpawn; } set { bulletSpawn = value; } }

    [SerializeField]
    private GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }

    [field: SerializeField] public float BulletTimer { get; set; }
    [field: SerializeField] public float BulletWaitTime { get; set; }


    private void Update() { Shoot(); }
    void FixedUpdate() { BulletWaitTime += Time.deltaTime; }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && BulletWaitTime >= BulletTimer)
        {
            GameObject obj = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
            BlueEnergyBullet bEnergy = obj.GetComponent<BlueEnergyBullet>();
            bEnergy.Init(20, this);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null) { OnHitWith(enemy); }
    }
    public void OnHitWith(Enemy enemy) { TakeDamage(enemy.DamageHit); }

}
