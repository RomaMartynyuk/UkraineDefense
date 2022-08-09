using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    public Vector3 positionOffset;

    public GameObject turret;

    private Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        turret = null;
    }
    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Не можна!");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
