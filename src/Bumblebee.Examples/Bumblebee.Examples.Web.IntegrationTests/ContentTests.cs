using System;
using System.Linq;

using Bumblebee.Examples.Web.IntegrationTests.Shared;
using Bumblebee.Examples.Web.Pages.Content;
using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using FluentAssertions;

using NUnit.Framework;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.IntegrationTests
{
    [TestFixture]
    public class ContentTests : HostTestFixture
    {
        [Test]
        public void given_tables_in_ascending_and_descending_order_when_verifying_order_should_be_valid()
        {
            Threaded<Session>
                .With<HeadlessChrome>()
                .NavigateTo<TablesPage>(String.Format("{0}/{1}", this.BaseUrl, "Content/Tables.htm"))
                .VerifyThat(page =>
                    page
                        .TableInAscendingOrder
                        .RowsAs<TablesRow>()
                        .Select(row => row.Id)
                        .Should()
                        .BeInAscendingOrder())
                .VerifyThat(page =>
                    page
                        .TableInDescendingOrder
                        .RowsAs<TablesRow>()
                        .Select(row => row.Id)
                        .Should()
                        .BeInDescendingOrder())
                .Session
                .End();
        }
    }

    public class TablesRow : TableRow
    {
        public TablesRow(IBlock parent, By @by) : base(parent, @by)
        {
        }

        public TablesRow(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }

        public int Id
        {
            get
            {
                var text = FindElements(By.TagName("td"))
                    .ElementAt(0)
                    .Text;

                return Int32.Parse(text);
            }
        }

        public string Name => FindElements(By.TagName("td"))
            .ElementAt(1)
            .Text;
    }
}
