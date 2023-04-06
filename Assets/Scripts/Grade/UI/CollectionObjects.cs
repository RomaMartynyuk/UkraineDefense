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
    [SerializeField] private Text _gunDesc;
    public void OpenDescription(Sprite image, string desc, string header, string gunDesc)
    {
        _object.SetActive(true);
        _image.sprite = image;
        _desc.text = desc;
        _header.text = header;
        _gunDesc.text = gunDesc;
    }
}
