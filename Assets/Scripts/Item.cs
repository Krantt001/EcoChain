using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] float _speed;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] GameObject hitSFX;

    ItemData _itemData;

    Camera _mainCamera;

    public bool IsOnConveyor { get; set; } = true;
    public Vector3 Direction { get; set; }
    
    public ItemData ItemData {
        get => _itemData;
        set
        {
            _itemData = value;
            _spriteRenderer.sprite = value.Sprite;
        }
    }

    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (IsOnConveyor)
        {
            var destination = _transform.position + Direction;
            _transform.position = Vector3.MoveTowards(_transform.position, destination, _speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Hammer _))
        {
            Destroy(gameObject);
            GameObject itemHitSFX = Instantiate(hitSFX);
            itemHitSFX.transform.position = this.transform.position;
            itemHitSFX.transform.localScale = new Vector3(5, 5);
        }
    }
}