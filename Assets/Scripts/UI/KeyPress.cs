using UnityEngine;
using UnityEngine.UI;

public class KeyPress : OnOffButton
{

    [SerializeField] private GameObject keyboardPressController;

    private GameObject[] keys;
    private bool isOn = true, isOff = false;

    private new void Start() {
        base.Start();
        base.State = ButtonState.On;
        keys = GameObject.FindGameObjectsWithTag("KeyPress");
    }


    private void Update() {
        if (base.State == ButtonState.On) {
            if (!isOn) return;
            keyboardPressController.SetActive(true);
            foreach (var key in keys) {
                key.GetComponent<Image>().enabled = true;
            }
            isOn = false;
            isOff = true;
        } else {            
            if (!isOff) return;
            keyboardPressController.SetActive(false);
            foreach (var key in keys) {
                key.GetComponent<Image>().enabled = false;
            }
            isOn = true;
            isOff = false;
        }
    }

    public void SwitchButton () {
        base.OnClick();
        base.State = (State == ButtonState.On) ? ButtonState.Off : ButtonState.On;
    }
}
