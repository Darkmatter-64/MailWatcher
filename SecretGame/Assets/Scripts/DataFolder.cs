using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* All this code is for the profiles/phone numbers within the book */

public class DataFolder : MonoBehaviour
{
    public GameObject CanvasDataFolder;
    public GameObject[] Pages;
    public Image ImagePage;
    public GameObject RightButtonObject;
    public GameObject LeftButtonObject;
    private int PageNumber = 0;


    private bool dragging = false;
    private bool OnCollisition;
    private Vector3 offset;
    private Vector3 startPosition;
    public Sprite LetterText;
    public float HoldingTime;
    public SpriteRenderer sr;

    public int CurrentDay = 1;


    public AudioSource audioSr;
    public AudioClip[] audioClips;
    public bool PlayedSound = false;
    private float pi1 = 0.8f;
    private float pi2 = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        CheckMassive();
        CanvasDataFolder.SetActive(false);
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
        if (CurrentDay != CameraMove.TheDay)
        {
            CurrentDay = CameraMove.TheDay;
            sr.sortingOrder = 8;
        }


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
        Pages[PageNumber].SetActive(true);





        if (PageNumber == 0)
        {
            LeftButtonObject.SetActive(false);
        }
        else
        {
            LeftButtonObject.SetActive(true);
            Pages[PageNumber - 1].SetActive(false);
        }
        if (PageNumber == Pages.Length - 1)
        {
            RightButtonObject.SetActive(false);
        }
        else
        {
            RightButtonObject.SetActive(true);
            Pages[PageNumber + 1].SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        if (CameraMove.ItemInHand != sr)
        {
            sr.sortingOrder = CameraMove.ItemInHand.sortingOrder + 1;
            CameraMove.ItemInHand = sr;
        }
        audioSr.pitch = Random.Range(pi1, pi2);
        audioSr.PlayOneShot(audioClips[0]);
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    private void OnMouseUp()
    {
        if (HoldingTime <= 0.14f && CameraMove.CanOpenLetter == true)
        {
            //CheckMassive();
            CameraMove.CanOpenLetter = false;
            CanvasDataFolder.SetActive(true);
        }
        HoldingTime = 0;
        dragging = false;
        if (dragging == false && OnCollisition == false && CameraMove.CanOpenLetter == true)
        {
            audioSr.pitch = Random.Range(pi1, pi2);
            audioSr.PlayOneShot(audioClips[1]);
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + Random.Range(-23, 23));
            startPosition = transform.position;
        }
    }


    public void CloseFolder()
    {
        CameraMove.CanOpenLetter = true;
        CanvasDataFolder.SetActive(false);
        audioSr.pitch = Random.Range(pi1, pi2);
        audioSr.PlayOneShot(audioClips[1]);
    }
    public void RightButton()
    {
        PageNumber++;
        audioSr.pitch = Random.Range(pi1, pi2);
        audioSr.PlayOneShot(audioClips[2]);
    }
    public void LeftButton()
    {
        PageNumber--;
        audioSr.pitch = Random.Range(pi1, pi2);
        audioSr.PlayOneShot(audioClips[2]);
    }


    public void CheckMassive()
    {
        for (int i = 0; i < Pages.Length; i++)
        {
            Pages[i].SetActive(false);
        }
    }

}
