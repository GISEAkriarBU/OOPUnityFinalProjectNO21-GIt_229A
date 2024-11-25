using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class _Weapon : MonoBehaviour 
{
    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } set { damage = value; } }

    protected IShoot shooter;
    public abstract void OnHitWith (Entity entity);//override ไปสู่อาวุธสองชิ้น 
    public abstract void Move (); //override ไปสู่อาวุธสองชิ้น 

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

   
}
