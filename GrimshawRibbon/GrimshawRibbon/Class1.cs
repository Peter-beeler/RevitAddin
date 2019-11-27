using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;

namespace GrimshawRibbon
{
    class App : IExternalApplication
    {
        // define a method that will create our tab and button
        static void AddRibbonPanel(UIControlledApplication application)
        {
            // Create a custom ribbon tab
            String tabName = "PathAnalysis";
            application.CreateRibbonTab(tabName);

            // Create two push buttons
            PushButtonData button1 = new PushButtonData("Start Analysis", "Start Analysis",
                @"C:\Users\42974\source\repos\TravelAna\TravelAna\bin\Debug\netstandard2.0\TravelAna.dll", "RuleCheck.PathAnalysis");
            PushButtonData button2 = new PushButtonData("Label", "Label",
                @"C:\Users\42974\source\repos\TravelAna\TravelAna\bin\Debug\netstandard2.0\TravelAna.dll", "RuleCheck.Labels");

            // Create a ribbon panel
            RibbonPanel m_projectPanel = application.CreateRibbonPanel(tabName, "PathAnalysis");

            // Add the buttons to the panel
            List<RibbonItem> projectButtons = new List<RibbonItem>();
            projectButtons.AddRange(m_projectPanel.AddStackedItems(button1,button2));

          
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // do nothing
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // call our method that will load up our toolbar
            AddRibbonPanel(application);
            return Result.Succeeded;
        }
    }
}
