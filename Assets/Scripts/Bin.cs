using System;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField] ItemType _acceptedType;
    [SerializeField] int _capacity;

    int _count;

    public event Action<Bin> BinFull;
    
    public void Accept(ItemData itemData)
    {
        if (itemData.ItemType == _acceptedType)
        {
            _count++;

            if (_count >= _capacity)
            {
                BinFull?.Invoke(this);
                _count = 0;
            }
        }
        else
        {
            // Mauvais objet
        }
    }
}