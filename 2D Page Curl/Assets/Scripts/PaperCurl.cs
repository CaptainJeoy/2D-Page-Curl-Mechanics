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
    [Header("BOTTOM RIGHT VARIABLES")]

    [SerializeField] private Transform bottomRightmask;
    [SerializeField] private Transform bottomRightcover;
    [SerializeField] private Vector3 bottomRightoffset;

    [SerializeField] private Vector2 bottomRightAngleRange;
    [SerializeField] private Transform paperBottomRightEdge;

    Quaternion defaultBottomRightCoverRot, defaultBottomRightMaskRot;
    Vector3 defaultBottomRightMaskPos;

    bool isBottomRightDragging = false;

    [Space]
    [Header("BOTTOM LEFT VARIABLES")]

    [SerializeField] private Transform bottomLeftmask;
    [SerializeField] private Transform bottomLeftcover;
    [SerializeField] private Vector3 bottomLeftoffset;

    [SerializeField] private Vector2 bottomLeftAngleRange;
    [SerializeField] private Transform paperBottomLeftEdge;

    Quaternion defaultBottomLeftCoverRot, defaultBottomLeftMaskRot;
    Vector3 defaultBottomLeftMaskPos;

    bool isBottomLeftDragging = false;

    [Space]
    [Header("BOTTOM CENTER VARIABLES")]

    [SerializeField] private Transform bottomCentermask;
    [SerializeField] private Transform bottomCentercover;
    [SerializeField] private Vector3 bottomCenteroffset;

    [SerializeField] private Vector2 bottomCenterAngleRange;
    [SerializeField] private Transform paperBottomCenterEdge;

    Quaternion defaultBottomCenterCoverRot, defaultBottomCenterMaskRot;
    Vector3 defaultBottomCenterMaskPos;

    bool isBottomCenterDragging = false;

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

        BottomRightSetup();
        BottomLeftSetup();
        BottomCenterSetup();
    }

    private void TopRightSetup()
    {
        Vector3 distBetween = topRightcover.position;

        float angle = (Mathf.Atan2(distBetween.y, distBetween.x) * (180f / Mathf.PI)) + 225f;

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

    private void BottomRightSetup()
    {
        Vector3 distBetween = bottomRightcover.position;

        float angle = (Mathf.Atan2(distBetween.y, distBetween.x) * (180f / Mathf.PI)) + 315f;

        defaultBottomRightCoverRot = Quaternion.AngleAxis(angle, Vector3.forward);
        defaultBottomRightMaskRot = Quaternion.AngleAxis(angle / 2f, Vector3.forward);

        defaultBottomRightMaskPos = bottomRightoffset + ((bottomRightcover.position + transform.position) / 2f);

        bottomRightmask.position = defaultBottomRightMaskPos;
        bottomRightmask.rotation = defaultBottomRightMaskRot;

        bottomRightcover.rotation = defaultBottomRightCoverRot;
    }

     private void BottomLeftSetup()
    {
        Vector3 distBetween = bottomLeftcover.position;

        float angle = (Mathf.Atan2(distBetween.y, distBetween.x) * (180f / Mathf.PI)) + 225f;

        defaultBottomLeftCoverRot = Quaternion.AngleAxis(angle, Vector3.forward);
        defaultBottomLeftMaskRot = Quaternion.AngleAxis(angle / 2f, Vector3.forward);

        defaultBottomLeftMaskPos = bottomLeftoffset + ((bottomLeftcover.position + transform.position) / 2f);

        bottomLeftmask.position = defaultBottomLeftMaskPos;
        bottomLeftmask.rotation = defaultBottomLeftMaskRot;

        bottomLeftcover.rotation = defaultBottomLeftCoverRot;
    }

    private void BottomCenterSetup()
    {
        Vector3 distBetween = bottomCentercover.position;

        float angle = (Mathf.Atan2(distBetween.y, distBetween.x) * (180f / Mathf.PI)) + 90f;

        defaultBottomCenterCoverRot = Quaternion.AngleAxis(angle, Vector3.forward);
        defaultBottomCenterMaskRot = Quaternion.AngleAxis(angle / 2f, Vector3.forward);

        defaultBottomCenterMaskPos = bottomCenteroffset + ((bottomCentercover.position + transform.position) / 2f);

        bottomCentermask.position = defaultBottomCenterMaskPos;
        bottomCentermask.rotation = defaultBottomCenterMaskRot;

        bottomCentercover.rotation = defaultBottomCenterCoverRot;
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

        ResetAllCoverRototation();
#else
        currVec = Camera.main.ScreenToWorldPoint(Input.GetTouch(Input.touchCount - 1).position) - prevVec;
#endif

        TopRightPageLogic();
        TopLeftPageLogic();
        TopCenterPageLogic();

        BottomRightPageLogic();
        BottomLeftPageLogic();
        BottomCenterPageLogic();

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
            }
        }
