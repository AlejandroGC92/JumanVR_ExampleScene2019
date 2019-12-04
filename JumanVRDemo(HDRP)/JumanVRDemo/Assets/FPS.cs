using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public Text fpsText;
    public Text volumeText;
    public GameObject fogVolume;
    bool gameobjectSwitch;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameobjectSwitch = !gameobjectSwitch;
        }
        fogVolume.SetActive(gameobjectSwitch);

        fpsText.text = "FPS = " + (1 / Time.deltaTime).ToString("00.0");

        if(gameobjectSwitch == true) volumeText.text = "Volume ON";
        else volumeText.text = "volume OFF";
    }
}
