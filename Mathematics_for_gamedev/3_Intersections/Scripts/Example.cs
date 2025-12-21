using System;
using System.Linq;
using UnityEngine;

namespace Holistic3D_courses.Mathematics_for_gamedev.Intersections
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private ReflectColor[] _colors;
        [SerializeField] private GameObject _planeObject;
        [SerializeField] private GameObject[] _reflectObjects;

        private void Start()
        {
            var planeMesh = _planeObject.GetComponent<MeshFilter>().sharedMesh;
            var localSize = planeMesh.bounds.size;
            var worldSize = Vector3.Scale(localSize, _planeObject.transform.lossyScale);
            var planeHalfSize = new Vector2(worldSize.x / 2, worldSize.z / 2);

            for (var i = 0; i < _reflectObjects.Length; i++)
            {
                var reflectObj = _reflectObjects[i];
                var ray = new Ray(reflectObj.transform.position, reflectObj.transform.forward);
                var result = IntersectionUtils.ReflectOnPlane(ray, _planeObject.transform, planeHalfSize,
                    out var hitPoint, out var reflected);
                var color = _colors.FirstOrDefault(x => x.Type == result)!.Color;
                var endPoint = result == RelationType.AHEAD ? hitPoint : reflectObj.transform.position + reflectObj.transform.forward * 5;
                
                Debug.DrawLine(reflectObj.transform.position, endPoint, color, float.MaxValue);
                if (result == RelationType.AHEAD)
                    Debug.DrawLine(hitPoint, hitPoint + reflected, color, float.MaxValue);
            }
        }
    }

    [Serializable]
    public class ReflectColor
    {
        [SerializeField] private RelationType _type;
        [SerializeField] private Color _color;

        public RelationType Type => _type;
        public Color Color => _color;
    }
}