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
			audioSource = Utilities.GetComponent<AudioSource>(gameObject);
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
}
