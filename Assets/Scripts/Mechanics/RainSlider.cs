using UnityEngine;
using UnityEngine.UI;

public class SliderFillController : MonoBehaviour
{
    public Slider slider;
    public float fillDuration = 3f;
    public float defillDuration = 1f;

    private float targetValue;
    private float currentValue;
    private bool isFilling = false;
    private Raining RainManagerRaining;
    public Image fillImage;
    private Color fillColor = new Color(0,255,0);
    private Color defillColor = new Color(255,0, 0);
    private void Start()
    {
        // Initialize the slider value
        RainManagerRaining = GameObject.Find("RainManager").GetComponent<Raining>();
        targetValue = 0f;
        currentValue = 1f;
    }

    private void Update()
    {
        
        if (isFilling)
            targetValue = 1f;
        else
            targetValue = 0f;

        
        currentValue = Mathf.MoveTowards(currentValue, targetValue, Time.deltaTime / (isFilling ? fillDuration : defillDuration));

        
        slider.value = currentValue;

        
        if (Mathf.Approximately(currentValue, targetValue))
            isFilling = !isFilling; 
            RainManagerRaining.ChangeState(isFilling);
            fillImage.color = isFilling ? fillColor : defillColor;
    }
}