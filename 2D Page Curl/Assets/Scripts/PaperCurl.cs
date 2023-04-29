using UnityEngine;

public class PaperCurl : MonoBehaviour
{
    [Space]
    [Header("TOP RIGHT VARIABLES")]

    [SerializeField] private Transform topRightmask;
    [SerializeField] private Transform topRightcover;  
    [SerializeField] private Vector3 topRightoffset;

    [SerializeField] private Vector2 topRightAngleRange;
    [SerializeField] private Transform paperTopRightEdge;

    Quaternion defaultTopRightCoverRot, defaultTopRightMaskRot;
    Vector3 defaultTopRightMaskPos;

    bool isTopRightDragging = false;

    [Space]
    [Header("TOP LEFT VARIABLES")]

    [SerializeField] private Transform topLeftmask;
    [SerializeField] private Transform topLeftcover;
    [SerializeField] private Vector3 topLeftoffset;

    [SerializeField] private Vector2 topLeftAngleRange;
    [SerializeField] private Transform paperTopLeftEdge;

    Quaternion defaultTopLeftCoverRot, defaultTopLeftMaskRot;
    Vector3 defaultTopLeftMaskPos;

    bool isTopLeftDragging = false;

    [Space]
    [Header("TOP CENTER VARIABLES")]

    [SerializeField] private Transform topCentermask;
    [SerializeField] private Transform topCentercover;
    [SerializeField] private Vector3 topCenteroffset;

    [SerializeField] private Vector2 topCenterAngleRange;
    [SerializeField] private Transform paperTopCenterEdge;

    Quaternion defaultTopCenterCoverRot, defaultTopCenterMaskRot;
    Vector3 defaultTopCenterMaskPos;

    bool isTopCenterDragging = false;

    [Space]
    [Header("GENERAL VARIABLES")]

    [SerializeField] private float pullSpeed = 1f;
    [SerializeField] private float rotReturnSpeed = 10f;

    Vector3 currVec, prevVec;

    private void Start()
    {
        TopRightSetup();
        TopLeftSetup();
        TopCenterSetup();
    }

    private void TopRightSetup()
    {
        Vector3 distBetween = topRightcover.position;

        float angle = (90f + (Mathf.Atan2(distBetween.y, distBetween.x) * (180f / Mathf.PI))) * 2f;

        defaultTopRightCoverRot = Quaternion.AngleAxis(angle, Vector3.forward);
        defaultTopRightMaskRot = Quaternion.AngleAxis(angle / 2f, Vector3.forward);

        defaultTopRightMaskPos = topRightoffset + ((topRightcover.position + transform.position) / 2f);

        topRightmask.position = defaultTopRightMaskPos;
        topRightmask.rotation = defaultTopRightMaskRot;

        topRightcover.rotation = defaultTopRightCoverRot;
    }

    private void TopLeftSetup()
    {
        Vector3 distBetween = topLeftcover.position;

        float angle = (Mathf.Atan2(distBetween.y, distBetween.x) * (180f / Mathf.PI)) - 45f;

        defaultTopLeftCoverRot = Quaternion.AngleAxis(angle, Vector3.forward);
        defaultTopLeftMaskRot = Quaternion.AngleAxis(angle / 2f, Vector3.forward);

        defaultTopLeftMaskPos = topLeftoffset + ((topLeftcover.position + transform.position) / 2f);

        topLeftmask.position = defaultTopLeftMaskPos;
        topLeftmask.rotation = defaultTopLeftMaskRot;

        topLeftcover.rotation = defaultTopLeftCoverRot;
    }

    private void TopCenterSetup()
    {
        Vector3 distBetween = topCentercover.position;

        float angle = (Mathf.Atan2(distBetween.y, distBetween.x) * (180f / Mathf.PI)) - 90f;

        defaultTopCenterCoverRot = Quaternion.AngleAxis(angle, Vector3.forward);
        defaultTopCenterMaskRot = Quaternion.AngleAxis(angle / 2f, Vector3.forward);

        defaultTopCenterMaskPos = topCenteroffset + ((topCentercover.position + transform.position) / 2f);

        topCentermask.position = defaultTopCenterMaskPos;
        topCentermask.rotation = defaultTopCenterMaskRot;

        topCentercover.rotation = defaultTopCenterCoverRot;
    }


