using System.Collections;
using System.Collections.Generic;
using UnityEditor;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currenLevel;
    [SerializeField] private int enemisenemis;
    [SerializeField] private int enemiesPassed = 0;
    [SerializeField] UiEndGame uiEndGame;
    [SerializeField] List<GameObject> activeEnemies = new List<GameObject>();

    public int Enemisenemis => enemisenemis;
    public static GameManager Instance;
    SpawnEnemySystem spawnEnemySystem;





    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {

            Destroy(this.gameObject);
        }
        spawnEnemySystem = GetComponentInChildren<SpawnEnemySystem>();

    }

    void Start()
    {
        AudioManager.Instance.musicAudioSource.Play();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEnemySpawned(GameObject gameObject)
    {
        activeEnemies.Add(gameObject);

    }

    // Gọi khi enemy chết
    public void OnEnemyDied(GameObject gameObject)
    {
        activeEnemies.Remove(gameObject);


        // activeEnemies -= 1;
        if (activeEnemies.Count <= 0 && spawnEnemySystem.IsEndWave())
        {
            CountEnemyPassed();
            YouWin();
            AudioManager.Instance.PlaySFX(AudioManager.Instance.victory);
        }
    }
    public void YouWin()
    {

        uiEndGame.gameObject.SetActive(true);
        uiEndGame.ActiveUiYouWin(CalculateStars());
        AudioManager.Instance.PlaySFX(AudioManager.Instance.victory);
        AudioManager.Instance.musicAudioSource.Pause();


        SaveSystem.SaveLevelData(currenLevel, CalculateStars(), true);
        if (CalculateStars() >= 1)
        {
            SaveSystem.SaveLevelData(currenLevel + 1, 0, true);
        }



    }
    public void YouLose()
    {
        uiEndGame.gameObject.SetActive(true);
        uiEndGame.ActiveUiYouLose();
        AudioManager.Instance.PlaySFX(AudioManager.Instance.youLose);
    }

    public void CountEnemyPassed()
    {
        enemiesPassed++;
        if (enemiesPassed >= Enemisenemis)
        {
            YouLose();
        }

    }

    public int CalculateStars()
    {
        float ratioEnemyPassed = ((float)enemiesPassed / Enemisenemis) * 100f;
        int stars = 0;

        if (ratioEnemyPassed <= 33) stars += 3;
        if (ratioEnemyPassed > 33 && ratioEnemyPassed <= 66) stars += 2;
        if (ratioEnemyPassed > 66) stars += 1;




        return stars;
    }
}
