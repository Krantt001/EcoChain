using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] List<ItemData> _items;
    [SerializeField] float _delayBetweenItems;
    [SerializeField] Transform _itemSpawnPoint;
    [SerializeField] Item _itemPrefab;
    [SerializeField] Vector3 _direction;
    
    bool _isActive = true;
    float _timer;

    void Update()
    {
        if (!_isActive)
            return;
        
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _timer += _delayBetweenItems;
            var newItem = Instantiate(_itemPrefab, _itemSpawnPoint.position, Quaternion.identity);
            newItem.ItemData = _items[Random.Range(0, _items.Count)];
            newItem.Direction = _direction;
        }
    }
}