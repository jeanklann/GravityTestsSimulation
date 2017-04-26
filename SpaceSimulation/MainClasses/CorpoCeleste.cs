using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSimulation {
    public class CorpoCeleste {
        public const double EarthMass = 5.9742E24;
        public const double EarthRadius = 6371E3;

        public double Mass = 1d;
        public double Radius = 1d;
        public Vector3 Velocity = new Vector3();
        public Vector3 Position = new Vector3();

        public CorpoCeleste() {

        }
        public CorpoCeleste(double mass, double radius) {
            Mass = mass;
            Radius = radius;
        }

        public double Gravity(double mass, double distance) {
            return SpaceMath.Gravity(Mass, mass, distance);
        }
    }
}
