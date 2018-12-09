using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    #region Singleton

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("il y a deja un buildmanager dans la scene");
        }
        instance = this;
    }
    #endregion
    public GameObject standardTurretPrefab;

    private TurretBlueprint turretToBuild;

    public bool canBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
       GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.Euler(0f, 90f, 0f));
        node.turret = turret;
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
