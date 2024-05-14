using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool getDamage = false;
    private Animator anim;
    private Player player;
    private void Awake() {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (getDamage) {
            StopAllCoroutines();
            StartCoroutine(ChangeAnimation("isDamage", .025f));
            getDamage = false;
        }

        if (player.isDisabling) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            StopAllCoroutines();
            StartCoroutine(ChangeAnimation("isLeft", .025f));
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            StopAllCoroutines();
            StartCoroutine(ChangeAnimation("isRight", .025f));
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            StopAllCoroutines();
            StartCoroutine(ChangeAnimation("isUp", .025f));
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            StopAllCoroutines();
            StartCoroutine(ChangeAnimation("isDown", .025f));
        }
    }

    IEnumerator ChangeAnimation(string boolName, float delay)
    {
        anim.SetBool(boolName, true);
        yield return new WaitForSeconds(delay);
        anim.SetBool(boolName, false);
    }
}
