using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //PS means Particle System

    public static GameController instance;
    public GameObject bullet;
    public GameObject ShootPS;

    public GameObject[] activateStuff;
    public GameObject loseCanvas;

    int currentSceneIndex;
    bool bulletShot;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        TinySauce.OnGameStarted(levelNumber: (currentSceneIndex+1).ToString());

        instance = this;

        if (loseCanvas!=null) { 
        loseCanvas.SetActive(false);
        }

        //this stuff will be set active after you win the level
        foreach (var item in activateStuff)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !bulletShot)
        {
            var shootFX = Instantiate(ShootPS, bullet.transform.position, Quaternion.identity);
            bullet.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(currentSceneIndex); 

        else { return; }
    }

    public void LevelComplete()
    {
        foreach (var item in activateStuff)
        {
            item.SetActive(true);
        }


        //while build enable this statement
        if(SceneManager.GetActiveScene().buildIndex < 1)
        {
            StartCoroutine(LoadLevelAfterDelay(currentSceneIndex+1));
            TinySauce.OnGameFinished(levelNumber: (currentSceneIndex + 1).ToString(), 1);
        }
        else
        {
            StartCoroutine(LoadLevelAfterDelay(0));
            TinySauce.OnGameFinished(levelNumber: (currentSceneIndex+1).ToString(), 0);
        }

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    IEnumerator LoadLevelAfterDelay(int sceneNo)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneNo);

    }

    public void LevelFailed()
    {
        loseCanvas.SetActive(true);
    }

}
