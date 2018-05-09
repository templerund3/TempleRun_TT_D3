using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadMapJson : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        LoadMapFromJson(1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Map mapCurrent;
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

    /// <summary>
    /// Close panle loading...
    /// </summary>
    /// <returns></returns>
    public IEnumerator ClosePaneLoad_TimeOut()
    {
        yield return new WaitForSeconds(7.0f);
    }
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
            Debug.Log(map.itemsInMapCurrent.Length);
            //map.itemsInMapCurrent[0] = JsonHelper.FromJson<Map.itemInMap>(items.ToString())[0];
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
                //Debug.Log(map.itemsInMapCurrent[i].name);
            }
        }
    }

    string loadMapJson(int _level)
    {
        TextAsset _text = Resources.Load("Level" + _level) as TextAsset;
        return _text.text;

    }
}
