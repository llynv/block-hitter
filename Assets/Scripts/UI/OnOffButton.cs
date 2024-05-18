using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffButton : MonoBehaviour
{
    public Sprite[] images;
    private List<bool> states = new List<bool>();

    public enum ButtonState {
        On,
        Off
    }

    protected ButtonState State;

    protected void Start() {
        foreach (var image in images) {
            states.Add(image == gameObject.GetComponent<Image>().sprite);
        }
    }

    public void OnClick() {
        Sprite enableImage = null;
        for (int index = 0; index < images.Length; index++) {
            states[index] = !states[index];
            if (states[index]) {
                enableImage = images[index];
            }
        }
        gameObject.GetComponent<Image>().sprite = enableImage;
    }
}
