using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewItem : MonoBehaviour
{
    [SerializeField] Image childImg;

    public void ChangeImage(Sprite Image)
    {
        childImg.sprite = Image;
    }
}
