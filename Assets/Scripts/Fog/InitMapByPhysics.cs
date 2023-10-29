/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FogOfWar
{
    public class InitMapByPhysics : MonoBehaviour
    {
        public FowManager fowManager;
        int[,] mapData;
        void Start()
        {
            PhysicsCheck();
        }
        *//*public void PhysicsCheck()
        {
            mapData = new int[(int)(fowManager.FogSizeX / fowManager.MapTileSize), (int)(fowManager.FogSizeY / fowManager.MapTileSize)];
            for (int i = 0; i < mapData.GetLength(0); i++)
            {
                for (int j = 0; j < mapData.GetLength(1); j++)
                {
                    if (Physics.CheckBox(fowManager.GetV3(new int[] { i, j }), new Vector3(fowManager.MapTileSize - 0.02f, 0f, fowManager.MapTileSize - 0.02f) / 2))
                    {
                        mapData[i, j] = 1;
                    }
                    else
                    {
                        mapData[i, j] = 0;
                    }
                }
            }
            fowManager.InitMap(mapData);
        }*//*
        public void PhysicsCheck()
        {
            mapData = new int[(int)(fowManager.FogSizeX / fowManager.MapTileSize), (int)(fowManager.FogSizeY / fowManager.MapTileSize)];
            for (int x = 0; x < mapData.GetLength(0); x++)
            {
                for (int y = 0; y < mapData.GetLength(1); y++)
                {
                    // 获取物体在2D平面上的位置
                    Vector2 objectPosition = fowManager.GetV2(new Vector2Int(x, y));

                    // 在 XY 平面上进行碰撞检测
                    if (Physics2D.OverlapBox(objectPosition, new Vector2(fowManager.MapTileSize - 0.02f, fowManager.MapTileSize - 0.02f) / 2, 0f))
                    {
                        mapData[x, y] = 1;
                    }
                    else
                    {
                        mapData[x, y] = 0;
                    }
                }
            }
            fowManager.InitMap(mapData);
        }

    }

}
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FogOfWar
{
    public class InitMapByPhysics : MonoBehaviour
    {
        public FowManager fowManager;
        int[,] mapData;

        void Start()
        {
            PhysicsCheck();
        }

        public void PhysicsCheck()
        {
            mapData = new int[(int)(fowManager.FogSizeX / fowManager.MapTileSize), (int)(fowManager.FogSizeY / fowManager.MapTileSize)];

            for (int i = 0; i < mapData.GetLength(0); i++)
            {
                for (int j = 0; j < mapData.GetLength(1); j++)
                {
                    if (Physics2D.OverlapBox(fowManager.GetV3(new Vector2Int(i, j)), new Vector2(fowManager.MapTileSize - 0.02f, fowManager.MapTileSize - 0.02f), 0))
                    {
                        mapData[i, j] = 1;
                    }
                    else
                    {
                        mapData[i, j] = 0;
                    }
                }
            }

            fowManager.InitMap(mapData);
        }
    }
}
