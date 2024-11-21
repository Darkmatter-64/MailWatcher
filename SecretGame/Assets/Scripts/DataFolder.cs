using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataFolder : MonoBehaviour
{
    public GameObject CanvasDataFolder;
    public Sprite[] Pages;
    public Image ImagePage;
    public GameObject RightButtonObject;
    public GameObject LeftButtonObject;
    private int PageNumber = 0;


    private bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    public Sprite LetterText;
    public float HoldingTime;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        ImagePage.sprite = Pages[0];
        CanvasDataFolder.SetActive(false);
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

        ImagePage.sprite = Pages[PageNumber];

        if (PageNumber == 0)
        {
            LeftButtonObject.SetActive(false);
        }
        else
        {
            LeftButtonObject.SetActive(true);
        }
        if (PageNumber == Pages.Length - 1)
        {
            RightButtonObject.SetActive(false);
        }
        else
        {
            RightButtonObject.SetActive(true);
        }
    }
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    private void OnMouseUp()
    {
        if (HoldingTime <= 0.14f && CameraMove.CanOpenLetter == true)
        {
            CameraMove.CanOpenLetter = false;
            CanvasDataFolder.SetActive(true);
        }
        HoldingTime = 0;
        dragging = false;
    }


    public void CloseFolder()
    {
        CameraMove.CanOpenLetter = true;
        CanvasDataFolder.SetActive(false);
    }
    public void RightButton()
    {
        PageNumber++;
    }
    public void LeftButton()
    {
        PageNumber--;
    }
}
