using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.gameObject.name == "GameOverCollider")
        {
            Debug.Log("HIT THE COLLIDER");
            LoadLevelFailed();
        }
        if (myCollider.gameObject.name == "NextLevelCollider")
        {
            Debug.Log("HIT THE COLLIDER");
            StartCoroutine(DelayTheBox());
            
        }
    }
    IEnumerator DelayTheBox()
    {
        yield return new WaitForSeconds(5);
        LoadLevelComplete();
    }
    public void LoadLevelFailed()
    {
        SceneManager.LoadScene("LevelFailed");
    }
    public void LoadLevelComplete()
    {
        SceneManager.LoadScene("LevelComplete");
    }

}
