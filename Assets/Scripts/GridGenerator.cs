using Sirenix.OdinInspector;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GridGenerator : MonoBehaviour
{
    public GameObject GridBlockPrefab;
    public float XOffset = 1;
    public float ZOffset = 1;
    public float LoopCount = 10;

    [Button]
    public void SpawnGrid()
    {
        var parent = new GameObject();
        //for (int i = 0; i < LoopCount; i++)
        //{
        //    for (int j = 0; j < LoopCount; j++) 
        //    {
        //        var grid = Instantiate(GridBlockPrefab, new Vector3(i * XOffset, 0, j * ZOffset), Quaternion.identity);
        //        grid.transform.SetParent(parent.transform, true);
        //    }
        //}

#if UNITY_EDITOR
        for (int i = 0; i < LoopCount; i++)
        {
            for (int j = 0; j < LoopCount; j++)
            {
                GameObject grid;
                if (!Application.isPlaying)
                {
                    grid = (GameObject)PrefabUtility.InstantiatePrefab(GridBlockPrefab);
                    grid.transform.position = new Vector3(i * XOffset, 0, j * ZOffset);
                }
                else
                {
                    grid = Instantiate(GridBlockPrefab, new Vector3(i * XOffset, 0, j * ZOffset), Quaternion.identity);
                }

                grid.transform.SetParent(parent.transform, true);
            }
        }
#endif
    }


}