#endif
    }

    private void CalculateTopRight(Vector3 pointerScreenPos)
    {
        if (isTopRightDragging)
        {
            Vector3 temp = topRightcover.position;

            //This clamps the position of the Top Right Cover to any number less than or equal to both x=3, y=3.
            temp.x = (temp.x <= 3f) ? temp.x + (((currVec.x + currVec.y) / 2f) * pullSpeed * Time.deltaTime) : 3f;
            temp.y = (temp.x <= 3f) ? temp.y + (((currVec.x + currVec.y) / 2f) * pullSpeed * Time.deltaTime) : 3f;

            topRightcover.position = temp;

            Vector3 distBetween = (topRightcover.position - Camera.main.ScreenToWorldPoint(pointerScreenPos)).normalized;

            float angleBetween = Mathf.Atan2(distBetween.y, distBetween.x);

            float angleInDegrees = angleBetween * (180f / Mathf.PI);

            float angleAdjusted = angleInDegrees + 225f;

            float clampedAngle = Mathf.Clamp(angleAdjusted, topRightAngleRange.x, topRightAngleRange.y);

            topRightcover.rotation = Quaternion.AngleAxis(clampedAngle, Vector3.forward);

            topRightmask.position = topRightoffset + ((topRightcover.position + transform.position) / 2f);
            topRightmask.rotation = Quaternion.AngleAxis(clampedAngle / 2f, Vector3.forward);
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
            }
        }
#endif
    }

    private void CalculateTopLeft(Vector3 pointerScreenPos)
    {
        if (isTopLeftDragging)
        {
            Vector3 temp = topLeftcover.position;

            //This clamps the position of the Top Left Cover to any number greater than or equal to x=-3, and any number less than or equal to y=3.
            temp.x = (temp.x >= -3f) ? temp.x + (((currVec.x - currVec.y) / 2f) * pullSpeed * Time.deltaTime) : -3f;
            temp.y = (temp.y <= 3f) ? temp.y + ((-(currVec.x - currVec.y) / 2f) * pullSpeed * Time.deltaTime) : 3f;

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
            }
        }
#endif
    }

    private void CalculateTopCenter(Vector3 pointerScreenPos)
    {
        if (isTopCenterDragging)
        {
            Vector3 temp = topCentercover.position;

            //This clamps the position of the Top Center Cover to anything less than or equal to y=3.
            temp.y = (temp.y <= 3f) ? temp.y + (currVec.y * pullSpeed * Time.deltaTime) : 3f;

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
    }

    private void BottomRightPageLogic()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && Trans2Rect(paperBottomRightEdge).Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            isBottomRightDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isBottomRightDragging = false;
        }

        CalculateBottomRight(Input.mousePosition);
#else
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Began && 
                Trans2Rect(paperBottomRightEdge).Contains(Camera.main.ScreenToWorldPoint(Input.GetTouch(Input.touchCount - 1).position)))
            {
                isBottomRightDragging = true;
            }
            else if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Moved)
            {
                CalculateBottomRight(Input.GetTouch(Input.touchCount - 1).position);
            }
            else if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Ended || Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Canceled)
            {
                isBottomRightDragging = false;
            }
        }
