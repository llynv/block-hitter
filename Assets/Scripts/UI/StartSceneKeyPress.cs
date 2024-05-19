using UnityEngine;
using UnityEngine.UI;

public class StartSceneKeyPress : OnOffButton
{
   private new void Awake() {
      base.Awake();
      base.State = GameStaticController.isKeyBoardPress ? ButtonState.On : ButtonState.Off;
   }

   public void SwitchButton () {
      base.State = (base.State == ButtonState.On) ? ButtonState.Off : ButtonState.On;
      OnClick();
      if (base.State == ButtonState.On) {
         GameStaticController.isKeyBoardPress = true;
      } else {
         GameStaticController.isKeyBoardPress = false;
      }
   }
}
