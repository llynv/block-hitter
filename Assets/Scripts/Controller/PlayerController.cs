using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool getDamage = false;
    private Animator anim;
    private Player player;
    private string currentAnimation = "";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
        currentAnimation = "player-idle";
    }

    private const float defaultAnimTime = .33f;

    private float animTime = defaultAnimTime;

    void Update()
    {
        animTime -= Time.deltaTime;

        if (animTime <= 0f)
        {
            ChangeAnimation("player-idle", .025f);
            animTime = 0f;
        }

        if (getDamage)
        {
            ChangeAnimation("damage", .025f);
            animTime = defaultAnimTime;
            getDamage = false;
        }

        anim.Play(currentAnimation);

        if (player.isDisabling) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeAnimation("left-hit", .025f);
            animTime = defaultAnimTime;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeAnimation("right-hit", .025f);
            animTime = defaultAnimTime;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeAnimation("up-hit", .025f);
            animTime = defaultAnimTime;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeAnimation("down-hit", .025f);
            animTime = defaultAnimTime;
        }
    }

    void ChangeAnimation(string animation, float delay)
    {
        currentAnimation = animation;
        anim.CrossFade(animation, delay);
    }
}
