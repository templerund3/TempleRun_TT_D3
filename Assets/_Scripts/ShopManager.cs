﻿using System.Collections;
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
        PlayerPrefs.SetInt("idCharacterCurrent", 0);
        PlayerPrefs.SetInt("Coin", 900);
        mCharacter = lstcharacter[PlayerPrefs.GetInt("idCharacterCurrent")];
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
            if(PlayerPrefs.GetInt("Character" + i) ==0) //chưa mua
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
        if(PlayerPrefs.GetInt("idCharacterCurrent") == mCharacter.idCharacter && mCharacter.isBuy)
        {
            costCharacter.text = "Selected";
        }
        else if (PlayerPrefs.GetInt("idCharacterCurrent") != mCharacter.idCharacter && mCharacter.isBuy)
        {
            costCharacter.text = "Select";
        }
        else
        {
            costCharacter.text = mCharacter.costCharacter.ToString();
        }

        txtCoinValue.text = PlayerPrefs.GetInt("Coin").ToString();
        
    }

    public void btnBuyCharacter()
    {
        if(!mCharacter.isBuy)
        {
            if(PlayerPrefs.GetInt("Coin") >= mCharacter.costCharacter)
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - mCharacter.costCharacter);
                PlayerPrefs.SetInt("idCharacterCurrent", mCharacter.idCharacter);
                PlayerPrefs.SetInt("Character" + mCharacter.idCharacter, 1);
                lstcharacter[mCharacter.idCharacter].isBuy = true;
            }
            else
            {
                panelDialog.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt("idCharacterCurrent", mCharacter.idCharacter);
        }
        UpdateCharacter();
    }
}

