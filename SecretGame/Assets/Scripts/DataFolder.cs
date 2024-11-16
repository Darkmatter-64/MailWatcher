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
    // Start is called before the first frame update
    void Start()
    {
        ImagePage.sprite = Pages[0];
        CanvasDataFolder.SetActive(false);
    }

    private void Update()
    {
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

    private void OnMouseUp()
    {
        CameraMove.CanOpenLetter = false;
        CanvasDataFolder.SetActive(true);
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
