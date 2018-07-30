using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class PointStampedPublisher : Publisher<Messages.Geometry.PointStamped>
    {
        private Messages.Geometry.PointStamped message;
        public string FrameId = "Unity";
        public Transform PublishedTransform;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void FixedUpdate()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            message = new Messages.Geometry.PointStamped();
            message.header = new Messages.Standard.Header();
            message.header.frame_id = FrameId;
        }

        private void UpdateMessage()
        {
            message.header.Update();
            //message.point = GetGeometryPoint(PublishedTransform.position.Unity2Ros());
            message.point = GetGeometryPoint(PublishedTransform.position);

            Publish(message);
        }

        private Messages.Geometry.Point GetGeometryPoint(Vector3 position)
        {
            Messages.Geometry.Point geometryPoint = new Messages.Geometry.Point();
            geometryPoint.x = position.x;
            geometryPoint.y = position.y;
            geometryPoint.z = position.z;
            return geometryPoint;
        }
    }
}
