using UnityEngine;
using System.Collections;

public sealed class BonusPointsCounter : BonusCounter
{
	private new void Awake()
	{
		levelBonus.text = textFormat;
		base.Awake();
	}

	protected override IEnumerator CalculatePoints()
	{
		yield return new WaitForSeconds(delayBeforeCount);

		for (int i = delta; i <= stage.BonusPoints; i += delta)
		{
			points.value += delta;
			levelBonus.text = i.ToString(textFormat);
			audioSource.PlayOneShot(sound);
			yield return new WaitForSeconds(iterationDelay);
		}
		onDone.Invoke();
	}
}
