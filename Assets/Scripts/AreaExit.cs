using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    [SerializeField] string transitionAreaName;
   // [SerializeField] AreaEnter theAreaEnter;
    void Start()
    {
       // theAreaEnter.transitionAreaName = transitionAreaName;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.instance.transitionName = transitionAreaName;

            MenuManager.instance.FadeImage();

            StartCoroutine(LoadSceneCoroutine());
        }
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneToLoad);
    }

}
