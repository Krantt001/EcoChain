using System;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField] Player _owner;
    [SerializeField] ItemType _acceptedType;
    [SerializeField] int _capacity;
    [SerializeField] AudioClip _correctSound;
    [SerializeField] AudioClip _errorSound;

    AudioSource _audioSource;
    
    int _count;

    public Player Owner => _owner;
    public ItemType AcceptedType => _acceptedType;
    
    public static event Action<Bin> BinFull;

    void Awake()
    {
        _audioSource = FindObjectOfType<AudioSource>();
    }

    public void Accept(Player player, ItemData itemData)
    {
        if (player != _owner || itemData == null)
            return;

        if (itemData.ItemType != _acceptedType)
        {
            _audioSource.PlayOneShot(_errorSound);
            return;
        }

        _count++;
        _owner.Points++;
        _owner.Pickup = null;
        _audioSource.PlayOneShot(_correctSound);

        if (_count >= _capacity)
        {
            BinFull?.Invoke(this);
            _count = 0;
        }
    }
}