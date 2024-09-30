using UnityEngine;

public class ServiceLocatorLoader : MonoBehaviour
{
    private ServiceLocator _serviceLocator;

    [SerializeField]
    private ViewedObjectController _viewedObjectController;

    [SerializeField]
    private Tooltip _tooltip;
    
    [SerializeField]
    private RootViewedObjectDescription _viewedObjectDescription;

    private void Awake()
    {
        ServiceLocator.Initialize();
        _serviceLocator = ServiceLocator.Instance;
        RegisterServices();
    }

    private void RegisterServices()
    {
        _serviceLocator.Register(_viewedObjectController);
        _serviceLocator.Register(_tooltip);
        _serviceLocator.Register(_viewedObjectDescription);
    }
}