using System.Collections;
using UnityEngine;

class Truck : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] float _speed;

    public IEnumerator Pickup(Bin bin)
    {
        var destination = bin.PickingPoint;

        Debug.Log(bin.PickingPoint);
        
        while (Vector3.Distance(_transform.position, destination) > float.Epsilon)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, destination, _speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);
        
        Destroy(gameObject, 3);
        
        while (gameObject)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _transform.position + Vector3.right, _speed * Time.deltaTime);
            yield return null;
        }
    }
}