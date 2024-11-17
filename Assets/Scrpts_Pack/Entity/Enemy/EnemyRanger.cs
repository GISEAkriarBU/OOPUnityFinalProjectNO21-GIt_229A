using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanger : Enemy , IShoot
{
    public GameObject player;
    public GameObject Bullet { get; set; }
    public Transform BulletSpawn { get; set; }
    public float BulletTimer { get; set; }
    public float BulletWaitTime { get; set; } = 2.0f; // Time between shots

    private float distance;
    public float shootingRange = 10f; // Distance to start shooting
    public override void OnHitWith(Entity entity) { if (entity is Player) { entity.TakeDamage(this.DamageHit); } }

    private void Start()
    {
        // Initialize bullet spawn point (e.g., a child object)
        BulletSpawn = transform.Find("BulletSpawnPoint");
        BulletTimer = BulletWaitTime;
    }

    private void Update()
    {
        Behaviour();
        BulletTimer -= Time.deltaTime;
        if (distance <= shootingRange && BulletTimer <= 0)
        {
            Shoot();
            BulletTimer = BulletWaitTime;
        }
    }

    public override void Behaviour()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        // Track the player without moving closer (optional logic to add)
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    public void Shoot()
    {
        if (Bullet != null && BulletSpawn != null)
        {
            GameObject obj = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
            RedEnergyBullet rEnergy = obj.GetComponent<RedEnergyBullet>();
            rEnergy.Init(20, this);
        }
    }
}
