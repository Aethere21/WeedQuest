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
using Microsoft.Xna.Framework;
#endif
#endregion

namespace WeedQuest.Screens
{
	public partial class GameScreen
	{

		void CustomInitialize()
		{
            SetLevelByName("City");

            Camera.Main.Orthogonal = true;
            Camera.Main.OrthogonalWidth = 600;
            Camera.Main.OrthogonalHeight = 400;
            

		}

		void CustomActivity(bool firstTimeCalled)
		{
            CollisionActivity();
		}

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        void SetUpTiles()
        {
            foreach (Sprite spr in VisibleRepresentation.Sprites)
            {
                if (spr.Name == "Spawn")
                {
                    PlayerInstance.Position.X = spr.Position.X;
                    PlayerInstance.Position.Y = spr.Position.Y;
                    spr.Visible = false;
                }

                if (spr.Name == "Collision")
                {
                    AddShapes(spr.Position, spr.ScaleX, spr.ScaleY, Color.Red, true);
                }

                if (spr.Name == "CollisionFloor")
                {
                    Vector3 pos = spr.Position;
                    pos.Y -= 8;
                    AddShapes(pos, spr.ScaleX, (spr.ScaleY ) / 2, Color.Red, true);
                }

                if(spr.Name == "WallCollision")
                {
                    AddShapes(spr.Position, spr.ScaleX, spr.ScaleY, Color.Red, true);
                    spr.Visible = false;
                }

                if(spr.Name == "BG")
                {
                    BackgroundSprite.Position.X = spr.Position.X;
                    BackgroundSprite.Position.Y = spr.Position.Y;
                    spr.Visible = false;
                }
            }
        }

        void SetLevelByName(string levelName)
        {
            GlobalData.CurrentLevelInfo.LevelName = levelName;
            VisibleRepresentation = (Scene)GetMember(levelName);
            SetUpTiles();
            //TileCollision.
            VisibleRepresentation.AddToManagers();
        }


        void AddShapes(Vector3 Position, float scaleX, float scaleY, Color color, bool Visible)
        {
            AxisAlignedRectangle rekd = new AxisAlignedRectangle(scaleX, scaleY);
            rekd.Position = Position;
            rekd.Color = color;
            rekd.Visible = Visible;
            TileCollision.AxisAlignedRectangles.Add(rekd);
        }

        private void CollisionActivity()
        {
            PlayerInstance.CollideAgainst(TileCollision);
        }
	}
}
