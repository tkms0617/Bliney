using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CreateColRowArea : MonoBehaviour
{
    [Tooltip("The objects you want to duplicate")]
    public GameObject _prefab;
    [Tooltip("The parent of the objects you want to duplicate")]
    public GameObject _parent;

    [Tooltip("Corner of the area you want to place your objects in")]
    public Vector3 _corner_1;
    [Tooltip("The corner diagonally placed against the other corner")]
    public Vector3 _corner_2;
    public int _row;
    public int _column;

    [Header("Initialize")]
    [Tooltip("Press to create objects according to data input")]
    public bool _Initialize;

    GameObject[] _fluorscent = new GameObject[512];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_Initialize)
        {
            if(_parent != null)
            {
                InstanceLights(_row, _column, _corner_1, _corner_2);
            }
            _Initialize = false;
        }
    }

    void InstanceLights(int row, int column, Vector3 corner_XZ, Vector3 cornerX_Z)
    {
        for (int i = 0; i < row * column; i++)
        {
            GameObject instanceLights = (GameObject)Instantiate(_prefab);

            int columnInstance = i / row;
            int rowInstance = i % row;

            instanceLights.transform.position =
                (corner_XZ.x - cornerX_Z.x) / (column - 1) * Vector3.right * columnInstance
                + (corner_XZ.z - cornerX_Z.z) / (row - 1) * Vector3.forward * rowInstance
                + (corner_XZ.y - cornerX_Z.y) / (column - 1) * Vector3.up * (columnInstance)
                + cornerX_Z;

            _fluorscent[i] = instanceLights;
            _fluorscent[i].transform.SetParent(_parent.transform, true);
            FollowParentLayer(_fluorscent[i]);
        }
    }

    void FollowParentLayer(GameObject _gameObject)
    {
        _gameObject.layer = _parent.layer;
        _gameObject.tag = _parent.tag;
    }
}
