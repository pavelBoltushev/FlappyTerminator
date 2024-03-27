using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] protected Projectile Projectile;    

    public virtual void Shoot()
    {
        Instantiate(Projectile, transform.position, transform.rotation);
    }
}
