using UnityEngine;

[System.Serializable]
public class SaveSetting
{
    public int localindex;
    public int resolutionindex;
    public int qualityindex;
    public float mastervolume;
    public float musicvolume;
    public float soundvolume;
    public bool isfullscreen;

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
}
