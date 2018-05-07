using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScenesManager : MonoBehaviour {

    public enum TypeScene
    {
        Spl,Home, SelectLevel, GamePlay
    }

    [System.Serializable]
    public struct Scenes
    {
        public TypeScene type;
        public GameObject objects;
    }

    public static ScenesManager Instance;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GoToScene(TypeScene.Home);
    }

    public Scenes[] secenes;
    public int currentScenes;

    public void GoToScene(TypeScene typeScene, UnityAction actionLoadScenesDone = null)
    {
        StartCoroutine(GoToSceneHandel(typeScene, actionLoadScenesDone));
    }

    private IEnumerator GoToSceneHandel(TypeScene typeScene, UnityAction actionLoadScenesDone = null)
    {
        Fade.Instance.StartFade();
        yield return new WaitUntil(() => Fade.Instance.state == Fade.FadeState.FadeInDone);

        secenes[currentScenes].objects.SetActive(false);

        for (int i = 0; i < secenes.Length; i++)
        {
            if (secenes[i].type == typeScene)
            {
                currentScenes = i;
                secenes[currentScenes].objects.SetActive(true);
                break;
            }
        }

        if (actionLoadScenesDone != null)
            actionLoadScenesDone();

        yield return new WaitForSeconds(0.02f);
        Fade.Instance.EndFade();
    }

   
}
