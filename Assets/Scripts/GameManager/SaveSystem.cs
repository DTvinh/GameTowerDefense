using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private static string savePath => Application.persistentDataPath + "/gameDefence.json";

    // Lưu dữ liệu level

    void Awake()
    {
        // DontDestroyOnLoad(gameObject);
        NewGame();
        Debug.Log(savePath);
    }

    public static void NewGame()
    {
        GameProgressData data = LoadProgress();
        if (data.levels.Count <= 0)
        {
            SaveLevelData(1, 0, true);

        }
    }
    public static void SaveLevelData(int levelNumber, int stars, bool unLock)
    {
        GameProgressData data = LoadProgress();

        LevelData levelData = data.levels.Find(x => x.levelNumber == levelNumber);
        if (levelData == null)
        {
            levelData = new LevelData();
            data.levels.Add(levelData);
        }
        levelData.levelNumber = levelNumber;
        if (stars > levelData.starsEarned)
        {
            levelData.starsEarned = stars;
        }
        levelData.unLock = unLock;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
        // Debug.Log(Application.persistentDataPath + "/gameDefence.json");
    }
    // Lấy dữ liệu level
    public static LevelData GetLevelData(int levelNumber)
    {
        GameProgressData data = LoadProgress();
        LevelData levelData = data.levels.Find(x => x.levelNumber == levelNumber);

        if (levelData == null)
        {
            return new LevelData() { levelNumber = levelNumber, starsEarned = 0, unLock = false };
        }
        return levelData;
    }

    public static GameProgressData GetData()
    {
        GameProgressData data = LoadProgress();

        return data;
    }


    private static GameProgressData LoadProgress()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<GameProgressData>(json);
        }
        return new GameProgressData();
    }

    public static void SaveSettingSound()
    {
        GameProgressData data = LoadProgress();
        AudioManager.Instance.SaveSettingVolume(ref data.settingSound);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
        // Debug.Log(Application.persistentDataPath + "/gameDefence.json");

    }
}



[System.Serializable]
public class LevelData
{

    public int levelNumber;
    public int starsEarned;
    public bool unLock;

}

[System.Serializable]
public class GameProgressData
{
    public List<LevelData> levels = new List<LevelData>();
    public SettingSound settingSound;
}
