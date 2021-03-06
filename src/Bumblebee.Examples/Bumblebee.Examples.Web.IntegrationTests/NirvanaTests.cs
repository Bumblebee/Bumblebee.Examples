﻿using System;
using System.Linq;
using Bumblebee.Examples.Web.Pages.Nirvana;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using Bumblebee.Setup.DriverEnvironments;
using FluentAssertions;

using NUnit.Framework;

namespace Bumblebee.Examples.Web.IntegrationTests
{
	// ReSharper disable InconsistentNaming

	[TestFixture]
	public class NirvanaTests : SessionFixture
	{
		private const string Url = "https://nirvanahq.com/login";
		private const string ValidUsername = "bumblebee@meinershagen.net";
		private const string Password = "P@ssw0rd";

		[Test]
		public void given_valid_logged_in_user_when_adding_task_should_add_task()
		{
		    Threaded<Session>
                .With<HeadlessChrome>()
                .NavigateTo<LoggedOutPage>(Url)
		        .Username.EnterText(ValidUsername)
		        .Password.EnterText(Password)
		        .Login.Click<LoggedInPage>();

		    var taskInfo = new { Name = $"Task {Guid.NewGuid()}", Note = "This is a note." };

            Threaded<Session>
				.CurrentBlock<LoggedInPage>()
				.ToolBar
                .NewTask
		        .Click()
				.Name.EnterText(taskInfo.Name)
				.Note.EnterText(taskInfo.Note)
				.Save.Click()
				.TaskLists
                .First(list => list.Name == "Focus")
				.TaskRows.First(row => row.Name == taskInfo.Name)
				.VerifyThat(row => row.Should().NotBeNull())
				.Delete();
		}
	}

    public abstract class SessionFixture
    {
        [OneTimeTearDown]
        public void AfterAll()
        {
            Threaded<Session>
                .End();
        }
    }
}
