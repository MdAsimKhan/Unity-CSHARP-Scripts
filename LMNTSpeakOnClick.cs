using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LMNT;

public class LMNTSpeakOnClick : MonoBehaviour
{
    private AudioSource audioSource;
	private LMNTSpeech speech;
    private bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        speech = GetComponent<LMNTSpeech>();
        StartCoroutine(speech.Prefetch());
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying) {
            triggered = false;
        }

        if (triggered) {
            return;
        }

        if (audioSource.isPlaying) {
            // animator.SetTrigger("Talk");
            triggered = true;
        }
    }

    public void OnMouseDown()
    {
        StartCoroutine(speech.Talk());
    }
}
