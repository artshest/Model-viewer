using UnityEngine;

public abstract class ViewedObject : MonoBehaviour
{
    [SerializeField] 
    private string _name;

    [SerializeField]
    [TextArea]
    private string _description;

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
}
