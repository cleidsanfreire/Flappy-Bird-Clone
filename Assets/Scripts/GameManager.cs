using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [FormerlySerializedAs("prefabs")] // Alterar o nome sem alterar os atribbutos no Unity
    public List<GameObject> obstaclePrefabs;
    public float obstacleInterval = 1.5f;

    public float obstacleSpeed = 8;

    public float obstacleOffsetX = 30;
    public Vector2 obstacleOffsetY = new Vector2(0, 0);

    [HideInInspector]
    public int score;
    private bool isGameOver = false;

    void Awake()
    { // deixei o Awake como (awake) e ficou dando erro. Atente-se a digitação!
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameActive()
    {
        return !isGameOver;
    }

    public void EndGame()
    {
        // Set flag
        isGameOver = true;
        Debug.Log("Game Over!... You Score is " + score);

        // Reload scene
        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay){
        // Esperar 2 segundos(delay)
        yield return new WaitForSeconds(delay); // yield (Coroutines)
        //Recarregar a cena
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Reload scene please. wait!!!");
        //

    }
}
