using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnapScrolling : MonoBehaviour
{
    public GameObject PanPrefab;
    
    private GameObject[] _panPrefab;
    private Vector2 _contentVecor;
    private Vector2[] _pansPos;
    private RectTransform _contentRect;

    private int _panCount = 11;
    private int _sectionID;
    private bool _isScrolling;
    void Start()
    {
        _isScrolling = false;
        _contentRect = GetComponent<RectTransform>();
        _panPrefab = new GameObject[_panCount];
        _pansPos = new Vector2[_panCount];
        for (int i = 0; i < _panCount; i++)
        {
            _panPrefab[i] = Instantiate(PanPrefab, transform, false);
            if (i == 0) continue;
            _panPrefab[i].transform.localPosition = new Vector2(_panPrefab[i].transform.localPosition.x,
                _panPrefab[i-1].transform.localPosition.y - PanPrefab.GetComponent<RectTransform>().sizeDelta.y - 200);
            _pansPos[i] = -_panPrefab[i].transform.localPosition;
        }
    }

    private void FixedUpdate()
    {
        float nearestPos = float.MaxValue;
        for (int i = 0; i < _panCount; i++)
        {
            float distance = Mathf.Abs(_contentRect.anchoredPosition.y - _pansPos[i].y);
            if(distance < nearestPos)
            {
                nearestPos = distance;
                _sectionID = i;
            }
        }
        if (_isScrolling) return;
        _contentVecor.y = Mathf.SmoothStep(_contentRect.anchoredPosition.y, _pansPos[_sectionID].y, 20f * Time.fixedDeltaTime);
        _contentRect.anchoredPosition = _contentVecor;
        
    }

    public void Scrolling(bool scroll)
    {
        _isScrolling = scroll;
    }

    public bool GetScrolling()
    {
        return _isScrolling;
    }
}
