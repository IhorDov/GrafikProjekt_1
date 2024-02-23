using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GrafikProjekt1
{
    public class Game : GameWindow
    {
        







       
        private List<GameObject> gameObjects = new List<GameObject>();

        

        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Matrix4 view = Matrix4.CreateTranslation(0.0f, 0, -3f);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(60.0f),
            (float)Size.X / (float)Size.Y, 0.3f, 1000.0f);
            gameObjects.ForEach(x => x.Draw(view * projection));
            SwapBuffers();


        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            gameObjects.ForEach(x => x.Update(args));

            
            //Console.WriteLine((float)watch.Elapsed.TotalSeconds);
            

            

            

            

        }

        protected override void OnLoad()
        {
            base.OnLoad();

            

            

            
            Texture texture0 = new Texture("Textures/wall.jpg");
            Texture texture1 = new Texture("Textures/AragonTexUdenBaggrund.png");
    
            

            
            Dictionary<string, object> uniforms = new Dictionary<string, object>();
            uniforms.Add("texture0", texture0);
            uniforms.Add("texture1", texture1);
            Material mat = new Material("Shaders/shader.vert",
            "Shaders/shader.frag", uniforms);
            Renderer rend = new Renderer(mat, new QuadMesh());
            Renderer rend2 = new Renderer(mat, new CubeMesh());
            GameObject triangle = new GameObject(rend, this);
            gameObjects.Add(triangle);
            GameObject cube = new GameObject(rend2, this);
            cube.transform.Position = new Vector3(1, 0, 0);
            gameObjects.Add(cube);



            GL.Enable(EnableCap.DepthTest);


      











        }

        protected override void OnUnload()
        {
            base.OnUnload();
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            
        }

        


    }
}
