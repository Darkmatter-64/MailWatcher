using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Code after you open any letter */

public class LetterUI : MonoBehaviour
{


    public void CloseLetter()
    {
        CameraMove.CanOpenLetter = true;
        CameraMove.OnLetter = false;
    }
}
