using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPaperCode : MonoBehaviour
{
    // Fixed typo
    public GameObject PaperCanvas; // Used to say 'PaperCnavas'
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        CameraMove.CanOpenLetter = false;
        PaperCanvas.SetActive(true);
    }
    public void CloseFolder()
    {
        CameraMove.CanOpenLetter = true;
        PaperCanvas.SetActive(false);
    }
}
