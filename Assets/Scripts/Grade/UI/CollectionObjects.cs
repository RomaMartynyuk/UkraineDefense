using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionObjects : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private Image? _image;
    [SerializeField] private Text _desc;
    [SerializeField] private Text _header;
    public void OpenDescription(Sprite image, string desc, string header)
    {
        _object.SetActive(true);
        _image.sprite = image;
        _desc.text = desc;
        _header.text = header;
    }
}
