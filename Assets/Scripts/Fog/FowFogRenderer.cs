/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FogOfWar
{
    public class FowFogRenderer : MonoBehaviour
    {
        public FowManager fowManager;
        public GameObject rendererPrefab;
        Material material;
        // Use this for initialization
        void Start()
        {
            var renderer = Instantiate(rendererPrefab, transform);
            renderer.transform.localPosition = Vector3.zero;
            renderer.transform.localScale = new Vector3(fowManager.FogSizeX / 2, 1, fowManager.FogSizeY / 2);
            material = renderer.GetComponentInChildren<Renderer>().material;
        }

        // Update is called once per frame
        void Update()
        {
            if (fowManager.map.FogTexture != null)
            {
                material.SetTexture("_MainTex", fowManager.map.FogTexture);
            }

        }
    }

}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FogOfWar
{
    public class FowFogRenderer : MonoBehaviour
    {
        public FowManager fowManager;
        public GameObject rendererPrefab;
        Material material;

        // Use this for initialization
        void Start()
        {
            var renderer = Instantiate(rendererPrefab, transform);
            renderer.transform.localPosition = Vector3.zero;
            renderer.transform.localScale = new Vector3(fowManager.FogSizeX / 2, fowManager.FogSizeY / 2, 1); // Adjust Z scale for 2D
            Debug.Log(renderer.name);
            material = renderer.GetComponentInChildren<MeshRenderer>().material; // Use SpriteRenderer instead of Renderer

        }

        // Update is called once per frame
        void Update()
        {
            if (fowManager.map.FogTexture != null)
            {
                material.SetTexture("_MainTex", fowManager.map.FogTexture);
            }
        }
    }
}
