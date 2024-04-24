using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.InputManagerEntry;

public class UIMainMenu : MonoBehaviour
{
    UIView mainMenuView;

    //test

    Button newgameButton;

    public const string MenuName = "Menu";

    private void OnEnable()
    {
        GetComponent<UIDocumentLocalization>().onCompleted += Bind;
        
    }

    private void OnDisable()
    {
        GetComponent<UIDocumentLocalization>().onCompleted -= Bind;
    }


    private void Start()
    {
        setupViews();
        //_continuegameButton.SetActive(_saveData.HasSaveData());
    }

    private void setupViews()
    {
         VisualElement root = GetComponent<UIDocument>().rootVisualElement;
         /*VisualElement mainMenu = root.Q<VisualElement>("test");
         if (mainMenu == null)
         {
             Debug.LogError("Cannot find main menu element.");
             return;
         }

         newgameButton = mainMenu.Q<Button>("button");
         if (newgameButton == null)
         {
             Debug.LogError("Cannot find new game button.");
             return;
         }

         newgameButton.RegisterCallback<ClickEvent>( ev => newGame());
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;*/

        mainMenuView = new MenuView(root.Q<VisualElement>("main_menu"));
        //mainMenuView.Show();
    }

    private void newGame()
    {
        Debug.Log("New game button clicked.");
    }
    public void SetActiveMainMenu(bool expression)
    {
        gameObject.SetActive(expression);
    }

    void Bind(VisualElement root)
    {

    }
}
