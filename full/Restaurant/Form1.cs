using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JustSaying.Messaging.MessageHandling;
using Messages.Events;

namespace Restaurant
{
    public partial class Form1 : Form, IHandler<OrderAccepted>
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool Handle(OrderAccepted message)
        {
            throw new NotImplementedException();
        }
    }
}
