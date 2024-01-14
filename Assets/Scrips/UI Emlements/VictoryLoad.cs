using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DeactivateGameObjects();
    }

    void DeactivateGameObjects()
    {
        // Holen Sie sich alle GameObjects in der aktuellen Szene
        GameObject[] allGameObjects = SceneManager.GetSceneByBuildIndex(2).GetRootGameObjects();

        // Deaktiviere jedes GameObject
        foreach (GameObject go in allGameObjects)
        {
            go.SetActive(false);
        }
    }


}
