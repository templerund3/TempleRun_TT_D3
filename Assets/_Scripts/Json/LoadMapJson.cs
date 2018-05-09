using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadMapJson : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //LoadMapFromJson(1);
    }
    //public void ReadMapFromJson(int _level)
    //{
    //    string dbPath = "";
    //    if (Application.platform == RuntimePlatform.Android)
    //    {
    //        // Path.Combine combines strings into a file path
    //        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
    //        string filePath = Path.Combine(Application.streamingAssetsPath, "Level" + _level + ".json");
    //        Debug.Log(filePath);
    //        WWW reader = new WWW(filePath);
    //        while (!reader.isDone) { }
    //        string realPath = Application.persistentDataPath + "Level" + _level.ToString();
    //        System.IO.File.WriteAllBytes(realPath, reader.bytes);
    //        dbPath = realPath;
    //        if (File.Exists(dbPath))
    //        {
    //            // Read the json from the file into a string
    //            string dataAsJson = File.ReadAllText(dbPath);

    //            // Pass the json to JsonUtility, and tell it to create a GameData object from it
    //            //map = JsonHelper.FromJson<Map>(dataAsJson);
    //            Debug.Log(dbPath);
    //            var objJson = SimpleJSON.JSON.Parse(dataAsJson);
    //        }
    //        else
    //        {
    //            Debug.LogError("Cannot load game data!");
    //        }
    //    }
    //    else
    //    {
    //        string filePath = Path.Combine(Application.streamingAssetsPath, "Level" + _level + ".json");
    //        Debug.Log(filePath);
    //        if (File.Exists(filePath))
    //        {
    //            //string dataAsJson = File.ReadAllText(dbPath);
    //            string dataAsJson = loadMapJson(_level);
    //            // Pass the json to JsonUtility, and tell it to create a GameData object from it
    //            //map = JsonHelper.FromJson<Map>(dataAsJson);
    //            //Debug.Log(dbPath);
    //            var objJson = SimpleJSON.JSON.Parse(dataAsJson);
    //            Debug.Log(objJson);
    //        }
    //        else
    //        {
    //            Debug.LogError("Cannot load game data!");
    //        }
    //    }

    //    //StartCoroutine(ClosePaneLoad_TimeOut());
    //}

    Map map = new Map();
    public void LoadMapFromJson(int _level)
    {
        var objJson = SimpleJSON.JSON.Parse(loadMapJson(_level));
        Debug.Log(objJson);
        if(objJson != null)
        {
            map.backgroundName = objJson["BackgroundName"];
            map.star3 = objJson["star3"].AsInt;
            map.star2 = objJson["star2"].AsInt;
            var items = objJson["items"];
            map.itemsInMapCurrent = new Map.itemInMap[items.Count];
            
            //map.itemsInMapCurrent = JsonHelper.FromJson<Map.itemInMap>(items);
            Debug.Log(map.itemsInMapCurrent.Length);
            for (int i = 0; i < map.itemsInMapCurrent.Length; i++)
            {
                map.itemsInMapCurrent[i].name = items[i]["name"];
                map.itemsInMapCurrent[i].posX = items[i]["posX"].AsFloat;
                map.itemsInMapCurrent[i].posY = items[i]["posY"].AsFloat;
                map.itemsInMapCurrent[i].rotX = items[i]["rotX"].AsFloat;
                map.itemsInMapCurrent[i].rotY = items[i]["rotY"].AsFloat;
                map.itemsInMapCurrent[i].rotZ = items[i]["rotZ"].AsFloat;
                map.itemsInMapCurrent[i].scaleX = items[i]["scaleX"].AsFloat;
                map.itemsInMapCurrent[i].scaleY = items[i]["scaleY"].AsFloat;

                for (int j = 0; j < _item.Count; j++)
                {
                    if (_item[j].name.Contains(map.itemsInMapCurrent[i].name))
                    {
                        GameObject a = Instantiate(_item[j], objMap.transform, true);
                        a.transform.position = new Vector2(map.itemsInMapCurrent[i].posX, map.itemsInMapCurrent[i].posY);
                        a.transform.rotation = Quaternion.Euler(new Vector3(map.itemsInMapCurrent[i].rotX, map.itemsInMapCurrent[i].rotY, map.itemsInMapCurrent[i].rotZ));
                        //a.transform.localScale = new Vector2(map.itemsInMapCurrent[i].scaleX, map.itemsInMapCurrent[i].scaleY);
                    }
                }

                Debug.Log(map.itemsInMapCurrent[i].name);
            }
        }
    }

    public GameObject objMap;

    public List<GameObject> _item;

    string loadMapJson(int _level)
    {
        TextAsset _text = Resources.Load("Level" + _level) as TextAsset;
        return _text.text;

    }
}
