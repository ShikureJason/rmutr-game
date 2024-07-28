using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ChoseSaveSlotView : UIView
{
    internal static SelectSaveEvent SelectSaveEvent = new SelectSaveEvent();

    private const string saveSlotView = "save_slot";
    private const string saveSlotCreateNameView = "create_name_save";
    private const string createSlotTextName = "textfield_create_slot_name";
    private const string createTextButtonName = "button_slot_name_comfirm";


    
    private List<SaveSlot> saveSlots = new List<SaveSlot>();

    private VisualElement createSaveNameElement;
    private VisualElement saveSlotElement;

    private Button buttonConfirmSlotName;


    private TextField textFieldCreateSlotName;

    private string slotName;
    private int slot;
    public ChoseSaveSlotView(VisualElement topElement) : base(topElement)
    {

    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        createSaveNameElement = m_TopElement.Q<VisualElement>(saveSlotCreateNameView);
        buttonConfirmSlotName = m_TopElement.Q<Button>(createTextButtonName);
        textFieldCreateSlotName = m_TopElement.Q<TextField>(createSlotTextName);
        saveSlotElement = m_TopElement.Q<VisualElement>(saveSlotView);

        initlizeSaveSlot();
    }

    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();
        textFieldCreateSlotName.RegisterCallback<ChangeEvent<string>>(evt => slotName = evt.newValue);
        buttonConfirmSlotName.RegisterCallback<ClickEvent>(evt => SelectSaveEvent.RaiseEvent(slotName, slot));

        registerCallbackSaveSlot();
    }

    private void initlizeSaveSlot()
    {
        for (int i = 0; i < 5; i++)
        {
            SaveSlot save = new SaveSlot();
            saveSlots.Add(save);
            saveSlotElement.Add(save);

            Debug.Log("Run + " + i);

            if (GameData.Instance.SaveDataList.Count > i && GameData.Instance.SaveDataList[i] != null)
            {
                saveSlots[i].SaveSlotData.style.display = DisplayStyle.Flex;
                saveSlots[i].SaveSlotEmpty.style.display = DisplayStyle.None;
            }
            else
            {
                saveSlots[i].SaveSlotEmpty.style.display = DisplayStyle.Flex;
                saveSlots[i].SaveSlotData.style.display = DisplayStyle.None;
            }
        }
    }

    private void registerCallbackSaveSlot()
    {
        for (int i = 0; i < saveSlots.Count; i++)
        {
            int slotIndex = i;
            saveSlots[slotIndex].RegisterCallback<ClickEvent>(evt => selectSaveSlot(slotIndex));
        }
    }

    private void selectSaveSlot(int slot)
    {
        saveSlotElement.style.display = DisplayStyle.None;
        createSaveNameElement.style.display = DisplayStyle.Flex;
        this.slot = slot;
        Debug.Log(slot);
    }

}

public class SaveSlot : VisualElement
{

    public VisualElement SaveSlotEmpty;
    public VisualElement SaveSlotData;
    
    public SaveSlot()
    {
         SaveSlotEmpty = new VisualElement();
         SaveSlotData = new VisualElement();

        AddToClassList("saveSlot-Slot");

        Label textSaveEmpty = new Label();
        textSaveEmpty.text = "Empty";
        textSaveEmpty.AddToClassList("saveslot-text-EmptySaveSlot");
        SaveSlotEmpty.Add(textSaveEmpty);
        SaveSlotEmpty.AddToClassList("saveSlot-SaveSlotContainer");
        SaveSlotData.AddToClassList("saveSlot-SaveSlotContainer");

        Add(SaveSlotEmpty);
        Add(SaveSlotData);
        
        SaveSlotEmpty.style.display = DisplayStyle.Flex;
        SaveSlotData.style.display = DisplayStyle.None;
    }
}

public class SelectSaveEvent
{
    internal UnityAction<string, int> OnEventRaised;

    internal void RaiseEvent(string slotName, int saveSlot) => OnEventRaised?.Invoke(slotName, saveSlot);
}
