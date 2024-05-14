using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool GetDamage { get; set; } = false;
    private Animator anim;
    private Player player;
    private void Awake() {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (player.isDisabling) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            StopAllCoroutines();
            StartCoroutine(ChangeAnimation("isLeft", .05f));
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            StopAllCoroutines();
            StartCoroutine(ChangeAnimation("isRight", .05f));
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            StopAllCoroutines();
            StartCoroutine(ChangeAnimation("isUp", .05f));
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            StopAllCoroutines();
            StartCoroutine(ChangeAnimation("isDown", .05f));
        }

        if (GetDamage) {
            StopAllCoroutines();
            StartCoroutine(ChangeAnimation("isDamage", .05f));
            GetDamage = false;
        }
    }

    IEnumerator ChangeAnimation(string boolName, float delay)
    {
        anim.SetBool(boolName, true);
        yield return new WaitForSeconds(delay);
        anim.SetBool(boolName, false);
    }
}
