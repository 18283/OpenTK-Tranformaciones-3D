using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    public class Game: GameWindow
    {
        //private Parte parte1;
        //private Poligono frente;
        //private Objeto objeto1;
        private Escenario escenario1;

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            //parte1 = new Parte();
            //frente = new Poligono();
            //objeto1 = new Objeto();
            escenario1 = new Escenario();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.DepthTest);

            Serializador serializador = new Serializador();

            if (!File.Exists("figura3d.json"))
            {
                serializador.CrearYGuardar(); // Crear y guardar el objeto si no existe el archivo
            }

            Poligono objetoCargado = serializador.Cargar("figura3d.json");
            //parte.AnadirPoligono("objeto", objetoCargado);

            Punto a = new Punto();
            Punto b = new Punto();
            Punto c = new Punto();
            Punto d = new Punto();
            Punto a1 = new Punto();
            Punto b1 = new Punto();
            Punto c1 = new Punto();
            Punto d1 = new Punto();
            Punto f = new Punto();
            Punto g = new Punto();
            Punto h = new Punto();
            Punto i = new Punto();
            Punto f1 = new Punto();
            Punto g1 = new Punto();
            Punto h1 = new Punto();
            Punto i1 = new Punto();

            a.Set(0.2f, 0.8f, 0.0f);
            b.Set(0.2f, 0.6f, 0.0f);
            c.Set(0.8f, 0.6f, 0.0f);
            d.Set(0.8f, 0.8f, 0.0f);

            a1.Set(0.2f, 0.8f, 0.2f);
            b1.Set(0.2f, 0.6f, 0.2f);
            c1.Set(0.8f, 0.6f, 0.2f);
            d1.Set(0.8f, 0.8f, 0.2f);

            //abajo
            f.Set(0.4f, 0.6f, 0.0f);
            g.Set(0.4f, 0.1f, 0.0f);
            h.Set(0.6f, 0.1f, 0.0f);
            i.Set(0.6f, 0.6f, 0.0f);

            f1.Set(0.4f, 0.6f, 0.2f);
            g1.Set(0.4f, 0.1f, 0.2f);
            h1.Set(0.6f, 0.1f, 0.2f);
            i1.Set(0.6f, 0.6f, 0.2f);

            Poligono frente = new Poligono();
            frente.AnadirPunto("Punto1", a);
            frente.AnadirPunto("Punto2", b);
            frente.AnadirPunto("Punto3", c);
            frente.AnadirPunto("Punto4", d);


            Poligono atras = new Poligono();
            atras.AnadirPunto("Punto5", a1);
            atras.AnadirPunto("Punto6", b1);
            atras.AnadirPunto("Punto7", c1);
            atras.AnadirPunto("Punto8", d1);

            Poligono izquierda = new Poligono();
            izquierda.AnadirPunto("Punto9", a1);
            izquierda.AnadirPunto("Punto10", b1);
            izquierda.AnadirPunto("Punto11", b);
            izquierda.AnadirPunto("Punto12", a);

            Poligono derecha = new Poligono();
            derecha.AnadirPunto("Punto13", d1);
            derecha.AnadirPunto("Punto14", c1);
            derecha.AnadirPunto("Punto15", c);
            derecha.AnadirPunto("Punto16", d);

            Poligono frente2 = new Poligono();
            frente2.AnadirPunto("P1", f);
            frente2.AnadirPunto("P2", g);
            frente2.AnadirPunto("P3", h);
            frente2.AnadirPunto("P4", i);

            Poligono atras2 = new Poligono();
            atras2.AnadirPunto("P5", f1);
            atras2.AnadirPunto("P6", g1);
            atras2.AnadirPunto("P7", h1);
            atras2.AnadirPunto("P8", i1);

            Poligono izquierda2 = new Poligono();
            izquierda2.AnadirPunto("P9", f);
            izquierda2.AnadirPunto("P10", g);
            izquierda2.AnadirPunto("P11", g1);
            izquierda2.AnadirPunto("P12", f1);

            Poligono derecha2 = new Poligono();
            derecha2.AnadirPunto("P1", i);
            derecha2.AnadirPunto("P2", h);
            derecha2.AnadirPunto("P3", h1);
            derecha2.AnadirPunto("P4", i1);

            Parte parte1 = new Parte();
            parte1.AnadirPoligono("c1", frente);
            parte1.AnadirPoligono("c2", atras);
            parte1.AnadirPoligono("c3", izquierda);
            parte1.AnadirPoligono("c4", derecha);

            Parte parte2 = new Parte();
            parte2.AnadirPoligono("c1", frente2);
            parte2.AnadirPoligono("c2", atras2);
            parte2.AnadirPoligono("c3", izquierda2);
            parte2.AnadirPoligono("c4", derecha2);

            Objeto objeto1 = new Objeto();
            objeto1.AnadirParte("Parte1", parte1);
            objeto1.AnadirParte("Parte2", parte2);

            /////objeto2

            Punto a2 = new Punto(-0.2f, 0.2f, 0.0f);
            Punto b2 = new Punto(-0.2f, -0.2f, 0.0f);
            Punto c2 = new Punto(0.2f, -0.2f, 0.0f);
            Punto d2 = new Punto(0.2f, 0.2f, 0.0f);

            Punto a21 = new Punto(-0.2f, 0.2f, 0.2f);
            Punto b21 = new Punto(-0.2f, -0.2f, 0.2f);
            Punto c21 = new Punto(0.2f, -0.2f, 0.2f);
            Punto d21 = new Punto(0.2f, 0.2f, 0.2f);

            // va2c2ios 
            Poligono front = new Poligono();
            Poligono back = new Poligono();
            Poligono left = new Poligono();
            Poligono right = new Poligono();
            Poligono up = new Poligono();
            Poligono down = new Poligono();


            front.AnadirPunto("p1", a2);
            front.AnadirPunto("p2", b2);
            front.AnadirPunto("p3", c2);
            front.AnadirPunto("p4", d2);

            back.AnadirPunto("p5", a21);
            back.AnadirPunto("p6", b21);
            back.AnadirPunto("p7", c21);
            back.AnadirPunto("p8", d21);

            left.AnadirPunto("p1", a2);
            left.AnadirPunto("p2", a21);
            left.AnadirPunto("p3", b21);
            left.AnadirPunto("p4", b2);

            right.AnadirPunto("p1", d2);
            right.AnadirPunto("p2", d21);
            right.AnadirPunto("p3", c21);
            right.AnadirPunto("p4", c2);

            up.AnadirPunto("p1", a2);
            up.AnadirPunto("p2", a21);
            up.AnadirPunto("p3", d21);
            up.AnadirPunto("p4", d2);

            down.AnadirPunto("p1", b2);
            down.AnadirPunto("p2", b21);
            down.AnadirPunto("p3", c21);
            down.AnadirPunto("p4", c2);


            Parte cubo2 = new Parte();

            Objeto cubo = new Objeto();

            cubo2.AnadirPoligono("a", front);
            cubo2.AnadirPoligono("b", back);
            cubo2.AnadirPoligono("c", left);
            cubo2.AnadirPoligono("d", right);
            cubo2.AnadirPoligono("e", up);
            cubo2.AnadirPoligono("f", down) ;

            cubo.AnadirParte("cubo", cubo2);

            escenario1.AnadirObjeto("Objeto1", objeto1);
            escenario1.AnadirObjeto("Onjeto2", cubo);



            //frente.trasladar(0.02f, 0.0f, 0.0f);
            //frente.escalar(1.5f); //aqui
            //parte1.escalar(1.2f);
            //objeto1.escalar(1.3f);
            //Console.WriteLine();
            //escenario1.escalar(1.2f);

            GL.Rotate(45, 0.0, 0.1, 0.1);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);




            //frente.Dibujar();
            //frente.trasladar(0.001f, 0.0f, 0.0f);
            //frente.rotar(0, 0, 1);
            //Console.WriteLine(frente.GetCentro().ToString());

            //parte.Dibujar();
            //parte1.Dibujar();
            //parte1.rotar(0, 0, 1);
            //parte1.trasladar(0f, 0f, 0.001f);
            //Console.WriteLine(parte1.GetCentro().ToString());

            float s = (float)(e.Time * 0.01);
            //objeto1.Dibujar();
            //objeto1.rotar(0, 0, s);
            //objeto1.trasladar(0f, 0f, 0.001f);

            escenario1.Dibujar();
            //escenario1.rotar(0, 0, s);
            escenario1.trasladar(0f, 0f, 0.001f);

            //frente.Dibujar();


            Context.SwapBuffers();

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }
        }
    }
}
