using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] Image _image;

    void Start()
    {
        _player.PointsChanged += OnPointsChanged;
        _player.PickupChanged += OnPickupChanged;
    }

    void OnDestroy()
    {
        _player.PointsChanged -= OnPointsChanged;
        _player.PickupChanged -= OnPickupChanged;
    }

    void OnPointsChanged(int points)
    {
        _scoreText.text = $"{points}";
    }

    void OnPickupChanged(ItemData pickup)
    {
        if (pickup == null)
        {
            _image.sprite = null;
            _image.color = Color.clear;
            return;
        }

        _image.sprite = pickup.Sprite;
        _image.color = Color.white;
    }
}