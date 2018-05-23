using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] AudioClip sound;

    AudioSource audioSource;

    private void Awake()
	{
		SetAudioSource();
	}

	private void SetAudioSource()
	{
		try
		{
			audioSource = GetAudioSource();
		}
		catch (System.Exception ex)
		{
			Debug.LogError(ex.Message);
			enabled = false;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
    {
		audioSource.PlayOneShot(sound);
    }

	private AudioSource GetAudioSource()
	{
		AudioSource output;
		output = GetComponent<AudioSource>();
		if (output == null)
		{
			string message =
				string.Format("Game object {0} misses required Audio Source component", gameObject.name);
			throw new System.Exception(message);
		}
		else
			return output;
	}
	
}
