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

    private GameObject turretToBuild;

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

}
