using BitmapFont = FlatRedBall.Graphics.BitmapFont;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if XNA4 || WINDOWS_8
using Color = Microsoft.Xna.Framework.Color;
#elif FRB_MDX
using Color = System.Drawing.Color;
#else
using Color = Microsoft.Xna.Framework.Graphics.Color;
#endif

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Microsoft.Xna.Framework.Media;
#endif

// Generated Usings
using WeedQuest.Entities;
using FlatRedBall;
using FlatRedBall.Screens;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.ManagedSpriteGroups;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Graphics.Particle;
using Microsoft.Xna.Framework.Graphics;

namespace WeedQuest.Screens
{
	public partial class MenuScreen : Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		protected static FlatRedBall.Graphics.Particle.EmitterList EmitterListFile;
		protected static Microsoft.Xna.Framework.Graphics.Texture2D StartScreen;
		protected static FlatRedBall.Graphics.Particle.EmitterList EmitterListFileRight;
		
		private FlatRedBall.ManagedSpriteGroups.SpriteFrame BackgroundSprite;
		private FlatRedBall.Math.Geometry.AxisAlignedRectangle mAxisAlignedRectangleInstance;
		public FlatRedBall.Math.Geometry.AxisAlignedRectangle AxisAlignedRectangleInstance
		{
			get
			{
				return mAxisAlignedRectangleInstance;
			}
			private set
			{
				mAxisAlignedRectangleInstance = value;
			}
		}
		private WeedQuest.Entities.ExitButton ExitButtonInstance;
		private WeedQuest.Entities.StartButton StartButtonInstance;

		public MenuScreen()
			: base("MenuScreen")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			BackgroundSprite = new FlatRedBall.ManagedSpriteGroups.SpriteFrame();
			BackgroundSprite.Name = "BackgroundSprite";
			mAxisAlignedRectangleInstance = new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
			mAxisAlignedRectangleInstance.Name = "mAxisAlignedRectangleInstance";
			ExitButtonInstance = new WeedQuest.Entities.ExitButton(ContentManagerName, false);
			ExitButtonInstance.Name = "ExitButtonInstance";
			StartButtonInstance = new WeedQuest.Entities.StartButton(ContentManagerName, false);
			StartButtonInstance.Name = "StartButtonInstance";
			
			
			PostInitialize();
			base.Initialize(addToManagers);
			if (addToManagers)
			{
				AddToManagers();
			}

        }
        
