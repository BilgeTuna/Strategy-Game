using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    public GameObject itemPrefab;
    public int itemCount = 12;
    public float itemHeight = 420f;

    private RectTransform contentRect;
    private Vector2 contentVector;

    [SerializeField] private ObjectPool objectPool;

    void Start()
    {
        contentRect = GetComponent<RectTransform>();
        contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, itemCount * itemHeight);

        for (int i = 0; i < itemCount; i++)
        {
            //GameObject newItem = Instantiate(itemPrefab, transform);
            GameObject gameObject = objectPool.GetPooledObject();
            gameObject.transform.parent = transform.parent;
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -i * itemHeight);
        }
    }

    public void OnScrollValueChanged(Vector2 scrollValue)
    {
        contentVector += scrollValue * 10f;
        contentRect.anchoredPosition = contentVector;
    }
}
