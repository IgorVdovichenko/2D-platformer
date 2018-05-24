using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class LandingSoundController : MonoBehaviour
{
    bool playedLandingSound = true;
    public AudioClip groundedSound;
    AudioSource sound;

    public string groundLayerMaskName = "Floor";
    GroundedChecker groundedChecker;

    private void Awake()
    {
        try
        {
            sound = Utilities.GetComponent<AudioSource>(gameObject);
            groundedChecker = new GroundedChecker(gameObject, groundLayerMaskName);
        }
        catch (Exception e)
        {
            Utilities.HandleException(e);
        }
    }

    private void Update()
    {
        if (groundedChecker.IsGrounded() == false)
            playedLandingSound = false;

        PlayLandingSound();
    }

    private void PlayLandingSound()
    {
        if (groundedChecker.IsGrounded() && playedLandingSound == false)
        {
            sound.PlayOneShot(groundedSound);
            playedLandingSound = true;
        }
    }
}
