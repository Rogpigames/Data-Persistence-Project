using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static DataManager Instance;
    public string userName;
    public string savedUserName;
    public int savedScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        LoadName();
        LoadScore();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData //Clase que creas para guardar todo
    {
        public string userScoreName;
        public int gameScore;
    }

    public void SaveName()
    {
        SaveData dataUserName = new SaveData();
        savedUserName = userName;
        dataUserName.userScoreName = savedUserName;

        string jsonUserName = JsonUtility.ToJson(dataUserName);

        File.WriteAllText(Application.persistentDataPath + "/highestscore.json", jsonUserName);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/highestscore.json";
        if (File.Exists(path))
        {
            string jsonUserName = File.ReadAllText(path);
            SaveData dataUserName = JsonUtility.FromJson<SaveData>(jsonUserName);

            savedUserName = dataUserName.userScoreName;
        }
    }

    public void SaveScore()
    {
        SaveData dataScoreName = new SaveData();
        dataScoreName.gameScore = savedScore;

        string jsonUserName = JsonUtility.ToJson(dataScoreName);

        File.WriteAllText(Application.persistentDataPath + "/highestscorenumber.json", jsonUserName);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/highestscorenumber.json";
        if (File.Exists(path))
        {
            string jsonUserName = File.ReadAllText(path);
            SaveData dataScoreName = JsonUtility.FromJson<SaveData>(jsonUserName);

            savedScore = dataScoreName.gameScore;
        }
    }
}
