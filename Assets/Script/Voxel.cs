using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VoxelState { Dead, Alive }
public class voxel
{
    private Vector3Int _index;
    private GameObject _goVoxel;
    private VoxelState _status = VoxelState.Alive;
    public VoxelState Status
    {
        get
        {
            return _status;
        }
        set
        {
            _goVoxel.SetActive(value == VoxelState.Alive);
            _status = value;
        }
    }

    public voxel(Vector3Int index, GameObject goVoxelPrefab)
    {
        _index = index;
        _goVoxel = GameObject.Instantiate(goVoxelPrefab, _index, Quaternion.identity);
    }
}