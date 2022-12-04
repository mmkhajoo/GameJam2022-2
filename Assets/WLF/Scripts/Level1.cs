using DefaultNamespace;
using TMPro;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public TextMeshProUGUI tvText;
    
    // Start is called before the first frame update
    public Animator leftArrow;
    public GameObject leftLight;
    public TriggerEventHandler[] leftTrigger;

    private int _leftCounter;

    public Animator rightArrow;
    public GameObject rightLight;
    public TriggerEventHandler[] rightTrigger;

    private int _rightCounter;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRightArrowAnimation()
    {
        if (_rightCounter == rightTrigger.Length)
        {
            tvText.SetText("Welcome to Passion");
            leftArrow.enabled = false;
            leftLight.SetActive(false);
            
            return;
        }
        
        if (_leftCounter > 0)
        {
            leftTrigger[_leftCounter-1].gameObject.SetActive(false);
            leftArrow.enabled = false;
            leftLight.SetActive(false);
        }

        rightArrow.enabled = true;
        rightArrow.Play("UpDown-Right");
        rightTrigger[_rightCounter].gameObject.SetActive(true);
        rightLight.SetActive(true);
        
        tvText.SetText("Go to Right =>");

        _rightCounter++;

        Debug.Log("Right Arrow Called.");
    }

    public void StartLeftArrowAnimation()
    {
        if (_leftCounter == leftTrigger.Length)
        {
            tvText.SetText("Welcome to Passion");
            rightArrow.enabled = false;
            rightLight.SetActive(false);
            
            return;
        }
        
        if (_rightCounter > 0)
        {
            rightTrigger[_rightCounter-1].gameObject.SetActive(false);
            rightArrow.enabled = false;
            rightLight.SetActive(false);
        }

        leftArrow.enabled = true;
        leftArrow.Play("UpDown");
        leftTrigger[_leftCounter].gameObject.SetActive(true);
        leftLight.SetActive(true);
        
        tvText.SetText("<= Go to Left");

        _leftCounter++;
        
        Debug.Log("Left Arrow Called.");
    }

    public void MakeThingsColorFull()
    {
        var colorFullHandler = FindObjectOfType<PlayerLightHandler>(true);
        
        colorFullHandler.ActivateMask();
    }


}
