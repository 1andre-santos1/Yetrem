﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private Sprite imageToDraw;
    private List<Sprite> GalleryPictures = new List<Sprite>();

    private void Awake()
    {

        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        foreach (Sprite o in Resources.LoadAll<Sprite>("Gallery"))
            GalleryPictures.Add(o);
    }

    public void SetPictureToDraw(GameObject g)
    {
        imageToDraw = g.GetComponent<Image>().sprite;
    }

    public void SetNewPicture()
    {
        FindObjectOfType<Drawing>().gameObject.GetComponent<SpriteRenderer>().sprite = imageToDraw;
    }

    public int GetGallerySize()
    {
        return GalleryPictures.Count;
    }
    public List<Sprite> GetGalleryPictures()
    {
        return GalleryPictures;
    }
}
