using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace AcquaintDemo
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
			//This is an easy way to make sure that the app successfully launches before the tests begin
			app.WaitForElement(x => x.Marked("setupDataPartitionPhraseField"), timeout: TimeSpan.FromSeconds(80));
		}

		[Test]
		public void Repl()
		{
			app.Repl();
			//The REPL is a console-like environment in which the developer enters expressions or a commands
			//It will then evaluate those expressions, and display the results to the user
		}

		[Test]
		public void AddContactTest()
		//PRO-TIP: Naming conventions of tests should reflect a behavioral user action 
		{
			//PRO-TIP: 'WaitForElement' is extremely useful when you need to slow down the test for the elements to populate on the page
			app.EnterText("juneDemo");
			app.DismissKeyboard();
			app.Tap(x => x.Marked("setupContinueButton"));
			//PRO-TIP: The test steps taken above will NOT appear in Test Cloud becuase I did not put screenshots

			app.Tap(x => x.Marked("acquaintanceListFloatingActionButton"));
			//PRO-TIP: 'Marked' scans for ID, Class, and Text 
			app.Screenshot("Let's start by Tapping on the Floating Action Button to add a new contact");

			#region FirstName
			app.Tap(x => x.Marked("firstNameField"));
			app.Screenshot("Then we Tapped on the 'First Name' Text Field");
			app.EnterText("Bill");
			app.Screenshot("We typed in our first name, 'Bill'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			#endregion

			#region LastName
			app.Tap(x => x.Marked("lastNameField"));
			app.Screenshot("Next we Tapped on the 'Last Name' Text Field");
			app.EnterText("Gates");
			app.Screenshot("We typed in our first name, 'Gates'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			#endregion

			#region CompanyName
			app.Tap(x => x.Marked("companyField"));
			app.Screenshot("Then we Tapped on the 'Company' Text Field");
			app.EnterText("Microsoft");
			app.Screenshot("We typed in our company, 'Microsoft'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			#endregion

			#region JobTitle
			app.Tap(x => x.Marked("jobTitleField"));
			app.Screenshot("Then we Tapped on the 'Title' Text Field");
			app.EnterText("CEO");
			app.Screenshot("We typed in our title, 'CEO'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			#endregion

			#region PhoneNumber
			app.Tap(x => x.Marked("phoneNumberField"));
			app.Screenshot("Then we Tapped on the 'Phone Number' Text Field");
			app.EnterText("1111111111");
			app.Screenshot("We typed in our phone number, '1111111111'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			#endregion

			app.Tap(x => x.Marked("acquaintanceSaveButton"));
			app.Screenshot("Lastly, we saved our new contact");
		}

		[Test]
		public void CheckContactTest()
		{
			app.EnterText("juneDemo");
			app.DismissKeyboard();
			app.Tap(x => x.Marked("setupContinueButton"));

			app.Tap(x => x.Marked("Gates, Bill"));
			//PRO-TIP: We are using the name becuase it's the least brittle element 
			app.Screenshot("We confirmed our contact that we made");
		}

	}
}
