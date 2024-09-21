using OpenTK;
using OpenTK.Graphics;

namespace ConsoleApp1
{
    public class Punto
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public Punto()
        {
            x = 0.0f;
            y = 0.0f;
            z = 0.0f;
        }

        public Punto(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Set(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public (float, float, float) Get()
        {
            return (x, y, z);
        }

        //public void trasladar(Punto tras)
        //{
        //    this.x += tras.x;
        //    this.y += tras.y;
        //    this.z += tras.z;
        //}

        //public void escalar(float factor, Punto centro)
        //{
        //    //this.x = centro.x + (this.x - centro.x) * factor;
        //    //this.y = centro.y + (this.y - centro.y) * factor;
        //    //this.z = centro.z + (this.z - centro.z) * factor;
        //    // Crear una matriz de escalado centrada en el origen
        //    Matrix4 scaleMatrix = Matrix4.CreateScale(factor);

        //    // Trasladar el punto al origen respecto al centro de escalado
        //    Vector3 puntoOriginal = new Vector3(this.x - centro.x, this.y - centro.y, this.z - centro.z);

        //    // Aplicar el escalado
        //    Vector3 puntoEscalado = Vector3.Transform(puntoOriginal, scaleMatrix);

        //    // Trasladar el punto de vuelta al centro
        //    this.x = centro.x + puntoEscalado.X;
        //    this.y = centro.y + puntoEscalado.Y;
        //    this.z = centro.z + puntoEscalado.Z;

        //}

        //public void rotar(float angulox, float anguloy, float anguloz, Punto centro)
        //{
        //    // Convertir ángulos a radianes
        //    float radx = (float)(Math.PI * angulox / 180.0f);
        //    float rady = (float)(Math.PI * anguloy / 180.0f);
        //    float radz = (float)(Math.PI * anguloz / 180.0f);
        //    float cosx = (float)Math.Cos(radx);
        //    float sinx = (float)Math.Sin(radx);
        //    float cosy = (float)Math.Cos(rady);
        //    float siny = (float)Math.Sin(rady);
        //    float cosz = (float)Math.Cos(radz);
        //    float sinz = (float)Math.Sin(radz);

        //    // Trasladar el punto al origen respecto al centro
        //    float xTemp = this.x - centro.x;
        //    float yTemp = this.y - centro.y;
        //    float zTemp = this.z - centro.z;

        //    // Rotación alrededor del eje x
        //    float yRotx = yTemp * cosx - zTemp * sinx;
        //    float zRotx = yTemp * sinx + zTemp * cosx;

        //    // Rotación alrededor del eje y
        //    float xRoty = xTemp * cosy + zRotx * siny;
        //    float zRoty = -xTemp * siny + zRotx * cosy;

        //    // Rotación alrededor del eje z
        //    float xRotz = xRoty * cosz - yRotx * sinz;
        //    float yRotz = xRoty * sinz + yRotx * cosz;

        //    // Trasladar el punto de vuelta al centro
        //    this.x = centro.x + xRotz;
        //    this.y = centro.y + yRotz;
        //    this.z = centro.z + zRoty;
        //}

        public override string ToString()
        {
            return $"[{x:F2}]-[{y:F2}]-[{z:F2}]";
        }
    }
}
