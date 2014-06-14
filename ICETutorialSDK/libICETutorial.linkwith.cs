using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libICETutorial.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64, Frameworks = "UIKit CoreGraphics", ForceLoad = true)]
