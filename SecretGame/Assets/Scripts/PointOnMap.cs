using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointOnMap : MonoBehaviour
{
    public Animator animaImage;
    public Animator animaTetxt;
    public Animator animaButton;
    public Animator animaPaper;
    public GameObject TextToDissapear;
    public GameObject Button;
    public GameObject Paper;
    public bool GotTheButton = false;
    public bool PaperIn = false;
    public GameObject CanvasPaper;
    public Image ButtonLImage;
    public Sprite LImage1;
    public Sprite LImage2;
    public CircleCollider2D cc2d;
    public TMP_InputField TheText;
    // Start is called before the first frame update
    void Start()
    {
        Button.SetActive(false);
        Paper.SetActive(false);
        CanvasPaper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GotTheButton == false)
        {//-0.005855696
            cc2d.radius = 0.3907061f;
        }
        else if (GotTheButton == true)
        {
            cc2d.radius = 0.7247019f;
        }
    }
    private void OnMouseEnter()
    {
        if (GotTheButton == false)
        {
            animaImage.Play("MouseEnter");
        }
        else
        {
            animaTetxt.Play("TextPointAppear");
        }
    }

    private void OnMouseExit()
    {
        if (GotTheButton == false)
        {
            animaImage.Play("MouseExit");
        }
        else 
        {
            animaTetxt.Play("TextPointDissapear");
        }
    }

    private void OnMouseDown()
    {
        if (GotTheButton == false && CameraMove.CanOpenLetter == true)
        {
            Button.SetActive(true);
            animaTetxt.Play("TextPointAppear");
            GotTheButton = true;
            animaButton.Play("MapButtonIdleAppear");
        }
    }



    public void RemoveButton()
    {
        animaTetxt.Play("TextPointDissapear");
        GotTheButton = false;
        animaImage.Play("MouseExit");
        animaButton.Play("MapButtonIdleDisappear");
        if (PaperIn == true)
        {
            PaperIn = false;
            TheText.text = "";
            animaPaper.Play("PaperFall");
            ButtonLImage.sprite = LImage1;
        }
    }

    public void AddPaperButton()
    {
        if (PaperIn == false)
        {
            ButtonLImage.sprite = LImage2;
            PaperIn = true;
            Paper.SetActive(true);
            animaPaper.Play("PaperAppear");
        }
        else
        {
            ButtonLImage.sprite = LImage1;
            PaperIn = false;
            TheText.text = "";
            animaPaper.Play("PaperDissapear");
        }
    }
}
