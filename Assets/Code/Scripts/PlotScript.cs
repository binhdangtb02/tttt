using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject towerObj;
    private TurretScript turret;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }
    private void OnMouseEnter()
    {
  
        sr.color = hoverColor;
    }
    private void OnMouseExit()
    {
        sr.color = startColor;
    }
    private void OnMouseDown()
    {
        if(UIManager.main.IsHoveringUI()) { return; }
        if(towerObj != null) {
            turret.OpenUpGradeUI();
            return;
        }
        Tower towerToBuild = BuildManager.main.GetSelectedTower();
        if(towerToBuild.cost > LevelManager.main.currency)
        {
            return;
        }
        LevelManager.main.SpendCurrency(towerToBuild.cost);
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        towerObj = Instantiate(towerToBuild.prefab, newPosition, Quaternion.identity);
        turret = towerObj.GetComponent<TurretScript>();
    }
}
