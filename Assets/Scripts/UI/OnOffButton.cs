using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffButton : MonoBehaviour
{
    public Sprite onImage;
    public Sprite offImage;
    

    public enum ButtonState {
        On,
        Off
    }

    protected ButtonState State;

    protected void Awake() {
        OnClick();
    }

    public void OnClick() {
        if (State == ButtonState.On) {
            gameObject.GetComponent<Image>().sprite = onImage;
        } else {
            gameObject.GetComponent<Image>().sprite = offImage;
        }
    }
}
