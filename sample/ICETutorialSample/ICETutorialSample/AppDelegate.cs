//
// AppDelegat.cs: Sample of how to use ICETutorial
//
// Author:
// 	Israel Soto (israel.soto@gmail.com)
//
// Copyright (c) 2014 Israel Soto (https://github.com/SotoiGhost)
//

using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using ICETutorialSDK;

namespace ICETutorialSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate, IICETutorialControllerDelegate
	{

		ICETutorialController view_controller;
		UIWindow window;

		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			// Init the pages texts, and pictures.
			var tutorialLayers = new ICETutorialPage [] {
				new ICETutorialPage ("Picture 1", "Champs-Elysées by night", "tutorial_background_00@2x.jpg", 3.0),
				new ICETutorialPage ("Picture 2", "The Eiffel Tower with\\n cloudy weather", "tutorial_background_01@2x.jpg", 3.0),
				new ICETutorialPage ("Picture 3", "An other famous street of Paris", "tutorial_background_02@2x.jpg", 3.0),
				new ICETutorialPage ("Picture 4", "The Eiffel Tower with a better weather", "tutorial_background_03@2x.jpg", 3.0),
				new ICETutorialPage ("Picture 5", "The Louvre's Museum Pyramide", "tutorial_background_04@2x.jpg", 3.0)
			};

			// Set the common style for SubTitles and Description (can be overrided on each page).
			var titleStyle = new ICETutorialLabelStyle {
				Font = UIFont.FromName ("Helvetica-Bold", 17f),
				TextColor = UIColor.White,
				LinesNumber = 1,
				Offset = 180
			};

			var subStyle = new ICETutorialLabelStyle {
				Font = UIFont.FromName ("Helvetica", 15f),
				TextColor = UIColor.White,
				LinesNumber = 2,
				Offset = 150
			};

			// Override point for customization after application launch.
			view_controller = new ICETutorialController (tutorialLayers, this) {
				// Set the common styles, and start scrolling (auto scroll, and looping enabled by default)
				CommonPageTitleStyle = titleStyle,
				CommonPageSubTitleStyle = subStyle
			};

			// Run it.
			view_controller.StartScrolling ();

			window.RootViewController = view_controller;
			window.MakeKeyAndVisible ();

			return true;
		}


		#region ICETutorialController delegate

		[Export ("tutorialController:scrollingFromPageIndex:toPageIndex:")]
		public void Scrolling (ICETutorialController tutorialController, uint fromPage, uint toPage)
		{
			Console.WriteLine ("Scrolling from " + fromPage.ToString () + " to " + toPage.ToString ());
		}

		[Export ("tutorialControllerDidReachLastPage:")]
		public void ReachedToLastPage (ICETutorialController tutorialController)
		{
			Console.WriteLine ("Tutorial reached the last page");
		}

		[Export ("tutorialController:didClickOnLeftButton:")]
		public void ClickedOnLeftButton (UIButton button)
		{
			Console.WriteLine ("Button 1 pressed");
		}

		[Export ("tutorialController:didClickOnRightButton:")]
		public void ClickedOnRightButton (UIButton button)
		{
			Console.WriteLine ("Button 2 pressed");
			Console.WriteLine ("Auto-scrolling stopped");

			view_controller.StopScrolling ();
		}

		#endregion
	}
}

