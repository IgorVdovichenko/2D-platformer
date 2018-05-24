using UnityEngine;

public class ButtonsManagerGUI : MonoBehaviour
{
    byte windowID = 10;
    string windowLabel = "Stages Manager";
    Vector2 topLeftWindowPos = new Vector2(50, 250);
    Vector2 windowSize = new Vector2(150, 75);
    Rect windowRect;

    [SerializeField]
    Stage[] stages;
    IStageClearedStatusSetter setter;

    private void Start()
    {
        windowRect = new Rect(topLeftWindowPos, windowSize);
        setter = new StageClearedStatusSetter(stages);
    }

    private void OnGUI()
    {

        windowRect = GUILayout.Window(windowID, windowRect, setter.WindowFunction, windowLabel);

    }
}
