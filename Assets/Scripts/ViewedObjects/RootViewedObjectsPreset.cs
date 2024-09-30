using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RootViewedObjectsPreset", order = 1)]
public class RootViewedObjectsPreset : ScriptableObject
{
    [SerializeField]
    private List<RootViewedObject> _rootViewedObjects;

    public List<RootViewedObject> RootViewedObject { get { return _rootViewedObjects; } }
}
