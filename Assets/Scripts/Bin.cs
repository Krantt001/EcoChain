using System;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField] ItemType _acceptedType;
    [SerializeField] int _capacity;

    int _count;

    GameManager _gameManager;

    public event Action<Bin> BinFull;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void Accept(ItemData itemData)
    {
        if (itemData.ItemType == _acceptedType)
        {
            _count++;
            _gameManager.Points++;

            if (_count >= _capacity)
            {
                BinFull?.Invoke(this);
                _count = 0;
            }
        }
        else
        {
            _gameManager.Lives--;
        }
    }
}