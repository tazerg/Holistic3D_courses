using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Holistic3D_courses.Mathematics_for_gamedev.Bitwise_operations
{
    public class Example : MonoBehaviour
    {
        private const int BIT_BASE = 2;
        
        [SerializeField] private TMP_Text _currentFlagText;
        [SerializeField] private TMP_Text _haveKeyText;
        [SerializeField] private TMP_Text _haveMapText;
        [SerializeField] private TMP_Text _haveClockText;
        [SerializeField] private TMP_Text _haveAnyMapClockText;
        [SerializeField] private TMP_Text _haveAllText;
        [SerializeField] private Button _giveKeyButton;
        [SerializeField] private Button _giveMapButton;
        [SerializeField] private Button _giveClockButton;
        [SerializeField] private Button _giveKeyAndClockButton;
        [SerializeField] private Button _takeKeyButton;
        [SerializeField] private Button _takeMapButton;
        [SerializeField] private Button _takeClockButton;
        [SerializeField] private Button _takeKeyAndMapButton;
        [SerializeField] private Button _takeAllButton;
        [SerializeField] private Button _toggleClockButton;
        
        private int _currentFlag;

        private void Awake()
        {
            Repaint();
            _giveKeyButton.onClick.AddListener(() => Give((int)ItemTypes.KEY));
            _giveMapButton.onClick.AddListener(() => Give((int)ItemTypes.MAP));
            _giveClockButton.onClick.AddListener(() => Give((int)ItemTypes.CLOCK));
            _giveKeyAndClockButton.onClick.AddListener(() => Give((int)(ItemTypes.KEY | ItemTypes.CLOCK)));
            
            _takeKeyButton.onClick.AddListener(() => Take((int)ItemTypes.KEY));
            _takeMapButton.onClick.AddListener(() => Take((int)ItemTypes.MAP));
            _takeClockButton.onClick.AddListener(() => Take((int)ItemTypes.CLOCK));
            _takeKeyAndMapButton.onClick.AddListener(() => Take((int)(ItemTypes.KEY | ItemTypes.MAP)));
            _takeAllButton.onClick.AddListener(() => Take((int)ItemTypes.ALL));
            
            _toggleClockButton.onClick.AddListener(() => Toggle((int) ItemTypes.CLOCK));
        }

        private void OnDestroy()
        {
            _giveKeyButton.onClick.RemoveAllListeners();
            _giveMapButton.onClick.RemoveAllListeners();
            _giveClockButton.onClick.RemoveAllListeners();
            _giveKeyAndClockButton.onClick.RemoveAllListeners();
            
            _takeKeyButton.onClick.RemoveAllListeners();
            _takeMapButton.onClick.RemoveAllListeners();
            _takeClockButton.onClick.RemoveAllListeners();
            _takeKeyAndMapButton.onClick.RemoveAllListeners();
            _takeAllButton.onClick.RemoveAllListeners();
            
            _toggleClockButton.onClick.RemoveAllListeners();
        }

        private void Give(int mask)
        {
            BitwiseUtils.SetFlag(ref _currentFlag, mask);
            Repaint();
        }

        private void Take(int mask)
        {
            BitwiseUtils.RemoveFlag(ref _currentFlag, mask);
            Repaint();
        }

        private void Toggle(int mask)
        {
            BitwiseUtils.ToggleFlag(ref _currentFlag, mask);
            Repaint();
        }

        private bool HasAny(int mask)
        {
            return BitwiseUtils.HasAnyFlag(_currentFlag, mask);
        }

        private bool Has(int mask)
        {
            return BitwiseUtils.HasFlag(_currentFlag, mask);
        }

        private void Repaint()
        {
            _currentFlagText.text = $"Current value: {Convert.ToString(_currentFlag, BIT_BASE).PadLeft(3, '0')}";
            _haveKeyText.text = $"Have key? {Has((int)ItemTypes.KEY)}";
            _haveMapText.text = $"Have map? {Has((int)ItemTypes.MAP)}";
            _haveClockText.text = $"Have clock? {Has((int)ItemTypes.CLOCK)}";
            _haveAnyMapClockText.text = $"Have any of map or clock? {HasAny((int)(ItemTypes.MAP | ItemTypes.CLOCK))}";
            _haveAllText.text = $"Have all? {Has((int)ItemTypes.ALL)}";
        }
    }

    [Flags]
    public enum ItemTypes
    {
        KEY = 1 << 0,
        MAP = 1 << 1,
        CLOCK = 1 << 2,
        
        ALL = KEY | MAP | CLOCK
    }
}