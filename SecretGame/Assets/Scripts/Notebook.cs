using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    public GameObject CanvasNotebook;
    //public GameObject[] Pages;
    public LinkedList<GameObject> Pages; // Change to Linked List
    public int PageNumber = 0; // Current page
    public GameObject RightButtonObject;
    public GameObject LeftButtonObject;


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
        {
            startPosition = transform.position;
        }
        //NotebookText = Pages[0];
        CanvasNotebook.SetActive(false);
        Pages.AddFirst(new GameObject());
        Pages.ElementAt(0).SetActive(true);
        // Old method set 16 FIXED pages. Using Linked List to have 'infinite' pages in Notebook.
        //Pages[1].SetActive(false);
        //Pages[2].SetActive(false);
        //Pages[3].SetActive(false);
        //Pages[4].SetActive(false);
        //Pages[5].SetActive(false);
        //Pages[6].SetActive(false);
        //Pages[7].SetActive(false);
        //Pages[8].SetActive(false);
        //Pages[9].SetActive(false);
        //Pages[10].SetActive(false);
        //Pages[11].SetActive(false);
        //Pages[12].SetActive(false);
        //Pages[13].SetActive(false);
        //Pages[14].SetActive(false);
        //Pages[15].SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Out")
        {
            OnCollisition = true;
            //dragging = false;
            //transform.position = startPosition;
        }
        else if (collision.tag != "Out")
        {
            OnCollisition = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (CurrentDay != CameraMove.TheDay)
        {
            CurrentDay = CameraMove.TheDay;
            sr.sortingOrder = 7;
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

        //Pages[PageNumber].SetActive(true);
        Pages.ElementAt(PageNumber).SetActive(true);

        if (PageNumber == 0)
        {
            RightButtonObject.SetActive(true);
            LeftButtonObject.SetActive(false);
            // Add new page
            if (Pages.Count() <= 1)
                Pages.AddLast(new GameObject());

            //Pages[PageNumber + 1].SetActive(false);
            Pages.ElementAt(PageNumber + 1).SetActive(false); // For LinkedList
        }
        // By new method, never on 'last' page
        //else if (PageNumber == Pages.Count() - 1)
        //{

        //    RightButtonObject.SetActive(false);
        //    LeftButtonObject.SetActive(true);
        //    Pages[PageNumber - 1].SetActive(false);
        //}
        else
        {
            if(Pages.Count() <= PageNumber + 1) // On last page
            {
                Pages.AddLast(new GameObject());
            }
            LeftButtonObject.SetActive(true);
            RightButtonObject.SetActive(true);
            //Pages[PageNumber - 1].SetActive(false);
            //Pages[PageNumber + 1].SetActive(false);
            // For LinkedList
            Pages.ElementAt(PageNumber - 1).SetActive(false);
            Pages.ElementAt(PageNumber + 1).SetActive(false);
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
            CameraMove.CanOpenLetter = false;
            CanvasNotebook.SetActive(true);
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
        CanvasNotebook.SetActive(false);
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

}
