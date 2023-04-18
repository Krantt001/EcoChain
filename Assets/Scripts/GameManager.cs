using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _startingLives;
    
    int _points;
    int _lives;
    
    public int Lives
    {
        get => _lives;
        set
        {
            _lives = value;
            LivesChanged?.Invoke(_lives);
        }
    }
    
    public int Points
    {
        get => _points;
        set
        {
            _points = value;
            PointsChanged?.Invoke(_points);
        }
    }

    public Action<int> LivesChanged { get; set; }
    public Action<int> PointsChanged { get; set; }

    void Start()
    {
        _lives = _startingLives;
    }
}