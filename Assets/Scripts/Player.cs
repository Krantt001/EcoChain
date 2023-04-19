using System;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] float _distanceThreshold;
    [SerializeField] Animator _animator;
    [SerializeField] float _speed;
    
    IActionProvider _actionProvider;
    
    Vector2 direction;
    Vector2 movement;
    
    int _points;
    ItemData _pickup;

    public float DistanceThreshold => _distanceThreshold;

    public int Points
    {
        get => _points;
        set
        {
            _points = value;
            PointsChanged?.Invoke(_points);
        }
    }

    public ItemData Pickup
    {
        get => _pickup;
        set
        {
            _pickup = value;
            PickupChanged?.Invoke(_pickup);
        }
    }

    public Action<int> PointsChanged { get; set; }
    public Action<ItemData> PickupChanged { get; set; }

    void Awake()
    {
        if (name == "Player")
            _actionProvider = new PlayerBehaviour();
        else
            _actionProvider = GetComponent<AIBehaviour>();
    }

    void LateUpdate()
    {
        Move();

        if (_actionProvider.Interacted)
        {
            Interact();
        }
    }

    void Move()
    {
        direction = _actionProvider.Direction;

        _animator.SetFloat("X", direction.x);
        _animator.SetFloat("Y", direction.y);

        movement = direction * (_speed * Time.deltaTime);

        transform.Translate(movement);
    }

    void Interact()
    {
        if (TryThrowInBin())
            return;
        
        TryPickupClosestItem();
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

    bool TryThrowInBin()
    {
        if (Pickup == null)
            return false;
        
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
            return false;

        closestBin.Accept(this, Pickup);
        Pickup = null;

        return true;
    }
}