using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressMainMenuButton : MonoBehaviour
{
    public Animator animaSceneClouse;
    public GameObject Musk;
    public GameObject Credits;
    // Start is called before the first frame update
    void Start()
    {
        animaSceneClouse.Play("CanvasMaskOpen");
        Credits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        Musk.SetActive(true);
        animaSceneClouse.Play("CanvasMaskCode");
    }

    public void OpenCredits()
    {
        Credits.SetActive(true);
    }
    public void ClouseCredits()
    {
        Credits.SetActive(false);
    }
}
