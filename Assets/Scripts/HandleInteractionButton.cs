using System;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class HandleInteractionButton : MonoBehaviour , MMEventListener<CorgiEngineEvent>
{

    public UnityEvent OnInteractButtonClicked;

    private InputSystemManager _inputSystemManager;

    private Character _character;

    [SerializeField] private bool _isInInteractionArea;
    
    // Start is called before the first frame update
    void Start()
    {
        _inputSystemManager = FindObjectOfType<InputSystemManager>(true);
        
        _inputSystemManager.InputActions.PlayerControls.AlternativeInteract.performed +=AlternativeInteractOnPerformed;
    }

    private void AlternativeInteractOnPerformed(InputAction.CallbackContext button)
    {
        if(!_isInInteractionArea)
            return;
        
        var control = button.control;
        
        if (control is ButtonControl buttonControl)
        {
            if (buttonControl.wasPressedThisFrame)
            {
                CallEvent();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMMEvent(CorgiEngineEvent eventType)
    {
        if (eventType.EventType == CorgiEngineEventTypes.SpawnCharacterStarts)
        {
            _character = FindObjectOfType<Character>(true);

            Debug.Log("Character Assigned");
        }
    }

    private void CallEvent()
    {
        OnInteractButtonClicked?.Invoke();

        Debug.Log("F Button Triggered.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Interactable"))
        {
            _isInInteractionArea = true;

            Debug.Log("Player in Interaction Area");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Interactable"))
        {
            _isInInteractionArea = false;
        
            Debug.Log("Player Got Out of Interaction Area");
        }
    }

    private void OnEnable()
    {
        this.MMEventStartListening();
    }

    private void OnDisable()
    {
        this.MMEventStopListening();
    }
}
