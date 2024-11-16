using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInputH;
    private float moveInputV;
    public float speed = 3f;
    public static bool OnLetter = false;
    public static Image LetterUIImage;
    public Image LetterUIImageCurrent;
    public GameObject LettersUI;
    // Start is called before the first frame update
    void Start()
    {
        LetterUIImage = LetterUIImageCurrent;
        OnLetter = false;
        rb = GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
        moveInputH = Input.GetAxis("Horizontal");
        moveInputV = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveInputH * speed, moveInputV * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (OnLetter == true)
        {
            LettersUI.SetActive(true);
        }
        else
        {
            LettersUI.SetActive(false);
        }
    }
}
