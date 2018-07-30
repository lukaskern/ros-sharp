using Newtonsoft.Json;

namespace RosSharp.RosBridgeClient.Messages.Geometry
{
    public class PointStamped : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "geometry_msgs/PointStamped";
        public Standard.Header header;
        public Point point;
        public PointStamped()
        {
            header = new Standard.Header();
            point = new Point();
        }
    }
}