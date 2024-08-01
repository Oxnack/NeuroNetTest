using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonSave : MonoBehaviour
{
    private string filePath;

    private void Start()
    {
        filePath = Path.Combine(Application.dataPath, "playerData.json");
    }

    public void SaveData(NeuroNetData data)
    {
        filePath = Path.Combine(Application.dataPath, "playerData.json");
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(filePath, json);
        Debug.Log("Data saved to " + filePath);
    }

    public NeuroNetData LoadData()
    {
        filePath = Path.Combine(Application.dataPath, "playerData.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            NeuroNetData data = JsonConvert.DeserializeObject<NeuroNetData>(json);
            Debug.Log("Data loaded from " + filePath);
            return data;
        }
        else
        {
            Debug.LogWarning("File not found: " + filePath);
            return null;
        }
    }
}

[System.Serializable]
public class NeuroNetData
{
    public float[] bestMass1 = new float[6];
    public float[] bestMass2 = new float[2];

    public int generation = 1; 
}
