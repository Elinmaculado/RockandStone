using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
    //Variables
    //Clicking / Score
    public Text scoreText;
    public float currentScore;
    public float clickPower;
    public float scoreIncreasePerSecond;
    public float x;

    //Planet Color
    //public float darkenAmount = 0.1f;
    public float planetDarkLimit;
    [SerializeField] private Color currentColor;
    private Image image;

    //Shop
    public Text shop1Text;
    public int shop1Price;
    public Button shop1Button;

    public Text shop2Text;
    public int shop2Price;
    public Button shop2Button;

    public Text shop3Text;
    public int shop3Price;
    public Button shop3Button;

    public Text ammount1Text;
    public int ammount1;
    public float ammount1Profit;
    
    public Text ammount2Text;
    public int ammount2;
    public float ammount2Profit;

    public Text ammount3Text;
    public int ammount3;
    public float ammount3Profit;

    private int shopLimit = 10;

    //UpgradeClick
    public int upgradePrice;
    public Text upgradeText;
    public Button upgradeButton;

    public GameObject gameEnd;

    void Start()
    {
        image = GetComponentInParent<Image>();
        currentColor = image.color;
        currentScore = 0;
        //hitPower = 1;
        scoreIncreasePerSecond = 1;
        x = 0f;
        
        shop1Text.text = "Tier 1: " + shop1Price + " $";
        shop2Text.text = "Tier 2: " + shop2Price + " $";
        shop3Text.text = "Tier 3: " + shop3Price + " $";


        ammount1Text.text = "Lvl " + ammount1 + ": $" + ammount1Profit + "/s";
        ammount2Text.text = "Lvl " + ammount2 + ": $" + ammount2Profit + "/s";
        ammount3Text.text = "Lvl " + ammount3 + ": $" + ammount3Profit + "/s";

        upgradeText.text = "Price: " + upgradePrice + " $";
    }

    void Update()
    {
        //Click
        scoreText.text = (int)currentScore + " $";
        scoreIncreasePerSecond = x * Time.deltaTime;
        currentScore += scoreIncreasePerSecond;
        UpdateColor();

        if (currentScore < shop1Price || ammount1 >= shopLimit)
        {
            shop1Button.interactable = false;
        }
        else
        {
            shop1Button.interactable = true;
        }
        
        if (currentScore < shop2Price || ammount2 >= shopLimit)
        {
            shop2Button.interactable = false;
        }
        else
        {
            shop2Button.interactable = true;
        }
        if (currentScore < shop3Price || ammount3 >= shopLimit)
        {
            shop3Button.interactable = false;
        }
        else
        {
            shop3Button.interactable = true;
        }

        if (currentScore < upgradePrice)
        {
            upgradeButton.interactable = false;
        }
        else
        { 
            upgradeButton.interactable = true; 
        }
    }

    #region Click
    public void Hit()
    {
        currentScore += clickPower;
    }

    public void UpdateColor()
    {
        if (currentScore >= planetDarkLimit)
        {
            endGame();
        }
        float progress = Mathf.Clamp01(currentScore / planetDarkLimit);
        currentColor = image.color;

        // Calcular los nuevos valores de color basados en el progreso
        currentColor.r = Mathf.Lerp(1f, 0f, progress); // De 1 a 0 conforme a progress
        currentColor.g = Mathf.Lerp(1f, 0f, progress);
        currentColor.b = Mathf.Lerp(1f, 0f, progress);

        // Asignar el nuevo color a la imagen
        image.color = currentColor;
    }
    #endregion

    #region Shop
    public void Shop1()
    {

            currentScore -= shop1Price;
            ammount1 += 1;
            ammount1Profit += 1;
            x += 1;
            shop1Price += 25;
            shop1Text.text = "Tier 1: " + shop1Price + " $";
            ammount1Text.text = "Lvl " + ammount1 + ": $" + ammount1Profit + "/s";
            if (ammount1 >=10)
            {
                shop1Button.interactable = false;
                shop1Text.text = "Tier 1 MAX";
                
            }
        
    }

    public void Shop2()
    {

            currentScore -= shop2Price;
            ammount2 += 1;
            ammount2Profit += 5;
            x += 5;
            shop2Price += 125;
            shop2Text.text = "Tier 2: " + shop2Price + " $";
            ammount2Text.text = "Lvl " + ammount2 + ": $" + ammount2Profit + "/s";
            if (ammount2 >= 10)
            {
                shop2Button.interactable = false;
                shop2Text.text = "Tier 2 MAX";
            }
        
    }

    public void Shop3()
    {

            currentScore -= shop3Price;
            ammount3 += 1;
            ammount3Profit += 15;
            x += 15;
            shop3Price += 400;
            shop3Text.text = "Tier 3: " + shop3Price + " $";
            ammount3Text.text = "Lvl " + ammount3 + ": $" + ammount3Profit + "/s";
            if (ammount3 >= 10)
            {
                shop3Button.interactable = false;
                shop3Text.text = "Tier 3 MAX";
            }
        
    }

    //UpgradeClick
    public void Upgrade()
    {
        if (currentScore >= upgradePrice)
        {
            currentScore -= upgradePrice;
            clickPower *= 2;
            upgradePrice *= 3;
            upgradeText.text = "Price: " + upgradePrice + " $";
            if (clickPower >=12)
            {
                upgradeButton.interactable = false;
                upgradeText.text = "MAX";
            }
        }
    }
    #endregion

   public void endGame()
    {
        image.enabled = false;
        gameEnd.SetActive(true);
    }
}
