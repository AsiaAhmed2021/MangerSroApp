using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp.Tools.Maps
{
    public static class MoveControl
    {
        public static void MoveOnly(this Control Target)
        {
            //            Control Target
            bool dragging = false;
            int Xoffset = 0;
            int Yoffset = 0;

            Target.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                dragging = true;
                Xoffset = e.X;
                Yoffset = e.Y;
            };
            Target.MouseUp += delegate { dragging = false; };
            Target.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (dragging)
                {
                    Target.Location = new System.Drawing.Point(
                        Target.Location.X + (e.Location.X - Xoffset),
                        Target.Location.Y + (e.Location.Y - Yoffset));
                }
            };
        }

        public static void MoveOnly(this Control Target,Control ControlMoved)
        {
            //            Control Target
            bool dragging = false;
            int Xoffset = 0;
            int Yoffset = 0;

            ControlMoved.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                dragging = true;
                Xoffset = e.X;
                Yoffset = e.Y;
            };
            ControlMoved.MouseUp += delegate { dragging = false; };
            ControlMoved.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (dragging)
                {
                    Target.Location = new System.Drawing.Point(
                        Target.Location.X + (e.Location.X - Xoffset),
                        Target.Location.Y + (e.Location.Y - Yoffset));
                }
            };
        }

        //public static Control Target, Move, MaxControl;


        //bool static dragging;
        //int  static Xoffset;
        //int  static Yoffset;

        //public MoveControl(Control MoveControl, Control Target)
        //{
        //    this.Move = MoveControl;
        //    this.Target = Target;

        //    Move.MouseDown += Move_MouseDown;
        //    Move.MouseUp += Move_MouseUp;
        //    Move.MouseMove += Move_MouseMove;
        //}

        //public MoveControl(Control MoveControl, Control Target, Control MaxControl)
        //{
        //    this.Move = MoveControl;
        //    this.Target = Target;
        //    this.MaxControl = MaxControl;
        //    Move.MouseDown += Move_MouseDown;
        //    Move.MouseUp += Move_MouseUp;
        //    Move.MouseMove += Move_MouseMove;
        //}

        //public MoveControl(Control Target)
        //{
        //    this.Target = Target;

        //    Target.MouseDown += Move_MouseDown;
        //    Target.MouseUp += Move_MouseUp;
        //    Target.MouseMove += Move_MouseMove;
        //}

        //private void Move_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (dragging)
        //    {
        //        if (MaxControl != null)
        //        {
        //            int MoveControlToX = Target.Location.X + (e.Location.X - Xoffset);
        //            int MoveControlToY = Target.Location.Y + (e.Location.Y - Yoffset);
        //            bool MaxAreaX = (Application.OpenForms[0].Left + MaxControl.Width) > Target.Location.X;
        //            bool MaxAreaY = (Application.OpenForms[0].Height + MaxControl.Height) > Target.Location.Y;


        //            Target.Location = new System.Drawing.Point(
        //              MaxAreaX ? MoveControlToX : Target.Location.X,
        //              MaxAreaY ? MoveControlToY : Target.Location.Y
        //               );
        //        }
        //        else
        //        {
        //            Target.Location = new System.Drawing.Point(
        //                Target.Location.X + (e.Location.X - Xoffset),
        //                Target.Location.Y + (e.Location.Y - Yoffset)
        //                );
        //        }
        //    }
        //}

        //private void Move_MouseUp(object sender, MouseEventArgs e)
        //{
        //    dragging = false;
        //}

        //private void Move_MouseDown(object sender, MouseEventArgs e)
        //{
        //    dragging = true;
        //    Xoffset = e.X;
        //    Yoffset = e.Y;
        //}

    }
}
