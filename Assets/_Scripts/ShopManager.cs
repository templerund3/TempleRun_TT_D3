using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoSingleton<ShopManager> 
{
    public List<Character> lstcharacter;

    private Character mCharacter;

    public ScrollRect scrollCharacter;
    public Button buttonNext;
    public Button buttonPre;

    public Text txtCoinValue;

    [Header("Character Information")]
    public Text nameCharacter;
    public Text costCharacter;

    public GameObject panelDialog;

    private void Start()
    {
        //PlayerPrefs.SetInt("idCharacterCurrent", 0);
        //PlayerPrefs.SetInt("Coin", 900);
        mCharacter = lstcharacter[PlayerPrefs.GetInt(ContsInGame.ID_CHARACTER_CURRENT)];
        if (mCharacter.idCharacter <= 0)
        {
            buttonPre.gameObject.SetActive(false);
        }
        else if(mCharacter.idCharacter >= lstcharacter.Count)
        {
            buttonNext.gameObject.SetActive(false);
        }
        UpdateCharacter();

        for (int i = 0; i < lstcharacter.Count; i++)
        {
            if (PlayerPrefs.GetInt(ContsInGame.ID_CHARACTER_CURRENT + i) == 0) //chưa mua
            {
                lstcharacter[i].isBuy = false;
            }
            else //đã mua
            {
                lstcharacter[i].isBuy = true;
            }
        }
    }

    public void btnNext()
    {
        MusicController.Instance.PlayUIClick();

        scrollCharacter.horizontalNormalizedPosition += 0.33f;
        mCharacter = lstcharacter[mCharacter.idCharacter+1];
        buttonPre.gameObject.SetActive(true);
        if (mCharacter.idCharacter >= lstcharacter.Count-1)
        {
            buttonNext.gameObject.SetActive(false);
        }
        UpdateCharacter();
    }

    public void btnPre()
    {
        MusicController.Instance.PlayUIClick();

        scrollCharacter.horizontalNormalizedPosition -= 0.33f;
        mCharacter = lstcharacter[mCharacter.idCharacter-1];
        buttonNext.gameObject.SetActive(true);
        if (mCharacter.idCharacter <= 0)
        {
            buttonPre.gameObject.SetActive(false);
        }
        UpdateCharacter();
    }

    private void UpdateCharacter()
    {
        nameCharacter.text = mCharacter.nameCharacter;
        if(PlayerPrefs.GetInt(ContsInGame.ID_CHARACTER_CURRENT) == mCharacter.idCharacter && mCharacter.isBuy)
        {
            costCharacter.text = ContsInGame.SELECTED_TEXT;
        }
        else if (PlayerPrefs.GetInt(ContsInGame.ID_CHARACTER_CURRENT) != mCharacter.idCharacter && mCharacter.isBuy)
        {
            costCharacter.text = ContsInGame.SELECT_TEXT;
        }
        else
        {
            costCharacter.text = mCharacter.costCharacter.ToString();
        }

        txtCoinValue.text = PlayerPrefs.GetInt(ContsInGame.COIN).ToString();
        
    }

    public void btnBuyCharacter()
    {
        MusicController.Instance.PlayUIClick();

        if(!mCharacter.isBuy)
        {
            if (PlayerPrefs.GetInt(ContsInGame.COIN) >= mCharacter.costCharacter)
            {
                PlayerPrefs.SetInt(ContsInGame.COIN, PlayerPrefs.GetInt(ContsInGame.COIN) - mCharacter.costCharacter);
                PlayerPrefs.SetInt(ContsInGame.ID_CHARACTER_CURRENT, mCharacter.idCharacter);
                PlayerPrefs.SetInt(ContsInGame.CHARACTER + mCharacter.idCharacter, 1);
                lstcharacter[mCharacter.idCharacter].isBuy = true;
            }
            else
            {
                panelDialog.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt(ContsInGame.ID_CHARACTER_CURRENT, mCharacter.idCharacter);
        }
        UpdateCharacter();
    }
}


