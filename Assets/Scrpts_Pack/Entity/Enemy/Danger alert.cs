using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dangeralert : Enemy , IShoot //override มาจาก Enemy  และ ใช้ interfere จาก IShoot
{
    
    public float Speed;
   
    [SerializeField] private Player player;
    // Distance เพื่อใช้ dectect ระยะ
    private float distance;
    public float ShootingRange = 10f;

    [SerializeField]
    private GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }

    [SerializeField]
    private Transform bulletSpawn;
    public Transform BulletSpawn { get { return bulletSpawn; } set { bulletSpawn = value; } }

    [field: SerializeField]
    public float BulletTimer { get; set; }
    [field: SerializeField]
    public float BulletWaitTime { get; set; }
    private void Start()
    {
        this.DamageHit = 20;
        Debug.Log($" enemy chase at you");
        Init(60);
    }
    private void FixedUpdate()
    {
        BulletWaitTime += Time.deltaTime;
        Behaviour();
    }

    public override void OnHitWith(Entity entity) { if (entity is Player) { entity.TakeDamage(this.DamageHit);  } }

    public override void Behaviour()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Speed * Time.deltaTime);
        //for shoot
        float distanceP = direction.magnitude;
        if (distanceP <= ShootingRange) { Shoot(); }

    }
    public void Shoot()
    {
        if (BulletWaitTime >= BulletTimer)
        {
            GameObject obj = Instantiate(bullet, BulletSpawn.position, Quaternion.identity);
            RedEnergyBullet rEnergy = obj.GetComponent<RedEnergyBullet>();
            rEnergy.Init(20, this);

            BulletWaitTime = 0;
        }
    }
}
