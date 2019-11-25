using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SoundOverAndClick : MonoBehaviour, IPointerEnterHandler {

    public AudioClip SoundClick;

    public AudioClip SoundOver;

    private Button gameButton { get { return GetComponent<Button>(); } }

    private AudioSource audioSource { get { return GetComponent<AudioSource>(); } }

	// Use this for initialization
	void Start () {

        gameObject.AddComponent<AudioSource>();

        audioSource.clip = SoundOver;
        audioSource.playOnAwake = false;

        audioSource.pitch = 0.7f;
        audioSource.volume = 0.2f;

        gameButton.onClick.AddListener(() => OnButtonClick());

	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.PlayOneShot(SoundOver);
            StartCoroutine(Wait(0.2f));

        }

    }


    public void OnButtonClick()
    {
        audioSource.PlayOneShot(SoundClick);

        StartCoroutine(Wait(0.5f));
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);

    }
}
