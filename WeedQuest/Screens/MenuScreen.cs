#region Usings

using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Graphics.Model;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
using FlatRedBall.Localization;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
#endif
#endregion

namespace WeedQuest.Screens
{
	public partial class MenuScreen
	{

		void CustomInitialize()
		{
            EmitterListFile[0].Position.X = -455;
            EmitterListFile[0].Position.Y = -115;
            EmitterListFile[0].Position.Z = 5;

            EmitterListFileRight[0].Position.X = 455;
            EmitterListFileRight[0].Position.Y = -115;
            EmitterListFileRight[0].Position.Z = 5;
		}

		void CustomActivity(bool firstTimeCalled)
		{
            InputManager.Keyboard.ControlPositionedObject(AxisAlignedRectangleInstance, 100);

            FlatRedBall.Debugging.Debugger.Write(AxisAlignedRectangleInstance.X + " " + AxisAlignedRectangleInstance.Y);

		}

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

	}
}
