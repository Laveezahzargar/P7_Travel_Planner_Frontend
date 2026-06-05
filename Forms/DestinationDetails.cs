using P7_Travel_Planner_Frontend.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P7_Travel_Planner_Frontend.Forms
{
    public partial class DestinationDetails : Form
    {
        public DestinationDetails(DestinationDto destination)
        {
            InitializeComponent();

            //lblName.Text = destination.Name;
            //lblCountry.Text = destination.Country;

            // If available
            // txtDescription.Text = destination.Description;
        }
    }
}
