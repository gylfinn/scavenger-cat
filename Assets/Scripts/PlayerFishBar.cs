using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFishBar : MonoBehaviour
{
    [SerializeField]private FishCollection fishCollection;
    [SerializeField]private Image totalFishBar;
    [SerializeField]private Image currentFishBar;
    void Awake()
    {
        totalFishBar.fillAmount = fishCollection.totalFish/5;
    }
    void Update()
    {
        currentFishBar.fillAmount = fishCollection.fishCollected / 5;
    }
}
