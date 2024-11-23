using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{

    public bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    public Sprite LetterText;
    public float HoldingTime;
    private bool OnCollisition;

    // Start is called before the first frame update
    private void Start()
    {
        startPosition = transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Out")
        {
            OnCollisition = true;
            //dragging = false;
            //transform.position = startPosition;
        }
    }
    private void Update()
    {
        if (dragging == true && CameraMove.CanOpenLetter == true)
        {
            if (HoldingTime <= 1)
            {
                HoldingTime = HoldingTime + Time.deltaTime;
            }
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
        if (dragging == false && OnCollisition == true)
        {
            OnCollisition = false;
            dragging = false;
            transform.position = startPosition;

        }
    }
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    private void OnMouseUp()
    {
        CameraMove.LetterUIImage.sprite = LetterText;
        if (HoldingTime <= 0.14f && CameraMove.CanOpenLetter == true)
        {
            CameraMove.CanOpenLetter = false;
            CameraMove.OnLetter = true;
        }
        HoldingTime = 0;
        dragging = false;
        if (dragging == false && OnCollisition == false)
        {
            startPosition = transform.position;
        }
    }



}