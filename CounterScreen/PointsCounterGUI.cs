using UnityEngine;

public class PointsCounterGUI : MonoBehaviour
{
	Rect buttonRect = new Rect(50, 50, 75, 30);
	BonusPointsCounter counter;
	//BallsCounter counter;

	private void Awake()
	{
		counter = FindObjectOfType(typeof(BonusPointsCounter)) as BonusPointsCounter;
		//counter = FindObjectOfType(typeof(BallsCounter)) as BallsCounter;
	}

	private void OnGUI()
	{
		if (GUI.Button(buttonRect, "Activate"))
			counter.Activate(0);
	}
}
