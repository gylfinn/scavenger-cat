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
        totalFishBar.fillAmount = 1;
    }
    void Update()
    {
        Debug.Log(fishCollection.fishCollected / fishCollection.totalFish);
        currentFishBar.fillAmount = fishCollection.fishCollected / fishCollection.totalFish;
    }
}
