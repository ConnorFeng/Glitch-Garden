using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    [SerializeField]
    int enemyRemain = 0;

    [SerializeField]
    bool timeFinished = false;

    [SerializeField]
    GameObject levelCompleteCanvas;

    [SerializeField]
    GameObject levelLoseCanvas;

    [SerializeField]
    float timeOfWinVFX = 5f;

    private void Start()
    {
        if(levelCompleteCanvas)levelCompleteCanvas.SetActive(false);
        if(levelLoseCanvas)levelLoseCanvas.SetActive(false);
    }

    public void AttackerSpawned()
    {
        enemyRemain++;
    }

    public void TimeFinished()
    {
        timeFinished = true;
        StopSpawners();
    }
     
    public void AttackerKilled()
    {
        enemyRemain--;
        if (timeFinished && enemyRemain == 0)
        {
            //Debug.Log("You win!");
            StartCoroutine(WinVFX());
        }
    }

    IEnumerator WinVFX()
    {
        levelCompleteCanvas.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timeOfWinVFX);
        //Debug.Log("Next level!");
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        Time.timeScale = 0;
        levelLoseCanvas.SetActive(true);
        
    }


    private void StopSpawners()
    {
        AttackerSpawner[] attackerSpawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach( AttackerSpawner spawner in attackerSpawnerArray)
        {
            spawner.StopSpawn();
        }

    }

}
