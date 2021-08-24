using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //M‰‰ritell‰‰n halutut atribuutit pelaajalle

    [SerializeField] string playerName;

    [SerializeField] int maxLevel = 50;
    [SerializeField] int playerLevel = 1;
    [SerializeField] int currentXP;
    [SerializeField] int[] xpForNextLevel;
    [SerializeField] int  baseLevelXP = 100;

    [SerializeField] int maxHP = 100;
    [SerializeField] int currentHP;

    [SerializeField] int maxMana = 100;
    [SerializeField] int currentMana;

    [SerializeField] int intelligence;
    [SerializeField] int strenght;
    [SerializeField] int dexterity;
    [SerializeField] int vitality;

    [SerializeField] int speed;
    [SerializeField] int dodge;
    [SerializeField] int parry;
    [SerializeField] int defence;

    // Start is called before the first frame update
    void Start()
    {
        xpForNextLevel = new int[maxLevel]; //Luodaan for-looppi, joka m‰‰ritt‰‰ kuinka monta taitotasoa pelaajalla on ja kuinka paljon kokemusta tarvitaan seuraavaan tasoon
        xpForNextLevel[1] = baseLevelXP;

        for (int i = 2; i < xpForNextLevel.Length; i++)
        {
            xpForNextLevel[i] = (int)(0.02f * i * i * i + 3.06f* i * i * i + 105.6f * i); // muutetaan float -> int
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddXP(100);
        }
    }

    public void AddXP(int amountOfXp) //luodaan methodi pelaajan tason kasvattamiseen
    {
        currentXP += amountOfXp; // sen hetkisen xp:n p‰‰lle lis‰t‰‰n tarvittava xp m‰‰r‰ tason kasvattamiseen
        if (currentXP > xpForNextLevel[playerLevel]) // Tarkistetaan, jos nykyinen xp on enemm‰n kuin tarvittava xp tason kasvattamiseen
        {
            currentXP = xpForNextLevel[playerLevel]; //Sillon pelaajan taso kasvaa seuraavalle tasolle
            playerLevel++;

            if(playerLevel % 2 == 0)
            {
                dexterity++;
            }
            else
            {
                defence++;
            }
            if (playerLevel % 1 == 0)
            {
                maxHP = maxHP + 10;
                maxMana = maxMana + 10;
            }

        }
    }
}
