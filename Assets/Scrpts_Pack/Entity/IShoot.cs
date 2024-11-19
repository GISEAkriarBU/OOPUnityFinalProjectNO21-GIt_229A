using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShoot //abstract interfere ไว้ให้สำหรับ entity ที่มีความสามารถในการ ยิง ได้
{
    Transform BulletSpawn { get; set; }
    GameObject Bullet { get; set; }
    float BulletTimer { get; set; }
    float BulletWaitTime { get; set; }
    void Shoot();
}
