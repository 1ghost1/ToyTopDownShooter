using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodServer : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteControl;
    [SerializeField] private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        spriteControl.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
