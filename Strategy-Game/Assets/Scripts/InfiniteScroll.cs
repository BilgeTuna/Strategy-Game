using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] GameObject prefab;
    [SerializeField] List<Sprite> builds;

    private void Start()
    {
        foreach (Sprite build in builds)
        {
            GameObject newBuild = Instantiate(prefab, scrollViewContent);
            if (newBuild.TryGetComponent<ScrollViewItem>(out ScrollViewItem item))
            {
                item.ChangeImage(build);
            }
        }
    }
}
