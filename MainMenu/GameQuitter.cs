#define EDITOR

using UnityEngine;

public class GameQuitter: MonoBehaviour
{
    //Attach this method in Unity to a button
    public void QuitGame()
    {
#if EDITOR
        if (UnityEditor.EditorApplication.isPlaying == true)
                   UnityEditor.EditorApplication.isPlaying = false;

#else
        else Application.Quit();
#endif
    }
}
