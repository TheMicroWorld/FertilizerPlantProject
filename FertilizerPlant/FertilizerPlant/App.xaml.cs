using FertilizerPlant.global.context;
using ProductManagementService.entities.produt;
using ProductManagementService.entities.stock;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FertilizerPlant
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ApplicationContext context;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            context = new ApplicationContext();
            context.Init();
        }
    }
}
