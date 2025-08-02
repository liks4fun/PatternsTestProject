namespace PatternsTestProject.Patterns.Factory.Default
{
    public class Point
    {
        private double x, y;

        protected Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
        
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }
        }
    }
}