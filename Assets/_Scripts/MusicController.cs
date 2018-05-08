using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour 
{
    [SerializeField]
    private bool isOn;

    public bool IsOn
    {
        get { return isOn; }
        set
        {
            isOn = value;
            UpdateButtons();
        }
    }

    public Button buttonMusic;
    public Sprite isOnSprite;
    public Sprite isOffSprite;

    public AudioSource audioSource;

    private void Start()
    {
        isOn = true;
    }

    private void UpdateButtons()
    {
        buttonMusic.gameObject.GetComponent<Image>().sprite = isOn ? isOnSprite : isOffSprite;
    }

    public void OnClickButton()
    {
        if(isOn)
        {
            PlayNewMusic();
        }
        else
        {
            audioSource.Stop();
        }
    }

    private IEnumerator PlayNewMusic()
    {
        while (audioSource.volume >= 0.1f)
        {
            audioSource.volume -= 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
        audioSource.Stop();
        if (isOn)
        {
            audioSource.Play();
        }
        audioSource.volume = 1;
    }
}