// Generated AddToManagers
		public override void AddToManagers ()
		{
			EmitterListFile.AddToManagers(mLayer);
			EmitterListFileRight.AddToManagers(mLayer);
			SpriteManager.AddSpriteFrame(BackgroundSprite);
			ShapeManager.AddAxisAlignedRectangle(mAxisAlignedRectangleInstance);
			ExitButtonInstance.AddToManagers(mLayer);
			StartButtonInstance.AddToManagers(mLayer);
			base.AddToManagers();
			AddToManagersBottomUp();
			CustomInitialize();
		}


		public override void Activity(bool firstTimeCalled)
		{
			// Generated Activity
			if (!IsPaused)
			{
				
				EmitterListFile.TimedEmit();
				EmitterListFileRight.TimedEmit();
				ExitButtonInstance.Activity();
				StartButtonInstance.Activity();
			}
			else
			{
			}
			base.Activity(firstTimeCalled);
			if (!IsActivityFinished)
			{
				CustomActivity(firstTimeCalled);
			}


				// After Custom Activity
				
            
		}

		public override void Destroy()
		{
			// Generated Destroy
			if (this.UnloadsContentManagerWhenDestroyed && ContentManagerName != "Global")
			{
				EmitterListFile.RemoveFromManagers(ContentManagerName != "Global");
			}
			else
			{
				EmitterListFile.RemoveFromManagers(false);
			}
			if (this.UnloadsContentManagerWhenDestroyed && ContentManagerName != "Global")
			{
				EmitterListFile = null;
			}
			else
			{
				EmitterListFile.MakeOneWay();
			}
			StartScreen = null;
			if (this.UnloadsContentManagerWhenDestroyed && ContentManagerName != "Global")
			{
				EmitterListFileRight.RemoveFromManagers(ContentManagerName != "Global");
			}
			else
			{
				EmitterListFileRight.RemoveFromManagers(false);
			}
			if (this.UnloadsContentManagerWhenDestroyed && ContentManagerName != "Global")
			{
				EmitterListFileRight = null;
			}
			else
			{
				EmitterListFileRight.MakeOneWay();
			}
			
			if (BackgroundSprite != null)
			{
				SpriteManager.RemoveSpriteFrame(BackgroundSprite);
			}
			if (AxisAlignedRectangleInstance != null)
			{
				ShapeManager.Remove(AxisAlignedRectangleInstance);
			}
			if (ExitButtonInstance != null)
			{
				ExitButtonInstance.Destroy();
				ExitButtonInstance.Detach();
			}
			if (StartButtonInstance != null)
			{
				StartButtonInstance.Destroy();
				StartButtonInstance.Detach();
			}

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			BackgroundSprite.Texture = StartScreen;
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.X = 0f;
			}
			else
			{
				BackgroundSprite.RelativeX = 0f;
			}
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.Y = 0f;
			}
			else
			{
				BackgroundSprite.RelativeY = 0f;
			}
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.Z = 0f;
			}
			else
			{
				BackgroundSprite.RelativeZ = 0f;
			}
			BackgroundSprite.Width = 1024f;
			BackgroundSprite.Height = 768f;
			BackgroundSprite.PixelSize = 0.5f;
			AxisAlignedRectangleInstance.Width = 32f;
			AxisAlignedRectangleInstance.Height = 32f;
			if (ExitButtonInstance.Parent == null)
			{
				ExitButtonInstance.X = 320f;
			}
			else
			{
				ExitButtonInstance.RelativeX = 320f;
			}
			if (ExitButtonInstance.Parent == null)
			{
				ExitButtonInstance.Y = 180f;
			}
			else
			{
				ExitButtonInstance.RelativeY = 180f;
			}
			if (ExitButtonInstance.Parent == null)
			{
				ExitButtonInstance.Z = 3f;
			}
			else
			{
				ExitButtonInstance.RelativeZ = 3f;
			}
			if (StartButtonInstance.Parent == null)
			{
				StartButtonInstance.X = -320f;
			}
			else
			{
				StartButtonInstance.RelativeX = -320f;
			}
			if (StartButtonInstance.Parent == null)
			{
				StartButtonInstance.Y = 180f;
			}
			else
			{
				StartButtonInstance.RelativeY = 180f;
			}
			if (StartButtonInstance.Parent == null)
			{
				StartButtonInstance.Z = 3f;
			}
			else
			{
				StartButtonInstance.RelativeZ = 3f;
			}
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			CameraSetup.ResetCamera(SpriteManager.Camera);
			AssignCustomVariables(false);
		}
		public virtual void RemoveFromManagers ()
		{
			if (BackgroundSprite != null)
			{
				SpriteManager.RemoveSpriteFrame(BackgroundSprite);
			}
			if (AxisAlignedRectangleInstance != null)
			{
				ShapeManager.RemoveOneWay(AxisAlignedRectangleInstance);
			}
			ExitButtonInstance.RemoveFromManagers();
			StartButtonInstance.RemoveFromManagers();
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
				ExitButtonInstance.AssignCustomVariables(true);
				StartButtonInstance.AssignCustomVariables(true);
			}
			BackgroundSprite.Texture = StartScreen;
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.X = 0f;
			}
			else
			{
				BackgroundSprite.RelativeX = 0f;
			}
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.Y = 0f;
			}
			else
			{
				BackgroundSprite.RelativeY = 0f;
			}
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.Z = 0f;
			}
			else
			{
				BackgroundSprite.RelativeZ = 0f;
			}
			BackgroundSprite.Width = 1024f;
			BackgroundSprite.Height = 768f;
			BackgroundSprite.PixelSize = 0.5f;
			mAxisAlignedRectangleInstance.Width = 32f;
			mAxisAlignedRectangleInstance.Height = 32f;
			if (ExitButtonInstance.Parent == null)
			{
				ExitButtonInstance.X = 320f;
			}
			else
			{
				ExitButtonInstance.RelativeX = 320f;
			}
			if (ExitButtonInstance.Parent == null)
			{
				ExitButtonInstance.Y = 180f;
			}
			else
			{
				ExitButtonInstance.RelativeY = 180f;
			}
			if (ExitButtonInstance.Parent == null)
			{
				ExitButtonInstance.Z = 3f;
			}
			else
			{
				ExitButtonInstance.RelativeZ = 3f;
			}
			if (StartButtonInstance.Parent == null)
			{
				StartButtonInstance.X = -320f;
			}
			else
			{
				StartButtonInstance.RelativeX = -320f;
			}
			if (StartButtonInstance.Parent == null)
			{
				StartButtonInstance.Y = 180f;
			}
			else
			{
				StartButtonInstance.RelativeY = 180f;
			}
			if (StartButtonInstance.Parent == null)
			{
				StartButtonInstance.Z = 3f;
			}
			else
			{
				StartButtonInstance.RelativeZ = 3f;
			}
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			SpriteManager.ConvertToManuallyUpdated(BackgroundSprite);
			ExitButtonInstance.ConvertToManuallyUpdated();
			StartButtonInstance.ConvertToManuallyUpdated();
		}
		public static void LoadStaticContent (string contentManagerName)
		{
			if (string.IsNullOrEmpty(contentManagerName))
			{
				throw new ArgumentException("contentManagerName cannot be empty or null");
			}
			#if DEBUG
			if (contentManagerName == FlatRedBallServices.GlobalContentManager)
			{
				HasBeenLoadedWithGlobalContentManager = true;
			}
			else if (HasBeenLoadedWithGlobalContentManager)
			{
				throw new Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
			}
			#endif
			if (!FlatRedBallServices.IsLoaded<FlatRedBall.Graphics.Particle.EmitterList>(@"content/screens/menuscreen/emitterlistfile.emix", contentManagerName))
			{
			}
			EmitterListFile = FlatRedBallServices.Load<FlatRedBall.Graphics.Particle.EmitterList>(@"content/screens/menuscreen/emitterlistfile.emix", contentManagerName);
			if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/menuscreen/startscreen.png", contentManagerName))
			{
			}
			StartScreen = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/menuscreen/startscreen.png", contentManagerName);
			if (!FlatRedBallServices.IsLoaded<FlatRedBall.Graphics.Particle.EmitterList>(@"content/screens/menuscreen/emitterlistfileright.emix", contentManagerName))
			{
			}
			EmitterListFileRight = FlatRedBallServices.Load<FlatRedBall.Graphics.Particle.EmitterList>(@"content/screens/menuscreen/emitterlistfileright.emix", contentManagerName);
			WeedQuest.Entities.ExitButton.LoadStaticContent(contentManagerName);
			WeedQuest.Entities.StartButton.LoadStaticContent(contentManagerName);
			CustomLoadStaticContent(contentManagerName);
		}
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "EmitterListFile":
					return EmitterListFile;
				case  "StartScreen":
					return StartScreen;
				case  "EmitterListFileRight":
					return EmitterListFileRight;
			}
			return null;
		}
		public static object GetFile (string memberName)
		{
			switch(memberName)
			{
				case  "EmitterListFile":
					return EmitterListFile;
				case  "StartScreen":
					return StartScreen;
				case  "EmitterListFileRight":
					return EmitterListFileRight;
			}
			return null;
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "EmitterListFile":
					return EmitterListFile;
				case  "StartScreen":
					return StartScreen;
				case  "EmitterListFileRight":
					return EmitterListFileRight;
			}
			return null;
		}


	}
}