    private Rect Trans2Rect(Transform trans)
    {
        Vector2 worldRectSize = Vector2.Scale(trans.lossyScale, trans.lossyScale);

        Vector2 worldPivotPos = worldRectSize * (trans.lossyScale / 2f);

        Vector2 worldRectPos = (Vector2)trans.position - worldPivotPos;

        return new Rect(worldRectPos, worldRectSize);
    }

    private void Update()
    {
#if UNITY_EDITOR
        currVec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - prevVec;
#else
        currVec = Camera.main.ScreenToWorldPoint(Input.GetTouch(Input.touchCount - 1).position) - prevVec;
#endif
        TopRightPageLogic();
        TopLeftPageLogic();
        TopCenterPageLogic();
#if UNITY_EDITOR
        prevVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#else
        prevVec = Camera.main.ScreenToWorldPoint(Input.GetTouch(Input.touchCount - 1).position);
#endif
    }

    private void TopRightPageLogic()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && Trans2Rect(paperTopRightEdge).Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            isTopRightDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isTopRightDragging = false;
        }

        CalculateTopRight(Input.mousePosition);
#else
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Began && 
                Trans2Rect(paperTopRightEdge).Contains(Camera.main.ScreenToWorldPoint(Input.GetTouch(Input.touchCount - 1).position)))
            {
                isTopRightDragging = true;
            }
            else if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Moved)
            {
                CalculateTopRight(Input.GetTouch(Input.touchCount - 1).position);
            }
            else if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Ended || Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Canceled)
            {
                isTopRightDragging = false;

                topRightcover.rotation = Quaternion.Slerp(topRightcover.rotation, defaultTopRightCoverRot, Time.deltaTime * rotReturnSpeed);
                topRightmask.rotation = Quaternion.Slerp(topRightmask.rotation, defaultTopRightMaskRot, Time.deltaTime * rotReturnSpeed);
            }
        }
#endif
    }

    private void CalculateTopRight(Vector3 pointerScreenPos)
    {
        if (isTopRightDragging)
        {
            Vector3 temp = topRightcover.position;

            temp.x += ((currVec.x + currVec.y) / 2f) * pullSpeed * Time.deltaTime;
            temp.y += ((currVec.x + currVec.y) / 2f) * pullSpeed * Time.deltaTime;

            topRightcover.position = temp;

            Vector3 distBetween = (topRightcover.position - Camera.main.ScreenToWorldPoint(pointerScreenPos)).normalized;

            float angleBetween = Mathf.Atan2(distBetween.y, distBetween.x);

            float angleInDegrees = angleBetween * (180f / Mathf.PI);

            float angleAdjusted = (90f + angleInDegrees) * 2f;

            float clampedAngle = Mathf.Clamp(angleAdjusted, topRightAngleRange.x, topRightAngleRange.y);

            topRightcover.rotation = Quaternion.AngleAxis(clampedAngle, Vector3.forward);

            topRightmask.position = topRightoffset + ((topRightcover.position + transform.position) / 2f);
            topRightmask.rotation = Quaternion.AngleAxis(clampedAngle / 2f, Vector3.forward);
        }
        else
        {
            //Rotate back to center
            topRightcover.rotation = Quaternion.Slerp(topRightcover.rotation, defaultTopRightCoverRot, Time.deltaTime * rotReturnSpeed);
            topRightmask.rotation = Quaternion.Slerp(topRightmask.rotation, defaultTopRightMaskRot, Time.deltaTime * rotReturnSpeed);
        }
    }

    private void TopLeftPageLogic()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && Trans2Rect(paperTopLeftEdge).Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            isTopLeftDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isTopLeftDragging = false;
        }

        CalculateTopLeft(Input.mousePosition);
#else
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Began &&
                Trans2Rect(paperTopLeftEdge).Contains(Camera.main.ScreenToWorldPoint(Input.GetTouch(Input.touchCount - 1).position)))
            {
                isTopLeftDragging = true;
            }
            else if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Moved)
            {
                CalculateTopLeft(Input.GetTouch(Input.touchCount - 1).position);
            }
            else if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Ended || Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Canceled)
            {
                isTopLeftDragging = false;

                topLeftcover.rotation = Quaternion.Slerp(topLeftcover.rotation, defaultTopLeftCoverRot, Time.deltaTime * rotReturnSpeed);
                topLeftmask.rotation = Quaternion.Slerp(topLeftmask.rotation, defaultTopLeftMaskRot, Time.deltaTime * rotReturnSpeed);
            }
        }