#endif
    }

    private void CalculateBottomRight(Vector3 pointerScreenPos)
    {
        if (isBottomRightDragging)
        {
            Vector3 temp = bottomRightcover.position;

            //This clamps the position of the Bottom Right Cover to any number less than or equal to x=3, and any number greater than or equal to y=-3.
            temp.x = (temp.x <= 3f) ? temp.x + (((currVec.x - currVec.y) / 2f) * pullSpeed * Time.deltaTime) : 3f;
            temp.y = (temp.y >= -3f) ? temp.y + ((-(currVec.x - currVec.y) / 2f) * pullSpeed * Time.deltaTime) : -3f;

            bottomRightcover.position = temp;

            Vector3 distBetween = (bottomRightcover.position - Camera.main.ScreenToWorldPoint(pointerScreenPos)).normalized;

            float angleBetween = Mathf.Atan2(distBetween.y, distBetween.x);

            float angleInDegrees = angleBetween * (180f / Mathf.PI);

            float angleAdjusted = angleInDegrees + 315f;

            float clampedAngle = Mathf.Clamp(angleAdjusted, bottomRightAngleRange.x, bottomRightAngleRange.y);

            bottomRightcover.rotation = Quaternion.AngleAxis(clampedAngle, Vector3.forward);

            bottomRightmask.position = bottomRightoffset + ((bottomRightcover.position + transform.position) / 2f);
            bottomRightmask.rotation = Quaternion.AngleAxis(clampedAngle / 2f, Vector3.forward);
        }
    }

    private void BottomLeftPageLogic()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && Trans2Rect(paperBottomLeftEdge).Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            isBottomLeftDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isBottomLeftDragging = false;
        }

        CalculateBottomLeft(Input.mousePosition);
#else
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Began && 
                Trans2Rect(paperBottomLeftEdge).Contains(Camera.main.ScreenToWorldPoint(Input.GetTouch(Input.touchCount - 1).position)))
            {
                isBottomLeftDragging = true;
            }
            else if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Moved)
            {
                CalculateBottomLeft(Input.GetTouch(Input.touchCount - 1).position);
            }
            else if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Ended || Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Canceled)
            {
                isBottomLeftDragging = false;
            }
        }
#endif
    }

    private void CalculateBottomLeft(Vector3 pointerScreenPos)
    {
        if (isBottomLeftDragging)
        {
            Vector3 temp = bottomLeftcover.position;

            //This clamps the position of the Bottom Left Cover to any number greater than or equal to both x=-3, y=-3.
            temp.x = (temp.x >= -3f) ? temp.x + (((currVec.x + currVec.y) / 2f) * pullSpeed * Time.deltaTime) : -3f;
            temp.y = (temp.y >= -3f) ? temp.y + (((currVec.x + currVec.y) / 2f) * pullSpeed * Time.deltaTime) : -3f;

            bottomLeftcover.position = temp;

            Vector3 distBetween = (bottomLeftcover.position - Camera.main.ScreenToWorldPoint(pointerScreenPos)).normalized;

            float angleBetween = Mathf.Atan2(distBetween.y, distBetween.x);

            float angleInDegrees = angleBetween * (180f / Mathf.PI);

            float angleAdjusted = angleInDegrees + 225;

            //Not doing it this way because the calculated angle gets overflow once it's less than 45 deg, it then jumps to 400
            //float clampedAngle = Mathf.Clamp(angleAdjusted, bottomLeftAngleRange.x, bottomLeftAngleRange.y);

            bottomLeftcover.rotation = Quaternion.AngleAxis(angleAdjusted, Vector3.forward);
            bottomLeftcover.eulerAngles = new Vector3(0f, 0f, Mathf.Clamp(bottomLeftcover.eulerAngles.z, bottomLeftAngleRange.x, bottomLeftAngleRange.y));

            bottomLeftmask.position = bottomLeftoffset + ((bottomLeftcover.position + transform.position) / 2f);
            bottomLeftmask.rotation = Quaternion.AngleAxis(bottomLeftcover.eulerAngles.z / 2f, Vector3.forward);
        }
    }

    private void BottomCenterPageLogic()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && Trans2Rect(paperBottomCenterEdge).Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            isBottomCenterDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isBottomCenterDragging = false;
        }

        CalculateBottomCenter(Input.mousePosition);
