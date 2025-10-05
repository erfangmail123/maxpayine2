using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int highScore;
    public float musicVolume;
    public float sfxVolume;
    // اضافه کنید فیلدهای دیگر لازم را
}

public static class SaveSystem
{
    static string SavePath => Path.Combine(Application.persistentDataPath, "savegame.json");

    public static void Save(SaveData data)
    {
        var json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);
        Debug.Log("Saved to: " + SavePath);
    }

    public static SaveData Load()
    {
        if (!File.Exists(SavePath)) return new SaveData();
        var json = File.ReadAllText(SavePath);
        return JsonUtility.FromJson<SaveData>(json);
    }
}
