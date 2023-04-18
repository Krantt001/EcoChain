using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 movement;

    [SerializeField]
    public Sprite leftSprite;
    [SerializeField]
    public Sprite rightSprite;
    [SerializeField]
    public Sprite upSprite;
    [SerializeField]
    public Sprite downSprite;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontalInput, verticalInput).normalized;
        movement = direction * 6f * Time.deltaTime;

        transform.Translate(movement, Space.World);

        if(verticalInput > 0){
             spriteRenderer.sprite = upSprite;
        }else if(verticalInput < 0){
             spriteRenderer.sprite = downSprite;
        }else if (horizontalInput > 0){
             spriteRenderer.sprite =  rightSprite;
        }else if(horizontalInput < 0){
             spriteRenderer.sprite = leftSprite;
        }

        // transform.position += transform.position + new Vector3(movement.x, movement.y, 0f);
    }
}
