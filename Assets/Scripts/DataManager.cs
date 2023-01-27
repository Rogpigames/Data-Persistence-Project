using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static DataManager Instance;
    public string userName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        LoadName();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData //Clase que creas para guardar todo
    {
        public string userScoreName;
    }

    public void SaveName()
    {
        SaveData dataUserName = new SaveData();
        dataUserName.userScoreName = userName;

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

            userName = dataUserName.userScoreName;
        }
    }
}
