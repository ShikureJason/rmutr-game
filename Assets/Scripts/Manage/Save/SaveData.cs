using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public CharacterPrefapSO _currentCharacter;
    public SceneSO CurrentScene;
    [Header("Player Location")]
    public Vector3 Position;
    public Quaternion Rotation;

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
