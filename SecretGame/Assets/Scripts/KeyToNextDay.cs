using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyToNextDay : MonoBehaviour
{
    public Animator ObjectAnimator;
    public Text DayText;
    public Color Invisible;
    public Color Visible;
    public GameObject TheCamera;
    public float DissapeearSpeed = 1;
    public bool StartDissapear;




    // Start is called before the first frame update
    void Start()
    {
        DayText.color = Invisible;
    }

    // Update is called once per frame
    void Update()
    {
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
        StartCoroutine(RunIt());
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
