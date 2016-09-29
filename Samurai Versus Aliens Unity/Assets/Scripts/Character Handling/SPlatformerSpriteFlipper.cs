using UnityEngine;
using System.Collections;

public class SPlatformerSpriteFlipper : MonoBehaviour {

    public SPlatformerCharacterController myController;

    private Vector3 originalScale;
    private Vector3 flipScale;
    public bool facingRight = true;

    private bool flip = false;
    // Use this for initialization
    void Start()
    {
        originalScale = transform.localScale;
        flipScale = originalScale;
        flipScale.x *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(myController.dirFlip))
        {
            flip = !flip;

            if (flip)
                transform.localScale = flipScale;
            else
                transform.localScale = originalScale;


            facingRight = false;
        }
    }
}
