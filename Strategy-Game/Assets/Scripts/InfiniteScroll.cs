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
        // Calculate the total height of the content
        float contentHeight = content.sizeDelta.y;

        // Calculate the number of visible children in the scroll view
        numVisibleChildren = Mathf.RoundToInt(scrollView.GetComponent<RectTransform>().rect.height / childHeight) + 1;

        // If the number of visible children is greater than the total number of children, we don't need to loop
        if (numVisibleChildren >= content.childCount)
        {
            return;
        }

        // Duplicate the first visible children and append them to the end of the content
        for (int i = 0; i < numVisibleChildren; i++)
        {
            RectTransform child = content.GetChild(i).GetComponent<RectTransform>();
            RectTransform duplicate = Instantiate(child, content);
            duplicate.anchoredPosition += new Vector2(0f, contentHeight);
        }
    }

    private void OnEnable()
    {
        // Subscribe to the onValueChanged event of the ScrollRect component
        scrollView.onValueChanged.AddListener(OnScrollValueChanged);
    }

    private void OnDisable()
    {
        // Unsubscribe from the onValueChanged event of the ScrollRect component
        scrollView.onValueChanged.RemoveListener(OnScrollValueChanged);
    }

    private void OnScrollValueChanged(Vector2 scrollPos)
    {
        // Get the last child of the content
        RectTransform lastChild = content.GetChild(content.childCount - 1).GetComponent<RectTransform>();

        // If the last child is fully visible, we need to loop
        if (lastChild.anchoredPosition.y + lastChild.sizeDelta.y <= scrollView.GetComponent<RectTransform>().rect.height)
        {
            // Get the first visible child
            RectTransform firstChild = content.GetChild(0).GetComponent<RectTransform>();

            // Move it to the end of the content
            firstChild.anchoredPosition += new Vector2(0f, content.sizeDelta.y);

            // Set it as the last child
            firstChild.SetAsLastSibling();
        }
        // If the first child is fully visible, we need to loop backwards
        else if (content.GetChild(0).GetComponent<RectTransform>().anchoredPosition.y >= 0)
        {
            // Get the last visible child
            RectTransform lastVisibleChild = content.GetChild(numVisibleChildren - 1).GetComponent<RectTransform>();

            // Move it to the beginning of the content
            lastVisibleChild.anchoredPosition -= new Vector2(0f, content.sizeDelta.y);

            // Set it as the first child
            lastVisibleChild.SetAsFirstSibling();
        }
    }
}
