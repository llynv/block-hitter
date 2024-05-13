using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private void Awake() {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            StartCoroutine(ChangeAnimation("isLeft", .05f));
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            StartCoroutine(ChangeAnimation("isRight", .05f));
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            StartCoroutine(ChangeAnimation("isUp", .05f));
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            StartCoroutine(ChangeAnimation("isDown", .05f));
        }
    }

    IEnumerator ChangeAnimation(string boolName, float delay)
    {
        anim.SetBool(boolName, true);
        yield return new WaitForSeconds(delay);
        anim.SetBool(boolName, false);
    }
}