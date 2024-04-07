using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdProjectile : Projectile
{
    private Bird _bird;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            _bird.AddScore();
            Destroy(gameObject);
        }
    }

    public void Init(Bird bird)
    {
        _bird = bird;
    }
}
