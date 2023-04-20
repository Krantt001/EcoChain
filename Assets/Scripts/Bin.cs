using System.Collections;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField] Player _owner;
    [SerializeField] ItemType _acceptedType;
    [SerializeField] AudioClip _correctSound;
    [SerializeField] AudioClip _errorSound;
    [SerializeField] GameObject _effect;
    [SerializeField] SpriteRenderer _outline;
    [SerializeField] GameObject _sign;

    AudioSource _audioSource;
    
    public Player Owner => _owner;
    public ItemType AcceptedType => _acceptedType;
    public bool IsLocked { get; private set; }
    
    void Awake()
    {
        _audioSource = FindObjectOfType<AudioSource>();
    }

    public void Accept(Player player, ItemData itemData)
    {
        player.Pickup = null;
        
        if (IsLocked)
        {
            _audioSource.PlayOneShot(_errorSound);
            return;
        }
        
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

        _owner.Points++;
        _audioSource.PlayOneShot(_correctSound);
        StartCoroutine(ShowOutline(Color.green));
    }

    public void Lock()
    {
        IsLocked = true;
        Invoke(nameof(Unlock), 3f);
        
        _outline.gameObject.SetActive(true);
        _outline.color = Color.black;
        _sign.SetActive(true);
    }
    
    void Unlock()
    {
        _sign.SetActive(false);
        IsLocked = false;
        _outline.gameObject.SetActive(false);
    }

    IEnumerator ShowOutline(Color color)
    {
        _outline.gameObject.SetActive(true);

        _outline.color = color;

        yield return new WaitForSeconds(0.5f);
        
        _outline.gameObject.SetActive(false);
    }
}