#endif
    }

    private void CalculateTopLeft(Vector3 pointerScreenPos)
    {
        if (isTopLeftDragging)
        {
            Vector3 temp = topLeftcover.position;

            temp.x += ((currVec.x - currVec.y) / 2f) * pullSpeed * Time.deltaTime;
            temp.y += (-(currVec.x - currVec.y) / 2f) * pullSpeed * Time.deltaTime;

            topLeftcover.position = temp;

            Vector3 distBetween = (topLeftcover.position - Camera.main.ScreenToWorldPoint(pointerScreenPos)).normalized;

            float angleBetween = Mathf.Atan2(distBetween.y, distBetween.x);

            float angleInDegrees = angleBetween * (180f / Mathf.PI);

            float angleAdjusted = angleInDegrees - 45f;

            float clampedAngle = Mathf.Clamp(angleAdjusted, topLeftAngleRange.x, topLeftAngleRange.y);

            topLeftcover.rotation = Quaternion.AngleAxis(clampedAngle, Vector3.forward);

            topLeftmask.position = topLeftoffset + ((topLeftcover.position + transform.position) / 2f);
            topLeftmask.rotation = Quaternion.AngleAxis(clampedAngle / 2f, Vector3.forward);
        }
        else
        {
            //Rotate back to center
            topLeftcover.rotation = Quaternion.Slerp(topLeftcover.rotation, defaultTopLeftCoverRot, Time.deltaTime * rotReturnSpeed);
            topLeftmask.rotation = Quaternion.Slerp(topLeftmask.rotation, defaultTopLeftMaskRot, Time.deltaTime * rotReturnSpeed);
        }
    }

    private void TopCenterPageLogic()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && Trans2Rect(paperTopCenterEdge).Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            isTopCenterDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isTopCenterDragging = false;
        }

        CalculateTopCenter(Input.mousePosition);
#else
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Began &&
                Trans2Rect(paperTopCenterEdge).Contains(Camera.main.ScreenToWorldPoint(Input.GetTouch(Input.touchCount - 1).position)))
            {
                isTopCenterDragging = true;
            }
            else if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Moved)
            {
                CalculateTopCenter(Input.GetTouch(Input.touchCount - 1).position);
            }
            else if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Ended || Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Canceled)
            {
                isTopCenterDragging = false;

                topCentercover.rotation = Quaternion.Slerp(topCentercover.rotation, defaultTopCenterCoverRot, Time.deltaTime * rotReturnSpeed);
                topCentermask.rotation = Quaternion.Slerp(topCentermask.rotation, defaultTopCenterMaskRot, Time.deltaTime * rotReturnSpeed);
            }
        }
#endif
    }

    private void CalculateTopCenter(Vector3 pointerScreenPos)
    {
        if (isTopCenterDragging)
        {
            Vector3 temp = topCentercover.position;

            temp.y += currVec.y * pullSpeed * Time.deltaTime;

            topCentercover.position = temp;

            Vector3 distBetween = (topCentercover.position - Camera.main.ScreenToWorldPoint(pointerScreenPos)).normalized;

            float angleBetween = Mathf.Atan2(distBetween.y, distBetween.x);

            float angleInDegrees = angleBetween * (180f / Mathf.PI);

            float angleAdjusted = angleInDegrees - 90f;

            float clampedAngle = Mathf.Clamp(angleAdjusted, topCenterAngleRange.x, topCenterAngleRange.y);

            topCentercover.rotation = Quaternion.AngleAxis(clampedAngle, Vector3.forward);

            topCentermask.position = topCenteroffset + ((topCentercover.position + transform.position) / 2f);
            topCentermask.rotation = Quaternion.AngleAxis(clampedAngle / 2f, Vector3.forward);
        }
        else
        {
            //Rotate back to center
            topCentercover.rotation = Quaternion.Slerp(topCentercover.rotation, defaultTopCenterCoverRot, Time.deltaTime * rotReturnSpeed);
            topCentermask.rotation = Quaternion.Slerp(topCentermask.rotation, defaultTopCenterMaskRot, Time.deltaTime * rotReturnSpeed);
        }
    }    
}
