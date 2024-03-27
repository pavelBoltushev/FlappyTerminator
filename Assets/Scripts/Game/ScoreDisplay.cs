using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    private TMP_Text _scoreView;

    private void Start()
    {
        _scoreView = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _bird.ScoreChanged += ChangeScoreView;        
    }

    private void OnDisable()
    {
        _bird.ScoreChanged -= ChangeScoreView;
    }

    private void ChangeScoreView(int value)
    {
        _scoreView.text = value.ToString();
    }
}
