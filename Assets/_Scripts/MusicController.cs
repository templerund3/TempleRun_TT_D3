﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoSingleton<MusicController> 
{
    [SerializeField]
    private bool isOn; //biến check có bật music hay không ?

    public Button buttonMusic;
    public Sprite isOnSprite;
    public Sprite isOffSprite;

    [Header("AudioClip")]
    public AudioClip buttonSound;
    public AudioClip coinSound;
    public AudioClip loseSound;
    public AudioClip dieSound;
    public AudioClip jumpSound;
    public AudioClip winSound;

    [Header("AudioSource")]
    public AudioSource musicSource;
    public AudioSource soundSource;

    private void Start()
    {    
        isOn = true;
    }

    #region ===MUSIC===
    /// <summary>
    /// Update hình ảnh button
    /// </summary>
    private void UpdateButtons()
    {
        buttonMusic.gameObject.GetComponent<Image>().sprite = isOn ? isOnSprite : isOffSprite;
    }

    /// <summary>
    /// Click button
    /// </summary>
    public void OnClickButton()
    {
        isOn = !isOn;
        if(isOn)
        {
           StartCoroutine( PlayNewMusic());
        }
        else
        {
            musicSource.Stop();
        }
        UpdateButtons();
    }

    /// <summary>
    /// Hàm tắt nhạc cũ, bật nhac mới
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayNewMusic()
    {
        while (musicSource.volume >= 0.1f)
        {
            musicSource.volume -= 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
        musicSource.Stop();
        if (isOn)
        {
            musicSource.Play();
        }
        musicSource.volume = 1;
    }
    #endregion

    #region ===SOUND===
    public void PlayLoseSound()
    {
        if (!isOn)
        {
            return;
        }           
        //StopGameMusic();
        soundSource.clip = loseSound;
        soundSource.Play();
    }

    public void PlayDieSound()
    {
        if (!isOn)
        {
            return;
        }
        soundSource.clip = dieSound;
        soundSource.Play();
    }

    public void PlayUIClick()
    {
        if (!isOn)
        {
            return;
        }  
        soundSource.clip = buttonSound;
        soundSource.Play();
    }

    public void PlayWinSound()
    {
        if (!isOn)
        {
            return;
        }  
        //StopGameMusic();
        soundSource.clip = winSound;
        soundSource.Play();
    }

    public void PlayCoinSound()
    {
        if (!isOn)
        {
            return;
        }
        soundSource.clip = coinSound;
        soundSource.Play();
    }

    public void PlayJumpSound()
    {
        if (!isOn)
        {
            return;
        }
        soundSource.clip = jumpSound;
        soundSource.Play();
    }
    #endregion
}