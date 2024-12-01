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
    public float textspeed;
    public GameObject Confetti;
    public GameObject Panel;

    private int index;

    public AudioSource audioSr;
    public AudioClip[] audioClips;
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
        yield return new WaitForSeconds(0.7f);
        Confetti.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        StartDiaologue();
        yield return new WaitForSeconds(1f);
        audioSr.PlayOneShot(audioClips[0]);
        yield return new WaitForSeconds(0.07f);
        audioSr.PlayOneShot(audioClips[1]);
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
