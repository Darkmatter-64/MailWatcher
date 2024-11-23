using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPaperCode : MonoBehaviour
{
    public GameObject PaperCnavas;
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
        PaperCnavas.SetActive(true);
    }
    public void CloseFolder()
    {
        CameraMove.CanOpenLetter = true;
        PaperCnavas.SetActive(false);
    }
}
