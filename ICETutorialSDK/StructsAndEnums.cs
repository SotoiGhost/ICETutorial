//
// StructsAndEnums.cs: Where all the enums and structs are defined
//
// Author:
// 	Israel Soto (israel.soto@gmail.com)
//
// Copyright (c) 2014 Israel Soto (https://github.com/SotoiGhost)
//

using System;

namespace ICETutorialSDK
{
	[Flags]
	public enum ScrollingState {
		Auto = 1 << 0,
		Manual = 1 << 1,
		Looping = 1 << 2
	}
}

