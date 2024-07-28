using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MapController : MonoBehaviour
{
    public RectTransform minimapArea;
    [Header("Event Listenner")]
    [SerializeField] private VoidEvent _playerHasSpawnEventListenner = default;
    private GameObject Player;
    private VisualElement _root;
    private VisualElement _playerRepresentation;
    private VisualElement _mapContainer;
    private VisualElement _mapImage;

    [Range(1, 15)]
    public float miniMultiplyer = 1f;
    [Range(1, 15)]
    public float fullMultiplyer = 1f;

    private void OnEnable()
    {
        _playerHasSpawnEventListenner.OnEventRaised += setupTranformPlayer;
    }

    private void OnDisable()
    {
        _playerHasSpawnEventListenner.OnEventRaised -= setupTranformPlayer;
    }

    void Start()
    {
        //Get references
        _root = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("container");
        _mapImage = _root.Q<VisualElement>("map_image");
        _mapContainer = _root.Q<VisualElement>("map");
        _playerRepresentation = _root.Q<VisualElement>("arrow");

    }

    private void setupTranformPlayer()
    {
        Player = GameObject.FindWithTag("Player");
        _playerRepresentation.style.left = minimapArea.rect.width / 2;
        _playerRepresentation.style.top = minimapArea.rect.height / 2;
    }

    void LateUpdate()
    {
        UpdatePlayerIconPosition();
    }

    /// <summary>
    /// Check wither the map is in "full" mode
    /// </summary>
    //private bool IsMapOpen => _root.ClassListContains("root-container-full");


    /// <summary>
    /// Toggle between full and mini mode
    /// </summary>
    /// <param name="on">Should the map be in full mode?</param>
    /// 
    private void UpdatePlayerIconPosition()
    {
        Vector2 minimapPosition = WorldToMinimapPosition(Player.transform.position);
        _mapImage.style.left = -minimapPosition.x + (minimapArea.rect.width / 2);
        _mapImage.style.top = -minimapPosition.y + (minimapArea.rect.height / 2);
    }

    private Vector2 WorldToMinimapPosition(Vector3 worldPosition)
    {
        float minimapWidth = _mapImage.resolvedStyle.width;
        float minimapHeight = _mapImage.resolvedStyle.height;
        float worldWidth = 100; 
        float worldHeight = 100;

        float x = (worldPosition.x / worldWidth) * minimapWidth;
        float y = (worldPosition.z / worldHeight) * minimapHeight;

        return new Vector2(x, y);
    }
    private void ToggleMap(bool on)
    {
        _root.EnableInClassList("root-container-mini", !on);
        _root.EnableInClassList("root-container-full", on);
    }


}
