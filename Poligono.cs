using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Audio.OpenAL;
using System.Collections;

namespace ConsoleApp1
{
    internal class Poligono
    {
        public Punto centroPol { get; set; }
        public IDictionary<string, Punto> ListaDePuntos { get; set; }

        public Poligono()
        {
            centroPol=new Punto();
            ListaDePuntos = new Dictionary<string, Punto>();
        }

        public void SetCentro(Punto c)
        {
            centroPol = c;
        }

        public Punto GetCentro()
        {
            return centroPol;
        }

        public void AnadirPunto(string clave, Punto valor)
        {
            ListaDePuntos.Add(clave, valor);
            this.Centro();
        }

        public void Centro()
        {
                float maxX = ListaDePuntos.Values.Max(punto => punto.x);
                float minX = ListaDePuntos.Values.Min(punto => punto.x);
                float cx = (maxX + minX) / 2;
                float maxY = ListaDePuntos.Values.Max(punto => punto.y);
                float minY = ListaDePuntos.Values.Min(punto => punto.y);
                float cy = (maxY + minY) / 2;
                float maxZ = ListaDePuntos.Values.Max(punto => punto.z);
                float minZ = ListaDePuntos.Values.Min(punto => punto.z);
                float cz = (maxZ + minZ) / 2;
                Punto centroMasa = new Punto();
                centroMasa.Set(cx, cy, cz);
                this.SetCentro(centroMasa);
        }

        public void trasladar(float trasladarX, float trasladarY, float trasladarZ)
        {
            //Punto n=new Punto();
            //foreach (var punto in ListaDePuntos)
            //{
            //    n.Set(trasladarX, trasladarY, trasladarZ);
            //    punto.Value.trasladar(n);
            //}
            Matrix4 m = Matrix4.CreateTranslation(trasladarX, trasladarY, trasladarZ);
            Vector4 v;
            foreach (var punto in ListaDePuntos)
            {
                Vector4 v1 = new Vector4(punto.Value.x, punto.Value.y, punto.Value.z, 1);
                v=v1* m;
                punto.Value.x = v.X;
                punto.Value.y = v.Y;
                punto.Value.z = v.Z;
            }

        }

        public void escalar(float valorDeEscalar)
        {

            //foreach (var punto in ListaDePuntos)
            //{
            //    punto.Value.escalar(valorDeEscalar, centroPol);
            //}
            Matrix4 m = Matrix4.CreateScale(valorDeEscalar);
            Vector4 v;
            foreach (var punto in ListaDePuntos)
            {
                Vector4 v1 = new Vector4(punto.Value.x, punto.Value.y, punto.Value.z, 1);
                v = v1 * m;
                punto.Value.x = v.X;
                punto.Value.y = v.Y;
                punto.Value.z = v.Z;
            }
        }

        public void rotar(float anguloX, float anguloY, float anguloZ)
        {
            //foreach (var punto in ListaDePuntos)
            //{
            //    punto.Value.rotar(anguloX, anguloY, anguloZ, centroPol);
            //}

            Matrix4 mx = Matrix4.CreateRotationX(MathHelper.RadiansToDegrees(anguloX));
            Matrix4 my = Matrix4.CreateRotationY(MathHelper.RadiansToDegrees(anguloY));
            Matrix4 mz = Matrix4.CreateRotationZ(MathHelper.RadiansToDegrees(anguloZ));
            Matrix4 mtotal= mx * my * mz;

            Vector4 v;

            foreach (var punto in ListaDePuntos)
            {
                Vector4 v1 = new Vector4(punto.Value.x-centroPol.x, punto.Value.y-centroPol.y, punto.Value.z - centroPol.z, 1);
                v = v1 * mtotal;
                punto.Value.x = v.X+centroPol.x;
                punto.Value.y = v.Y+centroPol.y;
                punto.Value.z = v.Z+centroPol.z;
            }
        }
        public void Dibujar()
        {
            GL.Begin(PrimitiveType.LineLoop);

            //this.Centro();
            

            foreach (var punto in ListaDePuntos)
            {
                GL.Vertex3(punto.Value.x, punto.Value.y, punto.Value.z);
                Console.WriteLine(punto.Key);
            }
            GL.End();
            GL.Flush();
        }
    }
}
