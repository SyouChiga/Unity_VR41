using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour
{
    /// <summary>ドラッグタイプ</summary>
    enum DragType
    {
        Move,
        Rotate,
    };

    /// <summary>ドラッグ状態</summary>
    private bool _isDragging = false;

    /// <summary>過去の座標</summary>
    private Vector3 _prevPos = Vector3.zero;

    /// <summary></現在のドラッグタイプsummary>
    private DragType _currentType;

    /// <summary>回転量</summary>
    private Quaternion _originalRot;

    /// <summary>座標</summary>
    private float _x = 0.0f;
    private float _y = 0.0f;

    /// <summary>動作速度の最大限度</summary>
    [SerializeField] private float _speedLimit = 100.0f;

    /// <summary>動作範囲</summary>
    [SerializeField][Range(0.0f,10.0f)] private float _moveSpeed = 5.0f;

    /// <summary>回転範囲</summary>
    [SerializeField] [Range(0.0f, 10.0f)] private float _rotateSpeed = 5.0f;

    /// <summary>支配するもの</summary>
    [SerializeField] private Transform _controlTarget;
    private Transform ControlTarget
    {
        get
        {
            if(!_controlTarget)
            {
                _controlTarget = transform;
            }
            return _controlTarget;
        }
    }


    /// <summary>初期化</summary>
    void Start()
    {
        _originalRot = ControlTarget.rotation;
    }

    /// <summary>更新</summary>
    void Update()
    {
        float wheelval = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = ControlTarget.position;

        pos += ControlTarget.forward * wheelval * 2.0f;
        ControlTarget.position = pos;

        // マウス左クリック
        if(Input.GetMouseButtonDown(0))
        {
            OnMouseDown(DragType.Move);
        }

        // マウス→クリック
        if (Input.GetMouseButtonDown(1))
        {
            OnMouseDown(DragType.Rotate);
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            OnMouseUp();
        }

        OnMouseMove();
    }

    /// <summary>  </summary>
    private void OnMouseDown(DragType type)
    {
        _isDragging = true;
        _currentType = type;
        _prevPos = Input.mousePosition;
    }

    /// <summary>  </summary>
    private void OnMouseUp()
    {
        _isDragging = false;
    }

    /// <summary>  </summary>
    private void OnMouseMove()
    {
        if (!_isDragging) { return; }
        Vector3 delta = Input.mousePosition - _prevPos;
        _prevPos = Input.mousePosition;

        switch(_currentType)
        {
            case DragType.Move:
                Vector3 pos = ControlTarget.position;
                delta *= (_moveSpeed / _speedLimit);
                pos += ControlTarget.up * -delta.y;
                pos += ControlTarget.right * delta.x;
                ControlTarget.position = pos;
                return;

            case DragType.Rotate:
                delta *= (_rotateSpeed / _speedLimit);
                _x += delta.x;
                if(_x <= -180)
                {
                    _x += 360;
                }
                else if(_x > 180)
                {
                    _x = -360;
                }
                _y -= delta.y;
                _y = Mathf.Clamp(_y, -85.0f, 85.0f);
                ControlTarget.rotation = _originalRot * Quaternion.Euler(_y, _x, 0.0f);
                return;
        }
       
    }


}
