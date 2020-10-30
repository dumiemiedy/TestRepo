using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelGrids : MonoBehaviour
{
    [SerializeField]
    private Vector3Int GridDimension = new Vector3Int(10, 20, 5);
    private voxel[,,] _voxels;
    private GameObject _GoVoxelPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _GoVoxelPrefab = Resources.Load("Prefabs/VoxelCube") as GameObject;
        CreateVoxelGrid();

        /*Dog barry = new Dog("Barry", "Kevin's dog");
        Dog Yang = new Dog("Barry", "Yang's dog");

        barry.Bark(6);
        barry.Bark(6);*/
    }

    private void CreateVoxelGrid()
    {
        _voxels = new voxel[GridDimension.x, GridDimension.y, GridDimension.z];


        for (int x = 0; x < GridDimension.x; x++)
        {
            for (int y = 0; y < GridDimension.y; y++)
            {
                for (int z = 0; z < GridDimension.z; z++)
                {
                    _voxels[x, y, z] = new voxel(new Vector3Int(x, y, z), _GoVoxelPrefab);

                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleRaycast();

        }
    }

    private void HandleRaycast()
    {
        Debug.Log("clicked");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out RaycastHit hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.CompareTag("Voxel"))
            {
                objectHit.gameObject.GetComponent<VoxelTrigger>().TriggerVoxel.Status = VoxelState.Dead;
                GameObject.Destroy(objectHit.gameObject);
            }
        }
    }
}
