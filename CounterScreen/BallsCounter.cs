using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public sealed class BallsCounter : BonusCounter
{
	[SerializeField] Text bonusPoints;
	[SerializeField] Text ballsText;
	[SerializeField] IntValue balls;
	[SerializeField] int pointsPerBall = 1000;

	private readonly string ballsTextFormat = "-1000x00";

	private Image image;

	private new void Awake()
	{
		image = GetComponentInChildren<Image>();
		base.Awake();
		bonusPoints.text = textFormat;
		ballsText.text = ballsTextFormat;
	}

	protected override void Hide()
	{
		base.Hide();
		image.enabled = false;
	}

	protected override void Show()
	{
		base.Show();
		image.enabled = true;
	}

	protected override IEnumerator CalculatePoints()
	{
		yield return new WaitForSeconds(delayBeforeCount);

		for (int i = pointsPerBall; i <= balls.value * pointsPerBall; i += pointsPerBall)
		{
			int balls = i / pointsPerBall;
			ballsText.text = balls.ToString(ballsTextFormat);
			bonusPoints.text = i.ToString(textFormat);
			points.value += pointsPerBall;
			audioSource.PlayOneShot(sound);
			yield return new WaitForSeconds(iterationDelay);
		}
		onDone.Invoke();
		balls.value = balls.defaultValue;
	}
}
