using UnityEngine;
using UnityEngine.UI;
using System;

public static class Utilities
{
    public static T GetComponent<T>(GameObject obj)
        where T: Component
    {
		T output = obj.GetComponent<T>();
		if (output == null)
		{
			string message =
				string.Format("{0} does not have {1} component attached", obj.name, typeof(T).Name);
			throw new System.Exception(message);
		}
        else
            return output;
    }

	public static void HandleException(Exception e)
	{
		Debug.LogError(e.Message);
		UnityEditor.EditorApplication.isPlaying = false;
	}

	public static void StopEditorApplication()
	{
		if(UnityEditor.EditorApplication.isPlaying == true)
			UnityEditor.EditorApplication.isPlaying = false;
	}

	public static bool AllButtonsInactive(Button[] buttons)
    {
        if (GetNumOfInactiveButtons(buttons) == buttons.Length)
            return true;
        else
            return false;
    }

    private static int GetNumOfInactiveButtons(Button[] buttons)
    {
        int output = 0;

        foreach (var item in buttons)
        {
            if (!item.interactable)
                output++;
        }

        return output;
    }
}
