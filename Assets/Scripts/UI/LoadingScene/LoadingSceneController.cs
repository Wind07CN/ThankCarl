using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    [SerializeField] private float timer = 10f;

    private void Start()
    {

    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            StartCoroutine(LoadNextAsyncScene());
        }
    }

    IEnumerator LoadNextAsyncScene()
    {
        string sceneTag = Utils.GetDataRecord().NextSceneNum;
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneTag);

        while (!load.isDone)
        {
            yield return null;
        }
    }

}
