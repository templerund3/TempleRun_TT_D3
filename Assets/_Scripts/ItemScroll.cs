using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScroll : MonoBehaviour {

    public int ID;
    private int count = 8;
    public GameObject itemBtnLevel;
    // Use this for initialization
    public void InitItem()
    {
        for (int i = 1; i <= count; i++)
        {
            BtnnLevel btnCurrent = Instantiate(itemBtnLevel, transform.GetChild(0)).GetComponent<BtnnLevel>();
            btnCurrent.Level = i + ID * count;
            btnCurrent.InitLevel();
        }
    }

}
