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
    public float hitPower;
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

    public Text shop2Text;
    public int shop2Price;

    public Text ammount1Text;
    public int ammount1;
    public float ammount1Profit;
    
    public Text ammount2Text;
    public int ammount2;
    public float ammount2Profit;

    //UpgradeClick
    public int upgradePrice;
    public Text upgradeText;

    void Start()
    {
        image = GetComponentInParent<Image>();
        currentColor = image.color;
        currentScore = 0;
        //hitPower = 1;
        scoreIncreasePerSecond = 1;
        x = 0f;
        
    }

    void Update()
    {
        //Click
        scoreText.text = (int)currentScore + " $";
        scoreIncreasePerSecond = x * Time.deltaTime;
        currentScore += scoreIncreasePerSecond;
        
        //Shop
        shop1Text.text = "Tier 1: " + shop1Price + " $";
        shop2Text.text = "Tier 2: " + shop2Price + " $";

        ammount1Text.text = "Lvl " + ammount1 + ": $" + ammount1Profit + "/s";
        ammount2Text.text = "Lvl " + ammount2 + ": $" + ammount2Profit + "/s";

        //Upgrade
        upgradeText.text = "Price: " + upgradePrice + " $";
    }

    //Click
    public void Hit()
    {
        currentScore += hitPower;

        // Obtener el porcentaje de progreso del score
        float progress = Mathf.Clamp01(currentScore / 10); // Se asegura de que el progreso esté entre 0 y 1

        // Obtener el color actual de la imagen
        currentColor = image.color;

        // Calcular los nuevos valores de color basados en el progreso
        currentColor.r = Mathf.Lerp(1f, 0f, progress); // De 1 a 0 conforme a progress
        currentColor.g = Mathf.Lerp(1f, 0f, progress);
        currentColor.b = Mathf.Lerp(1f, 0f, progress);

        // Asignar el nuevo color a la imagen
        image.color = currentColor;
    }

    //Shop
    public void Shop1()
    {
        if(currentScore >= shop1Price)
        {
            currentScore -= shop1Price;
            ammount1 += 1;
            ammount1Profit += 1;
            x += 1;
            shop1Price += 25;
        }
    }

    public void Shop2()
    {
        if (currentScore >= shop2Price)
        {
            currentScore -= shop2Price;
            ammount2 += 1;
            ammount2Profit += 5;
            x += 5;
            shop2Price += 125;
        }
    }

    //UpgradeClick
    public void Upgrade()
    {
        if (currentScore >= upgradePrice)
        {
            currentScore -= upgradePrice;
            hitPower *= 2;
            upgradePrice *= 2;
        }
    }
}
