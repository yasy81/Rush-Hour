using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    

    private MusicManager musicManager;
    private EngineManager engineManager;

    private void Start()
    {
        
        musicManager = FindObjectOfType<MusicManager>();
        engineManager = FindObjectOfType<EngineManager>();


        
    }

    

    
   
}
