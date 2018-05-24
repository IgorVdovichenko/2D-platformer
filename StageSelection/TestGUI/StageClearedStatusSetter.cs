using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class StageClearedStatusSetter : IStageClearedStatusSetter
{
    Stage[] stages;

    public StageClearedStatusSetter(Stage[] stages)
    {
        this.stages = stages;
    }

    public void WindowFunction(int windowID)
    {
        ShowToggles();
        ShowButtons();
        GUI.DragWindow();
    }

    void ShowToggles()
    {
        foreach (var stage in stages)
        {
            stage.cleared = GUILayout.Toggle(stage.cleared, stage.SceneName);
        }
    }

    private void ShowButtons()
    {
        Button("Select All", SelectAll);
        Button("Disselect All", DisselectAll);
        Button("Update", () => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }

    private void Button(string label, Action action)
    {
        if (GUILayout.Button(label))
            action();
    }

    void SelectAll()
    {
        foreach (var stage in stages)
        {
            stage.cleared = true;
        }
    }

    void DisselectAll()
    {
        foreach (var stage in stages)
        {
            stage.cleared = false;
        }
    }
}
