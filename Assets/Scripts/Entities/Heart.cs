using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Heart : Singleton<Heart>
{
    public int CurrentHeart { get; private set; }

    [SerializeField] private Sprite fullHeartImage, emptyHeartImage;

    private Transform heartContainer;
    [SerializeField] private int startingHeart = 0;
    [SerializeField] private int maxHeart;
    const string HEART_CONTAINER_TEXT = "Heart Container";

    protected override void Awake()
    {
        base.Awake();

        CurrentHeart = startingHeart;
    }

    private void Start()
    {
        heartContainer = GameObject.Find(HEART_CONTAINER_TEXT).transform;
        UpdateHeartImages();
    }

    public void DecreaseHeart()
    {
        if (CurrentHeart > 0)
        {
            CurrentHeart--;
            UpdateHeartImages();
        }
    }

    public void IncreaseHeart()
    {
        if (CurrentHeart < maxHeart)
        {
            CurrentHeart++;
            UpdateHeartImages();
        }
    }

    private void UpdateHeartImages()
    {
        Debug.Log("Updating heart images. Current hearts: " + CurrentHeart);

        for (int i = 0; i < maxHeart; i++)
        {
            if (i <= CurrentHeart - 1)
            {
                heartContainer.GetChild(i).GetComponent<Image>().sprite = fullHeartImage;
            }
            else
            {
                heartContainer.GetChild(i).GetComponent<Image>().sprite = emptyHeartImage;
            }
        }
    }
}
