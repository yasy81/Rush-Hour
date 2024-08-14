using TMPro; // Add this line to use Text Mesh Pro
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Change the type to TextMeshProUGUI
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = ((int)(t % 60)).ToString("00"); // Format with leading zero

        timerText.text = minutes + ":" + seconds;
    }
}
