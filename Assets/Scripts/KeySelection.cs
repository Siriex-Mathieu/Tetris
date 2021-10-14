// Detects keys pressed and prints their keycode
// https://docs.unity3d.com/ScriptReference/Event-keyCode.html
using UnityEngine;
using System.Collections;

public class KeySelection : MonoBehaviour
{
    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            print("Detected key code: " + e.keyCode);
        }
    }
}