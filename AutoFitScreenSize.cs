    public class AutoFitScreenSize : MonoBehaviour
    {
        public Camera mCamera;
        public Canvas mCanvas;

        private void Awake()
        {
            var rt = GetComponent<RectTransform>();
            var cameraTransform = mCamera.transform;
            var cameraTransformPosition = cameraTransform.position;
            var canvasPosition = mCanvas.transform.position;
            var vec1 = canvasPosition - cameraTransformPosition;
            var vec2 = Vector3.Project(vec1, cameraTransform.forward);
            canvasPosition = cameraTransformPosition + vec2;
            var planeDistance = Vector3.Distance(cameraTransformPosition, canvasPosition);
            float camHeight;
            float camWidth;
            if (mCamera.orthographic)
            {
                camHeight = mCamera.orthographicSize * 2.0f;
                camWidth = camHeight * mCamera.aspect;
            }
            else
            {
                camHeight = 2.0f * planeDistance * Mathf.Tan(mCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
                camWidth = camHeight * mCamera.aspect;
            }

            rt.sizeDelta = new Vector2(camWidth, camHeight);
        }
    }
