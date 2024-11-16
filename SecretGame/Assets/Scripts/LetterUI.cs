using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterUI : MonoBehaviour
{


    public void CloseLetter()
    {
        CameraMove.CanOpenLetter = true;
        CameraMove.OnLetter = false;
    }
}
