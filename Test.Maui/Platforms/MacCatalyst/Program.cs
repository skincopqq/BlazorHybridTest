﻿using ObjCRuntime;
using UIKit;

namespace Test.Maui.Platforms.MacCatalyst;

public class Program
{
    static void Main(string[] args)
    {
        UIApplication.Main(args, null, typeof(AppDelegate));
    }
}