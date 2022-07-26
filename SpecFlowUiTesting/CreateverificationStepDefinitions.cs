using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Capgemini.PowerApps.SpecFlowBindings;
using FluentAssertions;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;

namespace SpecFlowUiTesting
{
    [Binding]
    public class CreateverificationStepDefinitions : PowerAppsStepDefiner
    {
        [When(@"I change the view to '([^']*)' and open record number '([^']*)' by clicking in the '([^']*)' column")]
        public void WhenIChangeTheViewToAndOpenRecordNumberByClickingInTheColumn(string p0, string p1, string title)
        {
            string view = p0;
            string colId = title;
            int recordNumber = int.Parse(p1);

            var elements = Driver.FindElements(By.XPath("//button[starts-with(@id, 'ViewSelector')]"));
            var viewSelector = elements[0];

            viewSelector.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            var repairsButton = Driver.FindElement(By.XPath($"//*[@title=\"{view}\"]"));

            Actions action = new Actions(Driver);
            action.MoveToElement(repairsButton);
            action.Perform();

            repairsButton.Click();

            Thread.Sleep(5000);

            wait.Until(ExpectedConditions.ElementToBeClickable(Driver.FindElements(By.XPath($"//*[@col-id=\"{colId}\"]"))[recordNumber + 1])).Click();
        }

        [When(@"I open the record at position '([^']*)'")]
        public void WhenIOpenTheRecordAtPosition(string p0)
        {
            int position = int.Parse(p0);
            Actions action = new Actions(Driver);


            Thread.Sleep(2000);

            var row = Driver.FindElements(By.ClassName("wj-cells"))[position];

            action.DoubleClick(row).Perform();

            Thread.Sleep(2000);
        }

        [Then(@"I can see the value of '([^']*)' in the Status field")]
        public void ThenICanSeeTheValueOfInTheStatusField(string statusValue)
        {
            Driver.FindElement(By.XPath("//*[@aria-label=\"More Header Fields\"]")).Click();
            Thread.Sleep(1000);
            var statuscodeElem = Driver.FindElements(By.XPath("//div[contains(@id, 'statuscode') and contains(@role, 'button')]"));
            var statuscode = statuscodeElem[0].GetAttribute("title");
            statuscode.Should().Be(statusValue);
        }
    }
}
