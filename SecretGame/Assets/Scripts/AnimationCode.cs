using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCode : MonoBehaviour
{
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public Animator ObjectAnimator;
    public GameObject Panel;
    public AudioSource audioSr;
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ClouseScene()
    {
        Panel.SetActive(true);
        ObjectAnimator.Play("CanvasMaskCode2");
    }
    public void OnDestroy() 
    { 
        Destroy(gameObject);
    }
    public void OnDissapear()
    {
        gameObject.SetActive(false);
    }
    public void OnAppear()
    {
        Item1.SetActive(true);
    }
    public void OnDissapeaTwoItems()
    {
        Item2.SetActive(false);
        Item1.SetActive(false);
    }

    public void OpenLetterCan()
    {
        CameraMove.CanOpenLetter = true;
    }
    public void OpenLetterCanNot()
    {
        CameraMove.CanOpenLetter = false;
    }
    public void AudioPlay1()
    {
        audioSr.PlayOneShot(audioClips[0]);
    }
    public void AudioPlay2()
    {
        audioSr.PlayOneShot(audioClips[1]);
    }
    public void AudioPlay3()
    {
        audioSr.PlayOneShot(audioClips[2]);
    }

    public void ChooseRandomtoFalse()
    {
        int i = Random.Range(0, 3);
        if (i == 0)
        {
            Item1.SetActive(true);
            Item2.SetActive(false);
            Item3.SetActive(false);
        }
        else if (i == 1)
        {
            Item1.SetActive(false);
            Item2.SetActive(true);
            Item3.SetActive(false);
        }
        else if (i == 2)
        {
            Item1.SetActive(false);
            Item2.SetActive(false);
            Item3.SetActive(true);
        }
    }


}
