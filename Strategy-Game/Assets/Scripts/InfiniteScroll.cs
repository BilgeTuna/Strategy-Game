using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfiniteScroll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<GameObject> itemPrefabs;
    public float itemHeight;
    public int maxItems;

    private RectTransform contentRectTransform;
    private List<GameObject> items = new List<GameObject>();
    private int prefabIndex = 0;
    private bool isPointerOver = false;

    void Start()
    {
        contentRectTransform = GetComponent<RectTransform>();
        AddItems();
    }

    void Update()
    {
        if (!isPointerOver && items.Count < maxItems)
        {
            AddItems();
        }

        // Check if the last item has gone off-screen
        GameObject lastItem = items[items.Count - 1];
        if (contentRectTransform.InverseTransformPoint(lastItem.transform.position).y < contentRectTransform.rect.yMin)
        {
            // Move the last item to the top of the list
            items.Remove(lastItem);
            items.Insert(0, lastItem);

            // Update the positions of all items
            for (int i = 0; i < items.Count; i++)
            {
                items[i].transform.localPosition = new Vector3(0, -itemHeight * i, 0);
            }
        }
    }

    void AddItems()
    {
        for (int i = items.Count; i < maxItems; i++)
        {
            GameObject item = Instantiate(itemPrefabs[prefabIndex]);
            item.transform.SetParent(transform, false);
            item.transform.localPosition = new Vector3(0, -itemHeight * items.Count, 0);
            items.Add(item);

            contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, itemHeight * items.Count);

            prefabIndex++;
            if (prefabIndex >= itemPrefabs.Count)
            {
                prefabIndex = 0;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
    }
}
