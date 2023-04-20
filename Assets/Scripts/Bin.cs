using System;
using System.Collections;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField] Player _owner;
    [SerializeField] ItemType _acceptedType;
    [SerializeField] int _capacity;
    [SerializeField] AudioClip _correctSound;
    [SerializeField] AudioClip _errorSound;
    [SerializeField] GameObject _effect;
    [SerializeField] SpriteRenderer _outline;

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
        var effect = Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);

        if (player != _owner || itemData == null)
        {
            StartCoroutine(ShowOutline(Color.red));
            return;
        }

        if (itemData.ItemType != _acceptedType)
        {
            StartCoroutine(ShowOutline(Color.red));
            _audioSource.PlayOneShot(_errorSound);
            return;
        }

        _count++;
        _owner.Points++;
        _owner.Pickup = null;
        _audioSource.PlayOneShot(_correctSound);
        StartCoroutine(ShowOutline(Color.green));

        if (_count >= _capacity)
        {
            BinFull?.Invoke(this);
            _count = 0;
        }
    }

    IEnumerator ShowOutline(Color color)
    {
        _outline.gameObject.SetActive(true);

        _outline.color = color;

        yield return new WaitForSeconds(0.5f);
        
        _outline.gameObject.SetActive(false);
    }
}