ICETutorial
===========

ICETutorial MonoTouch binding for iOS (example ported too). A nice tutorial like the one introduced in the Path 3.X App

### Welcome to ICETutorial.
This small project is an implementation of the newly tutorial introduced by the Path 3.X app.
Very simple and efficient tutorial, composed with N full-screen pictures that you can swipe for switching to the next/previous page.

Here are the features :
* Compose your own tutorial with N pictures
* Fixed incrusted title (can be easily replaced by an UIImageView, or just removed)
* Scrolling sub-titles for page, with associated descriptions (change the texts, font, color...)
* Auto-scrolling (enable/disable, loop, setup duration)
* Cross fade between next/previous background
* Easy to use block access to button's events.

![ICETutorial](https://github.com/icepat/ICETutorial/blob/master/screen_shot.jpg?raw=true)

### Setting-up the ICETutorial
The code is commented, and I guess, easy to read/understand/modify.

**Texts and pictures :**
```c#
    // Init the pages texts, and pictures.
    ICETutorialPage layer1 = new ICETutorialPage ("Picture 1", 
                                                  "Champs-Elysées by night", 
                                                  "tutorial_background_00@2x.jpg", 
                                                  3.0);
    ICETutorialPage layer2 = new ICETutorialPage ("Picture 2", 
	                                                "The Eiffel Tower with\\n cloudy weather", 
	                                                "tutorial_background_01@2x.jpg", 
	                                                3.0);
    [...]
```

**Common styles for SubTitles and Descriptions :**
```c#
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
    // Load into an array.
    var tutorialLayers = new ICETutorialPage [] { layer1, layer2, ... };
```

**Init and load :**
```c#
    viewController = new ICETutorialController (tutorialLayers, this) {
        // Set the common styles, and start scrolling (auto scroll, and looping enabled by default)
        CommonPageTitleStyle = titleStyle,
        CommonPageSubTitleStyle = subStyle
    };
    // Run it.
    viewController.startScrolling ();
```

Documentation of this API and Thanks To 
========================================

All kudos for this great API goes to [@Icepat](https://github.com/icepat/).

The original project in Objective-C language: https://github.com/icepat/ICETutorial

Also available in the new Swift language!!: https://github.com/icepat/ICETutorialSwift
