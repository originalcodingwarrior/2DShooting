using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public Sprite idle;
    public Sprite holding;
    public Sprite throwing;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToIdle()
    {
        spriteRenderer.sprite = idle;
    }
    public void ChangeToHolding()
    {
        spriteRenderer.sprite = holding;
    }
    public void ChangeToThrowing()
    {
        spriteRenderer.sprite = throwing;
    }
}
