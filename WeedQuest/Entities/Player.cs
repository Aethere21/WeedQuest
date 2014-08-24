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

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

#endif
#endregion

namespace WeedQuest.Entities
{
	public partial class Player
	{

        public enum LeftOrRight
        {
            Left,
            Right
        }

        public LeftOrRight DirectionFacing
        {
            get;
            private set;
        }

		private void CustomInitialize()
		{
            ArmSprite.AttachTo(this, true);

		}

		private void CustomActivity()
		{
            AnimationActivity();
            CameraActivity();

            ArmActivity();

            this.DetermineMovementValues();
		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void AnimationActivity()
        {
            if(HorizontalRatio > 0)
            {
                this.DirectionFacing = LeftOrRight.Right;
            }
            else if(HorizontalRatio < 0)
            {
                this.DirectionFacing = LeftOrRight.Left;
            }
            
            if(IsOnGround){
                if (HorizontalRatio > 0)
                {
                    this.SpriteInstance.CurrentChainName = "WalkingRight";
                }
                else if (HorizontalRatio < 0)
                {
                    this.SpriteInstance.CurrentChainName = "WalkingLeft";
                }
                else
                {
                    if(DirectionFacing == LeftOrRight.Right)
                    {
                        this.SpriteInstance.CurrentChainName = "StandingRight";
                    }
                    else
                    {
                        this.SpriteInstance.CurrentChainName = "StandingLeft";
                    }
                }
            }
            else
            {
                if(DirectionFacing == LeftOrRight.Left)
                {
                    this.SpriteInstance.CurrentChainName = "JumpLeft";
                }
                else
                {
                    this.SpriteInstance.CurrentChainName = "JumpRight";
                }
            }
        }

        private void CameraActivity()
        {
            Camera.Main.Velocity.X = this.X - Camera.Main.Position.X;
            Camera.Main.Velocity.Y = this.Y - Camera.Main.Position.Y + 70;
        }

        private void ArmActivity()
        {
            if(this.DirectionFacing == LeftOrRight.Right)
            {
                this.ArmSprite.CurrentChainName = "ArmRight";
            }
            else
            {
                this.ArmSprite.CurrentChainName = "ArmLeft";
            }

            //ArmSprite.RelativePosition.X = 5;
            //ArmSprite.RelativePosition.Y = -5;
            ArmSprite.RelativePosition.Z = 6;
        }
	}
}
