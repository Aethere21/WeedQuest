using System;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using FlatRedBall.Audio;
using FlatRedBall.Screens;
using WeedQuest.Entities;
using WeedQuest.Screens;
namespace WeedQuest.Entities
{
	public partial class ExitButton
	{
		void OnPush (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.SpriteInstance.CurrentChainName = "ButtonDown";            
        }
        void OnLosePush (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.SpriteInstance.CurrentChainName = "ButtonUp";
        }
        void OnClick (FlatRedBall.Gui.IWindow callingWindow)
        {
            FlatRedBallServices.Game.Exit();
        }

	}
}
