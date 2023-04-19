using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Player> _players;
    [SerializeField] TextMeshProUGUI _winText;
    [SerializeField] int _pointLimit;

    void OnEnable()
    {
        _players.ForEach(player => player.PointsChanged += OnPointsChanged);
    }
    
    void OnDisable()
    {
        _players.ForEach(player => player.PointsChanged -= OnPointsChanged);
    }

    void OnPointsChanged(int points)
    {
        if (points >= _pointLimit)
        {
            var player = _players.First(player => player.Points == points);
            _winText.text = $"{player.name} a gagné !";
            _winText.gameObject.SetActive(true);
            Invoke(nameof(ChangeScene), 3);
            OnDisable();
        }
    }
    
    void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}