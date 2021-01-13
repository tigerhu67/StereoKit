using System;
using StereoKit;

class SKLoader
{
	static void Main(string[] args)
	{
		// If the app has a constructor that takes a string array, then
		// we'll use that, and pass the command line arguments into it on
		// creation
		Type   appType = typeof(StereoKitApp.App);
		ISKApp app     = appType.GetConstructor(new Type[] { typeof(string[]) }) != null
			? (ISKApp)Activator.CreateInstance(appType, new object[] { args })
			: (ISKApp)Activator.CreateInstance(appType);
		if (app == null)
			throw new Exception("StereoKit loader couldn't construct an instance of the ISKApp!");

		// Initialize StereoKit, and the app
		if (!SK.Initialize(app.Settings))
			Environment.Exit(1);
		app.Init();

		// Now loop until finished, and then shut down
		while (SK.Step(app.Step)) { }
		SK.Shutdown();
	}
}