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

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
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
        closestItem.transform.SetParent(_transform);
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
}