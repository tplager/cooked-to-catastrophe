using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FoodSingleton : MonoBehaviour
{
    private static FoodSingleton _instance;

    public static FoodSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("FoodSingleton");
                _instance = obj.AddComponent<FoodSingleton>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);


    }

    /// <summary>
    /// Author: John Vance
    /// Purpose: Called whenever a scene loads
    /// Restrictions: None
    /// </summary>
    /// <param name="scene">The scene being loaded</param>
    /// <param name="mode">What mode the scene loads in</param>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //food = null;
        if (scene.name == "Kitchen" || scene.name == "130_Kitchen")
        {
            GameObject obj = GameObject.Find("/Canvas/Plate");

            if (obj != null && (obj.transform.childCount > 0))
            {
                SetToPlate(obj);

            }

        }
        if (scene.name == "Cafeteria" || scene.name == "130_Cafeteria")
        {
            GameObject obj = GameObject.Find("/Canvas/Serving Plate");

            if (obj != null)
            {
                SetToPlate(obj);


            }

        }
    }


    public void SetToPlate(GameObject obj)
    {
        this.transform.position = obj.transform.position;
        this.transform.SetParent(obj.transform);
        Destroy(Instance);

    }

}
