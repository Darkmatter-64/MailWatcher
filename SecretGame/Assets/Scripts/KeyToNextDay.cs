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
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        DayText.color = Invisible;
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
        Panel.SetActive(true);
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        if (HoldingTime <= 0.14f && CameraMove.CanOpenLetter == true)
        {
            StartCoroutine(RunIt());
        }
        HoldingTime = 0;
        dragging = false;
        if (dragging == false && OnCollisition == false)
        {
            startPosition = transform.position;
        }
    }




    private IEnumerator RunIt()
    {
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

    }




}
