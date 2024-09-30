using TMPro;
using UnityEngine;

public class RootViewedObjectDescription : MonoBehaviour, IService
{
    [SerializeField]
    private TextMeshProUGUI _name;

    [SerializeField]
    private TextMeshProUGUI _description;


    public void SetObjectDesctiption(string name, string description)
    {
        _name.text = name;
        _description.text = description;
    }
}
