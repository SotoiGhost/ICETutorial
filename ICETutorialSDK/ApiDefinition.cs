//
// ApiDefinition.cs: Where all the bindings, between Obj-C and C#, are done
//
// Author:
// 	Israel Soto (israel.soto@gmail.com)
//
// Copyright (c) 2014 Israel Soto (https://github.com/SotoiGhost)
//

using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ICETutorialSDK
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_libraries
	//

	[BaseType (typeof (UIViewController))]
	interface ICETutorialController : IUIScrollViewDelegate {
		#region Properties

		[Export ("autoScrollEnabled", ArgumentSemantic.Assign)]
		bool AutoScrollEnabled { get; set; }

		[Export ("autoScrollDurationOnPage", ArgumentSemantic.Assign)]
		float AutoScrollDurationOnPage { get; set; }

		[Export ("commonPageTitleStyle")]
		ICETutorialLabelStyle CommonPageTitleStyle { get; set; }

		[Export ("commonPageSubTitleStyle")]
		ICETutorialLabelStyle CommonPageSubTitleStyle { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		IICETutorialControllerDelegate Delegate { get; set; }

		#endregion

		#region Constructors

		[Export ("initWithPages:")]
		IntPtr Constructor (ICETutorialPage [] pages);

		[Export ("initWithPages:delegate:")]
		IntPtr Constructor (ICETutorialPage [] pages, IICETutorialControllerDelegate del);

		#endregion

		#region Methods

		[Export ("setPages:")]
		void SetPages (ICETutorialPage [] pages);

		[Export ("numberOfPages")]
		uint NumberOfPages ();

		[Export ("startScrolling")]
		void StartScrolling ();

		[Export ("stopScrolling")]
		void StopScrolling ();

		[Export ("getCurrentState")]
		ScrollingState GetCurrentState ();

		#endregion
	}

	interface IICETutorialControllerDelegate { 

	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface ICETutorialControllerDelegate {
		[Export ("tutorialController:scrollingFromPageIndex:toPageIndex:")]
		void Scrolling (ICETutorialController tutorialController, uint fromPage, uint toPage);

		// - (void)tutorialControllerDidReachLastPage:(ICETutorialController *)tutorialController;
		[Export ("tutorialControllerDidReachLastPage:")]
		void ReachedToLastPage (ICETutorialController tutorialController);

		// - (void)tutorialController:(ICETutorialController *)tutorialController 
		// didClickOnLeftButton:(UIButton *)sender;
		[Export ("tutorialController:didClickOnLeftButton:")]
		void ClickedOnLeftButton (UIButton button);

		// - (void)tutorialController:(ICETutorialController *)tutorialController 
		// didClickOnRightButton:(UIButton *)sender;
		[Export ("tutorialController:didClickOnRightButton:")]
		void ClickedOnRightButton (UIButton button);
	}

	[BaseType (typeof (NSObject))]
	interface ICETutorialLabelStyle {

		#region Properties

		[Export ("text")]
		string Text { get; set; }

		[Export ("font")]
		UIFont Font { get; set; }

		[Export ("textColor")]
		UIColor TextColor { get; set; }

		[Export ("linesNumber", ArgumentSemantic.Assign)]
		uint LinesNumber { get; set; }

		[Export ("offset", ArgumentSemantic.Assign)]
		uint Offset { get; set; }

		#endregion

		#region Constructors

		[Export ("initWithText:")]
		IntPtr Constructor (string text);

		// - (id)initWithText:(NSString *)text
		// font:(UIFont *)font
		// textColor:(UIColor *)color;
		[Export ("initWithText:font:textColor:")]
		IntPtr Constructor (string text, UIFont font, UIColor color);

		#endregion
	}

	[BaseType (typeof(NSObject))]
	interface ICETutorialPage {

		#region Properties

		[Export ("title")]
		ICETutorialLabelStyle Title { get; set; }

		[Export ("subTitle")]
		ICETutorialLabelStyle SubTitle { get; set; }

		[Export ("pictureName")]
		string PictureName { get; set; }

		[Export ("duration", ArgumentSemantic.Assign)]
		double Duration { get; set; }

		#endregion


		#region Constructors

		[Export ("initWithTitle:subTitle:pictureName:duration:")]
		IntPtr Constructor (string title, string subTitle, string pictureName, double duration);

		#endregion

		#region Methods

		[Export ("setTitleStyle:")]
		void SetTitleStyle (ICETutorialLabelStyle style);

		[Export ("setSubTitleStyle:")]
		void SetSubTitleStyle (ICETutorialLabelStyle style);

		#endregion
	}
}