using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] float _speed;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Rigidbody2D _rigidbody2D;

    bool _dragging;
    
    ItemData _itemData;

    Camera _mainCamera;
    
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
        _transform.position = Vector3.MoveTowards(_transform.position, _transform.position + Vector3.left,
            _speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Shredder _))
        {
            Destroy(gameObject);
            // TODO : effet de particule explosion ou flamme
        }
    }

    public void OnMouseDown()
    {
        _dragging = true;
        _rigidbody2D.isKinematic = true;
    }

    public void OnMouseDrag()
    {
        if (!_dragging)
            return;

        var mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        _transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }

    public void OnMouseUp()
    {
        if (!_dragging)
            return;

        var hits = new RaycastHit2D[5];
        var size = Physics2D.RaycastNonAlloc(_mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, hits);

        for (int i = 0; i < size; i++)
        {
            var hit = hits[i];
            
            if (hit.collider.TryGetComponent(out Bin bin))
            {
                bin.Accept(ItemData);
                break;
            }
        }

        Destroy(gameObject);
    }
}