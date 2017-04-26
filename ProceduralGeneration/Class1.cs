using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProceduralGeneration
{
    public class Class1{
        private static Bitmap bm = new Bitmap(500, 500, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
        public static void Main(string[] args) {
            PerlinNoise perlin = new PerlinNoise(564165);
            for(int x = 0; x < 500; x++) {
                for(int y = 0; y < 500; y++) {
                    double v = perlin.Noise(x, y, 0) * 255f;
                    bm.SetPixel(x, y, Color.FromArgb((int)v,0,0));
                    Console.WriteLine("X, Y, V: "+ x + ", "+ y + ": "+v);
                }
                Console.WriteLine();
            }
            bm.Save("D:\\teste.png");
            
            Console.ReadLine();
        }
    }
}
