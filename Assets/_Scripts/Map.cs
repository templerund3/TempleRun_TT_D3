using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour 
{
    public int levelMap;
    public string backgroundName;
    public int star3;
    public int star2;
    public itemInMap[] itemsInMapCurrent;

    [System.Serializable]
    public struct itemInMap
    {
        public string name;
        public float posX;
        public float posY;
        public float rotX;
        public float rotY;
        public float rotZ;
        public float scaleX;
        public float scaleY;
    }
}
