using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePopUpUI : MonoBehaviour
{
    public static ScorePopUpUI Create (Vector3 position, string text, int scoreAmount)
    {
        Transform scorePopUp = Instantiate(GameAssets.Instance.scorePopUpPrefab, position, Quaternion.identity);
        ScorePopUpUI scorePopUpUI = scorePopUp.GetComponent<ScorePopUpUI>();
        scorePopUpUI.SetText(text == "Perfect" ? $"{text}! x{scoreAmount}" : $"{text} !");

        return scorePopUpUI;
    }

    private TextMeshPro textMeshPro;
    private float disappearTimer;
    private Color textColor;

    private void Awake() {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    public void SetText(string text) {
        textMeshPro.text = text;
        textColor = textMeshPro.color;
        disappearTimer = .5f;
    }

    private void Update() {
        float moveYSpeed = 1f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;

        if (disappearTimer < 0) {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMeshPro.color = textColor;

            if (textColor.a < 0) {
                Destroy(gameObject);
            }
        }
    }
}
