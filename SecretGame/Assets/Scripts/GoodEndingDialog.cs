using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoodEndingDialog : MonoBehaviour
{
    public Animator ObjectAnimator;
    public Text textUI;
    public string[] lines;
    public Sprite[] sprites;
    public float textspeed;
    public Image TheImage;
    public GameObject Confetti;
    public GameObject Panel;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        ObjectAnimator.Play("CanvasMaskOpen");
        textUI.text = string.Empty;
        StartCoroutine(StartPre());
    }

    // Update is called once per frame
    void Update()  
    {
        TheImage.sprite = sprites[index];  

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("df");
            if (textUI.text == lines[index])
            {
                NextString();
            }
            else
            { 
                StopAllCoroutines();
                textUI.text = lines[index];
            }
        }
        
    }

    void StartDiaologue()
    { 
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator StartPre()
    {
        yield return new WaitForSeconds(0.1f);
        Confetti.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        StartDiaologue();
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textUI.text += c;
            yield return new WaitForSeconds(textspeed);

        }
    }

    void NextString()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textUI.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Panel.SetActive(true);
            ObjectAnimator.Play("CanvasMaskCode2");
        }
    }
}