#else
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Began &&
                Trans2Rect(paperBottomCenterEdge).Contains(Camera.main.ScreenToWorldPoint(Input.GetTouch(Input.touchCount - 1).position)))
            {
                isBottomCenterDragging = true;
            }
            else if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Moved)
            {
                CalculateBottomCenter(Input.GetTouch(Input.touchCount - 1).position);
            }
            else if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Ended || Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Canceled)
            {
                isBottomCenterDragging = false;
            }
        }
#endif
    }

    private void CalculateBottomCenter(Vector3 pointerScreenPos)
    {
        if (isBottomCenterDragging)
        {
            Vector3 temp = bottomCentercover.position;

            //This clamps the position of the Bottom Center Cover to anything greater than or equal to y=-3.
            temp.y = (temp.y >= -3f) ? temp.y + (currVec.y * pullSpeed * Time.deltaTime) : -3f;

            bottomCentercover.position = temp;

            Vector3 distBetween = (bottomCentercover.position - Camera.main.ScreenToWorldPoint(pointerScreenPos)).normalized;

            float angleBetween = Mathf.Atan2(distBetween.y, distBetween.x);

            float angleInDegrees = angleBetween * (180f / Mathf.PI);

            float angleAdjusted = angleInDegrees + 90f;

            float clampedAngle = Mathf.Clamp(angleAdjusted, bottomCenterAngleRange.x, bottomCenterAngleRange.y);

            bottomCentercover.rotation = Quaternion.AngleAxis(clampedAngle, Vector3.forward);

            bottomCentermask.position = bottomCenteroffset + ((bottomCentercover.position + transform.position) / 2f);
            bottomCentermask.rotation = Quaternion.AngleAxis(clampedAngle / 2f, Vector3.forward);
        }
    }

    private void ResetAllCoverRototation()
    {
        //Rotates all covers back to center when not being touched

        if (!isTopRightDragging)
        {
            topRightcover.rotation = Quaternion.Slerp(topRightcover.rotation, defaultTopRightCoverRot, Time.deltaTime * rotReturnSpeed);
            topRightmask.rotation = Quaternion.Slerp(topRightmask.rotation, defaultTopRightMaskRot, Time.deltaTime * rotReturnSpeed);
        }

        if (!isTopLeftDragging)
        {
            topLeftcover.rotation = Quaternion.Slerp(topLeftcover.rotation, defaultTopLeftCoverRot, Time.deltaTime * rotReturnSpeed);
            topLeftmask.rotation = Quaternion.Slerp(topLeftmask.rotation, defaultTopLeftMaskRot, Time.deltaTime * rotReturnSpeed);
        }

        if (!isTopCenterDragging)
        {
            topCentercover.rotation = Quaternion.Slerp(topCentercover.rotation, defaultTopCenterCoverRot, Time.deltaTime * rotReturnSpeed);
            topCentermask.rotation = Quaternion.Slerp(topCentermask.rotation, defaultTopCenterMaskRot, Time.deltaTime * rotReturnSpeed);
        }

        if (!isBottomRightDragging)
        {
            bottomRightcover.rotation = Quaternion.Slerp(bottomRightcover.rotation, defaultBottomRightCoverRot, Time.deltaTime * rotReturnSpeed);
            bottomRightmask.rotation = Quaternion.Slerp(bottomRightmask.rotation, defaultBottomRightMaskRot, Time.deltaTime * rotReturnSpeed);
        }

        if (!isBottomLeftDragging)
        {
            bottomLeftcover.rotation = Quaternion.Slerp(bottomLeftcover.rotation, defaultBottomLeftCoverRot, Time.deltaTime * rotReturnSpeed);
            bottomLeftmask.rotation = Quaternion.Slerp(bottomLeftmask.rotation, defaultBottomLeftMaskRot, Time.deltaTime * rotReturnSpeed);
        }
        
        if (!isBottomCenterDragging)
        {
            bottomCentercover.rotation = Quaternion.Slerp(bottomCentercover.rotation, defaultBottomCenterCoverRot, Time.deltaTime * rotReturnSpeed);
            bottomCentermask.rotation = Quaternion.Slerp(bottomCentermask.rotation, defaultBottomCenterMaskRot, Time.deltaTime * rotReturnSpeed);
        }
    }
}


