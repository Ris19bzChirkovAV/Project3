using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadScenes : MonoBehaviour
{
    public int SceneId;
    public Image loadFill;
    void Start()
    {
        StartCoroutine(loadFunc());
    }


    IEnumerator loadFunc()
    {
        AsyncOperation Operation = SceneManager.LoadSceneAsync(SceneId);
        while (!Operation.isDone)
        {
            float Progress = Operation.progress;
            loadFill.fillAmount = Progress;
            yield return null;
        }
        this.enabled = false;
    }
}
