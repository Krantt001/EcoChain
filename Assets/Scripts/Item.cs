using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] float _speed;
    [SerializeField] SpriteRenderer _spriteRenderer;
    
    ItemData _itemData;
    
    public ItemData ItemData {
        get => _itemData;
        set
        {
            _itemData = value;
            _spriteRenderer.sprite = value.Sprite;
        }
    }

    void Update()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _transform.position + Vector3.left,
            _speed * Time.deltaTime);
    }
}