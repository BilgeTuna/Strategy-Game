using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InfiniteScroll : MonoBehaviour
{
    public List<GameObject> prefabList;
    public RectTransform content;

    private List<GameObject> prefabs = new List<GameObject>();
    private int totalPrefabs;
    private int currentIndex = 0;

    private void Start()
    {
        // Initialize prefabs list with duplicates of the prefabs in prefabList
        for (int i = 0; i < 6; i++)
        {
            GameObject instance = Instantiate(prefabList[i % prefabList.Count], content);
            instance.SetActive(false);
            prefabs.Add(instance);
        }

        // Calculate the total number of prefabs
        totalPrefabs = prefabList.Count;

        // Set the size of the content based on the size of the prefabs and spacing
        content.sizeDelta = new Vector2(content.sizeDelta.x, prefabList[0].GetComponent<RectTransform>().rect.height);

        // Position the prefabs horizontally in the content
        for (int i = 0; i < 6; i++)
        {
            RectTransform prefabTransform = prefabs[i].GetComponent<RectTransform>();
            prefabTransform.anchorMin = new Vector2(0f, 0.5f);
            prefabTransform.anchorMax = new Vector2(0f, 0.5f);
            prefabTransform.pivot = new Vector2(0f, 0.5f);
            prefabTransform.anchoredPosition = new Vector2(i * prefabTransform.rect.width, 0f);
            prefabs[i].SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            // Shift the list of displayed prefabs by 2 items
            currentIndex = (currentIndex + 2) % totalPrefabs;

            // Reposition the prefabs based on the new current index
            for (int i = 0; i < 6; i++)
            {
                RectTransform prefabTransform = prefabs[i].GetComponent<RectTransform>();
                prefabTransform.anchoredPosition = new Vector2((i - 2) * prefabTransform.rect.width, 0f);
                prefabs[i].SetActive(true);

                // Set the new prefab based on the current index
                int prefabIndex = (currentIndex + i) % totalPrefabs;
                prefabs[i].GetComponent<Image>().sprite = prefabList[prefabIndex].GetComponent<Image>().sprite;
            }
        }
    }
}
