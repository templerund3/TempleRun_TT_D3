using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScroll : MonoBehaviour {

    public int ID;
    private int count = 8;
    public GameObject itemBtnLevel;
	// Use this for initialization
	public void Init () {
		for(int i = 0; i < count; i++)
        {
            BtnnLevel btnCurrent =  Instantiate(itemBtnLevel, transform.GetChild(0)).GetComponent<BtnnLevel>();
            btnCurrent.Level = i + ID * count+1;
            btnCurrent.txtLevel.text = btnCurrent.Level.ToString();
        }
	}
	
}
