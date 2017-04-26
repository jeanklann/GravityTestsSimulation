using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSimulation {
    public static class SpaceMath {
        public const double G = 6.67408E-11;

        public static double Gravity(double mass1, double mass2, double distance) {
            return (G * mass1 * mass2) / (distance * distance);
        }
        public static double NewtonsToMs2(double mass, double newtons) {
            return newtons / mass;
        }
        public static double Ms2ToNewtons(double mass, double acceleration) {
            return acceleration * mass;
        }

    }
}
