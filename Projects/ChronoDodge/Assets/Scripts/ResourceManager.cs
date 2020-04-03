using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{

    public Slider manaSlider;
    public Slider sparkSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxMana(float mana)
    {
        manaSlider.maxValue = mana;
    }

    public void SetMana(float mana)
    {
        manaSlider.value = mana;
    }

    public void DecreaseMana(float amount)
    {
        manaSlider.value -= amount;
    }

    public void IncreaseMana(float amount)
    {
        manaSlider.value += amount;
    }

    public float GetCurrentMana()
    {
        return manaSlider.value;
    }

    public void SetMaxSpark(int spark)
    {
        sparkSlider.maxValue = spark;
    }

    public void SetCurrentSpark(int spark)
    {
        sparkSlider.value = spark;
    }

    public void IncreaseSpark(int amount)
    {
        sparkSlider.value += amount;
    }

    public void DecreaseSpark(int amount)
    {
        sparkSlider.value -= amount;
    }

    public int GetCurrentSpark()
    {
        return (int)sparkSlider.value;
    }
}
