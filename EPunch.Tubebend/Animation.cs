using AnyCAD.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPunch.Tubebend
{
    class Animation
    {
        public delegate void AnimationHandler();
        public event AnimationHandler AnimationStop;

        protected virtual void OnAnimationStop() { AnimationStop?.Invoke(); }
 

        public double TimerOfObject { get; set; } = 0.5; //记录运动时间
        public double XSpeed { get; set; } = 10; //X方向(送料)的速度
        public double DSpeed { get; set; } = 10; //转料速度
        public double RSpeed { get; set; } = 10; //折弯速度
        public double DistanceX { get; set; } = 0; //X方向的位移
        public double AngleD { get; set; } = 0;
        public double AngleR { get; set; } = 0;
        public SceneNode m_Object { get; set; } //物体的节点
        public int Step { get; set; } = 0;
    }
}
