using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing;

namespace SpaceSimulation {
    public class Program {
        public static Size ImageSize = new Size(1000, 1000);
        public const double Proportion = 1E5;

        public static void Main(string[] args) {
            /*
            for(double x = 0; x < 100; x+=1.45649852) {
                Console.WriteLine(
                    SimplexNoise.noise(x, 0.76435434, 0.857438, 0.6432758)*0.5+0.5
                );
            }*/

            Bitmap bitmap = new Bitmap(ImageSize.Width, ImageSize.Height);

            CorpoCeleste Terra = new CorpoCeleste(CorpoCeleste.EarthMass, CorpoCeleste.EarthRadius);
            DrawPlanet(Terra, bitmap);
            //órbita geossíncrona
            /*
            Vector3 NavePosition = new Vector3(0, Terra.Radius + 35786E3, 0);
            Vector3 VelocidadeNave = new Vector3(3074.6, 0, 0);
            */

            Vector3 NavePosition = new Vector3(0, Terra.Radius + 2000E3, 0);
            Vector3 VelocidadeNave = new Vector3(10000, 0, 0);

            Console.WriteLine(VelocidadeNave);
            for(int i = 0; i < 100000; i++) {
                Point NavePositionPoint = Vector3ToImagePoint(NavePosition);
                if(NavePositionPoint.X >= 0 && NavePositionPoint.X < ImageSize.Width &&
                   NavePositionPoint.Y >= 0 && NavePositionPoint.Y < ImageSize.Height) {
                    bitmap.SetPixel(NavePositionPoint.X, NavePositionPoint.Y, Color.Red);
                }
                
                Vector3 NavePositionNormalized = new Vector3(NavePosition.X, NavePosition.Y, 0);
                NavePositionNormalized.Normalize();
                VelocidadeNave -= SpaceMath.NewtonsToMs2(1, Terra.Gravity(1, Vector3.Distance(NavePosition, Terra.Position)))* NavePositionNormalized;
                NavePosition += VelocidadeNave;
            }
            Console.WriteLine(VelocidadeNave);

            bitmap.Save("D:/TesteImage.png");
            Console.WriteLine("Done.");
            //Console.ReadLine();
        }
        public static void DrawPlanet(CorpoCeleste Terra, Bitmap bitmap) {
            for(int x = 0; x < ImageSize.Width; x++) {
                for(int y = 0; y < ImageSize.Height; y++) {
                    Vector3 currentPos = ImagePointToVector3(new Point(x, y));
                    if(Vector3.Distance(currentPos, Terra.Position) <= Terra.Radius) {
                        bitmap.SetPixel(x, y, Color.Blue);
                    }
                }
            }
        }
        public static Point Vector3ToImagePoint(Vector3 pos) {
            return new Point(
                (int)((pos.X / Proportion) + ImageSize.Width/2.0), 
                (int)((pos.Y / Proportion) + ImageSize.Height/2.0)
            );
        }
        public static Vector3 ImagePointToVector3(Point pos) {
            return new Vector3(
                ((pos.X - ImageSize.Width / 2.0) * Proportion),
                ((pos.Y - ImageSize.Height / 2.0) * Proportion),
                0
            );
        }
    }
}
