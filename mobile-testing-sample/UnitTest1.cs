using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;

namespace mobile_testing_sample
{
    public class Tests
    {
        private AndroidDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723/");
            var driverOptions = new AppiumOptions()
            {
                AutomationName = AutomationName.AndroidUIAutomator2,
                PlatformName = "Android",
                DeviceName = "Android Emulator",
            };

            driverOptions.AddAdditionalAppiumOption("appPackage", "com.android.settings");
            driverOptions.AddAdditionalAppiumOption("appActivity", ".Settings");
            driverOptions.AddAdditionalAppiumOption("noReset", true);

            driver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

        [Test]
        public void SetOnOffWifiNetWork()
        {

            driver.ToggleWifi();

        }

        [Test]
        public void SetUpInstallApp()
        {
            driver.InstallApp("C:/Users/Lusa/Desktop/mobile-testing-sample/mobile-testing-sample/casasbahia_250000200.apk");
            
        }

        [Test]
        public void ADBIntegration()
        {

            driver.ExecuteScript("mobile: shell", "{command: rm, args: [-rf, /mnt/sdcard/Pic/*.*]}").ToString();

        }
    }
}