using System;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] Sprite _leftSprite;
    [SerializeField] Sprite _rightSprite;
    [SerializeField] Sprite _upSprite;
    [SerializeField] Sprite _downSprite;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] float _distanceThreshold;
    
    Vector2 direction;
    Vector2 movement;
    
    int _points;

    public int Points
    {
        get => _points;
        set
        {
            _points = value;
            PointsChanged?.Invoke(_points);
        }
    }

    public Action<int> PointsChanged { get; set; }

    ItemData _pickup;

    public ItemData Pickup
    {
        get => _pickup;
        set
        {
            _pickup = value;
            PickupChanged?.Invoke(_pickup);
        }
    }

    public Action<ItemData> PickupChanged { get; set; }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontalInput, verticalInput).normalized;
        movement = direction * 6f * Time.deltaTime;

        transform.Translate(movement, Space.World);

        if (verticalInput > 0)
        {
            _spriteRenderer.sprite = _upSprite;
        }
        else if (verticalInput < 0)
        {
            _spriteRenderer.sprite = _downSprite;
        }
        else if (horizontalInput > 0)
        {
            _spriteRenderer.sprite = _rightSprite;
        }
        else if (horizontalInput < 0)
        {
            _spriteRenderer.sprite = _leftSprite;
        }
    }

    void Interact()
    {
        if (Pickup == null)
        {
            TryPickupClosestItem();
            return;
        }

        TryThrowInBin();
    }

    void TryPickupClosestItem()
    {
        var items = FindObjectsOfType<Item>().ToList();

        var minDistance = float.MaxValue;
        Item closestItem = null;

        foreach (var item in items)
        {
            var distance = Vector3.Distance(_transform.position, item.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestItem = item;
            }
        }

        if (minDistance > _distanceThreshold)
            return;

        closestItem.IsOnConveyor = false;
        Pickup = closestItem.ItemData;
        Destroy(closestItem.gameObject);
    }

    void TryThrowInBin()
    {
        var bins = FindObjectsOfType<Bin>().ToList();

        var minDistance = float.MaxValue;
        Bin closestBin = null;

        foreach (var bin in bins)
        {
            var distance = Vector3.Distance(_transform.position, bin.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestBin = bin;
            }
        }

        if (minDistance > _distanceThreshold)
            return;

        closestBin.Accept(this, Pickup);
        Pickup = null;
    }
}