using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikProjekt1
{
    public class GameObject
    {
        public Transform transform;
        public Renderer renderer;
        public GameWindow gameWindow;
        public GameObject(Renderer renderer, GameWindow gameWindow)
        {
            this.renderer = renderer;
            this.gameWindow = gameWindow;
            transform = new Transform();
        }
        public void Update(FrameEventArgs args)
        {
        }
        public void Draw(Matrix4 vp)
        {
            renderer.Draw(transform.CalculateModel() * vp);
        }
    }
}
