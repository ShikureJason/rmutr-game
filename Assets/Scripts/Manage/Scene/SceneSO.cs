using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "New Scene", menuName = "Scenes/Create Scene")]
public class SceneSO : ScriptableObject
{
    [SerializeField] private AssetReference _scene;
    [SerializeField] private SceneType _sceneType = default;

    public AssetReference Scene => _scene;
    public SceneType SceneType => _sceneType;

}
