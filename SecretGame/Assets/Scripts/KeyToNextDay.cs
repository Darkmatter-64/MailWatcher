using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class KeyToNextDay : MonoBehaviour
{
    public Animator ObjectAnimator;
    public GameObject Panel;
    public Text DayText;
    public Color Invisible;
    public Color Visible;
    public GameObject TheCamera;
    public float DissapeearSpeed = 1;
    public bool StartDissapear;

    private bool dragging = false;
    private bool OnCollisition;
    private Vector3 offset;
    private Vector3 startPosition;
    public float HoldingTime;
    public GameObject CanvasQuestion;

    public SpriteRenderer sr;
    public SpriteRenderer part1;
    public SpriteRenderer part2;
    public SpriteRenderer part3;
    public SpriteRenderer part4;
    public SpriteRenderer Smurf;

    public int CurrentDay = 1;
    // Start is called before the first frame update
    void Start()
    {
        CanvasQuestion.SetActive(false);
        startPosition = transform.position;
        Panel.SetActive(true);
        DayText.color = Invisible;
        ObjectAnimator.Play("CanvasMaskOpen");
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
    // Update is called once per frame
    void Update()
    {
        if (CameraMove.TheDay == 9)
        { 
        Destroy(gameObject);
        }
        if (CurrentDay != CameraMove.TheDay)
        {
            CurrentDay = CameraMove.TheDay;
            sr.sortingOrder = 5;
            part1.sortingOrder = 4;
            part2.sortingOrder = 4;
            part3.sortingOrder = 4;
            part4.sortingOrder = 3;
        }
        //Debug.Log(startPosition);
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

        if (StartDissapear == true)
        {
            DayText.color = DayText.color * (1 - Time.deltaTime * DissapeearSpeed) + Invisible * (Time.deltaTime + 0);
        }
        if (DayText.color == Invisible)
        {
            StartDissapear = false;
        }
    }


    private void OnMouseDown()
    {
        if (CameraMove.CanOpenLetter == true)
        {


            if (CameraMove.ItemInHand != sr)
            {
                sr.sortingOrder = CameraMove.ItemInHand.sortingOrder + 2;
                part1.sortingOrder = CameraMove.ItemInHand.sortingOrder + 2;
                part2.sortingOrder = CameraMove.ItemInHand.sortingOrder + 1;
                part3.sortingOrder = CameraMove.ItemInHand.sortingOrder + 2;
                part4.sortingOrder = CameraMove.ItemInHand.sortingOrder + 1;
                CameraMove.ItemInHand = sr;
            }
            Panel.SetActive(true);
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragging = true;
        }
    }

    private void OnMouseUp()
    {
        if (HoldingTime <= 0.14f && CameraMove.CanOpenLetter == true)
        {
            CanvasQuestion.SetActive(true);
        }
        HoldingTime = 0;
        dragging = false;
        if (dragging == false && OnCollisition == false && CameraMove.CanOpenLetter == true)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + Random.Range(-23, 23));
            startPosition = transform.position;
        }
    }


    public void Clouse()
    {
        CameraMove.CanOpenLetter = true;
        CanvasQuestion.SetActive(false);
    }
    public void Accept()
    {
        CameraMove.CanOpenLetter = true;
        StartCoroutine(RunIt());
    }

    public IEnumerator RunIt()
    {
        CameraMove.ItemInHand = Smurf;
        CanvasQuestion.SetActive(false);
        StartDissapear = false;
        CameraMove.CanOpenLetter = false;
        ObjectAnimator.Play("CanvasMaskClouse");
        yield return new WaitForSeconds(2f);
        TheCamera.transform.position = new Vector2 (0, 0);
        yield return new WaitForSeconds(1f);
        ObjectAnimator.Play("CanvasMaskOpen");
        CameraMove.TheDay += 1;
        DayText.color = Visible;
        DayText.text = "Day " + CameraMove.TheDay;
        CameraMove.CanOpenLetter = true;
        yield return new WaitForSeconds(2);
        StartDissapear = true;
        CameraMove.ItemInHand = Smurf;

    }




}
