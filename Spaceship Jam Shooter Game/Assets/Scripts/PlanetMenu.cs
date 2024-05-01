using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetMenu : MonoBehaviour
{
    [SerializeField]
    private int GoToSceneID;

    public void SelectPlanet()
    {
        //Debug.Log("Planet selected");
        SceneManager.LoadScene(GoToSceneID);
    }
}
