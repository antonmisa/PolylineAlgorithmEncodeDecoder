namespace PolylineAlgorithmEncodeDecoder
{
    public struct CoordinateEntity
    {
        public double Latitude;
        public double Longitude;

        public CoordinateEntity(double x, double y)
        {
            this.Latitude = x;
            this.Longitude = y;
        }
    }
}
