using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Holistic3D_courses.Mathematics_for_gamedev.Vectors.Scripts
{
    public class Example : MonoBehaviour
    {
        private const float MOVE_THRESHOLD = 200f;
        private const float MOVE_STEP = 50f;
        
        [SerializeField] private RectTransform _staticPoint;
        [SerializeField] private RectTransform _dynamicPoint;
        [SerializeField] private Button _upButton;
        [SerializeField] private Button _downButton;
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;
        [SerializeField] private TMP_Text _frontalRelationText;
        [SerializeField] private TMP_Text _lateralRelationText;
        [SerializeField] private TMP_Text _angleText;

        private void Awake()
        {
            Repaint();
            
            _upButton.onClick.AddListener(() => Move(new Vector2(0f, MOVE_STEP)));
            _downButton.onClick.AddListener(() => Move(new Vector2(0f, -MOVE_STEP)));
            _leftButton.onClick.AddListener(() => Move(new Vector2(-MOVE_STEP, 0f)));
            _rightButton.onClick.AddListener(() => Move(new Vector2(MOVE_STEP, 0f)));
        }

        private void OnDestroy()
        {
            _upButton.onClick.RemoveAllListeners();
            _downButton.onClick.RemoveAllListeners();
            _leftButton.onClick.RemoveAllListeners();
            _rightButton.onClick.RemoveAllListeners();
        }

        private void Move(Vector2 delta)
        {
            var currentPosition = _dynamicPoint.anchoredPosition;
            var newPosition = currentPosition + delta;
            if (Mathf.Abs(newPosition.x) > MOVE_THRESHOLD
                || Mathf.Abs(newPosition.y) > MOVE_THRESHOLD)
                return;

            _dynamicPoint.anchoredPosition = newPosition;
            Repaint();
        }

        private void Repaint()
        {
            var forward = _staticPoint.up;
            var direction2d = (_dynamicPoint.anchoredPosition - _staticPoint.anchoredPosition).normalized;
            var direction = new Vector3(direction2d.x, direction2d.y, 0f);

            _frontalRelationText.text = $"Frontal relation: {VectorUtils.GetFrontalRelationType(forward, direction)}";
            _lateralRelationText.text = $"Lateral relation: {VectorUtils.GetLateralRelation(forward, direction)}";
            _angleText.text = $"Angle: {VectorUtils.Angle(forward, direction)}";
        }
    }
}