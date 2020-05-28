using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opendoor : MonoBehaviour
{
    public SpriteRenderer door;
    public Sprite doorOpen;
    public Sprite mysprite;
    private SpriteRenderer toggle;
    void Start()
    {
        toggle = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            toggle.sprite = mysprite;
            door.sprite = doorOpen;
        }
    }
}
