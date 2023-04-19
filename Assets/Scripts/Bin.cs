using System;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField] Player _owner;
    [SerializeField] ItemType _acceptedType;
    [SerializeField] int _capacity;

    int _count;

    public Player Owner => _owner;
    public ItemType AcceptedType => _acceptedType;
    
    public static event Action<Bin> BinFull;

    public void Accept(Player player, ItemData itemData)
    {
        if (player != _owner || itemData == null)
            return;
        
        if (itemData.ItemType == _acceptedType)
        {
            _count++;
            _owner.Points++;
            _owner.Pickup = null;

            if (_count >= _capacity)
            {
                BinFull?.Invoke(this);
                _count = 0;
            }
        }
    }
}