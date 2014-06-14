//
// Main.cs: This is the main entry point of the application.
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

namespace ICETutorialSample
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}
