using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    public GameObject CanvasNotebook;
    public GameObject[] Pages;
    public int PageNumber = 0;
    public GameObject RightButtonObject;
    public GameObject LeftButtonObject;


    private bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    public Sprite LetterText;
    public float HoldingTime;
    // Start is called before the first frame update
    void Start()
    {
        {
            startPosition = transform.position;
        }
        //NotebookText = Pages[0];
        CanvasNotebook.SetActive(false);
        Pages[1].SetActive(false);
        Pages[2].SetActive(false);
        Pages[3].SetActive(false);
        Pages[4].SetActive(false);
        Pages[5].SetActive(false);
        Pages[6].SetActive(false);
        Pages[7].SetActive(false);
        Pages[8].SetActive(false);
        Pages[9].SetActive(false);
        Pages[10].SetActive(false);
        Pages[11].SetActive(false);
        Pages[12].SetActive(false);
        Pages[13].SetActive(false);
        Pages[14].SetActive(false);
        Pages[15].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging == true && CameraMove.CanOpenLetter == true)
        {
            if (HoldingTime <= 1)
            {
                HoldingTime = HoldingTime + Time.deltaTime;
            }
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }

        Pages[PageNumber].SetActive(true);

        if (PageNumber == 0)
        {
            RightButtonObject.SetActive(true);
            LeftButtonObject.SetActive(false);
            Pages[PageNumber + 1].SetActive(false);
        }
        else if (PageNumber == Pages.Length - 1)
        {
            RightButtonObject.SetActive(false);
            LeftButtonObject.SetActive(true);
            Pages[PageNumber - 1].SetActive(false);
        }
        else
        {
            LeftButtonObject.SetActive(true);
            RightButtonObject.SetActive(true);
            Pages[PageNumber - 1].SetActive(false);
            Pages[PageNumber + 1].SetActive(false);
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
            CanvasNotebook.SetActive(true);
        }
        HoldingTime = 0;
        dragging = false;
    }
    public void CloseFolder()
    {
        CameraMove.CanOpenLetter = true;
        CanvasNotebook.SetActive(false);
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
