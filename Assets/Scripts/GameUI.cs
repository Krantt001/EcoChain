using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;

    GameManager _gameManager;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();

        _gameManager.PointsChanged += OnPointsChanged;
        _gameManager.LivesChanged += OnLivesChanged;
    }

    void OnDestroy()
    {
        _gameManager.PointsChanged -= OnPointsChanged;
        _gameManager.LivesChanged -= OnLivesChanged;
    }

    void OnPointsChanged(int points)
    {
        _scoreText.text = $"{points}";
    }

    void OnLivesChanged(int lives)
    {
        
    }
}