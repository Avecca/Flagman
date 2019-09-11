using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    //connect trhough the inspector
    public AudioClip btnClick;
    public AudioClip gameOverSound;
    public AudioClip madeItSound;
    public AudioClip wrongGuessSound;
    public AudioClip roarSound;
    AudioSource audioSource;

    private void OnEnable()
    {
        ButtonInput.btnOne += OnOnePressed;
        ButtonInput.btnTwo += OnTwoPressed;
        ButtonInput.btnThree += OnThreePressed;
        ButtonInput.btnFour += OnFourPressed;
    }
    private void OnDisable()
    {
        ButtonInput.btnOne -= OnOnePressed;
        ButtonInput.btnTwo -= OnTwoPressed;
        ButtonInput.btnThree -= OnThreePressed;
        ButtonInput.btnFour -= OnFourPressed;
    }


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnFourPressed()
    {
        audioSource.clip = btnClick;
        PlaySound();
    }

    private void OnThreePressed()
    {
        audioSource.clip = btnClick;
        PlaySound();
    }


    private void OnTwoPressed()
    {
        audioSource.clip = btnClick;
        PlaySound();

    }

    private void OnOnePressed()
    {
        audioSource.clip = btnClick;
        PlaySound();

    }

    public void PlayRoar()
    {
        audioSource.clip = roarSound;
        PlaySound();

    }

    public void PlayGameOverSound()
    {
        audioSource.clip = gameOverSound;
        PlaySound();

    }

    public void PlaySuccessfullRoundSound()
    {
        audioSource.clip = madeItSound;
        PlaySound();

    }

    public void PlayWrongGuessSound()
    {
        audioSource.clip = wrongGuessSound;
        PlaySound();

    }

    private void PlaySound() {
        audioSource.Play();
    }
}



