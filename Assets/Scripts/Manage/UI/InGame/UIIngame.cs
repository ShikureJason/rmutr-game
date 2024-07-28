using UnityEngine;
using UnityEngine.UIElements;

[DisallowMultipleComponent]
public class UIIngame : MonoBehaviour
{
    public static BoolEvent OnInteractChanged;
    public static VoidEvent SettingPopupEvent;

    [SerializeField] private InputReaderSO _inputReader = default;

    [Header("Event Listener")]
    [SerializeField] private InteractEvent _interacteventListener = default;
    [SerializeField] private VoidEvent _initializeStartSceneListener = default;
    [SerializeField] private BoolEvent _loadScreenListener = default;
    [SerializeField] private VoidEvent _initializeManageStartEventListener = default;


    private const string inventoryName = "inventory";
    private const string minimapName = "minimap";
    private const string popupIngameName = "ui";
    private const string pauseMenuName = "pause_menu";
    private const string loadScreenName = "load_screen";


    private UIView inventoryView;
    private UIView minimapView;
    private UIView popupIngameView;
    private UIView pauseMenuView;
    private UIView loadScreenView;


    private bool isInventory = false;
    private bool isPause = false;
    private bool isSettingPopup = false;
    // Start is called before the first frame update

    private void OnEnable()
    {
        initlize();
        _initializeManageStartEventListener.OnEventRaised += onviewready;
        _inputReader.InventoryEvent += inventoryPopup;
        _inputReader.EscapeEvent += popupPauseMenu;
        _interacteventListener.OnEventRaised += interact;

        _initializeStartSceneListener.OnEventRaised += getInGame;
        _loadScreenListener.OnEventRaised += loadScreenPopup;
    }

    private void OnDisable()
    {
        _initializeManageStartEventListener.OnEventRaised -= onviewready;
        _inputReader.InventoryEvent -= inventoryPopup;
        _inputReader.EscapeEvent -= popupPauseMenu;
        _interacteventListener.OnEventRaised -= interact;
        PauseMenuView.ExitToMainMenuEvent.OnEventRaised -= exitToMainMenu;
        PauseMenuView.ResumeEvent.OnEventRaised -= popupPauseMenu;
        PauseMenuView.OnSettingPopupChange.OnEventRaised -= settingPopup;
        _initializeStartSceneListener.OnEventRaised -= getInGame;
        _loadScreenListener.OnEventRaised -= loadScreenPopup;
    }

    private void initlize()
    {
        OnInteractChanged = ScriptableObject.CreateInstance<BoolEvent>();
        SettingPopupEvent = ScriptableObject.CreateInstance<VoidEvent>();
    }

    private void onviewready()
    {
        Debug.Log("Start");
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        inventoryView = new InventoryView(root.Q<VisualElement>(inventoryName));
        minimapView = new MinimapView(root.Q<VisualElement>(minimapName));
        popupIngameView = new PopupInGameView(root.Q<VisualElement>(popupIngameName));
        pauseMenuView = new PauseMenuView(root.Q<VisualElement>(pauseMenuName));
        loadScreenView = new LoadScreenView(root.Q<VisualElement>(loadScreenName));

        PauseMenuView.ExitToMainMenuEvent.OnEventRaised += exitToMainMenu;
        PauseMenuView.ResumeEvent.OnEventRaised += popupPauseMenu;
        PauseMenuView.OnSettingPopupChange.OnEventRaised += settingPopup;
    }
    
    private void getInGame()
    {
        if (GameManager.Instance.CurrentSceneType == SceneType.Main)
        {
            minimapView.Show();
            popupIngameView.Show();
        }

    }

    private void DisposeAllView()
    {
        minimapView.Dispose();
        inventoryView.Dispose();
        popupIngameView.Dispose();
        pauseMenuView.Dispose();
    }

    private void inventoryPopup()
    {
        isInventory = !isInventory;

        if (isInventory) 
        {
            inventoryView.Hide();
        }
        else
        {
            inventoryView.Show();
        }
        
    }

    private void popupPauseMenu()
    {
        isPause = !isPause;

        if (isPause)
        {
            minimapView.Hide();
            GameManager.Instance.AdjustGameTime(isPause);
            pauseMenuView.Show();
        }
        else
        {
            if (isSettingPopup)
            {
                SettingPopupEvent.RaiseEvent();
                isPause = true;
            }
            else 
            {
                GameManager.Instance.AdjustGameTime(isPause);
                pauseMenuView.Hide();
                minimapView.Show();
            }
            
        }

    }
    private void interact(InteractType type, bool expression)
    {
        OnInteractChanged.RaiseEvent(expression);
    }

    private void exitToMainMenu()
    {
        
        pauseMenuView.Hide();
        GameManager.Instance.BackToMainMenu();
    }

    private void settingPopup(bool expression) => isSettingPopup = expression;

    private void loadScreenPopup(bool expression)
    {
        if (expression)
        {
            Debug.Log("LoadScreen Show");
            loadScreenView.Show();
        }
        else
        {
            Debug.Log("LoadScreen Hide");
            loadScreenView.Hide();
        }
    }
}
