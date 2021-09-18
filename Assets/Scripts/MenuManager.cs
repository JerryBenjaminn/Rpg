using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Image imageToFade;
    [SerializeField] GameObject menu;

    public static MenuManager instance;

    private PlayerStats[] playerStats;
    [SerializeField] TextMeshProUGUI[] nameText, hpText, manaText, lvlText, xpText;
    [SerializeField] Slider[] xpSlider;
    [SerializeField] Image[] characterImage;
    [SerializeField] GameObject[] characterPanel;
    private void Start()
    {
        instance = this;   
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.M)) // Tarkistetaan jos painetaan M-näppäintä, onko menu aktiivisena näytöllä. Jos ei, niin se aktivoidaan
        {
            if (menu.activeInHierarchy)
            {
                menu.SetActive(false);
            }
            else
            {
                menu.SetActive(true);
            }
        }      
    }
    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start fading");
    }
}
