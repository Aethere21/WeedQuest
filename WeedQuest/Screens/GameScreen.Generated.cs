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
using FlatRedBall.Math.Geometry;
using Microsoft.Xna.Framework.Graphics;

namespace WeedQuest.Screens
{
	public partial class GameScreen : Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		protected static FlatRedBall.Scene City;
		protected static Microsoft.Xna.Framework.Graphics.Texture2D Tileset;
		protected static Microsoft.Xna.Framework.Graphics.Texture2D CityBack;
		
		private FlatRedBall.Scene VisibleRepresentation;
		private FlatRedBall.Math.Geometry.ShapeCollection TileCollision;
		private WeedQuest.Entities.Player PlayerInstance;
		private FlatRedBall.Sprite BackgroundSprite;

		public GameScreen()
			: base("GameScreen")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			VisibleRepresentation = new FlatRedBall.Scene();
			VisibleRepresentation.Name = "VisibleRepresentation";
			TileCollision = new FlatRedBall.Math.Geometry.ShapeCollection();
			TileCollision.Name = "TileCollision";
			PlayerInstance = new WeedQuest.Entities.Player(ContentManagerName, false);
			PlayerInstance.Name = "PlayerInstance";
			BackgroundSprite = new FlatRedBall.Sprite();
			BackgroundSprite.Name = "BackgroundSprite";
			
			
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
			VisibleRepresentation.AddToManagers();
			TileCollision.AddToManagers();
			PlayerInstance.AddToManagers(mLayer);
			SpriteManager.AddSprite(BackgroundSprite);
			base.AddToManagers();
			AddToManagersBottomUp();
			CustomInitialize();
		}


		public override void Activity(bool firstTimeCalled)
		{
			// Generated Activity
			if (!IsPaused)
			{
				
				PlayerInstance.Activity();
			}
			else
			{
			}
			base.Activity(firstTimeCalled);
			if (!IsActivityFinished)
			{
				CustomActivity(firstTimeCalled);
			}
			VisibleRepresentation.ManageAll();


				// After Custom Activity
				
            
		}

		public override void Destroy()
		{
			// Generated Destroy
			if (this.UnloadsContentManagerWhenDestroyed && ContentManagerName != "Global")
			{
				City.RemoveFromManagers(ContentManagerName != "Global");
			}
			else
			{
				City.RemoveFromManagers(false);
			}
			if (this.UnloadsContentManagerWhenDestroyed && ContentManagerName != "Global")
			{
				City = null;
			}
			else
			{
				City.MakeOneWay();
			}
			Tileset = null;
			CityBack = null;
			
			if (VisibleRepresentation != null)
			{
				VisibleRepresentation.RemoveFromManagers(ContentManagerName != "Global");
			}
			if (TileCollision != null)
			{
				TileCollision.RemoveFromManagers(ContentManagerName != "Global");
			}
			if (PlayerInstance != null)
			{
				PlayerInstance.Destroy();
				PlayerInstance.Detach();
			}
			if (BackgroundSprite != null)
			{
				SpriteManager.RemoveSprite(BackgroundSprite);
			}

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			if (PlayerInstance.Parent == null)
			{
				PlayerInstance.Z = 5f;
			}
			else
			{
				PlayerInstance.RelativeZ = 5f;
			}
			BackgroundSprite.Texture = CityBack;
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.Z = -5f;
			}
			else
			{
				BackgroundSprite.RelativeZ = -5f;
			}
			BackgroundSprite.TextureScale = 1f;
			#if FRB_MDX
			BackgroundSprite.TextureAddressMode = Microsoft.DirectX.Direct3D.TextureAddress.Wrap;
			#else
			BackgroundSprite.TextureAddressMode = Microsoft.Xna.Framework.Graphics.TextureAddressMode.Wrap;
			#endif
			BackgroundSprite.ScaleX = 2000f;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			CameraSetup.ResetCamera(SpriteManager.Camera);
			AssignCustomVariables(false);
		}
		public virtual void RemoveFromManagers ()
		{
			if (VisibleRepresentation != null)
			{
				VisibleRepresentation.RemoveFromManagers(false);
			}
			if (TileCollision != null)
			{
				TileCollision.RemoveFromManagers(false);
			}
			PlayerInstance.RemoveFromManagers();
			if (BackgroundSprite != null)
			{
				SpriteManager.RemoveSpriteOneWay(BackgroundSprite);
			}
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
				PlayerInstance.AssignCustomVariables(true);
			}
			if (PlayerInstance.Parent == null)
			{
				PlayerInstance.Z = 5f;
			}
			else
			{
				PlayerInstance.RelativeZ = 5f;
			}
			BackgroundSprite.Texture = CityBack;
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.Z = -5f;
			}
			else
			{
				BackgroundSprite.RelativeZ = -5f;
			}
			BackgroundSprite.TextureScale = 1f;
			#if FRB_MDX
			BackgroundSprite.TextureAddressMode = Microsoft.DirectX.Direct3D.TextureAddress.Wrap;
			#else
			BackgroundSprite.TextureAddressMode = Microsoft.Xna.Framework.Graphics.TextureAddressMode.Wrap;
			#endif
			BackgroundSprite.ScaleX = 2000f;
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			VisibleRepresentation.ConvertToManuallyUpdated();
			PlayerInstance.ConvertToManuallyUpdated();
			SpriteManager.ConvertToManuallyUpdated(BackgroundSprite);
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
			if (!FlatRedBallServices.IsLoaded<FlatRedBall.Scene>(@"content/screens/gamescreen/city.scnx", contentManagerName))
			{
			}
			City = FlatRedBallServices.Load<FlatRedBall.Scene>(@"content/screens/gamescreen/city.scnx", contentManagerName);
			if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/gamescreen/tileset.png", contentManagerName))
			{
			}
			Tileset = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/gamescreen/tileset.png", contentManagerName);
			if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/gamescreen/cityback.png", contentManagerName))
			{
			}
			CityBack = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/gamescreen/cityback.png", contentManagerName);
			WeedQuest.Entities.Player.LoadStaticContent(contentManagerName);
			CustomLoadStaticContent(contentManagerName);
		}
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "City":
					return City;
				case  "Tileset":
					return Tileset;
				case  "CityBack":
					return CityBack;
			}
			return null;
		}
		public static object GetFile (string memberName)
		{
			switch(memberName)
			{
				case  "City":
					return City;
				case  "Tileset":
					return Tileset;
				case  "CityBack":
					return CityBack;
			}
			return null;
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "City":
					return City;
				case  "Tileset":
					return Tileset;
				case  "CityBack":
					return CityBack;
			}
			return null;
		}


	}
}
