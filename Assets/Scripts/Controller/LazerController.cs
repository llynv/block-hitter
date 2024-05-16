using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerController : MonoBehaviour
{
   private Animator anim;
   private Player player;
   private string currentAnimation = "";

   private void Awake()
   {
      anim = GetComponent<Animator>();
      player = GetComponentInParent<Player>();
      currentAnimation = "none";
   }

   private float animTime = .3f;

   void Update()
   {
      animTime -= Time.deltaTime;

      if (animTime <= 0f)
      {
         ChangeAnimation("none", .025f);
         animTime = 0f;
      }

      anim.Play(currentAnimation);

      if (player.isDisabling) return;

      if (Input.GetKeyDown(KeyCode.LeftArrow))
      {
         ChangeAnimation("shoot-left", .025f);
         animTime = .3f;
      }
      else if (Input.GetKeyDown(KeyCode.RightArrow))
      {
         ChangeAnimation("shoot-right", .025f);
         animTime = .3f;
      }
      else if (Input.GetKeyDown(KeyCode.UpArrow))
      {
         ChangeAnimation("shoot-up", .025f);
         animTime = .3f;
      }
      else if (Input.GetKeyDown(KeyCode.DownArrow))
      {
         ChangeAnimation("shoot-down", .025f);
         animTime = .3f;
      }
   }

   void ChangeAnimation(string animation, float delay)
   {
      currentAnimation = animation;
      anim.CrossFade(animation, delay);
   }
}
