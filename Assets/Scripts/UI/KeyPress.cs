using UnityEngine;
using UnityEngine.UI;

public class KeyPress : OnOffButton
{

    [SerializeField] private GameObject keyboardPressController;

    private GameObject[] keys;
    private bool isOn, isOff;

    private new void Awake() {
        isOn = GameStaticController.isKeyBoardPress;
        isOff = !isOn;
        base.State = isOn ? ButtonState.On : ButtonState.Off;
        base.Awake();
        keys = GameObject.FindGameObjectsWithTag("KeyPress");
        // Debug.Log(keys.Length);
        ButtonStateChange();
    }



    public void SwitchButton () {
        base.State = (base.State == ButtonState.On) ? ButtonState.Off : ButtonState.On;
        base.OnClick();
        ButtonStateChange();
    }

    private void ButtonStateChange() {
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
}
