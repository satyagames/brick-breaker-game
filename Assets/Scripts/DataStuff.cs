using UnityEngine;
using System.IO;

public class DataStuff : MonoBehaviour
{
    public static DataStuff Instance;

    public string userName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadJason();
    }

    [System.Serializable]
    class SaveData
    {
        public string userName;
        public int bestScore;
    }

    [ContextMenu("save data")] 
    public void SaveJason()
    {
        SaveData data = new SaveData();
        data.userName = userName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadJason()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.userName;
            bestScore = data.bestScore;
        }
    }
}