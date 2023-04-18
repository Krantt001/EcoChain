using UnityEngine;

public class GarbageManager : MonoBehaviour
{
    [SerializeField] Truck _truckPrefab;
    [SerializeField] Transform _truckSpawnPoint;
    
    void OnEnable()
    {
        Bin.BinFull += OnBinFull;
    }

    void OnDisable()
    {
        Bin.BinFull -= OnBinFull;
    }

    void OnBinFull(Bin bin)
    {
        var truck = Instantiate(_truckPrefab, _truckSpawnPoint.position, Quaternion.identity);
        StartCoroutine(truck.Pickup(bin));
    }
}