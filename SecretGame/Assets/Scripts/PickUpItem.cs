using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    public Sprite LetterText;
    public float HoldingTime;

    // Start is called before the first frame update
    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        if (dragging == true)
        {
            if (HoldingTime <= 1)
            {
                HoldingTime = HoldingTime + Time.deltaTime;
            }
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
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
    }

}