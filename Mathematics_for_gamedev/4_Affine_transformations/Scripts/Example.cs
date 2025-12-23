using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Holistic3D_courses.Mathematics_for_gamedev._Affine_transformations
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private GameObject _transformationObject;
        [SerializeField] private TMP_InputField _translateX;
        [SerializeField] private TMP_InputField _translateY;
        [SerializeField] private TMP_InputField _translateZ;
        [SerializeField] private TMP_InputField _rotateX;
        [SerializeField] private TMP_InputField _rotateY;
        [SerializeField] private TMP_InputField _rotateZ;
        [SerializeField] private TMP_InputField _scaleX;
        [SerializeField] private TMP_InputField _scaleY;
        [SerializeField] private TMP_InputField _scaleZ;
        [SerializeField] private Button _translateButton;
        [SerializeField] private Button _rotateButton;
        [SerializeField] private Button _scaleButton;

        private Mesh _mesh;

        private void Start()
        {
            _mesh = _transformationObject.GetComponent<MeshFilter>().mesh;
            
            _translateButton.onClick.AddListener(Translate);
            _rotateButton.onClick.AddListener(Rotate);
            _scaleButton.onClick.AddListener(Scale);
        }

        private void OnDestroy()
        {
            _translateButton.onClick.RemoveListener(Translate);
            _rotateButton.onClick.RemoveListener(Rotate);
            _scaleButton.onClick.RemoveListener(Scale);
        }

        private void Translate()
        {
            var vertices = _mesh.vertices;
            var newVertices = new Vector3[vertices.Length];
            for (var i = 0; i < vertices.Length; i++)
            {
                newVertices[i] = AffineTransformationsUtils.Translate(
                    vertices[i],
                    new Vector3(
                        float.Parse(_translateX.text),
                        float.Parse(_translateY.text),
                        float.Parse(_translateZ.text)
                    ));
            }

            _mesh.vertices = newVertices;
            _mesh.RecalculateBounds();
        }

        private void Rotate()
        {
            var vertices = _mesh.vertices;
            var center = _mesh.bounds.center;
            var newVertices = new Vector3[vertices.Length];
            for (var i = 0; i < vertices.Length; i++)
            {
                newVertices[i] = AffineTransformationsUtils.Rotate(
                    vertices[i],
                    new Vector3(
                        float.Parse(_rotateX.text),
                        float.Parse(_rotateY.text),
                        float.Parse(_rotateZ.text)
                    ),
                    center);
            }

            _mesh.vertices = newVertices;
        }

        private void Scale()
        {
            var vertices = _mesh.vertices;
            var center = _mesh.bounds.center;
            var newVertices = new Vector3[vertices.Length];
            for (var i = 0; i < vertices.Length; i++)
            {
                newVertices[i] = AffineTransformationsUtils.Scale(
                    vertices[i],
                    new Vector3(
                        float.Parse(_scaleX.text),
                        float.Parse(_scaleY.text),
                        float.Parse(_scaleZ.text)
                    ),
                    center);
            }

            _mesh.vertices = newVertices;
        }
    }
}