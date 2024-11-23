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
    public GameObject ButtonLeft;
    public GameObject ButtonRight;
    public GameObject CanvasPaper;
    public TMP_InputField TheText;
    // Start is called before the first frame update
    void Start()
    {
        TextToDissapear.SetActive(false);
        Button.SetActive(false);
        ButtonLeft.SetActive(false);
        ButtonRight.SetActive(false);
        Paper.SetActive(false);
        CanvasPaper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseEnter()
    {
        TextToDissapear.SetActive(true);
        animaTetxt.Play("TextPointAppear");
        if (GotTheButton == false)
        {
            ButtonLeft.SetActive(false);
            ButtonRight.SetActive(false);
            animaImage.Play("MouseEnter");
        }
    }

    private void OnMouseExit()
    {
        animaTetxt.Play("TextPointDissapear");
        if (GotTheButton == false)
        {
            animaImage.Play("MouseExit");
        }
    }

    private void OnMouseDown()
    {
        if (GotTheButton == false)
        {
            ButtonLeft.SetActive(true);
            ButtonRight.SetActive(true);
            Button.SetActive(true);
            GotTheButton = true;
            animaButton.Play("MapButtonIdleAppear");
            animaTetxt.Play("TextAppearButtons");
        }
    }



    public void RemoveButton()
    {
        animaTetxt.Play("TextDissapearButtons");
        GotTheButton = false;
        animaButton.Play("MapButtonIdleDisappear");
        if (PaperIn == true)
        {
            PaperIn = false;
            TheText.text = "";
            animaPaper.Play("PaperFall");
        }
    }

    public void AddPaperButton()
    {
        if (PaperIn == false)
        {
            PaperIn = true;
            Paper.SetActive(true);
            animaPaper.Play("PaperAppear");
        }
        else
        {
            PaperIn = false;
            TheText.text = "";
            animaPaper.Play("PaperDisapear");
        }
    }
}
