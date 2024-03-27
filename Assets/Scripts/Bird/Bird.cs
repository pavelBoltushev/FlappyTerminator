using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover), typeof(BirdShooter))]
public class Bird : MonoBehaviour
{
    public event UnityAction<int> ScoreChanged;
    public event UnityAction GameOver;

    private BirdMover _mover;
    private BirdShooter _shooter;
    private int _score;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
        _shooter = GetComponent<BirdShooter>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _shooter.Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out BirdProjectile projectile) == false)
            Die();
    }

    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.ResetBird();
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        GameOver?.Invoke();
        Time.timeScale = 0;
    }
}
