using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

using Image = UnityEngine.UI.Image;

public class KeyboardPress : MonoBehaviour
{
    [SerializeField] private Image[] normalKeys;
    [SerializeField] private Image[] pressKeys;

    void Start()
    {
        for (int i = 0; i < normalKeys.Length; i++)
        {
            normalKeys[i].gameObject.SetActive(true);
            pressKeys[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            normalKeys[0].gameObject.SetActive(false);
            pressKeys[0].gameObject.SetActive(true);
        } else
        {
            normalKeys[0].gameObject.SetActive(true);
            pressKeys[0].gameObject.SetActive(false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            normalKeys[1].gameObject.SetActive(false);
            pressKeys[1].gameObject.SetActive(true);
        } else
        {
            normalKeys[1].gameObject.SetActive(true);
            pressKeys[1].gameObject.SetActive(false);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            normalKeys[2].gameObject.SetActive(false);
            pressKeys[2].gameObject.SetActive(true);
        } else
        {
            normalKeys[2].gameObject.SetActive(true);
            pressKeys[2].gameObject.SetActive(false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            normalKeys[3].gameObject.SetActive(false);
            pressKeys[3].gameObject.SetActive(true);
        } else
        {
            normalKeys[3].gameObject.SetActive(true);
            pressKeys[3].gameObject.SetActive(false);
        }
    }
}
