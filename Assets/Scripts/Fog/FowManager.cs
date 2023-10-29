/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FogOfWar
{
    public class FowManager : MonoBehaviour
    {
        public static FowManager instance
        {
            get
            {
                return _instance;
            }
        }
        protected static FowManager _instance;
        public static void AddViewer(FowViewer viewer)
        {
            if (!_instance.viewerList.Contains(viewer))
            {
                _instance.viewerList.Add(viewer);
            }

        }
        public static void RemoveViewer(FowViewer viewer)
        {
            if (_instance.viewerList.Contains(viewer))
            {
                _instance.viewerList.Remove(viewer);
            }

        }

        public float FogSizeX = 10;
        public float FogSizeY = 10;
        public float MapTileSize = 1;
        public FOWMap map;
        public List<FowViewer> viewerList;
        public List<int[]> viewerPos;
        protected int[,] mapData;
        public float updateTime = 0.5f;

        // Use this for initialization
        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            viewerList = new List<FowViewer>();
            viewerPos = new List<int[]>();
            InvokeRepeating("NewFog", 0, updateTime);
        }

        public int[] GetPos(FowViewer viewer)
        {
            var x = (int)((viewer.transform.position.x - transform.position.x + FogSizeX / 2) / MapTileSize);
            var y = (int)((viewer.transform.position.z - transform.position.z + FogSizeY / 2) / MapTileSize);
            return new int[] { x, y };
        }
        public Vector3 GetV3(int[] pos)
        {
            return new Vector3(pos[0] * MapTileSize, 0, pos[1] * MapTileSize) + new Vector3(MapTileSize / 2, 0, MapTileSize / 2) + transform.position - new Vector3(FogSizeX / 2, 0, FogSizeY / 2);
        }

        public Vector2 GetV2(Vector2Int pos)
        {
            // 计算在2D平面上的坐标
            Vector2 v2Position = new Vector2(pos.x * MapTileSize, pos.y * MapTileSize) + new Vector2(MapTileSize / 2, MapTileSize / 2) + new Vector2(transform.position.x - FogSizeX / 2, transform.position.y - FogSizeY / 2);
            return v2Position;
        }

        public void InitMap(int[,] mapData)
        {
            map = new FOWMap();
            map.InitMap(mapData);
            this.mapData = mapData;

        }
        public void NewFog()
        {
            if (map == null) return;
            map.FreshFog();
            viewerPos.Clear();
            foreach (var viewer in viewerList)
            {
                var pos = GetPos(viewer);
                viewerPos.Add(pos);
                map.ComputeFog(pos[0], pos[1], viewer.viewerRange / MapTileSize);
            }

        }
        public void LerpFog()
        {
            map.Lerp();
        }
        // Update is called once per frame
        void Update()
        {
            LerpFog();
        }
        private void OnDestroy()
        {
            map.Release();
        }
        *//*        private void OnDrawGizmosSelected()
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawWireCube(transform.position, new Vector3(FogSizeX, 0f, FogSizeY));
                    if (mapData != null)
                    {
                        for (int i = 0; i < mapData.GetLength(0); i++)
                        {
                            for (int j = 0; j < mapData.GetLength(1); j++)
                            {
                                Gizmos.color = mapData[i, j] == 1 ? Color.red : Color.white;
                                Gizmos.DrawWireCube(GetV3(new int[] { i, j }), new Vector3(MapTileSize - 0.02f, 0f, MapTileSize - 0.02f));
                            }
                        }
                        foreach (var pos in viewerPos)
                        {

                            Gizmos.color = Color.green;
                            Gizmos.DrawCube(GetV3(pos), new Vector3(MapTileSize - 0.02f, 1f, MapTileSize - 0.02f));

                        }
                    }


                }*//*

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, new Vector3(FogSizeX, FogSizeY, 0f));
            if (mapData != null)
            {
                for (int x = 0; x < mapData.GetLength(0); x++)
                {
                    for (int y = 0; y < mapData.GetLength(1); y++)
                    {
                        Gizmos.color = mapData[x, y] == 1 ? Color.red : Color.white;

                        // 使用 Vector2Int 表示 2D 坐标
                        Vector2Int position = new Vector2Int(x, y);

                        // 计算在 2D 平面上的坐标
                        Vector2 objectPosition = GetV2(position);

                        // 绘制 2D Gizmos 方块
                        Gizmos.DrawWireCube(new Vector3(objectPosition.x, objectPosition.y, transform.position.z), new Vector3(MapTileSize - 0.02f, MapTileSize - 0.02f, 0f));
                    }
                }
                foreach (var pos in viewerPos)
                {
                    Gizmos.color = Color.green;

                    // 使用 Vector2Int 表示 2D 坐标
                    Vector2Int position = new Vector2Int(pos[0], pos[1]);

                    // 计算在 2D 平面上的坐标
                    Vector2 objectPosition = GetV2(position);

                    // 绘制 2D Gizmos 方块
                    Gizmos.DrawCube(new Vector3(objectPosition.x, objectPosition.y, transform.position.z), new Vector3(MapTileSize - 0.02f, 1f, MapTileSize - 0.02f));
                }
            }
        }

    }
}*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FogOfWar
{
    public class FowManager : MonoBehaviour
    {
        public static FowManager instance
        {
            get
            {
                return _instance;
            }
        }

        protected static FowManager _instance;

        public static void AddViewer(FowViewer viewer)
        {
            if (!_instance.viewerList.Contains(viewer))
            {
                _instance.viewerList.Add(viewer);
            }
        }

        public static void RemoveViewer(FowViewer viewer)
        {
            if (_instance.viewerList.Contains(viewer))
            {
                _instance.viewerList.Remove(viewer);
            }
        }

        public float FogSizeX = 10;
        public float FogSizeY = 10;
        public float MapTileSize = 1;
        public FOWMap map;
        public List<FowViewer> viewerList;
        public List<Vector2Int> viewerPos;
        protected int[,] mapData;
        public float updateTime = 0.5f;

        // Use this for initialization
        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            viewerList = new List<FowViewer>();
            viewerPos = new List<Vector2Int>();
            InvokeRepeating("NewFog", 0, updateTime);
        }

        public Vector2Int GetPos(FowViewer viewer)
        {
            var x = Mathf.FloorToInt((viewer.transform.position.x - transform.position.x + FogSizeX / 2) / MapTileSize);
            var y = Mathf.FloorToInt((viewer.transform.position.y - transform.position.y + FogSizeY / 2) / MapTileSize);
            return new Vector2Int(x, y);
        }

        public Vector3 GetV3(Vector2Int pos)
        {
            return new Vector3(pos.x * MapTileSize, pos.y * MapTileSize, 0) + new Vector3(MapTileSize / 2, MapTileSize / 2, 0) + transform.position - new Vector3(FogSizeX / 2, FogSizeY / 2, 0);
        }

        public void InitMap(int[,] mapData)
        {
            map = new FOWMap();
            map.InitMap(mapData);
            this.mapData = mapData;
        }

        public void NewFog()
        {
            if (map == null) return;
            map.FreshFog();
            viewerPos.Clear();
            foreach (var viewer in viewerList)
            {
                var pos = GetPos(viewer);
                viewerPos.Add(pos);
                map.ComputeFog(pos.x, pos.y, viewer.viewerRange / MapTileSize);
            }
        }

        public void LerpFog()
        {
            map.Lerp();
        }

        // Update is called once per frame
        void Update()
        {
            LerpFog();
        }

        private void OnDestroy()
        {
            map.Release();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, new Vector3(FogSizeX, FogSizeY, 0f));
            if (mapData != null)
            {
                for (int i = 0; i < mapData.GetLength(0); i++)
                {
                    for (int j = 0; j < mapData.GetLength(1); j++)
                    {
                        Gizmos.color = mapData[i, j] == 1 ? Color.red : Color.white;
                        Gizmos.DrawWireCube(GetV3(new Vector2Int(i, j)), new Vector3(MapTileSize - 0.02f, MapTileSize - 0.02f, 0f));
                    }
                }
                foreach (var pos in viewerPos)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawCube(GetV3(pos), new Vector3(MapTileSize - 0.02f, MapTileSize - 0.02f, 0f));
                }
            }
        }
    }
}

