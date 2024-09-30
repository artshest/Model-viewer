using System.Collections.Generic;
using UnityEngine;

public class ViewedObjectController : MonoBehaviour, IService
{
    [SerializeField]
    [Tooltip("ѕереопредел€ет параметр RootViewedObjects. ќставл€йте пустым, если хотите применить значени€ пол€ RootViewedObjects.")]
    private RootViewedObjectsPreset _rootViewedObjectsPreset;

    [SerializeField]
    private List<RootViewedObject> _rootViewedObjectPrefabs;
    private Dictionary<RootViewedObject, GameObject> _instantiatedRootViewedObjects = new Dictionary<RootViewedObject, GameObject>();

    [SerializeField]
    private CameraHandler _cameraHandler;

    [SerializeField]
    private AbilityButtonsController _abilityButtonsController;

    private int _curentObjectIndex = 0;

    private void Start()
    {
        if (_rootViewedObjectsPreset != null)
        {
            _rootViewedObjectPrefabs = new List<RootViewedObject>(_rootViewedObjectsPreset.RootViewedObject);
        }

        InitializeViewedObject();
    }

    private void InitializeViewedObject()
    {
        RootViewedObject viewedObject;

        if (_instantiatedRootViewedObjects.ContainsKey(_rootViewedObjectPrefabs[_curentObjectIndex]))
        {
            viewedObject = _instantiatedRootViewedObjects[_rootViewedObjectPrefabs[_curentObjectIndex]].GetComponent<RootViewedObject>();
            viewedObject.gameObject.SetActive(true);
        }
        else
        {
            viewedObject = Instantiate(_rootViewedObjectPrefabs[_curentObjectIndex], Vector3.zero, Quaternion.identity);
            _instantiatedRootViewedObjects.Add(_rootViewedObjectPrefabs[_curentObjectIndex], viewedObject.gameObject);
        }

        _cameraHandler.SetTarget(viewedObject.transform);
        _abilityButtonsController.SetAbilities(viewedObject.Abilities);;
    }

    public void ShowNextObject()
    {
        HideViewedObject();
        if (_curentObjectIndex == _rootViewedObjectPrefabs.Count - 1)
        {
            _curentObjectIndex = 0;
        }
        else
        {
            _curentObjectIndex++;
        }

        InitializeViewedObject();
    }   
    
    public void ShowPreviousObject()
    {
        HideViewedObject();
        if (_curentObjectIndex == 0)
        {
            _curentObjectIndex = _rootViewedObjectPrefabs.Count - 1;
        }
        else
        {
            _curentObjectIndex--;
        }

        InitializeViewedObject();
    }

    private void HideViewedObject()
    {
        _instantiatedRootViewedObjects[_rootViewedObjectPrefabs[_curentObjectIndex]].SetActive(false);
    }

}
