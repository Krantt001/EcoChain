using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] Image _itemImage;
    
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
            _itemImage.sprite = null;
            _itemImage.color = Color.clear;
            return;
        }

        _itemImage.sprite = pickup.Sprite;
        _itemImage.color = Color.white;
    }
}