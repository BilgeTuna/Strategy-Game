using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InfiniteScroll : MonoBehaviour
{
    public ScrollRect scrollView;
    public RectTransform content;
    public float childHeight;

    private int numVisibleChildren;

    private void Start()
    {
        float contentHeight = content.sizeDelta.y;

        numVisibleChildren = Mathf.RoundToInt(scrollView.GetComponent<RectTransform>().rect.height / childHeight) + 1;

        if (numVisibleChildren >= content.childCount)
        {
            return;
        }

        for (int i = 0; i < numVisibleChildren; i++)
        {
            RectTransform child = content.GetChild(i).GetComponent<RectTransform>();
            RectTransform duplicate = Instantiate(child, content);
            duplicate.anchoredPosition += new Vector2(0f, contentHeight);
        }
    }

    private void OnEnable()
    {
        scrollView.onValueChanged.AddListener(OnScrollValueChanged);
    }

    private void OnDisable()
    {
        scrollView.onValueChanged.RemoveListener(OnScrollValueChanged);
    }

    private void OnScrollValueChanged(Vector2 scrollPos)
    {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Approximately(scrollDelta, 0f))
        {
            return;
        }

        float scrollSpeed = scrollDelta > 0 ? 1f : -1f;
        scrollSpeed *= Mathf.Abs(scrollDelta) * 1f;

        for (int i = 0; i < numVisibleChildren; i++)
        {
            RectTransform child = content.GetChild(i).GetComponent<RectTransform>();
            child.anchoredPosition -= new Vector2(0f, scrollSpeed * 1f);
        }

        RectTransform lastChild = content.GetChild(content.childCount - 1).GetComponent<RectTransform>();

        if (lastChild.anchoredPosition.y + lastChild.sizeDelta.y <= scrollView.GetComponent<RectTransform>().rect.height)
        {
            RectTransform firstChild = content.GetChild(0).GetComponent<RectTransform>();
            firstChild.anchoredPosition += new Vector2(0f, content.sizeDelta.y);
            firstChild.SetAsLastSibling();
        }
        else if (content.GetChild(0).GetComponent<RectTransform>().anchoredPosition.y >= 0)
        {
            RectTransform lastVisibleChild = content.GetChild(numVisibleChildren - 1).GetComponent<RectTransform>();

            lastVisibleChild.anchoredPosition -= new Vector2(0f, content.sizeDelta.y);

            lastVisibleChild.SetAsFirstSibling();
        }
    }
}
