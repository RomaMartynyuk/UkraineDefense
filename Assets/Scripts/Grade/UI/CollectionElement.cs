using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionElement : MonoBehaviour
{
    [SerializeField] private string description;
    [SerializeField] private string header;
    [SerializeField] private Sprite image;
    [SerializeField] private string gunDescription;
    [SerializeField] CollectionObjects collectionObjects;
    public void UpdateDescription()
    {
        collectionObjects.OpenDescription(image, description, header, gunDescription);
    }
}
