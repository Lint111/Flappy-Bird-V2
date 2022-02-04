using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExitController : MonoBehaviour
{
    public void Exit()
    {      
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
