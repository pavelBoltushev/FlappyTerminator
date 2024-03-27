using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bird))]
public class BirdShooter : Shooter
{
    private Bird _bird;

    private void Start()
    {
        _bird = GetComponent<Bird>();
    }

    public override void Shoot()
    {
        BirdProjectile spawned = (BirdProjectile)Instantiate(Projectile, transform.position, transform.rotation);
        spawned.Init(_bird);
    }
}
